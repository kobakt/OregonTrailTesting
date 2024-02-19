using Microsoft.QualityTools.Testing.Fakes;
using OregonTrailDotNet.Window.Travel;
using static OregonTrailDotNet.Program;

namespace OregonTrailTests
{
    public class ConsoleTests
    {
        [Fact]
        public void MicrosoftFakes()
        {
            using (ShimsContext.Create())
            {
                var writer = new StringWriter();
                Queue<(char, ConsoleKey)> keys = new();
                for (int i = 0; i < 200; i++)
                {
                    keys.Enqueue(('5', ConsoleKey.D5));
                    keys.Enqueue(((char)13, ConsoleKey.Enter));
                }
                System.Fakes.ShimConsole.WriteLineString = (s) => writer.WriteLine(s);
                System.Fakes.ShimConsole.CursorVisibleSetBoolean = (_) => { };
                System.Fakes.ShimConsole.WindowHeightGet = () => 100;
                System.Fakes.ShimConsole.CursorLeftSetInt32 = (_) => { };
                System.Fakes.ShimConsole.SetCursorPositionInt32Int32 = (_, _) => { };
                System.Fakes.ShimConsole.WindowWidthGet = () => 100;
                System.Fakes.ShimConsole.KeyAvailableGet = () => true;
                WolfCurses.Core.Fakes.ShimInputManager.AllInstances.AddCharToInputBufferChar = (_,_) => { };

                System.Fakes.ShimConsole.ReadKeyBoolean = (_) =>
                {
                    var newKey = keys.Dequeue();
                    return new ConsoleKeyInfo(newKey.Item1, newKey.Item2, false, false, false);
                };
                OregonTrailDotNet.Window.Travel.Fakes.ShimTravel.AllInstances.OnWindowPostCreate = (_) => { };
                Main();
                //reader.
                Assert.Equal("", writer.ToString());
            }
        }
        [Fact]
        public void Streams()
        {
            //var writer = new StringWriter();
            //Console.SetOut(writer);
            Main();
        }
    }
}
