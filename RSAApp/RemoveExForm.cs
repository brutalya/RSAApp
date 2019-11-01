using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAApp
{
    public partial class RemoveExForm : Form
    {
        public RemoveExForm()
        {
            InitializeComponent();
        }

        private void RemoveExForm_Load(object sender, EventArgs e)
        {
            for(int i = 0; i<Tournament.mainTournament.Ex.ExList.Count();i++)
            {
                comboBox1.Items.Add(Tournament.mainTournament.Ex.ExList[i].Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Tournament.mainTournament.Ex.ExList.Count(); i++)
            {
                
                if (Tournament.mainTournament.Ex.ExList[i].Name == comboBox1.SelectedItem.ToString())
                {
                    Exercises.ExNames.Remove(Tournament.mainTournament.Ex.ExList[i].Name);
                    for(int j=0;j< Form1.ResultsEx.Columns.Count; j++)
                    {
                        if (Form1.ResultsEx.Columns[j].ToString()== Tournament.mainTournament.Ex.ExList[i].FirstName)
                        {
                            Form1.ResultsEx.Columns.RemoveAt(j);j--;
                        }
                        if(Form1.ResultsEx.Columns[j].ToString() == Tournament.mainTournament.Ex.ExList[i].SecondName)
                        {
                            Form1.ResultsEx.Columns.RemoveAt(j);j--;
                        }
                    }
                    Tournament.mainTournament.Ex.ExList.Remove(Tournament.mainTournament.Ex.ExList[i]);
                    for(int j = 0; j< Tournament.mainTournament.Ath.AthList.Count; j++)
                        Tournament.mainTournament.Ath.AthList[j].Exes.Remove(Tournament.mainTournament.Ex.ExList[i].Name);
                }
            }
            this.Close();
        }        
    }
}
