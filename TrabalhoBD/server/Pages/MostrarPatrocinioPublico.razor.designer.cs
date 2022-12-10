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
    public partial class MostrarPatrocinioPublicoComponent : ComponentBase
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
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.PatrocinioPublico> grid0;

        IEnumerable<TrabalhoBd.Models.Trabalho.PatrocinioPublico> _getPatrocinioPublicosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.PatrocinioPublico> getPatrocinioPublicosResult
        {
            get
            {
                return _getPatrocinioPublicosResult;
            }
            set
            {
                if (!object.Equals(_getPatrocinioPublicosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPatrocinioPublicosResult", NewValue = value, OldValue = _getPatrocinioPublicosResult };
                    _getPatrocinioPublicosResult = value;
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
            var trabalhoGetPatrocinioPublicosResult = await Trabalho.GetPatrocinioPublicos();
            getPatrocinioPublicosResult = trabalhoGetPatrocinioPublicosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-patrocinio-publico");
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(TrabalhoBd.Models.Trabalho.PatrocinioPublico args)
        {
            UriHelper.NavigateTo($"edit-patrocinio-publico/{args.ID}");
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var trabalhoDeletePatrocinioPublicoResult = await Trabalho.DeletePatrocinioPublico(data.ID);
                    if (trabalhoDeletePatrocinioPublicoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception trabalhoDeletePatrocinioPublicoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete PatrocinioPublico" });
            }
        }
    }
}
