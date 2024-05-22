using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class A
    {
        public delegate void MyDelegate(string msg);//создание делегата
        public static void ShowMsg(string msg) { Console.WriteLine(msg); }
        public static void Handlemes(string msg) { Console.WriteLine(msg); }

        public event MyDelegate onMsg;

        public void TakeMsg(string msg)
        {
            onMsg?.Invoke(msg);
        }
    }
}
