using System;

namespace ConsoleApp3
{
    class Drobi
    {
        int ch;
        int zn;

        public Drobi(int a)
        {
            ch = a;
            zn = 1;
        }
        public Drobi(int a, int b)
        {
            ch = a;
            zn = b;
        }
        public Drobi(int a, int b, int z)
        {
            zn = b;
            ch = z * b + a;
        }
        public double Desyat()
        {
            return (double)(ch) / zn;
        }
        public static Drobi operator + (Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn + y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator - (Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn - y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator * (Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.ch, x.zn * y.zn);
        }
        public static Drobi operator / (Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn, x.zn * y.ch);
        }
        public bool GetZnak()
        {
            return Desyat() >= 0;
        }
        public delegate void Changed(Drobi a, int b);

        public event Changed EventChangerCh;
        public event Changed EventChangerZn;
        public int Ch
        {
            get { return ch; }
            set 
            {
                EventChangerCh(this, value);
                ch = value; 
            }
        }
        public int Zn
        {
            get { return zn; }
            set
            {
                EventChangerZn(this, value);
                zn = value;
            }
        }
        public int this[int index]
        {
            get { return (index == 0) ? ch : zn; }
        }
    }
    class Method
    {
       public static void MyMethodCh(Drobi a, int x)
        {
            Console.WriteLine("Числитель изменён");
        }
        public static void MyMethodZn(Drobi a, int x)
        {
            Console.WriteLine("Знаменатель изменён");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Drobi dr1 = new Drobi(3);
            Drobi dr2 = new Drobi(-1, 2);
            Drobi dr3 = new Drobi(4, 5, 2);
            Console.WriteLine(dr1.Desyat());
            Console.WriteLine((dr1 + dr2).Ch+"/"+(dr1+dr2).Zn);
            Console.WriteLine(dr1.GetZnak());
            Console.WriteLine(dr2.GetZnak());
            dr1.EventChangerCh += Method.MyMethodCh;
            dr1.EventChangerZn += Method.MyMethodZn;
            dr1.Ch = 15;
            dr1.Zn = 3;
            Console.WriteLine(dr1[0]);
            Console.WriteLine(dr1[1]);
        }
    }
}