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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "insert into Client values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Signed Up !");
        }
    }
}
