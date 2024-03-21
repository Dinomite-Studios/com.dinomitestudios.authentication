using System;
using UnityEngine;

namespace Dinomite.Authentication
{
    /// <summary>
    /// A player's information.
    /// </summary>
    [Serializable]
    public class Player
    {
        /// <summary>
        /// The player's unique ID.
        /// </summary>
        [field: SerializeField, Tooltip("The player's unique ID.")]
        public string Id { get; set; }

        /// <summary>
        /// The player's in-game name.
        /// </summary>
        [field: SerializeField, Tooltip("The player's username.")]
        public string PlayerName { get; set; }
    }
}