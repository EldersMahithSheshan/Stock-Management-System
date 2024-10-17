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

namespace Stock
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {
            this.ActiveControl = dateTimePicker1;
            comboBox1.SelectedIndex = 0;
            LoadData();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH:mm ";
        }

        private void dateTimePicker1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox1.Text.Length > 0)
                {
                    SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("Select ProductName From [Products] WHERE [ProductCode]='" + textBox1.Text + "'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        textBox2.Text = dt.Rows[0][0].ToString();
                        textBox3.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Product Not Existed..!");
                    }
                }
                else
                {
                    textBox1.Focus();
                }
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox2.Text.Length > 0)
                {
                    textBox3.Focus();
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (textBox3.Text.Length > 0)
                {
                    comboBox1.Focus();
                }
                else
                {
                    textBox3.Focus();
                }
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (comboBox1.SelectedIndex != -1)
                {
                    button1.Focus();
                }
                else
                {
                    comboBox1.Focus();
                }
            }
        }

        private bool IfProductsExists(SqlConnection con, string productCode)
        {
            SqlDataAdapter sda = new SqlDataAdapter("Select 1 From [Stock] WHERE [ProductCode] = '" + productCode + "' ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
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
                    sqlQuery = @"UPDATE [Stock] SET [ProductName] = '" + textBox2.Text + "' ,[Quantity] = '" + textBox3.Text + "' ,[ProductStatus] = '" + status + "' WHERE [ProductCode] = '" + textBox1.Text + "'";
                }
                else
                {
                    sqlQuery = @"INSERT INTO Stock (ProductCode, ProductName,  TransDate, Quantity,  ProductStatus )
             VALUES
             ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy HH:mm") + "','" + textBox3.Text + "','" + status + "')";
                }

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Record Saved Successfully");
                LoadData();

                button1.Text = "ADD";
            }
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * From  [dbo].[Stock] ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells["dgSno"].Value = n + 1;
                dataGridView1.Rows[n].Cells["dgProCode"].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells["dgProName"].Value = item["ProductName"].ToString();
                dataGridView1.Rows[n].Cells["dgQuantity"].Value = float.Parse(item["Quantity"].ToString());
                dataGridView1.Rows[n].Cells["dgDate"].Value = DateTime.Parse(item["TransDate"].ToString()).ToString("MM/dd/yyyy HH:mm");
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells["dgStatus"].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells["dgStatus"].Value = "Deactive";
                }

            }
        }



        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button1.Text = "Update";
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["dgProCode"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["dgProName"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["dgQuantity"].Value.ToString();

            if (DateTime.TryParse(dataGridView1.SelectedRows[0].Cells["dgDate"].Value.ToString(), out DateTime parsedDate))
            {
                dateTimePicker1.Value = parsedDate;
                dateTimePicker1.Format = DateTimePickerFormat.Short;
            }
            else
            {
                // Handle the case where the date value is null or cannot be parsed
                // For example, you can display an error message and set a default date
                MessageBox.Show("Invalid date format. Setting default date.");
                dateTimePicker1.Value = DateTime.Today;
                dateTimePicker1.Format = DateTimePickerFormat.Short;
            }

            if (dataGridView1.SelectedRows[0].Cells["dgStatus"].Value.ToString() == "Active")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Validation())
            {
                {
                    SqlConnection con = new SqlConnection("Data Source=MS;Initial Catalog=Stock;Integrated Security=True");
                    var sqlQuery = "";

                    if (IfProductsExists(con, textBox1.Text))
                    {
                        con.Open();
                        sqlQuery = @"DELETE FROM [Stock] WHERE [ProductCode] = '" + textBox1.Text + "'";
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
            else if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(textBox3, "Product Quantity Required");
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar) & (Keys)e.KeyChar != Keys.Back & e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
