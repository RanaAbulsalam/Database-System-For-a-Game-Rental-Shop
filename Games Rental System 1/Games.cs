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
    public partial class Games : Form
    {
        public Games()
        {
            InitializeComponent();
        }

        private void GameBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.gameBindingSource.EndEdit();
            //this.tableAdapterManager.UpdateAll(this.games_Rental_SystemDataSet);

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Games_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Game' table. You can move, or remove it, as needed.

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "insert into Game(V_ID, Name, Category, Release, Price, Quantity) values('"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+ "','" + textBox7.Text + "')";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game Added !");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.gameTableAdapter.Fill(this.games_Rental_SystemDataSet.Game);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "update Game set V_ID = '" + textBox2.Text + "', Name ='" + textBox3.Text + "', Category ='" + textBox4.Text + "', Release ='" + textBox5.Text + "', Price ='" + textBox6.Text + "', Quantity ='" + textBox7.Text +  "' where G_ID = '"+textBox1.Text+"'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game Updated !");

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Inquiries queries = new Inquiries();
            queries.Show();
            this.Hide();
        }
    }
}
