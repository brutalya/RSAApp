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
    public partial class AddAthletBox : Form
    {
        static DataTable AddAthTable=new DataTable();
        public AddAthletBox()
        {
            InitializeComponent();
        }
        private void AddAthletBox_Load(object sender, EventArgs e)
        {
            if (AddAthTable.Columns.Count == 0)
            {
                AddAthTable.Columns.Add("№");
                AddAthTable.Columns.Add("Имя");
            }
            dataGridView1.DataSource = AddAthTable;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AddAthTable = new DataTable();
                AddAthTable.Columns.Add("№");
                AddAthTable.Columns.Add("Имя");
                List<Athlet> ath = new List<Athlet>(dataGridView1.RowCount-1);
                for (int i = 0; i < dataGridView1.RowCount-1; i++)
                {
                    if (i >= AddAthTable.Rows.Count) AddAthTable.Rows.Add();
                    AddAthTable.Rows[i][1] = dataGridView1[1, i].Value.ToString();
                    AddAthTable.Rows[i][0] = i+1;
                    ath.Add(new Athlet(dataGridView1[1, i].Value.ToString(), i+1));
                }
                Tournament.mainTournament.Ath= new Athlets(ath);
                this.Close();
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex < dataGridView1.ColumnCount && e.RowIndex < dataGridView1.RowCount && e.Button == MouseButtons.Right)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                Tournament.mainTournament.Ath.AthList.Remove(new Athlet(dataGridView1.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value.ToString())));
            }
            catch  { }
        }
    }
}
