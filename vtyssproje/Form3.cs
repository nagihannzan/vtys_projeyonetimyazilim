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
    public partial class Form3 : Form
    {
        private string connectionString = "Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True";

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btnSaveProject_Click(object sender, EventArgs e)
        {
            // Alanların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtProjectName.Text) ||
                string.IsNullOrWhiteSpace(txtTotalDelay.Text) ||
                dtpStartDate.Value == null || dtpEndDate.Value == null)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!");
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Projects (ProjectName, StartDate, EndDate, TotalDelay) VALUES (@ProjectName, @StartDate, @EndDate, @TotalDelay)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProjectName", txtProjectName.Text);
                    command.Parameters.AddWithValue("@StartDate", dtpStartDate.Value);
                    command.Parameters.AddWithValue("@EndDate", dtpEndDate.Value);
                    command.Parameters.AddWithValue("@TotalDelay", txtTotalDelay.Text);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                MessageBox.Show("Proje başarıyla eklendi!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }




        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
