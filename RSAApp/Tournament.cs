using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    [Serializable]
    class Tournament
    {
        public static Tournament mainTournament;
        public DataTable ResultEx { get; set; }
        public DataTable ResultAth { get; set; }
        public List<string> ExNames { get; set; }
        public string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        Athlets ath;
        public Athlets Ath
        {
            get { return ath; }
            set { ath = value; }
        }
        Exercises ex;
        public Exercises Ex
        {
            get { return ex; }
            set { ex = value; }
        }
        public Tournament()
        {

        }
        public Tournament(string name)
        {
            Name = name;
        }
        public Tournament(Athlets ath, Exercises ex)
        {
            Ath = ath;
            Ex = ex;
        }
        public Tournament(string name,Athlets ath)
        {
            Ath = ath;
            Name = name;
        }
        public Tournament(string name, Athlets ath, Exercises ex)
        {
            Name = name;
            Ath = ath;
            Ex = ex;
        }
    }
}
