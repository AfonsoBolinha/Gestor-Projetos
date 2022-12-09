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
    public partial class MostrarProjetosComponent : ComponentBase
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
            var trabalhoGetProjetosResult = await Trabalho.GetProjetos();
            getProjetosResult = trabalhoGetProjetosResult;
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-editar-projeto");
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(TrabalhoBd.Models.Trabalho.Projeto args)
        {
            UriHelper.NavigateTo($"editar-projeto/{args.ID}");
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var trabalhoDeleteProjetoResult = await Trabalho.DeleteProjeto(data.ID);
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
