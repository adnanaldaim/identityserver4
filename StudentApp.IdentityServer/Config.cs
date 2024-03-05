
using IdentityServer4.Models;

namespace StudentApp.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources => new[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
                Name = "role",
                UserClaims = new List<string>{ "role" }
            }
        };

        public static IEnumerable<ApiScope> ApiScopes => new[]
        {
            new ApiScope("StudentApp.API")
        };

        public static IEnumerable<ApiResource> ApiResources = new[]
        {
            new ApiResource("StudentApp.API")
            {
                 Scopes = new List<string> {"StudentApp.API" },
                 ApiSecrets = new List<Secret>{ new Secret("ScopeSecret".Sha256())},
                 UserClaims = new List<string> {"role"}
            }
        };

        public static IEnumerable<Client> Clients => new[]
        {
            new Client
            {
                ClientId = "apiClient",
                ClientName = " Api Client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = {new Secret("apiClient".Sha256())},
                AllowedScopes = {"StudentApp.API" }
            },
            new Client
            {
                ClientId = "webClient",
                ClientName = "Web Client",
                AllowedGrantTypes = GrantTypes.Code,
                ClientSecrets = {new Secret("webClient".Sha256())},
                AllowedScopes = {"openid", "profile", "StudentAPI.Web" },
                AllowedCorsOrigins = { "https://localhost:7225" },

                RedirectUris           = { "https://localhost:7225/signin-oidc" },
                PostLogoutRedirectUris = { "http://localhost:7225/signout-callback-oidc" },
                FrontChannelLogoutUri="http://localhost:7225/signout-oidc",

                AllowOfflineAccess = true,
                RequirePkce = true,
                RequireConsent = true,
                AllowPlainTextPkce = false
            }
        };
    }
}
