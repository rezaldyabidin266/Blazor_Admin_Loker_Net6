using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Resource.utility;
using BlazorAdminLoker2022.Service;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Laporan
{
    public class AdminCalonPelamarPageBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLaporan? serviceAdminLaporan { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }
        protected DxGrid Grid { get; set; }
        protected List<AdminCalonPelamar> calonPelamar = new List<AdminCalonPelamar>();
        protected bool ShowFilterRow { get; set; } = true;
        protected bool VisibleResponsive { get; set; } = true;
        protected GridDetailRowDisplayMode ShowMasterDetail { get; set; } = GridDetailRowDisplayMode.Never;
        protected int heightTable { get; set; } = 550;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }
        protected override void OnInitialized()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            await getBrowserDimensi();
            await getCalonPelamar();
        }

        protected async Task getBrowserDimensi()
        {
            var dimensi = await Js.InvokeAsync<BrowserDimensi>("getDimensions");
            if (dimensi.width < 576)
            {
                VisibleResponsive = false;
                heightTable = 300;
                ShowMasterDetail = GridDetailRowDisplayMode.Auto;
            }
            else
            {
                VisibleResponsive = true;
                heightTable = 550;
                ShowMasterDetail = GridDetailRowDisplayMode.Never; 
            }

            await InvokeAsync(StateHasChanged);
        }

        protected async Task getCalonPelamar()
        {
            try
            {
                calonPelamar = await serviceAdminLaporan.getCalonPelamar();              
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected Func<CancellationToken, Task<IEnumerable<AdminCalonPelamar>>> GetAsyncCalonPelamar(List<AdminCalonPelamar> args)
        {
            return returnValueApi;
            async Task<IEnumerable<AdminCalonPelamar>> returnValueApi(CancellationToken cancellationToken)
            {
                calonPelamar = await serviceAdminLaporan.getCalonPelamar();
                return calonPelamar;
            }
        }

        protected async void goHistory(int pelamarId)
        {
            navigationManager.NavigateTo($"/historyJawabanByPelamar/{pelamarId}");
        }
          
        protected void OnClick()
        {
            Grid.ShowColumnChooser(".column-chooser-button");
        }
    }
}
