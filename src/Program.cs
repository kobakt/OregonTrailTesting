// Created by Ron 'Maxwolf' McDowell (ron.mcdowell@gmail.com) 
// Timestamp 01/01/2016@7:40 PM

using OregonTrailDotNet;
using System;
using System.Threading;

namespace OregonTrailDotNet
{
    

    /// <summary>
    ///     Trail Simulation Game - Console Edition
    /// </summary>
    public static class Program
    {
        public static int Main()
        {
            return Program.Run(new Console());
        }
        /// <summary>
        ///     Example console app for game simulation entry point.
        /// </summary>
        public static int Run(IConsole console)
        {

            // Create console with title, no cursor, make CTRL-C act as input.
            console.Title = "Oregon Trail Clone";
            console.WriteLine("Starting...");
            console.CursorVisible = false;
            console.CancelKeyPress += Console_CancelKeyPress;

            // Because I want things to look correct like progress bars.
            console.OutputEncoding = System.Text.Encoding.Unicode;

            // Create game simulation singleton instance, and start it.
            GameSimulationApp.Create();

            void Simulation_ScreenBufferDirtyEvent(string tuiContent)
            {
                var tuiContentSplit = tuiContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                for (var index = 0; index < console.WindowHeight - 1; index++)
                {
                    console.CursorLeft = 0;
                    console.SetCursorPosition(0, index);

                    var emptyStringData = new string(' ', console.WindowWidth);

                    if (tuiContentSplit.Length > index)
                    {
                        emptyStringData = tuiContentSplit[index].PadRight(console.WindowWidth);
                    }

                    console.Write(emptyStringData);
                }
            }

            // Hook event to know when screen buffer wants to redraw the entire console screen.
            GameSimulationApp.Instance.SceneGraph.ScreenBufferDirtyEvent += Simulation_ScreenBufferDirtyEvent;

            // Prevent console session from closing.
            while (GameSimulationApp.Instance != null)
            {
                // Simulation takes any numbers of pulses to determine seconds elapsed.
                GameSimulationApp.Instance.OnTick(true);

                // Check if a key is being pressed, without blocking thread.
                if (console.KeyAvailable)
                //if (true)
                {
                    // GetModule the key that was pressed, without printing it to console.
                    var key = console.ReadKey(true);

                    // If enter is pressed, pass whatever we have to simulation.
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (key.Key)
                    {
                        case ConsoleKey.Enter:
                            GameSimulationApp.Instance.InputManager.SendInputBufferAsCommand();
                            break;
                        case ConsoleKey.Backspace:
                            GameSimulationApp.Instance.InputManager.RemoveLastCharOfInputBuffer();
                            break;
                        default:
                            GameSimulationApp.Instance.InputManager.AddCharToInputBuffer(key.KeyChar);
                            break;
                    }
                }

                // Do not consume all of the CPU, allow other messages to occur.
                Thread.Sleep(1);
            }

            // Make user press any key to close out the simulation completely, this way they know it closed without error.
            console.Clear();
            console.WriteLine("Goodbye!");
            console.WriteLine("Press ANY KEY to close this window...");
            console.ReadKey();
            return 0;
        }

        /// <summary>Write all text from objects to screen.</summary>
        /// <param name="tuiContent">The text user interface content.</param>


        /// <summary>
        ///     Fired when the user presses CTRL-C on their keyboard, this is only relevant to operating system tick and this view
        ///     of simulation. If moved into another framework like game engine this statement would be removed and just destroy
        ///     the simulation when the engine is destroyed using its overrides.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            // Destroy the simulation.
            GameSimulationApp.Instance.Destroy();

            // Stop the operating system from killing the entire process.
            e.Cancel = true;
        }
    }
}