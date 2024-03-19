using System.Threading.Tasks;

namespace Dinomite.Authentication
{
    /// <summary>
    /// A <see cref="ILoginProvider"/> is used by the <see cref="IAuthenticationService"/>
    /// to authenticate and sign in a <see cref="Player"/>.
    /// </summary>
    public interface ILoginProvider : IAuthenticationServiceModule
    {
        /// <inheritdoc cref="IAuthenticationService.LoginGuestAsync(bool)"/>
        Task<Player> LoginGuestAsync(bool createAccountIfNotExists);

        /// <inheritdoc cref="IAuthenticationService.LogoutAsync"/>
        Task LogoutAsync();
    }
}