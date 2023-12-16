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
    public partial class Income : Form
    {



        public Income()
        {
            InitializeComponent();
            GetTotInc();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewIncome Obj = new viewIncome();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
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


                    SqlCommand cmd = new SqlCommand("insert into IncomeTbl(IncName, IncAmt, IncCat, IncDate, IncDesc, IncUser) values(@IncName, @IncAmt, @IncCat, @IncDate, @IncDesc, @IncUser)", Con);


                    cmd.Parameters.AddWithValue("@IncName", textBox2.Text);
                    cmd.Parameters.AddWithValue("@IncAmt", Convert.ToDecimal(textBox1.Text));
                    cmd.Parameters.AddWithValue("@IncCat", comboBox1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@IncDate", dateTimePicker1.Value.Date);
                    cmd.Parameters.AddWithValue("@IncDesc", textBox3.Text);
                    cmd.Parameters.AddWithValue("@IncUser", Login.User);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    Con.Close();

                    MessageBox.Show("Income Successfully Added");

                    // Optionally, clear the textboxes and comboBox after insertion
                    textBox2.Text = "";
                    comboBox1.SelectedIndex = -1;
                    textBox1.Text = "";
                    textBox3.Text = "";
                    dateTimePicker1.Value = DateTime.Now; // Reset the dateTimePicker if you have one
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void GetTotInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label31.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
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
