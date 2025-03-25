using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace GtMotive.Estimate.Microservice.InfrastructureTests
{
#pragma warning disable
    public class MockSchemeProvider : IAuthenticationSchemeProvider
    {        
        private readonly List<AuthenticationScheme> _schemes = new()
        {
            new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler))
        };

        public Task<IEnumerable<AuthenticationScheme>> GetAllSchemesAsync() =>
            Task.FromResult<IEnumerable<AuthenticationScheme>>(new[] { new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)) });

        public Task<AuthenticationScheme> GetDefaultAuthenticateSchemeAsync() => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public Task<AuthenticationScheme> GetDefaultChallengeSchemeAsync() => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public Task<AuthenticationScheme> GetDefaultForbidSchemeAsync() => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public Task<AuthenticationScheme> GetDefaultSignInSchemeAsync() => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public Task<AuthenticationScheme> GetDefaultSignOutSchemeAsync() => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public Task<IEnumerable<AuthenticationScheme>> GetRequestHandlerSchemesAsync() => Task.FromResult<IEnumerable<AuthenticationScheme>>(_schemes);

        public Task<AuthenticationScheme> GetSchemeAsync(string name) => Task.FromResult(new AuthenticationScheme("TestScheme", "TestScheme", typeof(TestAuthHandler)));

        public void AddScheme(AuthenticationScheme scheme)
        {
            if (!_schemes.Any(s => s.Name == scheme.Name))
            {
                _schemes.Add(scheme);
            }
        }

        public void RemoveScheme(string name)
        {
            var scheme = _schemes.FirstOrDefault(s => s.Name == name);
            if (scheme != null)
            {
                _schemes.Remove(scheme);
            }
        }
    }

}
#pragma warning restore
