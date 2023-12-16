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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\FinanceDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void Addbtn_Click(object sender, EventArgs e)
        {
            if (UnameTb.Text == "" || PhoneTb.Text == "" || PasswordTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    // Open the connection to the database
                    Con.Open();

                    // Create a SQL command to insert the user data
                    SqlCommand cmd = new SqlCommand("insert into UsrTbl(Uname,UDOB,UPhone,UPassword,UAddress) values(@UName,@UDOB,@UPhone,@UPassword,@UAddress)", Con);

                    // Add parameters to the SQL command to avoid SQL injection
                    cmd.Parameters.AddWithValue("@UName", UnameTb.Text);
                    cmd.Parameters.AddWithValue("@UDOB", DOB.Value.Date); // Assuming you have a DateTimePicker for DOB
                    cmd.Parameters.AddWithValue("@UPhone", PhoneTb.Text);
                    cmd.Parameters.AddWithValue("@UPassword", PasswordTb.Text); // Consider using hashing for passwords
                    cmd.Parameters.AddWithValue("@UAddress", AddressTb.Text);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Close the connection
                    Con.Close();

                    MessageBox.Show("User Successfully Added");

                    // Optionally, clear the textboxes after insertion
                    UnameTb.Text = "";
                    PhoneTb.Text = "";
                    PasswordTb.Text = "";
                    AddressTb.Text = "";
                    // And reset the DOBPicker if you have one
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
    }
}
