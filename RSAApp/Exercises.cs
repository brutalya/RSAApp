using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    class Exercises: Tournament
    {
        int number;
        public int Number
        {
            get { return number; }
            set { if (value > 0) number = value; else throw new Exception("Упражнений должно быть больше 0!"); }
        }
        public Exercises()
        {

        }
        public Exercises(int num)
        {
            Number = num;
        }
    }
}
