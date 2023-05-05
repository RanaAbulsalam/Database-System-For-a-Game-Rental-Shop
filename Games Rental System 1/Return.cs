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
    public partial class Return : Form
    {
        public Return()
        {
            InitializeComponent();
        }

        private void Return_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'games_Rental_SystemDataSet.Game' table. You can move, or remove it, as needed.
            this.gameTableAdapter.Fill(this.games_Rental_SystemDataSet.Game);

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=COMPU-PC;Initial Catalog=Games Rental System;Integrated Security=True");
            SqlCommand command = new SqlCommand();
            command.Connection = con;
            con.Open();
            command.CommandText = "update Rents set Return_date ='" + textBox3.Text + "' where Rental_ID = '"+textBox1.Text+"'" +
                "update Game set Quantity = Quantity + 1  where G_ID = '" + textBox2.Text + "'";
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Game Returned !");
        }
    }
}
