using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    class Athlets
    {
        int number;
        public int Number
        {
            get { return number; }
            set { if (value > 0) number = value; else throw new Exception("Участников должно быть больше 0!"); }
        }
        Dictionary<int, string> athletsDict;
        public Dictionary<int, string> AthletsDict
        {
            get
            {
                return athletsDict;
            }
            set
            {
                bool isok = true;
                foreach (KeyValuePair<int, string> item in value)
                    if (item.Key <= 0||item.Key>value.Count)
                    {
                        isok = false;
                        throw new Exception("Ошибка ввода! Номер атлета должен быть больше Ноля и числа участников!");
                    }
                foreach (KeyValuePair<int, string> item in value)
                {
                    //чтоб не были одинаковыми
                }
                athletsDict = value;
            }
        }
        public Athlets()
        {

        }
        public Athlets(int num)
        {
            Number = num;
        }
        public Athlets(Dictionary<int,string> ath)
        {
            AthletsDict = ath;
            
        }
        public void addAthlet(int key,string value)
        {
            Dictionary<int, string> tempAthlets = AthletsDict;
            tempAthlets.Add(key, value);
            AthletsDict = tempAthlets;
        }
        public void removeAthlet(int key)
        {
            AthletsDict.Remove(key);
        }
        public void changeAthlet(int key,string newValue)
        {
            AthletsDict[key] = newValue;
        }
    }
}
