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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            string query = "Select * from Admin where Username = '" + textBox1.Text.Trim() + "' and password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter adaptor = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            if(table.Rows.Count == 1)
            {
                Games games = new Games();
                games.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username or password incorrect");
            }
        }
    }
}
