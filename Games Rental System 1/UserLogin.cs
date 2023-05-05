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
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            string query = "Select * from Client where Email = '" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";
            SqlDataAdapter adaptor = new SqlDataAdapter(query, con);
            DataTable table = new DataTable();
            adaptor.Fill(table);
            if (table.Rows.Count == 1)
            {
                UserOptions options = new UserOptions();
                options.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Username or password incorrect");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            SignUp signup = new SignUp();
            signup.Show();
            this.Hide();
        }
    }
}
