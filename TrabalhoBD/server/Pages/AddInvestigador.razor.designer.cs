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
    public partial class AddInvestigadorComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.Investigador _investigador;
        protected TrabalhoBd.Models.Trabalho.Investigador investigador
        {
            get
            {
                return _investigador;
            }
            set
            {
                if (!object.Equals(_investigador, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "investigador", NewValue = value, OldValue = _investigador };
                    _investigador = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TrabalhoBd.Models.Trabalho.Instituicao> _getInstituicaosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Instituicao> getInstituicaosResult
        {
            get
            {
                return _getInstituicaosResult;
            }
            set
            {
                if (!object.Equals(_getInstituicaosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInstituicaosResult", NewValue = value, OldValue = _getInstituicaosResult };
                    _getInstituicaosResult = value;
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
            investigador = new TrabalhoBd.Models.Trabalho.Investigador(){};

            var trabalhoGetInstituicaosResult = await Trabalho.GetInstituicaos();
            getInstituicaosResult = trabalhoGetInstituicaosResult;

            UriHelper.NavigateTo("add-investigador");
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Investigador args)
        {
            try
            {
                var trabalhoCreateInvestigadorResult = await Trabalho.CreateInvestigador(investigador);
                DialogService.Close(investigador);
            }
            catch (System.Exception trabalhoCreateInvestigadorException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Investigador!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
