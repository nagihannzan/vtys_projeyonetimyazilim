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
using System.Net.NetworkInformation;



namespace vtyssproje
{
    public partial class Form5 : Form
    {

        private string connectionString = "Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True";
        private int selectedEmployeeId;
        int employeeId;


        public Form5()
        {
            InitializeComponent();
            LoadEmployees();

        }
        private void LoadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT EmployeeId, EmployeeName, Employeemail FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvEmployees.DataSource = dataTable;
            }
        }



        private void Form5_Load(object sender, EventArgs e)
        {
            int employeeId = 1; // Örnek bir çalışan ID'si
            LoadEmployeeTasks(employeeId);

        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (EmployeeName,Employeemail,Employeepassword) VALUES (@EmployeeName,@Employeemail,@Employeepassword)";


                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                command.Parameters.AddWithValue("@Employeemail", txtEmployeemail.Text);
                command.Parameters.AddWithValue("@Employeepassword", txtEmployeepassword.Text);



                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
           
            }
      

        MessageBox.Show("Çalışan başarıyla eklendi!");
            LoadEmployees(); // Yeni çalışan eklendikten sonra listeyi yenil
        }
        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0)
            {
                int employeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value);
                LoadEmployeeTasks(employeeId);


            }
        }


       

        // Çalışan görevlerini listeleme
        private void LoadEmployeeTasks(int employeeId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM EmployeeTasks WHERE EmployeeId = @EmployeeId";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                adapter.SelectCommand.Parameters.AddWithValue("@EmployeeId", employeeId);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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

     

        private void btnAddTaskEmployee_Click(object sender, EventArgs e)
        {

        }


        private void dgvEmployees_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
                selectedEmployeeId = Convert.ToInt32(row.Cells["EmployeeId"].Value);
                MessageBox.Show("Seçilen Çalışan ID: " + selectedEmployeeId);

                // Seçilen çalışanın görevlerini yükle
                LoadEmployeeTasks(selectedEmployeeId);
            }

        }

        private void dgvEmployees_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(dgvEmployees.SelectedRows.Count > 0)
            {
                int EmployeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Proje başarıyla silindi!");
                            LoadEmployees();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı silinirken bir hata oluştu!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
                return;
            }

            int EmployeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE Employees SET EmployeeName = @EmployeeName, Employeemail = @Employeemail, Employeepassword = @Employeepassword WHERE EmployeeId = @EmployeeId";

                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                        command.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text);
                        command.Parameters.AddWithValue("@Employeemail", txtEmployeemail.Text);
                        command.Parameters.AddWithValue("@Employeepassword", txtEmployeepassword.Text);

                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Kullanıcı başarıyla güncellendi!");
                            LoadEmployees();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı güncellenirken bir hata oluştu!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hata: {ex.Message}");
                }
            }
        }

        private void btnGoToDetails_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen bir çalışan seçin.");
                return;
            }

            int selectedEmployeeId = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value);
            Form6 detailsForm = new Form6(selectedEmployeeId, connectionString);
            detailsForm.ShowDialog();
        }

        private void btnAssignEmployee_Click(object sender, EventArgs e)
        {
           
        }

        private void AssignEmployeeToTask(int taskId, int employeeId)
        {
        }
    }
}
