using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace vtyssproje
{
    public partial class Form6 : Form
    {
    
        private int selectedEmployeeId;
        private string connectionString = "Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True";

        private void LoadEmployeeDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = @"
            SELECT e.EmployeeName, e.Employeemail, 
                   COUNT(t.TaskId) AS TotalTasks,
                   SUM(CASE WHEN t.Status = 'Tamamlandı' THEN 1 ELSE 0 END) AS CompletedTasks,
                   SUM(CASE WHEN t.Status = 'Devam Ediyor' THEN 1 ELSE 0 END) AS InProgressTasks,
                   SUM(CASE WHEN t.Status = 'Tamamlanacak' THEN 1 ELSE 0 END) AS NotStartedTasks,
                   SUM(CASE WHEN t.Status = 'Tamamlandı' AND 
                             (t.CompletionDate <= t.EndDate OR t.CompletionDate IS NULL) THEN 1 ELSE 0 END) AS OnTimeTasks,
                   SUM(CASE WHEN (t.Status = 'Tamamlandı' AND t.CompletionDate > t.EndDate) 
                             OR t.Status = 'Gecikti' THEN 1 ELSE 0 END) AS LateTasks
            FROM Employees e
            LEFT JOIN Tasks t ON e.EmployeeId = t.EmployeeTaskId
            WHERE e.EmployeeId = @EmployeeId
            GROUP BY e.EmployeeName, e.Employeemail";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow row = dataTable.Rows[0];
                        lblEmployeeName.Text = row["EmployeeName"].ToString();
                        lblEmployeeEmail.Text = row["Employeemail"].ToString();
                        lblTotalTasks.Text = row["TotalTasks"].ToString();
                        lblCompletedTasks.Text = row["CompletedTasks"].ToString();
                        lblInProgressTasks.Text = row["InProgressTasks"].ToString();
                        lblNotStartedTasks.Text = row["NotStartedTasks"].ToString();
                        lblOnTimeTasks.Text = row["OnTimeTasks"].ToString();
                        lblLateTasks.Text = row["LateTasks"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Çalışanın görev detayları bulunamadı.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message);
            }

        }


        private void LoadEmployeeTasks()
        {
            // Çalışanın görev aldığı projeler ve görev durumlarını listele
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT p.ProjectName, t.TaskName, t.StartDate, t.EndDate, t.CompletionDate, t.Status
                    FROM Tasks t
                    JOIN Projects p ON t.ProjectId = p.ProjectId
                    WHERE t.EmployeeTaskId = @EmployeeId";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", selectedEmployeeId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvEmployeeProjects.DataSource = dataTable;
            }
        }

        public Form6(int employeeId, string connString)
        {
            InitializeComponent();
            selectedEmployeeId = employeeId;
            connectionString = connString;
            LoadEmployeeDetails();
            LoadEmployeeTasks();

        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void lblZamanindaTamamlanan_Click(object sender, EventArgs e)
        {

        }
    }
}
