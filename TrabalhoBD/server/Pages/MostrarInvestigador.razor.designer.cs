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
    public partial class MostrarInvestigadorComponent : ComponentBase
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
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.Investigador> grid0;

        IEnumerable<TrabalhoBd.Models.Trabalho.Investigador> _getInvestigadorsResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Investigador> getInvestigadorsResult
        {
            get
            {
                return _getInvestigadorsResult;
            }
            set
            {
                if (!object.Equals(_getInvestigadorsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvestigadorsResult", NewValue = value, OldValue = _getInvestigadorsResult };
                    _getInvestigadorsResult = value;
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
            var trabalhoGetInvestigadorsResult = await Trabalho.GetInvestigadors();
            getInvestigadorsResult = trabalhoGetInvestigadorsResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-investigador");
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(TrabalhoBd.Models.Trabalho.Investigador args)
        {
            UriHelper.NavigateTo($"edit-investigador/{args.ID}");
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var trabalhoDeleteInvestigadorResult = await Trabalho.DeleteInvestigador(data.ID);
                    if (trabalhoDeleteInvestigadorResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception trabalhoDeleteInvestigadorException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Investigador" });
            }
        }
    }
}
