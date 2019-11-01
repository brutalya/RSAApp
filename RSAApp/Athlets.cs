using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    [Serializable]
    class Athlets
    {
        int number;
        public int Number
        {
            get { return number; }
            set { if (value > 0) number = value; else throw new Exception("Участников должно быть больше 0!"); }
        }
        List<Athlet> athList;
        public List<Athlet>AthList
        {
            get { return athList; }
            set { if (value.Count() == Number) athList = value; else throw new Exception("Ошибка!"); }
        }
        public Athlets()
        {

        }
        public Athlets(int num)
        {
            Number = num;
            AthList = new List<Athlet>(num);
        }
        public Athlets(List<Athlet> a)
        {
            Number = a.Count();
            AthList = a;
        }
        public void addAthlet(Athlet a)
        {
            AthList.Add(a);
        }
        public void addAthlet(int n, string name)
        {
            AthList.Add(new Athlet(name,n));
        }
        public void removeAthlet(Athlet a)
        {
            AthList.Remove(a);
        }
        public void removeAthlet(int n)
        {
            foreach(Athlet item in AthList)
            {
                if (item.Number == n) AthList.Remove(item);
            }
        }
        public void removeAthlet(string name)
        {
            foreach (Athlet item in AthList)
            {
                if (item.Name == name) AthList.Remove(item);
            }
        }
        public void changeAthletName(int number,string newName)
        {
            for(int i =0; i<AthList.Count();i++)
            {
                if (AthList[i].Number == number) AthList[i].Name = newName;
            }
        }
        public void changeAthletNumber(int newNumber, string name)
        {
            for (int i = 0; i < AthList.Count(); i++)
            {
                if (AthList[i].Name == name) AthList[i].Number = number;
            }
        }
    }
}
