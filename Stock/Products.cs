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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Stock
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
            this.ActiveControl = textBox1;
            comboBox1.SelectedIndex = 0;
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
                // Insert Logic
                con.Open();
                bool status = false;
                if (comboBox1.SelectedIndex == 0)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

                var sqlQuery = "";

                if (IfProductsExists(con, textBox1.Text))
                {
                    sqlQuery = @"UPDATE [Products] SET [ProductName] = '" + textBox2.Text + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO [dbo].[Products] 
            ([ProductCode]
            ,[ProductName]
            ,[ProductStatus])
        VALUES
            ('" + textBox1.Text + "','" + textBox2.Text + "','" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();

                //Reading Data
                LoadData();

                button2.Text = "ADD";
            }

        }

        private bool IfProductsExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Products] WHERE [ProductCode] = '" + productCode + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From  [dbo].[Products] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }

            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validation())
            {

                SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
                var sqlQuery = "";

                if (IfProductsExists(con, textBox1.Text))
                {
                    con.Open();
                    sqlQuery = @"DELETE FROM [Products] WHERE [ProductCode] = '" + textBox1.Text + "'";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                }
                else
                {
                    MessageBox.Show("Record Not Exists...!");
                }


                //Reading Data
                LoadData();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox2.Text.Length > 0)
                {
                    comboBox1.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (comboBox1.SelectedIndex != -1)
                {
                    button2.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }
        private bool Validation()
        {
            bool result = false;
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox1, "Product Code Required");
            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox2, "Product Name Required");
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(comboBox1, "Select Status");

            }

            else
            {
                result = true;
            }
            return result;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
