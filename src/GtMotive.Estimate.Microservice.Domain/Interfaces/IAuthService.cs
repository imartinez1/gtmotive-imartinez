using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// IAuthService interface.
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// GenerateJwt token.
        /// </summary>
        /// <param name="user">user.</param>
        /// <returns>token string.</returns>
        string GenerateJwt(User user);
    }
}
