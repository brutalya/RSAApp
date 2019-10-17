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
                    
                }
            }
        }
    }
}
