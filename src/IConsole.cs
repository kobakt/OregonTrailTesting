using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrailDotNet
{
    public interface IConsole
    {

        public string Title { get; set; }
        public bool CursorVisible { get; set; }
        public Encoding OutputEncoding { get; set; }
        public int CursorLeft { get; set; }
        public int WindowHeight { get; set; }
        public int WindowWidth { get; set; }
        public bool KeyAvailable { get; }
        public ConsoleCancelEventHandler? CancelKeyPress { get; set; }

        public ConsoleKeyInfo ReadKey();
        public void Clear();

        public ConsoleKeyInfo ReadKey(bool v);

        public void SetCursorPosition(int v, int index);

        public void Write(string emptyStringData);

        public void WriteLine(string v);
    }
}
