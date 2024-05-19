using System;
using structures;
using structs;
using CLI;

namespace App {
    public class Globals
    {
        public const string MENU_PATH = "json/Menu.json";
    }
}
class Program
{
    static void Main()
    {
        Interface.Init();
        Interface.Run();
    }
}