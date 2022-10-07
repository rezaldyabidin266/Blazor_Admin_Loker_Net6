using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorAdminLoker2022.Shared.Admin
{
    public class AdminSidebarBase : ComponentBase
    {
        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }
        protected string? token;
        protected string? user;
        protected override async Task OnInitializedAsync()
        {
            token = await LocalStorage.GetItemAsync<string>("token");
            await decodeToken(token);
        }

        protected async Task decodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            user = jwtSecurityToken.Claims.First(claim => claim.Type == "myDisplayUser").Value;
            await Js.InvokeVoidAsync("console.log", jwtSecurityToken);
            await Js.InvokeVoidAsync("console.log", user);
        }
    }
}
