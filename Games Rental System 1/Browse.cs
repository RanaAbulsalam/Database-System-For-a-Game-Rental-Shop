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
    public partial class Browse : Form
    {
        string connectionString = @"Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True";

        public Browse()
        {
            InitializeComponent();
        }

        private void GameBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gameBindingSource.EndEdit();

        }

        private void Browse_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.games_Rental_SystemDataSet.Client);
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Game' table. You can move, or remove it, as needed.
            this.gameTableAdapter.Fill(this.games_Rental_SystemDataSet.Game);

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "insert into Rents values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', NULL)" +
                "update Game set Quantity = Quantity - 1";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game Rented!");
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select * from Game where V_ID = '" + textBox6.Text + "'", con);
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
                SqlDataAdapter Da = new SqlDataAdapter("select * from Game where year(Release) = '" + textBox5.Text + "'", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView1.DataSource = tbl;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlDataAdapter Da = new SqlDataAdapter("select * from Game where Category = '" + textBox7.Text + "'", con);
                DataTable tbl = new DataTable();
                Da.Fill(tbl);

                dataGridView1.DataSource = tbl;
            }
        }

        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
