namespace Dinomite.Authentication
{
    /// <summary>
    /// A <see cref="IAuthenticationServiceModule"/> providing generated usernames.
    /// </summary>
    public interface IUsernameProvider : IAuthenticationServiceModule
    {
        /// <summary>
        /// Generates a new username for a player and caches it locally.
        /// </summary>
        /// <returns>The player's randomly assigned username.</returns>
        string GetUsername();
    }
}