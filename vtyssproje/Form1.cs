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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=SULE\\SQLEXPRESS;Initial Catalog=ProjectManagementDB;Integrated Security=True;MultipleActiveResultSets=True");


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = textBox1.Text;
                string sifre = textBox2.Text;

                using ( connection)
                {
                    connection.Open();
                    using (SqlCommand sorgu = new SqlCommand())
                    {
                        sorgu.Connection = connection;
                        sorgu.CommandText = "SELECT * FROM Employees WHERE Employeemail ='" + email + "' AND Employeepassword ='" + sifre + "'";

                        using (SqlDataReader dr = sorgu.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                string ID = dr["EmployeeId"].ToString();
                                string ad = dr["EmployeeName"].ToString();
                                Form2 mainPage = new Form2();
                                mainPage.ShowDialog();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("The information you entered is incorrect.");
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }


        }
    }
}