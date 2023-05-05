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

namespace Games_Rental_System_1
{
    public partial class Inquiries : Form
    {
        public Inquiries()
        {
            InitializeComponent();
        }

        string connectionString = @"Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True";

        private void Inquiries_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.games_Rental_SystemDataSet.Client);
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Game' table. You can move, or remove it, as needed.
            this.gameTableAdapter.Fill(this.games_Rental_SystemDataSet.Game);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("  select  top 1  G_ID,count(G_ID) as TotalRents from Rents Group By G_ID Order By TotalRents DESC", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView1.DataSource = tbl;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select G_ID  from Game except select   G_ID from Rents WHERE DATEDIFF(MONTH, Rent_date, GETDATE()) = 1 Group By G_ID union all( select   G_ID from Rents WHERE DATEDIFF(MONTH, Rent_date, GETDATE()) = 1 Group By G_ID EXCEPT SELECT G_ID  FROM Game )", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView1.DataSource = tbl;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter(" select  top 1  C_ID,count(C_ID) as TotalRents from Rents where DATEDIFF(MONTH,Rent_date, GETDATE())=1 Group By C_ID Order By TotalRents DESC", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView2.DataSource = tbl;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select  top 1  V_ID,count(V_ID) as TotalRents from Rents where DATEDIFF(MONTH,Rent_date, GETDATE())=1 Group By V_ID Order By TotalRents DESC", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView3.DataSource = tbl;
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select V_ID  from Vendor except ( select   V_ID from Rents WHERE DATEDIFF(MONTH,Rent_date, GETDATE())=1 Group By V_ID ) union all ( select   V_ID from Rents WHERE DATEDIFF(MONTH,Rent_date, GETDATE())=1 Group By V_ID  EXCEPT SELECT V_ID  FROM Game)", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView3.DataSource = tbl;
            }
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select V_ID  from Vendor except (select   V_ID from Game WHERE Release >DATEADD(YEAR,-1, GETDATE()) Group By V_ID) union all ( select   V_ID from Game WHERE Release >DATEADD(YEAR,-1, GETDATE()) Group By V_ID EXCEPT SELECT V_ID  FROM Game)", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView3.DataSource = tbl;
            }
        }
    }
}
