using RealityCollective.ServiceFramework.Modules;
using System;
using System.Linq;
using System.Text;

namespace Dinomite.Authentication
{
    /// <summary>
    /// Default implementation for <see cref="IUsernameProvider"/>.
    /// </summary>
    [System.Runtime.InteropServices.Guid("6223ad38-0872-46b6-9354-6619a99ab8c6")]
    public class UsernameProvider : BaseServiceModule, IUsernameProvider
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name assigned to this service instance.</param>
        /// <param name="priority">The priority assigned to this service instance.</param>
        /// <param name="profile">The configuration profile for this service instance.</param>
        /// <param name="authenticationService">The parent service instance for this service intance.</param>
        public UsernameProvider(string name, uint priority, UsernameProviderProfile profile, IAuthenticationService authenticationService)
                : base(name, priority, profile, authenticationService)
        {
            usernamePrefix = profile.UsernamePrefix;
        }

        private readonly string usernamePrefix;

        /// <inheritdoc/>
        public string GetUsername()
        {
            var stringBuilder = new StringBuilder(usernamePrefix);
            stringBuilder.Append('_');
            stringBuilder.Append(Guid.NewGuid().ToString().Split('-').Last());

            return stringBuilder.ToString();
        }
    }
}