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
    public partial class AddExForm : Form
    {
        public AddExForm()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==false)
            {
                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                checkBox2.Enabled = false;
            }
            else
            {
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                checkBox2.Enabled = true;
            }
        }

        private void AddExForm_Load(object sender, EventArgs e) //LOAD 
        {
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            checkBox2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e) //ДОБАВЛЕНИЕ УПРАЖНЕНИЯ КНОПКА
        {
            bool isftt = false, isstt = false;
            int f = 0, s = 0;
            if (comboBox2.Items[0] == comboBox2.SelectedItem) isftt = true;//БОЛЬШЕ МЕНЬШЕ ПЕРВЫЙ
            if (comboBox3.Items[0] == comboBox3.SelectedItem) isstt = true;//БОЛЬШЕ МЕНЬШЕ ВТОРОЙ
            for(int i =0;i<4;i++)//СИСТЕМА СЧИСЛЕНИЯ
            {
                if (comboBox1.Items[i] == comboBox1.SelectedItem) f = i;//ПЕРВЫЙ
                if (comboBox4.Items[i] == comboBox4.SelectedItem) s = i;//ВТОРОЙ
            }
            if (checkBox1.Checked == false)//ЕСЛИ ТОЛЬКО ОДНО ЗНАЧЕНИЕ
            {
                Tournament.mainTournament.Ex.ExList.Add(new Exercise(textBox1.Text,checkBox3.Checked, isftt,f, comboBox1.Text + " упр " + (Tournament.mainTournament.Ex.ExList.Count+1), "упр " + (Tournament.mainTournament.Ex.ExList.Count+1)));
                Exercises.ExNames.Add(textBox1.Text);
                Form1.ResultsEx.Columns.Add(comboBox1.Text+" упр "+ Tournament.mainTournament.Ex.ExList.Count);
                Form1.ResultsEx.Columns.Add("упр " + Tournament.mainTournament.Ex.ExList.Count);
                for (int i = 0; i < Tournament.mainTournament.Ath.AthList.Count; i++)
                    Tournament.mainTournament.Ath.AthList[i].Exes.Add(textBox1.Text, new double[2] { 0, 0 });
                
            }
            else//ЕСЛИ ДВА ЗНАЧЕНИЯ
            {
                Tournament.mainTournament.Ex.ExList.Add(new Exercise(textBox1.Text, checkBox3.Checked, isftt, isstt, checkBox2.Checked,f,s, comboBox1.Text + " упр " + (Tournament.mainTournament.Ex.ExList.Count+1), comboBox4.Text + " упр " + (Tournament.mainTournament.Ex.ExList.Count+1)));
                //ruslan zhopa
                Exercises.ExNames.Add(textBox1.Text);
                Form1.ResultsEx.Columns.Add(comboBox1.Text + " упр " + Tournament.mainTournament.Ex.ExList.Count);
                Form1.ResultsEx.Columns.Add(comboBox4.Text + " упр " + Tournament.mainTournament.Ex.ExList.Count);
                for(int i =0;i< Tournament.mainTournament.Ath.AthList.Count;i++)
                    Tournament.mainTournament.Ath.AthList[i].Exes.Add(textBox1.Text, new double[2] { 0, 0 });
            }
            MessageBox.Show(Tournament.mainTournament.Ex.ExList.Count+" - ExList.Count");
            this.Close();
        }

    }
}
