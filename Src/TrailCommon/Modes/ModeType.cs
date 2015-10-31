﻿namespace TrailCommon
{
    /// <summary>
    ///     Since the view for game modes is separated from the actual logic being performed we need a logical way to know what
    ///     view to attach on the view. This enum serves that purpose, it is required to add any new game modes the simulation
    ///     needs to know about to this file.
    /// </summary>
    public enum ModeType
    {
        /// <summary>
        ///     Primary game mode used for advancing simulation down the trail.
        /// </summary>
        Travel,

        /// <summary>
        ///     Forces the player to make a decision about where to go next on the trail.
        /// </summary>
        ForkInRoad,

        /// <summary>
        ///     Lets the player hunt for food to bring back to the vehicle.
        /// </summary>
        Hunt,

        /// <summary>
        ///     Allows the configuration of party names, player profession, and purchasing initial items for trip.
        /// </summary>
        NewGame,

        /// <summary>
        ///     Prompts with a message about something happening to the player party or their vehicle. Stops the simulation until
        ///     the player continues on the trail again.
        /// </summary>
        RandomEvent,

        /// <summary>
        ///     Forces the player to make a choice about how to cross the river, they can ford the river, caulk their wagon and
        ///     float, or pay to take a ferry across.
        /// </summary>
        RiverCrossing,

        /// <summary>
        ///     Facilitates purchasing items from a list, prices can change per store as there is no central lookup for this
        ///     information.
        /// </summary>
        Store,

        /// <summary>
        ///     Same as normal store except it offers up advice and information about purchasing and what the items mean. This
        ///     advice is not offered after the simulation formally starts, it is shown by default when starting a new game.
        /// </summary>
        StartingStore,

        /// <summary>
        ///     Facilitates trading items with a fake AI vehicle, a list is created and values randomly selected from it for
        ///     possible trades.
        /// </summary>
        Trade,

        /// <summary>
        ///     Could be a landmark, settlement, fort, town, city.
        /// </summary>
        Location
    }
}