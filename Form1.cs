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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=SAURABH\\MSSQLSERVER01;Initial Catalog=SampleDB;Persist Security Info=True;User ID=GR; password = Hyphen@123; Trust Server Certificate=True";
        public Form1()
        {
            InitializeComponent();
        }

        //private void btnFetch_Click(object sender, EventArgs e)
        //{
            
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT TOP 5 * FROM dbo.SampleTable";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    BindingSource bindingSource = new BindingSource();
                    bindingSource.DataSource = dataTable;
                    dataGridView1.DataSource = bindingSource;

                    // Debugging: Display number of rows fetched
                    MessageBox.Show($"Rows fetched: {dataTable.Rows.Count}", "Data Fetch", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Check if data is being fetched
                    if (dataTable.Rows.Count > 0)
                    {
                        dataGridView1.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("No records found.", "Data Fetch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("SQL Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("General Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
