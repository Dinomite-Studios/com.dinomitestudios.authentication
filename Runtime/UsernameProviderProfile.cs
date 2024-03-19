using RealityCollective.ServiceFramework.Definitions;
using UnityEngine;

namespace Dinomite.Authentication
{
    /// <summary>
    /// Configuration profile for the <see cref="UsernameProvider"/>.
    /// </summary>
    public class UsernameProviderProfile : BaseProfile
    {
        [SerializeField]
        [Tooltip("Prefix applied to all generated usernames.")]
        private string usernamePrefix = null;

        /// <summary>
        /// Prefix applied to all generated usernames.
        /// </summary>
        public string UsernamePrefix => usernamePrefix;
    }
}