using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtyssproje
{
    public partial class Form4 : Form
    {
        private string connectionString = "Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True";
        private int projectId;

        public Form4(int selectedProjectId)
        {
            InitializeComponent();
            projectId = selectedProjectId;
            LoadTasks();
            LoadEmployees();
        }

        private void LoadTasks()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT 
                        t.TaskId, 
                        t.TaskName, 
                        t.StartDate, 
                        t.EndDate, 
                        t.Status, 
                        t.DaysRequired,
                        t.CompletionDate,
                        ISNULL(DATEDIFF(DAY, t.EndDate, t.CompletionDate), 0) AS DelayDays,
                        e.EmployeeName 
                    FROM Tasks t
                    LEFT JOIN Employees e ON t.EmployeeTaskId = e.EmployeeId
                    WHERE t.ProjectId = @ProjectId";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@ProjectId", projectId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvTasks.DataSource = dataTable;
            }
        }
        private void UpdateProjectEndDateIfNeeded()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            DECLARE @MaxCompletionDate DATE;
            
            -- Proje içindeki tamamlanan görevlerin en geç tamamlanma tarihini bul
            SELECT @MaxCompletionDate = MAX(CompletionDate)
            FROM Tasks
            WHERE ProjectId = @ProjectId AND CompletionDate IS NOT NULL;

            -- Eğer bulunan tarih mevcut bitiş tarihinden ileri bir tarihse, proje bitiş tarihini güncelle
            IF @MaxCompletionDate IS NOT NULL AND @MaxCompletionDate > (SELECT EndDate FROM Projects WHERE ProjectId = @ProjectId)
            BEGIN
                UPDATE Projects
                SET EndDate = @MaxCompletionDate
                WHERE ProjectId = @ProjectId;
            END";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }



        private void CheckAndUpdateTaskStatus()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Tasks
                    SET Status = 
                        CASE 
                            WHEN CompletionDate IS NOT NULL AND CompletionDate <= EndDate THEN 'Tamamlandı'
                            WHEN CompletionDate IS NOT NULL AND CompletionDate > EndDate THEN 'Gecikti'
                            ELSE 'Devam Ediyor'
                        END
                    WHERE ProjectId = @ProjectId";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }

            UpdateProjectEndDateIfNeeded();
            LoadTasks();
        }

       

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            dtpComletionDate.Format = DateTimePickerFormat.Custom;
            dtpComletionDate.CustomFormat = " ";  // Kullanıcı hiçbir tarih seçmemişse, boş görünür
            dtpComletionDate.Checked = false;  // Başlangıçta "CheckBox" seçili olmasın
            //dtpComletionDate.ValueChanged += dtpComletionDate_ValueChanged;
        }


        private void dtpComletionDate_ValueChanged(object sender, EventArgs e)
        {
            // Kullanıcı tarih seçtiğinde, formatı değiştirme
            if (dtpComletionDate.Checked)
            {
               dtpComletionDate.CustomFormat = "yyyy-MM-dd"; // Tarih formatını istediğiniz şekilde ayarlayabilirsiniz
            }
            else
            {
                dtpComletionDate.CustomFormat = " ";  // Eğer tarih seçilmediyse, boş görünsün
            }
        }


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (cmbEmployee.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir çalışan seçin.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Tasks (ProjectId, TaskName, StartDate, EndDate, Status, DaysRequired, EmployeeTaskId, CompletionDate) " +
                               "VALUES (@ProjectId, @TaskName, @StartDate, @EndDate, 'Devam Ediyor', @DaysRequired, @EmployeeTaskId, @CompletionDate)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProjectId", projectId);
                command.Parameters.AddWithValue("@TaskName", txtTaskName.Text);
                command.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                command.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                command.Parameters.AddWithValue("@DaysRequired", numericDaysRequired.Value);
                command.Parameters.AddWithValue("@EmployeeTaskId", Convert.ToInt32(cmbEmployee.SelectedValue));
                command.Parameters.AddWithValue("@CompletionDate", dtpComletionDate.Value);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Görev başarıyla eklendi!");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Veritabanı hatası: {ex.Message}");
                }
            }


            LoadTasks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 projectForm = new Form5();
            projectForm.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET Status = @Status WHERE TaskId = @TaskId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", cmbStatus.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@TaskId", int.Parse(txtTaskId.Text));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Görev başarıyla güncellendi!");
                            LoadTasks();
                        }
                        else
                        {
                            MessageBox.Show("Görev bulunamadı. Lütfen ID'yi kontrol edin.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Tasks SET EndDate = @EndDate WHERE TaskId = @TaskId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                        command.Parameters.AddWithValue("@TaskId", int.Parse(txtTaskId.Text));

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Görev başarıyla güncellendi!");
                            LoadTasks();
                        }
                        else
                        {
                            MessageBox.Show("Görev bulunamadı. Lütfen ID'yi kontrol edin.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private DataTable GetEmployees()
        {
            DataTable employees = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EmployeeId, EmployeeName FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.Fill(employees);
            }
            return employees;
        }

        private void LoadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EmployeeId, EmployeeName FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                DataTable employees = new DataTable();
                adapter.Fill(employees);

                cmbEmployee.DataSource = employees;
                cmbEmployee.DisplayMember = "EmployeeName";
                cmbEmployee.ValueMember = "EmployeeId";
            }
        }

        private void btnCheckTasks_Click(object sender, EventArgs e)
        {
            CheckAndUpdateTaskStatus();
        }
    }
}
