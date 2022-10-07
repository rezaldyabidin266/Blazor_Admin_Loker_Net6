using BlazorAdminLoker2022.Service;
using BlazorLoker2022.Resource.Admin.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Login
{
    public class AdminEditPasswordBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLogin? serviceAdminLogin { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }

        protected string? passwordLama;
        protected string? passwordBaru;
        protected string? passwordConfirm;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }

        protected override void OnInitialized()
        {

        }

        protected override async Task OnInitializedAsync()
        {

        }

        protected async Task ubahPassword()
        {
            if (passwordBaru == passwordConfirm)
            {
                try
                {
                    var ubahPw = new AdminUbahPassword
                    {
                        passwordLama = passwordLama,
                        passwordBaru = passwordBaru,
                    };
                    string msg = await serviceAdminLogin.ubahPassword(ubahPw);
                    await Js.InvokeVoidAsync("notifDev", msg, "success", 3000);
                }
                catch (Exception ex)
                {
                    await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                }
            }
            else
            {
                await Js.InvokeVoidAsync("notifDev", "Kata sandi unverifikasi", "error", 3000);
            }
        }
    }
}

