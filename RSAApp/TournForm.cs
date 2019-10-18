using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RSAApp.Tournament;

namespace RSAApp
{
    public partial class TournForm : Form
    {
        public TournForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {          
                Tournament newTournament = new Tournament(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                mainTournament = newTournament;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            this.Close();
        }
    }
}
