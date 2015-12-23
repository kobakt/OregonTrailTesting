﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TollRoad.cs" company="Ron 'Maxwolf' McDowell">
//   ron.mcdowell@gmail.com
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace TrailSimulation.Entity
{
    using Game;

    /// <summary>
    ///     Defines a location on the trail where the player is required to pay monies in order to use it. Typically this is
    ///     inserted as a skip location for a fork in the road, however it could be used as a normal location on the trail but
    ///     if the player did not have enough money they would be unable to continue down the trail.
    /// </summary>
    public sealed class TollRoad : Location
    {
        /// <summary>Initializes a new instance of the <see cref="TollRoad"/> class. Initializes a new instance of the<see cref="T:TrailSimulation.Entity.Location"/> class.</summary>
        /// <param name="name">Display name of the location as it should be known to the player.</param>
        /// <param name="climateType">Defines the type of weather the location will have overall.</param>
        public TollRoad(string name, Climate climateType) : base(name, climateType)
        {
            // Cost of the toll road will be anywhere from one (1) to thirteen (13) monies.
            Cost = GameSimulationApp.Instance.Random.Next(1, 13);
        }

        /// <summary>
        ///     Gets the total toll for the cost road the player must pay before they will be allowed on the cost road.
        /// </summary>
        public int Cost { get; }

        /// <summary>
        ///     Determines if the location allows the player to chat to other NPC's in the area which can offer up advice about the
        ///     trail ahead.
        /// </summary>
        public override bool ChattingAllowed
        {
            get { return false; }
        }

        /// <summary>
        ///     Determines if this location has a store which the player can buy items from using their monies.
        /// </summary>
        public override bool ShoppingAllowed
        {
            get { return false; }
        }
    }
}