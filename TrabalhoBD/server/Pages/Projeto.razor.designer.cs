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

namespace TrabalhoBd.Pages
{
    public partial class ProjetoComponent : ComponentBase
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
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.Projeto> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TrabalhoBd.Models.Trabalho.Projeto> _getProjetosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Projeto> getProjetosResult
        {
            get
            {
                return _getProjetosResult;
            }
            set
            {
                if (!object.Equals(_getProjetosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getProjetosResult", NewValue = value, OldValue = _getProjetosResult };
                    _getProjetosResult = value;
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
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }

            var trabalhoGetProjetosResult = await Trabalho.GetProjetos($"[object Object][object Object][object Object][object Object][object Object][object Object]", int.Parse($"{}"), int.Parse($"{}"));
            getProjetosResult = trabalhoGetProjetosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddProjeto>("Add Projeto", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Grid0RowDoubleClick(DataGridRowMouseEventArgs<TrabalhoBd.Models.Trabalho.Projeto> args)
        {
            var dialogResult = await DialogService.OpenAsync<EditProjeto>("Edit Projeto", new Dictionary<string, object>() { {"ID", args.Data.ID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var trabalhoDeleteProjetoResult = await Trabalho.DeleteProjeto(int.Parse($"{data.ID}"));
                    if (trabalhoDeleteProjetoResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception trabalhoDeleteProjetoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Projeto" });
            }
        }
    }
}
