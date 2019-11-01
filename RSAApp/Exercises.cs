using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    [Serializable]
    class Exercises
    {
        public static List<string> ExNames;
        int number;
        List<Exercise> exList;
        public List<Exercise> ExList
        {
            get { return exList; }
            set { exList = value; }
        }
        public int Number
        {
            get { return number; }
            set { if (value > 0) number = value; else throw new Exception("Упражнений должно быть больше 0!"); }
        }
        public Exercises()
        {
            ExList = new List<Exercise>();
        }
        public Exercises(int num)
        {
            Number = num;
            ExList = new List<Exercise>(num);
        }
        public Exercises(List<Exercise> e)
        {
            Number = e.Count();
            ExList = e;
        }
    }
}
