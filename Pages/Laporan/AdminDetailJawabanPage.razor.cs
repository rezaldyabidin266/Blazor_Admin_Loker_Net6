using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Laporan
{
    public class AdminDetailJawabanPageBase: ComponentBase
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
        public int headerJawabanId { get; set; }
        [Parameter]
        public string loker { get; set; }
        
        protected AdminHistoryDetailJawaban detailJawaban = new AdminHistoryDetailJawaban();
        protected List<RespondJawaban> responJawaban = new List<RespondJawaban>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }
        protected override void OnInitialized()
        {

        }
        protected override async Task OnInitializedAsync()
        {
            await getDetailJawaban();
        }
        protected async Task getDetailJawaban()
        {
            try
            {
                detailJawaban = await serviceAdminLaporan.getHistoryDetailJawaban(headerJawabanId);
                responJawaban = detailJawaban.respondJawaban;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }
    }
}
