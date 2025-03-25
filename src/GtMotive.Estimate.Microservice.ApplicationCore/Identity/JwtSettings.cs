namespace GtMotive.Estimate.Microservice.ApplicationCore.Identity
{
    /// <summary>
    /// JwtSettings.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Gets or sets Issuer.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Gets or sets Secret.
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Gets or sets ExpirationInDays.
        /// </summary>
        public int ExpirationInDays { get; set; }
    }
}
