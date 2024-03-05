using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StudentApp.API.Identity;

namespace StudentApp.API.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IOptions<IdentityServerSettings> _identitySettings;
        private readonly HttpClient _httpClient;
        private readonly DiscoveryDocumentResponse disco;
        private readonly ILogger<TokenController> _logger;

        public TokenController(IOptions<IdentityServerSettings> identitySettings, ILogger<TokenController> logger)
        {
            _identitySettings = identitySettings;
            _httpClient = new HttpClient();
            disco = _httpClient.GetDiscoveryDocumentAsync(this._identitySettings.Value.DiscoveryUrl).Result;
            if (disco.IsError)
                throw new Exception("Unable to get discovery document", disco.Exception);
            _logger = logger;
        }
        [HttpGet]
        public async Task<TokenResponse> GetToken(string username, string password)
        {
            try
            {
                var tokenResponse = await _httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _identitySettings?.Value.ClientId,
                    ClientSecret = _identitySettings?.Value.ClientSecret,
                    UserName = username,
                    Password = password,
                    Scope = _identitySettings?.Value.Scope
                });

                if (tokenResponse.IsError)
                    throw new Exception("Unable to get token", disco.Exception);

                return tokenResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
