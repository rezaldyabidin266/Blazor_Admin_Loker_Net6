using BlazorAdminLoker2022.Resource.Laporan;
using BlazorAdminLoker2022.Service;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Laporan
{
    public class AdminHistoryJawabanBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLaporan? serviceAdminLaporan { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }
        
        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }
        protected List<AdminAllHistoryJawaban> allHistoryJawaban = new List<AdminAllHistoryJawaban>();
        protected List<AdminHistoryJawabanByLokerClass> historyByLoker = new List<AdminHistoryJawabanByLokerClass>();
        protected List<AdminHistoryDetailJawaban> historyDetailjawaban = new List<AdminHistoryDetailJawaban>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }
        
        protected override void OnInitialized()
        {

        }
        
        protected override async Task OnInitializedAsync()
        {
            await getAllHistory();
        }
        
        protected async Task getAllHistory()
        {
            try
            {
                allHistoryJawaban = await serviceAdminLaporan.getAllHistoryJawaban();
                await Js.InvokeVoidAsync("console.log", allHistoryJawaban);
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }
        
    }
}
