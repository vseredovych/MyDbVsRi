using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace MyDbVsRi
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.MainMenu();
            Console.WriteLine("Hello World!");
         }
    }
}
