using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace vtyssproje
{
    public partial class Form2 : Form
    {
        private string connectionString = "Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True";

        public Form2()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Projects";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgvProjects.DataSource = dataTable; // DataGridView adı
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnAddProject_Click(object sender, EventArgs e)
        {
            Form3 projectForm = new Form3();
            projectForm.ShowDialog();
            LoadProjects(); // Yeni proje eklendikten sonra güncelle
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                int projectId = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectId"].Value);
                Form4 taskForm = new Form4(projectId);
                taskForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir proje seçin!");
            }
        }

        private void btnDeleteProject_Click(object sender, EventArgs e)
        {
            if (dgvProjects.SelectedRows.Count > 0)
            {
                int projectId = Convert.ToInt32(dgvProjects.SelectedRows[0].Cells["ProjectId"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Projects WHERE ProjectId = @ProjectId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProjectId", projectId);
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Proje başarıyla silindi!");
                            LoadProjects();
                        }
                        else
                        {
                            MessageBox.Show("Proje silinirken bir hata oluştu!");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir proje seçin!");
            }
        }
    }
}
