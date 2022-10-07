using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Resource.utility;
using BlazorAdminLoker2022.Service;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Laporan
{
    public class AdminHistoryJawabanByLokerBase : ComponentBase
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
        public int idLoker { get; set; }
        protected List<AdminHistoryJawabanByLokerClass> historyJawaban = new List<AdminHistoryJawabanByLokerClass>();
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
                historyJawaban = await serviceAdminLaporan.getHistoryJawabanByLoker(idLoker);
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }


        protected Func<CancellationToken, Task<IEnumerable<AdminHistoryJawabanByLokerClass>>> GetAsyncHistoryJawabanByLoker(List<AdminHistoryJawabanByLokerClass> args)
        {
            return returnValueApi;
            async Task<IEnumerable<AdminHistoryJawabanByLokerClass>> returnValueApi(CancellationToken cancellationToken)
            {
                historyJawaban = await serviceAdminLaporan.getHistoryJawabanByLoker(idLoker);
                return historyJawaban;
            }
        }

        protected async void goDetailJawaban(AdminHistoryJawabanByLokerClass historyByLoker)
        {
            navigationManager.NavigateTo($"/detailJawaban/{historyByLoker.judulLowongan}/{historyByLoker.headerJawabanId}");
        }
        protected void goQuest()
        {
            navigationManager.NavigateTo($"adminQuestion/{idLoker}");
        }
        protected void goLokerEdit()
        {
            navigationManager.NavigateTo($"lokerEdit/{idLoker}");
        }
        protected void goHistory()
        {
            navigationManager.NavigateTo($"historyJawabanByLoker/{idLoker}");
        }
        protected void OnClick()
        {
            Grid.ShowColumnChooser(".column-chooser-button");
        }

    }
}
