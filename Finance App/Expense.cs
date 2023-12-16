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


namespace Finance_App
{
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
            GetTotExp();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();
        }
        private void GetTotExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label31.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\FinanceDb.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox1.SelectedIndex == -1 || textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {

                    Con.Open();


                    SqlCommand cmd = new SqlCommand("insert into ExpenseTbl(ExpName, ExpAmt, ExpCat, ExpDate, ExpDesc, ExpUser) values(@ExpName, @ExpAmt, @ExpCat, @ExpDate, @ExpDesc, @ExpUser)", Con);


                    cmd.Parameters.AddWithValue("@ExpName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@ExpAmt", Convert.ToDecimal(textBox1.Text));
                    cmd.Parameters.AddWithValue("@ExpCat", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ExpDate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@ExpDesc", textBox3.Text);
                    cmd.Parameters.AddWithValue("@ExpUser", Login.User);


                    cmd.ExecuteNonQuery();


                    Con.Close();

                    MessageBox.Show("Expense Successfully Added");

                    // Optionally, clear the textboxes and comboBox after insertion
                    textBox2.Text = "";
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox3.Text = "";
                    dateTimePicker1.Value = DateTime.Now;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewIncome Obj = new viewIncome();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
 }
    
