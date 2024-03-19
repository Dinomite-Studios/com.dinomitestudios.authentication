using RealityCollective.ServiceFramework.Services;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Assertions;

namespace Dinomite.Authentication
{
    /// <summary>
    /// Default implementation for <see cref="IAuthenticationService"/>.
    /// </summary>
    [System.Runtime.InteropServices.Guid("ff860b7b-a53e-4f6a-8295-e618bbc87ccb")]
    public class AuthenticationService : BaseServiceWithConstructor, IAuthenticationService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="name">The name assigned to this service instance.</param>
        /// <param name="priority">The priority assigned to this service instance.</param>
        /// <param name="profile">The configuration profile for this service instance.</param>
        public AuthenticationService(string name, uint priority, AuthenticationServiceProfile profile)
            : base(name, priority) { }

        private ILoginProvider loginProvider;

        private bool isSignedIn;
        /// <inheritdoc/>
        public bool IsSignedIn
        {
            get => isSignedIn;
            private set
            {
                if (isSignedIn == value)
                {
                    return;
                }

                isSignedIn = value;
                SignInStatusChanged?.Invoke(IsSignedIn);

                if (!IsSignedIn)
                {
                    LoggedInPlayer = null;
                }
            }
        }

        private Player loggedInPlayer;
        /// <inheritdoc/>
        public Player LoggedInPlayer
        {
            get => loggedInPlayer;
            private set
            {
                if (loggedInPlayer == value)
                {
                    return;
                }

                loggedInPlayer = value;
                PlayerChanged?.Invoke();
            }
        }

        /// <inheritdoc/>
        public event SignInStatusChangedDelegate SignInStatusChanged;

        /// <inheritdoc/>
        public event Action PlayerChanged;

        /// <inheritdoc/>
        public override void Initialize()
        {
            if (!Application.isPlaying)
            {
                return;
            }

            if (loginProvider == null)
            {
                var loginProviders = ServiceManager.Instance.GetServices<ILoginProvider>();
                Assert.IsTrue(loginProviders.Count > 0, $"There is no active {nameof(ILoginProvider)}. The {nameof(IAuthenticationService)} requires an active {nameof(ILoginProvider)}.");
                Assert.IsFalse(loginProviders.Count > 1, $"There is more than one active {nameof(ILoginProvider)}. The {nameof(IAuthenticationService)} supports only one active {nameof(ILoginProvider)}.");
                loginProvider = loginProviders[0];
            }
        }

        /// <inheritdoc/>
        public async Task<Player> LoginGuestAsync(bool createAccountIfNotExists)
        {
            if (IsSignedIn)
            {
                return LoggedInPlayer;
            }

            LoggedInPlayer = await loginProvider.LoginGuestAsync(createAccountIfNotExists);
            if (LoggedInPlayer == null)
            {
                IsSignedIn = false;
                return null;
            }

            IsSignedIn = true;
            return LoggedInPlayer;
        }

        /// <inheritdoc/>
        public async Task LogoutAsync()
        {
            if (!IsSignedIn)
            {
                return;
            }

            await loginProvider.LogoutAsync();
            IsSignedIn = false;
        }
    }
}