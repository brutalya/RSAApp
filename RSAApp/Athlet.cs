using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RSAApp
{
    [Serializable]
    internal class Athlet
    {
        public Dictionary<string, double[]> Exes { get; set; }

        int number;
        public int Number
        {
            get { return number; }
            set { if (value > 0) number = value; }
        }
        int allPoints;
        public int AllPoints
        {
            get { return allPoints; }
            set { if (value >= 0) allPoints = value; }
        }
        int[] points;
        public int[] Points
        {
            get { return points; }
            set { foreach (int item in value) if (item < 0) throw new Exception("Ошибка ввода!"); points = value; }
        }
        public string Name { get; set; }
        public Athlet()
        {
            AllPoints = 0;
            Points = new int[0];
            //if(Tournament.mainTournament.Ex.ExList.Count>0)
            Exes = new Dictionary<string, double[]>();
        }
        public Athlet(string name)
        {
            AllPoints = 0;
            //if (Tournament.mainTournament.Ex.ExList.Count > 0)
            Points = new int[0];
            Exes = new Dictionary<string, double[]>();
            Name = name;
        }
        public Athlet(string name, int num)
        {
            AllPoints = 0;
            Points = new int[0];
            //if (Tournament.mainTournament.Ex.ExList.Count > 0)
            Exes = new Dictionary<string, double[]>();
            Name = name;
            Number = num;
        }
    }
}