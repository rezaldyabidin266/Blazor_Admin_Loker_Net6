using BlazorAdminLoker2022.Service;
using BlazorLoker2022.Resource.Admin.Login;
using Microsoft.AspNetCore.Components;

namespace BlazorAdminLoker2022.Pages
{
    public class IndexBase : ComponentBase
    {
        [Inject]
        protected ServiceAdminLogin? ServiceAdminTest { get; set; }

        protected List<AdminKalimatMotivasi> adminMotivasi = new List<AdminKalimatMotivasi>();
        protected override async Task OnInitializedAsync()
        {
            adminMotivasi = await ServiceAdminTest.adminMotivasi();
        }
    }
}
