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
    public partial class Dashboard : Form
    {
        public string LoggedInUser { get; set; }


        public Dashboard()
        {
            InitializeComponent();
            GetTotInc();
            GetIncomeTransactionCount();
            GetLastIncomeDate();
            GetTotExp();
            GetExpenseTransactionCount();
            GetLastExpenseDate();
            GetMinIncome();
            GetTotExp();
            GetExpenseTransactionCount();
            GetLastExpense();
            GetLastIncome();
            GetMaxExpense();
            GetMinExpense(); 
            GetBalance();
            GetBestIncomeCategory();
            GetBestExpenseCategory();

        }

        private void Incomes_Load(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\FinanceDb.mdf;Integrated Security=True;Connect Timeout=30");



        private void GetTotInc()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label8.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }



        // For the number of income transactions
        private void GetIncomeTransactionCount()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label10.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }


        // For the last income transaction date
        private void GetLastIncomeDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 IncDate from IncomeTbl where IncUser='" + Login.User + "' order by IncDate Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label11.Text = "Last Transacion date :" + (dt.Rows.Count > 0 ? Convert.ToDateTime(dt.Rows[0][0]).ToShortDateString() : "N/A");
            Con.Close();
        }


        private void GetTotExp()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label15.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // For the number of expense transactions
        private void GetExpenseTransactionCount()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label13.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }


        // For the last expense transaction date
        private void GetLastExpenseDate()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 ExpDate from ExpenseTbl where ExpUser='" + Login.User + "' order by ExpDate Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label12.Text = "Last Transacion date :" + (dt.Rows.Count > 0 ? Convert.ToDateTime(dt.Rows[0][0]).ToShortDateString() : "N/A");
            Con.Close();
        }


        // For Maximum Income Amount in Euros
        private void GetMaxIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label20.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // For Last Income Amount in Euros
        private void GetLastIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 IncAmt from IncomeTbl where IncUser='" + Login.User + "' order by IncDate Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label31.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // For Maximum Expense Amount in Euros
        private void GetMaxExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label17.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // For Last Expense Amount in Euros
        private void GetLastExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 ExpAmt from ExpenseTbl where ExpUser='" + Login.User + "' order by ExpDate Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label29.Text = "€" + dt.Rows[0][0].ToString();
            Con.Close();
        }

        // For Balance (Total Income - Total Expense)
        private void GetBalance()
        {
            Con.Open();
            SqlDataAdapter sdaIncome = new SqlDataAdapter("select Sum(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dtIncome = new DataTable();
            sdaIncome.Fill(dtIncome);
            decimal totalIncome = dtIncome.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(dtIncome.Rows[0][0]) : 0;

            SqlDataAdapter sdaExpense = new SqlDataAdapter("select Sum(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dtExpense = new DataTable();
            sdaExpense.Fill(dtExpense);
            decimal totalExpense = dtExpense.Rows[0][0] != DBNull.Value ? Convert.ToDecimal(dtExpense.Rows[0][0]) : 0;

            label27.Text = "€" + (totalIncome - totalExpense).ToString();
            Con.Close();
        }

        // For Minimum Income Amount in Euros
        private void GetMinIncome()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTbl where IncUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label23.Text = dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value ? "€" + Convert.ToDecimal(dt.Rows[0][0]).ToString("0.00") : "€0.00";
            Con.Close();
        }

        // For Minimum Expense Amount in Euros
        private void GetMinExpense()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpenseTbl where ExpUser='" + Login.User + "'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label19.Text = dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value ? "€" + Convert.ToDecimal(dt.Rows[0][0]).ToString("0.00") : "€0.00";
            Con.Close();
        }

        // For Best Income Category
        private void GetBestIncomeCategory()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 IncCat from IncomeTbl where IncUser='" + Login.User + "' group by IncCat order by Sum(IncAmt) Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label25.Text = dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "N/A";
            Con.Close();
        }

        // For Best Expense Category
        private void GetBestExpenseCategory()
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Top 1 ExpCat from ExpenseTbl where ExpUser='" + Login.User + "' group by ExpCat order by Sum(ExpAmt) Desc", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label33.Text = dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "N/A";
            Con.Close();
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void label37_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label35_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            viewExpense Obj = new viewExpense();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            viewIncome Obj = new viewIncome();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Expense Obj = new Expense();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }
    }
}
