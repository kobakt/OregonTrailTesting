using NSubstitute;
using OregonTrailDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OregonTrailTests
{
    public class ConsoleMockTests
    {
        [Fact]
        public void test()
        {
            IConsole console = Substitute.For<IConsole>();
            console.KeyAvailable.Returns(true);
            // public ConsoleKeyInfo(char keyChar, ConsoleKey key, bool shift, bool alt, bool control);
            console.ReadKey(Arg.Any<bool>()).Returns(new ConsoleKeyInfo('1', ConsoleKey.D1, false, false, false));
            //console.WriteLine(Arg.Any<string>());
            Program.Run(console);
        }
    }
}
