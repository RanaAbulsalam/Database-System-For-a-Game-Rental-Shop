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
    public partial class UpdateUser : Form
    {
        public UpdateUser()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "update CLient set Fname = '" + textBox1.Text + "', LName ='" + textBox2.Text + "', Email ='" + textBox3.Text + "', Password ='" + textBox4.Text + "', Phone ='" + textBox5.Text + "', Age ='" + textBox6.Text + "', Gender ='" + textBox7.Text + "', City ='" + textBox8.Text + "', Street ='" + textBox9.Text + "' where Email = '" + textBox3.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Account Updated !");
        }
    }
}
