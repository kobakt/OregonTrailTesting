using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrailDotNet
{
    public class Console : IConsole
    {

        string IConsole.Title { get; set; } = System.Console.Title;
        bool IConsole.CursorVisible { get; set; } = System.Console.CursorVisible;
        Encoding IConsole.OutputEncoding { get; set; } = System.Console.OutputEncoding;
        int IConsole.CursorLeft { get; set; } = System.Console.CursorLeft;
        int IConsole.WindowHeight { get; set; } = System.Console.WindowHeight;
        int IConsole.WindowWidth { get; set; } = System.Console.WindowWidth;

        bool IConsole.KeyAvailable
        { get {
                for (int i = 0; i < 100; i++)
                {
                    if (System.Console.KeyAvailable)
                    {
                        return true;

                    }
                }
                return false;
            }
        }
        ConsoleCancelEventHandler IConsole.CancelKeyPress 
        { 
            get => new ConsoleCancelEventHandler((_,_) => { }); 
            set => System.Console.CancelKeyPress += value; 
        }

        void IConsole.Clear()
        {
            System.Console.Clear();
        }

        ConsoleKeyInfo IConsole.ReadKey()
        {
            return System.Console.ReadKey();
        }

        ConsoleKeyInfo IConsole.ReadKey(bool v)
        {
            return System.Console.ReadKey(v);
        }

        void IConsole.SetCursorPosition(int v, int index)
        {
            System.Console.SetCursorPosition(v, index);
        }

        void IConsole.Write(string emptyStringData)
        {
            System.Console.Write(emptyStringData);
        }

        void IConsole.WriteLine(string v)
        {
            System.Console.WriteLine(v);
        }
    }
}
