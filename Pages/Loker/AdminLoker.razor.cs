using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Resource.Loker;
using BlazorAdminLoker2022.Service;
using BlazorLoker2022.Resource.Admin.Login;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.IdentityModel.Tokens.Jwt;

namespace BlazorAdminLoker2022.Pages.Loker
{
    public class AdminLokerBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLoker? serviceAdminLoker { get; set; }
        [Inject]
        protected ServiceAdminLogin? serviceAdminLogin { get; set; }
        [Inject]
        protected ServiceAdminLaporan? serviceAdminLaporan { get; set; }


        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }

        protected List<AdminAllLoker> adminAllLoker = new List<AdminAllLoker>();
        protected string? backgroundApi;
        protected string? ilustrasiApi;
        protected Dictionary<int, string> imageIlustrasi = new Dictionary<int, string>();
        protected List<AdminKalimatMotivasi> listMotivasi = new List<AdminKalimatMotivasi>();
        protected string? kalimatMotivasi;
        protected string? gambarMotivasi;
        protected List<AdminCalonPelamar> calonPelamar = new List<AdminCalonPelamar>();
        protected string token;

        protected int ActivePageLoker = 1;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            
        }
        protected override void OnInitialized()
        {
      
        }
        protected override async Task OnInitializedAsync()
        {
            await GetAllLoker();
            await GetGambarIlustrasi();
            await GetGambarIlustrasiBackground();
            await GetListKalimatMotivasi();
            await GetGambarMotivasi();
            await getCalonPelamar();        
        }

        protected async Task decodeToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var namaUser = jwtSecurityToken.Claims.First(claim => claim.Type == "myDisplayUser").Value;
        }

        protected async Task GetAllLoker()
        {
            try
            {
                adminAllLoker = await serviceAdminLoker.GetAllLoker();
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                await Js.InvokeVoidAsync("console.log",ex.Message);
            }
        }

        protected async Task GetGambarIlustrasi()
        {       
            try
            {
                foreach (var item in adminAllLoker.OrderBy(x => x.idLoker))
                {
                    byte[] byteImg = await serviceAdminLoker.GetGambarIlustrasi(item.idLoker);
                    var base64 = Convert.ToBase64String(byteImg);
                    ilustrasiApi = "data:image/png;base64," + base64;
                    //baseImgList.Add(ilustrasiApi);
                    imageIlustrasi.Add(item.idLoker, ilustrasiApi);
                }
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task GetGambarIlustrasiBackground()
        {
            try
            {
                byte[] byteImg = await serviceAdminLoker.GetGambarBackground(3);
                var base64 = Convert.ToBase64String(byteImg);
                backgroundApi = "data:image/png;base64," + base64;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task GetListKalimatMotivasi()
        {
            try
            {
                try
                {
                    listMotivasi = await serviceAdminLogin.adminMotivasi();
                    var lastId = listMotivasi.LastOrDefault();
                    Random rnd = new Random();
                    int idRandom = rnd.Next(0,lastId.id);
                    foreach (var x in listMotivasi)
                    {
                        if (x.id == idRandom)
                        {
                            kalimatMotivasi = x.kalimat;
                        }
              
                    }
                }
                catch (Exception ex)
                {
                    await Js.InvokeVoidAsync("console.log", ex.Message);
                    await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                }
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task refreshMotivasi()
        {
            try
            {
                try
                {
                    listMotivasi = await serviceAdminLogin.adminMotivasi();
                    var lastId = listMotivasi.LastOrDefault();
                    Random rnd = new Random();
                    int idRandom = rnd.Next(0, lastId.id);
                    foreach (var x in listMotivasi)
                    {
                        if (x.id == idRandom)
                        {
                            kalimatMotivasi = x.kalimat;
                        }

                    }
                    byte[] fotoByte = await serviceAdminLogin.adminGambarMotivasi();
                    var foto = Convert.ToBase64String(fotoByte);
                    gambarMotivasi = "data:image/png;base64," + foto;
                }
                catch (Exception ex)
                {

                    await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                }
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task GetGambarMotivasi()
        {
            try
            {
                byte[] fotoByte = await serviceAdminLogin.adminGambarMotivasi();
                var foto = Convert.ToBase64String(fotoByte);
                gambarMotivasi = "data:image/png;base64," + foto;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task getCalonPelamar()
        {
            try
            {
                calonPelamar = await serviceAdminLaporan.getCalonPelamar();
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
            }
        }


        protected async Task goEdit(int idLoker)
        {
            navigationManager.NavigateTo($"/lokerEdit/{idLoker}");
        }
        protected async void shareLink(int idLoker)
        {
            var link = $"https://loker.esbrasilonline.com/lokerDetail/{idLoker}";
            var msg = await Js.InvokeAsync<string>("copyText",link);
            await Js.InvokeVoidAsync("notifDev", msg, "success", 3000);
        }
        protected void goWeb(int idLoker)
        {
            navigationManager.NavigateTo($"https://loker.esbrasilonline.com/lokerDetail/{idLoker}");
        }

    }
}
