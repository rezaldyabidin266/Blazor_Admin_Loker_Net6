using BlazorAdminLoker2022.Resource.Login;
using BlazorAdminLoker2022.Service;
using BlazorAgentVs2022.Utility;
using BlazorLoker2022.Resource.Admin.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace BlazorAdminLoker2022.Pages.Login
{
    public class AdminLoginBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLogin serviceAdminLogin { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }

        [Inject]
        protected AuthenticationStateProvider authenticationStateProvider { get; set; }

        protected string token;
        public EditContext? LoginAdmin { get; set; }
        protected string message;

        protected AdminLoginClass AdminLoginClass = new AdminLoginClass();
        protected string browserUser;
        protected override void OnInitialized()
        {
            LoginAdmin = new EditContext(AdminLoginClass);

        }
        protected override async Task OnInitializedAsync()
        {
            browserUser = await Js.InvokeAsync<string>("myBrowser");
            await Js.InvokeVoidAsync("getLocation");
        }

        protected async Task postLogin()
        {
            if (LoginAdmin.Validate())
            {
                try
                {
                    var koordinat = await LocalStorage.GetItemAsStringAsync("Koordinat");
                    AdminLocation koordinatResult = JsonConvert.DeserializeObject<AdminLocation>(koordinat);
                    AdminLoginClass.browser = browserUser;
                    AdminLoginClass.longitude = koordinatResult.Longitude;
                    AdminLoginClass.latitude = koordinatResult.Latitude;
                    AdminLoginClass.remarks = koordinatResult.Remarks;
                    AdminLoginClass.ipAddress = "0";
                    token = await serviceAdminLogin.loginAdmin(AdminLoginClass);
                    await LocalStorage.SetItemAsync("token", token);
                    ((MyAuthenticationProvider)authenticationStateProvider).MarkUserAsAuthenticated(token);
                    navigationManager.NavigateTo("/loker");
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                }
            }
        }
    }
}
