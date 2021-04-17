using System;

namespace Console_Calculyator
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Ifoda ifoda = new Ifoda(text);
            Console.WriteLine(ifoda.Asos());
            Console.ReadKey();
        }
    }
    class Ifoda
    {
        public Ifoda(string a)
        {
            this.matn = a;
        }
        private string matn;
        private static string B(string a, int i, char b)
        {
            int min = 0, max = 0, j;
            for (j = i - 1; j >= 0; min++, j--)
            {
                if (a[j] != '*' && a[j] != '/' && a[j] != '+' && a[j] != '-') continue;
                else break;
            }
            for (j = i + 1; j < a.Length; max++, j++)
            {
                if (a[j] != '*' && a[j] != '/' && a[j] != '+' && a[j] != '-') continue;
                else break;
            }
            double x = Convert.ToDouble(a.Substring(i - min, min));
            double y = Convert.ToDouble(a.Substring(i + 1, max));
            switch (b)
            {
                case '*': x = x * y; break;
                case '/': x = x / y; break;
                case '+': x = x + y; break;
                case '-': x = x - y; break;
                case '^': x = Math.Pow(x, y); break;
            }
            a = a.Substring(0, i - min) + Convert.ToString(x) + a.Substring(i + max + 1);
            return a;
        }
        public string Asos()
        {
            char a = '*', b = '/', c = '+', d = '-', e = '^';
            for (int i = 0; i < matn.Length; i++)
            {
                if (matn[i] == a || matn[i] == b || matn[i] == e)
                {
                    matn = B(matn, i, matn[i]);
                    i = 0;
                }
            }
            for (int i = 0; i < matn.Length; i++)
            {
                if (matn[i] == c || matn[i] == d)
                {
                    if (i == 0) continue;
                    matn = B(matn, i, matn[i]);
                    i = 0;
                }
            }
            return matn;
        }
    }
}
