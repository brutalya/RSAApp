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
                //Athlets ath = new Athlets(Convert.ToInt32(textBox1.Text));
                //Exercises ex = new Exercises(Convert.ToInt32(textBox2.Text));
                Tournament newTournament = new Tournament(textBox3.Text);
                mainTournament = newTournament;
                MessageBox.Show("Турнир успехно создан!");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        }
    }
}
