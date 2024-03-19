using System;
using UnityEngine;

namespace Dinomite.Authentication
{
    [Serializable]
    public class Player
    {
        [SerializeField]
        [Tooltip("The player's unique ID.")]
        private string id;

        /// <summary>
        /// The player's unique ID.
        /// </summary>
        public string Id
        {
            get => id;
            set => id = value;
        }

        [SerializeField]
        [Tooltip("The player's avatar source URL.")]
        private string avatarUrl;

        /// <summary>
        /// The player's avatar source URL.
        /// </summary>
        public string AvatarUrl
        {
            get => avatarUrl;
            set => avatarUrl = value;
        }

        [SerializeField]
        [Tooltip("The country code of the player's country.")]
        private string country;

        /// <summary>
        /// The country code of the player's country.
        /// </summary>
        public string Country
        {
            get => country;
            set => country = value;
        }

        [SerializeField]
        [Tooltip("The player's username.")]
        private string username;

        /// <summary>
        /// The player's username.
        /// </summary>
        public string Username
        {
            get => username;
            set => username = value;
        }

        [SerializeField]
        [Tooltip("When was this player created?")]
        private DateTime? createdAt;

        /// <summary>
        /// When was this player created?
        /// </summary>
        public DateTime? CreatedAt
        {
            get => createdAt;
            set => createdAt = value;
        }
    }
}