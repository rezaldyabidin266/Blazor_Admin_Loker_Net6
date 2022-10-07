using BlazorAdminLoker2022.Service;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using BlazorAdminLoker2022.Resource.Loker;

namespace BlazorAdminLoker2022.Pages.Loker
{
    public class AdminQuestionBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLoker? serviceAdminLoker { get; set; }

        [Inject]
        protected NavigationManager navigationManager { get; set; }

        [Inject]
        protected IJSRuntime? Js { get; set; }

        [Inject]
        protected Blazored.LocalStorage.ILocalStorageService LocalStorage { get; set; }

        [Parameter]
        public int idLoker { get; set; }
        protected List<AdminQuestionClass> questions = new List<AdminQuestionClass>();
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }
        protected override void OnInitialized()
        {
          
        }
        protected override async Task OnInitializedAsync()
        {
            await getQuest();
        }

        protected async Task getQuest()
        {
            try
            {
                questions = await serviceAdminLoker.getQuestion(idLoker);
                await Js.InvokeVoidAsync("console.log", questions);
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
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
    }
}
