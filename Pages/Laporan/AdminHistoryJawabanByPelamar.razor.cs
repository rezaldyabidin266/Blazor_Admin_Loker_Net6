using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Resource.utility;
using BlazorAdminLoker2022.Service;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Laporan
{
    public class AdminHistoryJawabanByPelamarBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLaporan? serviceAdminLaporan { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }
        [Parameter]
        public int pelamarId { get; set; }
        protected List<AdminHistoryJawabanByPelamarClass> historyJawaban = new List<AdminHistoryJawabanByPelamarClass>();
        protected GridDetailRowDisplayMode ShowMasterDetail { get; set; } = GridDetailRowDisplayMode.Never;
        protected DxGrid Grid { get; set; }
        protected bool ShowFilterRow { get; set; } = true;
        protected bool VisibleResponsive { get; set; } = true;
        protected bool masterDetail { get; set; } = false;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }
        protected override void OnInitialized()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            await getBrowserDimensi();
            await getHistoryJawaban();
        }

        protected async Task getBrowserDimensi()
        {
            var dimensi = await Js.InvokeAsync<BrowserDimensi>("getDimensions");
            if (dimensi.width < 576)
            {
                VisibleResponsive = false;
                masterDetail = true;
                ShowMasterDetail = GridDetailRowDisplayMode.Auto;
            }
            else
            {
                VisibleResponsive = true;
                masterDetail = false;
                ShowMasterDetail = GridDetailRowDisplayMode.Never;
            }
            await InvokeAsync(StateHasChanged);
        }

        protected async Task getHistoryJawaban()
        {
            try
            {
                historyJawaban = await serviceAdminLaporan.getHistoryJawabanByPelamar(pelamarId);
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected Func<CancellationToken, Task<IEnumerable<AdminHistoryJawabanByPelamarClass>>> GetAsyncHistoryJawabanByPelamar(List<AdminHistoryJawabanByPelamarClass> args)
        {
            return returnValueApi;
            async Task<IEnumerable<AdminHistoryJawabanByPelamarClass>> returnValueApi(CancellationToken cancellationToken)
            {
                historyJawaban = await serviceAdminLaporan.getHistoryJawabanByPelamar(pelamarId);
                return historyJawaban;
            }
        }

        protected async void goDetailJawaban(AdminHistoryJawabanByPelamarClass adminCalonPelamar)
        {           
            navigationManager.NavigateTo($"/detailJawaban/{adminCalonPelamar.judulLowongan}/{adminCalonPelamar.headerJawabanId}");
        }

        protected void OnClick()
        {
            Grid.ShowColumnChooser(".column-chooser-button");
        }
    }
}
