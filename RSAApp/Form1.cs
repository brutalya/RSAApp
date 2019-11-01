using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAApp
{
    public partial class Form1 : Form
    {
        public static DataTable ResultsAth = new DataTable("resultsAth");
        public static DataTable ResultsEx = new DataTable("resultsEx");
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Strong files(*.strong)|*.strong|All files(*.*)|*.*";
            saveFileDialog1.Filter = "Strong files(*.strong)|*.strong|All files(*.*)|*.*";
        }
        public void UpdateLayout()
        {
            Data();
            ExToAth();
            dataGridView2.DataSource = ResultsAth;
            dataGridView1.DataSource = ResultsEx;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //TOURNAMENT MAIN
            Tournament.mainTournament = new Tournament("MainTourn", new Athlets(), new Exercises());
            Exercises.ExNames = new List<string>();
            //dataGridView ATHLETS
            ResultsAth.Columns.Add("№");
            ResultsAth.Columns.Add("ИМЯ");
            ResultsAth.Columns.Add("Общее кол-во баллов");
            dataGridView2.DataSource = ResultsAth;
            //datagridview EXERCISES
            ResultsEx.Columns.Add("№");
            ResultsEx.Columns.Add("ИМЯ");
            dataGridView1.DataSource = ResultsAth;
            for (int j = 0; j < this.dataGridView1.ColumnCount; j++)
            {
                this.dataGridView1.Columns[j].Width = 45;
            }
            //datagridview 2222 settings
            this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView2.ColumnHeadersHeight = this.dataGridView1.ColumnHeadersHeight * 2;
            this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            dataGridView2.ReadOnly = true;
            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //datagridview 2222 settings
            //datagridview 1111 settings
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dataGridView1.ColumnHeadersHeight = 100;// this.dataGridView1.ColumnHeadersHeight * 2;
            this.dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
            this.dataGridView1.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView1_CellPainting);
            this.dataGridView1.Paint += new PaintEventHandler(dataGridView1_Paint);
            this.dataGridView1.Scroll += new ScrollEventHandler(dataGridView1_Scroll);
            this.dataGridView1.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView1_ColumnWidthChanged);
            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //datagridview 1111 settings
        }

        private void создатьТурнирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TournForm newForm = new TournForm();
            newForm.Show();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateLayout();
        }
        
        //datagridview1
        private void dataGridView1_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            Rectangle rtHeader = this.dataGridView1.DisplayRectangle;
            rtHeader.Height = this.dataGridView1.ColumnHeadersHeight / 2;
            this.dataGridView1.Invalidate(rtHeader);
        }

        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            dataGridView1.DataSource = ResultsEx;
            List <string> monthes = Exercises.ExNames;
            for (int j = 2; j <= (monthes.Count*2);)
            {
                Rectangle rectangle1 = this.dataGridView1.GetCellDisplayRectangle(j, -1, true);
                int width2 = this.dataGridView1.GetCellDisplayRectangle(j + 1, -1, true).Width;
                rectangle1.X += 1;
                rectangle1.Y += 1;
                rectangle1.Width = rectangle1.Width + width2 - 2;
                rectangle1.Height = rectangle1.Height / 2 - 2;
                e.Graphics.FillRectangle(new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor), rectangle1);
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Center;
                format.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(monthes[(j / 2)-1],
                this.dataGridView1.ColumnHeadersDefaultCellStyle.Font,
                new SolidBrush(this.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor),
                rectangle1,
                format);
                j += 2;
            }
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                Rectangle r2 = e.CellBounds;
                r2.Y += e.CellBounds.Height / 2;
                r2.Height = e.CellBounds.Height / 2;
                e.PaintBackground(r2, true);
                e.PaintContent(r2);
                e.Handled = true;
            }
        }
        //datagridview1

        private void добавитьУпражнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddExForm newForm = new AddExForm();
            newForm.Show();
        }
        public static void Data()
        {
            try
            {
                for (int i = 0; i < Tournament.mainTournament.Ath.AthList.Capacity; i++)//заполнение ATHLETS
                {
                    if (i >= ResultsAth.Rows.Count) ResultsAth.Rows.Add();
                    ResultsAth.Rows[i][0] = Tournament.mainTournament.Ath.AthList[i].Number;
                    ResultsAth.Rows[i][1] = Tournament.mainTournament.Ath.AthList[i].Name;
                    ResultsAth.Rows[i][2] = Tournament.mainTournament.Ath.AthList[i].AllPoints;
                }
                while (ResultsAth.Rows.Count != Tournament.mainTournament.Ath.AthList.Capacity)//удаление пустых строк ATHLETS
                    if (ResultsAth.Rows.Count != Tournament.mainTournament.Ath.AthList.Capacity)
                    {
                        for (int i = 0; i < (ResultsAth.Rows.Count - Tournament.mainTournament.Ath.AthList.Capacity); i++)
                        {
                            ResultsAth.Rows.RemoveAt(ResultsAth.Rows.Count - i - 1);
                        }
                    }
                for (int i = 0; i < ResultsAth.Rows.Count; i++)//заполнение EXERCISES из ATHLETS
                {
                    ResultsEx.Rows.Add();
                    ResultsEx.Rows[i][0] = ResultsAth.Rows[i][0];
                    ResultsEx.Rows[i][1] = ResultsAth.Rows[i][1];
                }
                while (ResultsEx.Rows.Count != Tournament.mainTournament.Ath.AthList.Capacity)//удаление пустых строк EXERCISES
                    if (ResultsEx.Rows.Count != Tournament.mainTournament.Ath.AthList.Capacity)
                    {
                        for (int i = 0; i < (ResultsEx.Rows.Count - Tournament.mainTournament.Ath.AthList.Capacity); i++)
                        {
                            ResultsEx.Rows.RemoveAt(ResultsEx.Rows.Count - i - 1);
                        }
                    }
                for(int i=0;i<Tournament.mainTournament.Ex.ExList.Count;i++)
                {
                    
                }
            }
            catch { }//(Exception ex){ MessageBox.Show("Ошибка: "+ex.Message); }
        }

        private void результатыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddAthletBox form = new AddAthletBox();
            form.Show();
        }

        private void удалитьУпражнениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveExForm form = new RemoveExForm();
            form.Show();
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AthExes();
            ToPoints();//подсчет очков
        }
        public void ExToAth()
        {
            try
            {
                /*for (int i = 3; i < ResultsAth.Columns.Count; i++)
                {
                    ResultsAth.Columns.RemoveAt(i); i--;
                }*/
                for (int i = 0; i < Tournament.mainTournament.Ex.ExList.Count(); i++)//заполнение ATHLETS из EXERCISES
                {
                    ResultsAth.Columns.Add();
                    ResultsAth.Columns[i + 3].ColumnName = Tournament.mainTournament.Ex.ExList[i].Name;
                }
                while (ResultsAth.Columns.Count != Tournament.mainTournament.Ex.ExList.Count() + 3)//удаление пустых столбцов EXERCISES
                    if (ResultsAth.Columns.Count != Tournament.mainTournament.Ex.ExList.Count() + 3)
                    {
                        for (int i = 0; i < (ResultsAth.Columns.Count - 3 - Tournament.mainTournament.Ex.ExList.Count()); i++)
                        {
                            ResultsAth.Columns.RemoveAt(ResultsAth.Columns.Count - i - 1);
                        }
                    }
                for(int i =0;i<Tournament.mainTournament.Ex.ExList.Count;i++)
                {
                    for (int j = 0; j < Tournament.mainTournament.Ath.AthList.Count; j++)
                        ResultsAth.Rows[j][i+3] = Tournament.mainTournament.Ath.AthList[j].Points[i];
                }
            } catch { }// (Exception ex) { MessageBox.Show("Ошибка: "+ex.Message); }
        }
        public void AthExes()
        {
            try
            {
                int k = 2;
                for (int i = 0; i < Tournament.mainTournament.Ath.AthList.Count; i++)
                {
                    k = 2;
                    for (int j = 0; j < Tournament.mainTournament.Ex.ExList.Count; j++)
                    {
                        Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0] = Convert.ToDouble(dataGridView1.Rows[i].Cells[k].Value.ToString());
                        if (Tournament.mainTournament.Ex.ExList[j].IsAnother == true)
                            Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1] = Convert.ToDouble(dataGridView1.Rows[i].Cells[k + 1].Value.ToString());
                        k = k + 2;
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show("Ошибка1: " + ex.Message); }
        }
        public void ToPoints()//подсчет очков
        {
            int[] points = new int[Tournament.mainTournament.Ath.AthList.Count];
            Dictionary<int, double> tempDict = new Dictionary<int, double>();
            Dictionary<int, double> tempDict1 = new Dictionary<int, double>();
            Dictionary<int, double> tempDict2 = new Dictionary<int, double>();
            for (int j = 0; j < Tournament.mainTournament.Ex.ExList.Count; j++)
            {
                points = new int[Tournament.mainTournament.Ath.AthList.Count];
                tempDict = new Dictionary<int, double>();
                for (int i = 0; i < Tournament.mainTournament.Ath.AthList.Count; i++)
                {
                    if(Tournament.mainTournament.Ex.ExList[j].IsAnother==false)//Если только один способ измерения
                        tempDict1.Add(Tournament.mainTournament.Ath.AthList[i].Number, Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0]);
                    else
                    {
                        if(Tournament.mainTournament.Ex.ExList[j].UseFirst==false)//если первый не используется в подсчете второго
                        {
                            if (Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1] == 0)// если ВТОРОЕ ЗНАЧЕНИЕ 0
                                if (Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                    tempDict1.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0] * (double)1000000);
                                else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                    tempDict1.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0] / (double)1000);
                            else// если ПЕРВОЕ ЗНАЧЕНИЕ 0
                                if(Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)
                                    if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                        tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                    else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                        tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                else
                                    if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                        tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                    else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                        tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                        }
                        else//IsAnother = TRUE, UseFirst = TRUE, оба в деле
                        {
                            if (Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1] == 0)//ЕСЛИ ВТОРОЕ 0
                                if (Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                    tempDict1.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0]);
                                else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                    tempDict1.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][0]);
                            else//ЕСЛИ ПЕРВОЕ 0
                            {
                                if (Tournament.mainTournament.Ex.ExList[j].FirstImportant == true)//первое важнее
                                    if(Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)
                                        if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                        else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                    else
                                        if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                        else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                else
                                {
                                    if (Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)//первое неважно
                                        if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                        else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                    else
                                        if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)//если чем БОЛЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                        else//если чем МЕНЬШЕ ТЕМ ЛУЧШЕ
                                            tempDict2.Add(Tournament.mainTournament.Ath.AthList[i].Number, (double)Tournament.mainTournament.Ath.AthList[i].Exes[Tournament.mainTournament.Ex.ExList[j].Name][1]);
                                }
                            }
                        }
                    }
                }
                double temp = 0;
                double[] tempTempDict1 = new double[tempDict.Count];
                Dictionary<int, double> tempTempDict = new Dictionary<int, double>(tempDict1.Count+tempDict2.Count);
                int tDi = 1;
                foreach (KeyValuePair<int, double> item in tempDict1)
                {
                    tempDict[item.Key] = item.Value;
                    tDi++;
                }
                foreach (KeyValuePair<int, double> item in tempDict2)
                {
                    tempDict[item.Key] = item.Value;
                    tDi++;
                }
                tempDict1 = tempDict1.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                tempDict2 = tempDict2.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
                /*for (int i = 0; i < tempDict1.Count() - 1; i++)//SORT
                {
                    for (int g = i + 1; g < tempDict1.Count(); g++)
                    {

                        if (tempDict1[i] > tempDict1[g])
                        {
                            temp = tempDict1[i];
                            tempDict1[i] = tempDict1[g];
                            tempDict1[g] = temp;
                        }
                    }
                }*/
                /*for (int i = 0; i < tempDict2.Count() - 1; i++)//SORT
                {
                    for (int g = i + 1; g < tempDict2.Count(); g++)
                    {
                        if (tempDict2[i] > tempDict2[g])
                        {
                            temp = tempDict2[i];
                            tempDict2[i] = tempDict2[g];
                            tempDict2[g] = temp;
                        }
                    }
                }*/
                int oaowo=0;
                if (Tournament.mainTournament.Ex.ExList[j].IsFirstToTop == true)//ОБРАТНЫЙ ОТСЧЕТ
                    tempDict1.Reverse();
                if (Tournament.mainTournament.Ex.ExList[j].IsSecondToTop == true)
                    tempDict2.Reverse();
                //В ОДИН СЛОВАРЬ
                tDi = 1;
                foreach (KeyValuePair<int, double> item in tempDict1)
                {
                    tempTempDict[tDi] = item.Value;
                    tDi++;
                }
                foreach (KeyValuePair<int, double> item in tempDict2)
                {
                    tempTempDict[tDi] = item.Value;
                    tDi++;
                }
                //ПРИСВАИВАНИЕ ОЧКОВ
                
                for (int i =1;i<tempDict.Count+1;i++) //ТРАБЛ ЗДЕСЬ!!!
                {
                    for(int g = 0;g<tempDict.Count;g++)
                    {
                        if (tempTempDict[i] == tempDict[g+1])
                            points[g] = tempDict.Count - i+1;
                    }
                }
                //ЗАГРУЗКА В TOURNAMENT.MAINTOURNAMENT
                for(int i=0;i<Tournament.mainTournament.Ath.AthList.Count;i++)
                {
                    for (int g = 0; g < points.Count(); g++)
                        if (Convert.ToInt32(ResultsAth.Rows[i][0].ToString()) == g + 1)
                        {

                            for (int h = 0; h < Tournament.mainTournament.Ath.AthList.Count; h++)
                                if (Tournament.mainTournament.Ath.AthList[h].Number == g+1)
                                {
                                    if (Tournament.mainTournament.Ath.AthList[h].Points.Count() !=points.Count())
                                        Tournament.mainTournament.Ath.AthList[h].Points = new int[points.Count()];
                                    Tournament.mainTournament.Ath.AthList[h].Points[j] = points[g];

                                }
                        }
                }
            }
            //СУММА ВСЕХ ОЧКОВ
            for (int i = 0; i < Tournament.mainTournament.Ath.AthList.Count; i++)
            {
                Tournament.mainTournament.Ath.AthList[i].AllPoints = 0;
                for (int j = 0; j < Tournament.mainTournament.Ath.AthList[i].Points.Count(); j++)
                    Tournament.mainTournament.Ath.AthList[i].AllPoints = Tournament.mainTournament.Ath.AthList[i].AllPoints + Tournament.mainTournament.Ath.AthList[i].Points[j];
            }
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            //ExToAth();
            //Data();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            // создаем объект BinaryFormatter
            Tournament.mainTournament.ExNames = Exercises.ExNames;
            Tournament.mainTournament.ResultAth = ResultsAth;
            Tournament.mainTournament.ResultEx = ResultsEx;
            BinaryFormatter formatter = new BinaryFormatter();
            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Tournament.mainTournament);
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            // создаем объект BinaryFormatter
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                Tournament.mainTournament = (Tournament)formatter.Deserialize(fs);
            }
            for (int j = 0; j < Tournament.mainTournament.Ath.AthList.Count; j++)
            {
                Tournament.mainTournament.Ath.AthList[j].Exes = new Dictionary<string, double[]>();
                for (int i = 0; i < Tournament.mainTournament.Ex.ExList.Count; i++)
                {
                    Tournament.mainTournament.Ath.AthList[j].Exes.Add(Tournament.mainTournament.Ex.ExList[i].Name, new double[2]);
                }
            }
            ResultsAth = Tournament.mainTournament.ResultAth;
            ResultsEx = Tournament.mainTournament.ResultEx;
            Exercises.ExNames = Tournament.mainTournament.ExNames;
        }
    }
}
