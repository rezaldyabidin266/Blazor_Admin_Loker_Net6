using BlazorAdminLoker2022.Resource.Loker;
using BlazorAdminLoker2022.Resource.utility;
using BlazorAdminLoker2022.Service;
using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;

namespace BlazorAdminLoker2022.Pages.Loker
{
    public class AdminLokerEditBase : ComponentBase
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

        protected string? token;        

        protected string? backgroundApi;
        protected string? ilustrasiApi;

        protected bool UploadVisible { get; set; } = false;
        protected string? apiUploadIlustrasi { get; set; }
        protected string? apiUploadBackground { get; set; }
        protected AdminIdLoker dataIdLoker = new AdminIdLoker();
        protected AdminUpdateLoker dataUpdateLoker = new AdminUpdateLoker();
        public EditContext? updateLokerContext { get; set; }
        protected string messageUpdateLoker;
        protected List<KriteriaDtos> kriteriaList = new List<KriteriaDtos>();
        protected bool popKriteria { get; set; } = false;
        protected BrowserDimensi dimensi = new BrowserDimensi();
        protected int memoRow;
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

        }

        protected override void OnInitialized()
        {
            updateLokerContext = new EditContext(dataIdLoker);
        }

        protected override async Task OnInitializedAsync()
        {
            token = await LocalStorage.GetItemAsync<string>("token");
            await GetGambarIlustrasi();
            await GetGambarIlustrasiBackground();
            await GetIdLoker();
            apiUploadIlustrasi = serviceAdminLoker.urlUploadIlustrasi();
            apiUploadBackground = serviceAdminLoker.urlUploadBackground();
            await getQuest();
            await getBrowserDimensi();
        }
        
        protected async Task getBrowserDimensi()
        {
            dimensi = await Js.InvokeAsync<BrowserDimensi>("getDimensions");
            if (dimensi.width < 576)
            {
                memoRow = 11;        
            }
            else
            {
                memoRow = 5;
            }

            await InvokeAsync(StateHasChanged);
        }

        protected async Task GetGambarIlustrasi()
        {

            try
            {
                byte[] byteImg = await serviceAdminLoker.GetGambarIlustrasi(idLoker);
                var base64 = Convert.ToBase64String(byteImg);
                ilustrasiApi = "data:image/png;base64," + base64;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                await Js.InvokeVoidAsync("console.log", ex.Message);
            }
        }

        protected async Task GetGambarIlustrasiBackground()
        {
            try
            {
                byte[] byteImg = await serviceAdminLoker.GetGambarBackground(idLoker);
                var base64 = Convert.ToBase64String(byteImg);
                backgroundApi = "data:image/png;base64," + base64;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }

        protected async Task GetIdLoker()
        {
            try
            {
                dataIdLoker = await serviceAdminLoker.GetIdLoker(idLoker);
                kriteriaList = dataIdLoker.kriteriaDtos;
            }
            catch (Exception ex)
            {
                await Js.InvokeVoidAsync("console.log", ex.Message);
                await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
            }
        }
        

        protected string GetUploadUrl(string url)
        {
            return navigationManager.ToAbsoluteUri(url).AbsoluteUri;
        }

        protected async void ErrorHandling(FileUploadErrorEventArgs e)
        {

            string errorMessage = e.RequestInfo.ResponseText;
            await Js.InvokeVoidAsync("notifDev", errorMessage, "error", 3000);
            await InvokeAsync(StateHasChanged);

        }

        protected async void SettingHeaderUpload(FileUploadStartEventArgs args)
        {

            args.RequestHeaders.Add("Authorization", $"Bearer {token}");
            args.RequestData.Add("Id", $"{idLoker}");
        }

        protected void SelectedFilesChangedAwal(IEnumerable<UploadFileInfo> files)
        {

            UploadVisible = files.ToList().Count > 0;
            InvokeAsync(StateHasChanged);

        }

        protected async void UploadSuksesIlustrasi(FileUploadEventArgs e)
        {
            
            var message = "File " + e.FileInfo.Name + " Berhasil Di Upload";
            await Js.InvokeVoidAsync("notifDev", message, "success", 3000);
           
            await GetGambarIlustrasi();
            await InvokeAsync(StateHasChanged);
        }

        protected async void UploadSuksesBackground(FileUploadEventArgs e)
        {

            var message = "File " + e.FileInfo.Name + " Berhasil Di Upload";
            await Js.InvokeVoidAsync("notifDev", message, "success", 3000);

            await GetGambarIlustrasiBackground();
            await InvokeAsync(StateHasChanged);
        }
        protected void CheckedChanged(bool value)
        {
            dataIdLoker.isOpen = value;
        }
        protected async Task btnUpdateLoker()
        {
            if (updateLokerContext.Validate())
            {
                try
                {
                    dataUpdateLoker.idLoker = dataIdLoker.idLoker;
                    dataUpdateLoker.judul = dataIdLoker.judul;
                    dataUpdateLoker.keterangan = dataIdLoker.keterangan;
                    dataUpdateLoker.isOpen = dataIdLoker.isOpen;
                    dataUpdateLoker.kriteriaDtos = kriteriaList;
                    string mess = await serviceAdminLoker.PutLoker(dataUpdateLoker);
                    await Js.InvokeVoidAsync("notifDev", "Update Berhasil", "success", 3000);

                }
                catch (Exception ex)
                {
                    messageUpdateLoker = ex.Message;
                    await Js.InvokeVoidAsync("notifDev", ex.Message, "error", 3000);
                }
            }
        }

        protected void addKriteriaList()
        {
            popKriteria = true;
        }
        protected async Task getQuest()
        {
            try
            {
                var data = await serviceAdminLoker.getQuestion(idLoker);

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


