using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using TrabalhoBd.Models.Trabalho;
using Microsoft.EntityFrameworkCore;

namespace TrabalhoBd.Pages
{
    public partial class InvestigadorStatusComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected TrabalhoService Trabalho { get; set; }
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.InvestigadorStatus> datagrid0;

        IEnumerable<TrabalhoBd.Models.Trabalho.InvestigadorStatus> _getInvestigadorStatusesResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.InvestigadorStatus> getInvestigadorStatusesResult
        {
            get
            {
                return _getInvestigadorStatusesResult;
            }
            set
            {
                if (!object.Equals(_getInvestigadorStatusesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvestigadorStatusesResult", NewValue = value, OldValue = _getInvestigadorStatusesResult };
                    _getInvestigadorStatusesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            var trabalhoGetInvestigadorStatusesResult = await Trabalho.GetInvestigadorStatuses();
            getInvestigadorStatusesResult = trabalhoGetInvestigadorStatusesResult;
        }
    }
}
