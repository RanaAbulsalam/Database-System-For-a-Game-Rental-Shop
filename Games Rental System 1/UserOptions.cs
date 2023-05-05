using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Games_Rental_System_1
{
    public partial class UserOptions : Form
    {
        public UserOptions()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Browse browse = new Browse();
            browse.Show();
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Return ret = new Return();
            ret.Show();
            this.Hide();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UpdateUser update = new UpdateUser();
            update.Show();
            this.Hide();
        }
    }
}
