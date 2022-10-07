using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace BlazorAgentVs2022.Utility
{
    public class MyAuthenticationProvider : AuthenticationStateProvider
    {
        private ILocalStorageService _LocalStorage;
        public string TokenJwt;
        public MyAuthenticationProvider(ILocalStorageService localStorage)
        {
            _LocalStorage = localStorage;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity;
            try
            {
                var token = await _LocalStorage.GetItemAsync<string>("token");
                TokenJwt = token;
                identity = SetClaim(token);
            }
            catch
            {
                identity = new ClaimsIdentity();
            }

            var user = new ClaimsPrincipal(identity);
            return await Task.FromResult(new AuthenticationState(user));

        }
        public void MarkUserAsAuthenticated(string token)
        {
            ClaimsIdentity identity = SetClaim(token);
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
        private ClaimsIdentity SetClaim(string token)
        {
            var identity = new ClaimsIdentity(token);
            return identity;
        }
        public void MarkUserAsLogout()
        {
            _LocalStorage.RemoveItemAsync("token");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }

    //Add Token Headers
    public class TokenControl : DelegatingHandler
    {
        private readonly ILocalStorageService _LocalStorage;
        public TokenControl(ILocalStorageService localStorage)
        {
            _LocalStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //get the token
            var token = await _LocalStorage.GetItemAsync<string>("token");
            //add header
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //continue down stream request       
            var response = await base.SendAsync(request, cancellationToken);
            return response;
        }
    }
}
