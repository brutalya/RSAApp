using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    class Tournament
    {
        public static Tournament mainTournament=new Tournament();
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        int numberOfAth;
        public int NumberOfAth
        {
            get { return numberOfAth; }
            set { if (value > 0) numberOfAth = value;  else throw new Exception("Участников должно быть больше 0!"); }
        }
        int numberOfEx;
        public int NumberOfEx
        {
            get { return numberOfEx; }
            set { if (value > 0) numberOfEx = value; else throw new Exception("Упражнений должно быть больше 0!"); }
        }
        public Tournament()
        {

        }
        public Tournament(int num, int numex)
        {
            NumberOfAth = num;
            NumberOfEx = numex;
        }
    }
}
