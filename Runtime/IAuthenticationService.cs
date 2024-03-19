using RealityCollective.ServiceFramework.Interfaces;
using System;
using System.Threading.Tasks;

namespace Dinomite.Authentication
{
    public delegate void SignInStatusChangedDelegate(bool isSignedIn);

    /// <summary>
    /// Interface for a service system that implements player authentication.
    /// </summary>
    public interface IAuthenticationService : IService
    {
        /// <summary>
        /// Gets whether the player is signed in to the backend service.
        /// </summary>
        bool IsSignedIn { get; }

        /// <summary>
        /// Gets the logged in <see cref="Player"/>.
        /// </summary>
        /// <remarks>Returns null if <see cref="IsSignedIn"/> is false.</remarks>
        Player LoggedInPlayer { get; }

        /// <summary>
        /// Raised when the player's sign in status has changed.
        /// </summary>
        event SignInStatusChangedDelegate SignInStatusChanged;

        /// <summary>
        /// Raised when the active player data has changed.
        /// </summary>
        event Action PlayerChanged;

        /// <summary>
        /// Performs guest player login that will use a unique device identifier to
        /// identify the player across sessions. This API will always return the same player when
        /// run on the same device as before.
        /// </summary>
        /// <param name="createAccountIfNotExists">If set, will attempt to create the player account on the fly.</param>
        /// <returns>The guest <see cref="Player"/>.</returns>
        Task<Player> LoginGuestAsync(bool createAccountIfNotExists);

        /// <summary>
        /// Logs the <see cref="LoggedInPlayer"/> off.
        /// </summary>
        Task LogoutAsync();
    }
}