using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Shop
    {
        public Shop(double area)
        {
            Area = area;
        }
        private double _area;
        public double Area
        {
            get
            {
                return _area;
            }
            set
            {
                if (value <= 0) throw new ArgumentException();
                _area = value;
            }
        }
        public static Shop operator + (Shop obj, double area)
        {
            if (area <= 0) throw new ArgumentException();
            obj.Area += area;
            return obj;
        }
        public static Shop operator -(Shop obj, double area)
        {
            if (area <= 0 || obj.Area <= area) throw new ArgumentException();
            obj.Area -= area;
            return obj;
        }
        public static bool operator > (Shop obj1, Shop obj2)
        {
            return obj1.Area > obj2.Area;
        }
        public static bool operator <(Shop obj1, Shop obj2)
        {
            return obj1.Area < obj2.Area;
        }
        public static bool operator != (Shop obj1, Shop obj2)
        {
            return obj1.Area != obj2.Area;
        }
        public static bool operator ==(Shop obj1, Shop obj2)
        {
            return obj1.Area == obj2.Area;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj == this) return true;
            if (obj is Shop)
            {
                Shop T = (Shop)obj;
                if (T.Area == Area) return true;
            }
            return false;
        }
       public override string ToString()
        {
            return $"Area of shop is {Area}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Shop Silpo = new Shop(1000);
            Shop Rozetka = new Shop(2000);

            //тест перегрузки операторов +, -
            Console.WriteLine(Silpo);
            Silpo = Silpo + 150;
            Console.WriteLine(Silpo);
            Silpo = Silpo - 25;
            Console.WriteLine(Silpo);

            //тест перегрузки логических операторов
            if (Silpo.Equals(Rozetka)) Console.WriteLine("Shops has equal area\n");
                else Console.WriteLine("Shops has NOT equal area\n");

            if (Silpo > Rozetka) Console.WriteLine("Silpo is bigger than Rozetka\n");
                else Console.WriteLine("Silpo is NOT bigger than Rozetka\n");
        }
    }
}
