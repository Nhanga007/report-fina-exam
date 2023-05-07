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
namespace CinemaApp
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home hm = new Home("");
            hm.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangePass cg = new ChangePass();   
            cg.ShowDialog();    
        }
    }
}
