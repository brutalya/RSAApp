using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RSAApp
{
    [Serializable]
    internal class Exercise
    {
        public string Name { get; set; }
        double firstValue;
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        bool[] first;
        bool[] second;
        public bool [] First
        {
            get { return first; }
            set
            {
                for (int i = 0; i<value.Count(); i++)
                {
                    for (int j = 0; j < value.Count(); j++)
                    {

                    }
                }
                first = value;
            }
        }
        public bool[] Second
        {
            get { return second; }
            set
            {
                for (int i = 0; i < value.Count(); i++)
                {
                    for (int j = 0; j < value.Count(); j++)
                    {

                    }
                }
                second = value;
            }
        }
        public double FirstValue
        {
            get { return firstValue; }
            set { if (value >= 0) firstValue = value; else throw new Exception("Ошибка ввода!");  }
        }
        double secondValue;
        public double SecondValue
        {
            get { return secondValue; }
            set { if (value >= 0) secondValue = value; else throw new Exception("Ошибка ввода!"); }
        }
        public bool IsFirstToTop { get; set; } //true больше значит лучше, false меньше значит лучше
        public bool IsSecondToTop { get; set; } //true больше значит лучше, false меньше значит лучше
        public bool IsAnother { get; set; } //свойство определяет есть ли второй способ подсчета(когда не закончил упражнение)
        public bool UseFirst { get; set; } //если атлет не закончил упражнение, то свойство определяет нужно ли использовать первый способ
        public bool FirstImportant { get; set; } //true больше значит важнее, false меньше значит второй важнее
        public Exercise()
        {
            First = new bool[4];
            Second = new bool[4];
        }
        public Exercise(string name)
        {
            First = new bool[4];
            Second = new bool[4];
            Name = name;
        }
        public Exercise(string name,bool fimp, bool isftotop, bool isstotop, bool usefirst, int f,int s,string fn,string sn)
        {
            First = new bool[4];
            Second = new bool[4];
            Name = name;
            IsFirstToTop = isftotop;
            IsSecondToTop = isstotop;
            IsAnother = true;
            UseFirst = usefirst;
            FirstName = fn;
            SecondName = sn;
            FirstImportant = fimp;
        }
        public Exercise(string name,bool fimp, bool isftotop,int f, string fn, string sn)
        {
            First = new bool[4];
            First[f] = true;
            Name = name;
            IsFirstToTop = isftotop;
            IsAnother = false;
            FirstName = fn;
            SecondName = sn;
            FirstImportant = fimp;
        }
        public Exercise(Exercise exe)
        {
            First = exe.First;
            Name = exe.Name;
            IsFirstToTop = exe.IsFirstToTop;
            IsAnother = exe.IsAnother;
            FirstName = exe.FirstName;
            SecondName = exe.SecondName;
            FirstImportant = exe.FirstImportant;
        }
    }
}