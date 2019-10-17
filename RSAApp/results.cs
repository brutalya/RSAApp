using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSAApp
{
    class results
    {
        Dictionary<int, string> athlets;
        public Dictionary<int, string> Athlets
        {
            get
            {
                return athlets;
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
                athlets = value;
            }
        }
        public void addAthlet(int key,string value)
        {
            Dictionary<int, string> tempAthlets = Athlets;
            tempAthlets.Add(key, value);
            Athlets = tempAthlets;
        }
        public void removeAthlet(int key)
        {
            Athlets.Remove(key);
        }
        public void changeAthlet(int key,string newValue)
        {
            Athlets[key] = newValue;
        }
    }
}
