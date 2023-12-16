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
    public partial class Login : Form


    {


        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public static object Users { get; internal set; }
        private void label3_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\FinanceDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string User;
      



        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            // Add the schema name before the table name like dbo.UserTbl if it's different
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from dbo.UsrTbl where UName=@UName and UPassword=@UPassword", Con);
            sda.SelectCommand.Parameters.AddWithValue("@UName", UnameTb.Text);
            sda.SelectCommand.Parameters.AddWithValue("@UPassword", PasswordTb.Text);

            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                User = UnameTb.Text;
                Dashboard Obj = new Dashboard();
                Obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong UserName or Password!!!");
                UnameTb.Text = "";
                PasswordTb.Text = "";
            }
            Con.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
