﻿using System;
using System.Text;

namespace TrailEntities
{
    /// <summary>
    ///     Erases all of the saved games that have been saved to a give slot directory. Typically there are ten save slots.
    /// </summary>
    public sealed class EraseSavedGamesState : ModeState<OptionInfo>
    {
        /// <summary>
        ///     This constructor will be used by the other one
        /// </summary>
        public EraseSavedGamesState(IMode gameMode, OptionInfo userData) : base(gameMode, userData)
        {
        }

        /// <summary>
        ///     Returns a text only representation of the current game mode state. Could be a statement, information, question
        ///     waiting input, etc.
        /// </summary>
        public override string GetStateTUI()
        {
            var eraseSaves = new StringBuilder();


            eraseSaves.Append("Press ENTER KEY to continue.\n");
            return eraseSaves.ToString();
        }

        /// <summary>
        ///     Determines if user input is currently allowed to be typed and filled into the input buffer.
        /// </summary>
        /// <remarks>Default is FALSE. Setting to TRUE allows characters and input buffer to be read when submitted.</remarks>
        public override bool AcceptsInput
        {
            get { return false; }
        }

        /// <summary>
        ///     Fired when the game mode current state is not null and input buffer does not match any known command.
        /// </summary>
        /// <param name="input">Contents of the input buffer which didn't match any known command in parent game mode.</param>
        public override void OnInputBufferReturned(string input)
        {
            throw new NotImplementedException();
        }
    }
}