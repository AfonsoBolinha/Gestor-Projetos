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
    public partial class AddContemComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.Contem _contem;
        protected TrabalhoBd.Models.Trabalho.Contem contem
        {
            get
            {
                return _contem;
            }
            set
            {
                if (!object.Equals(_contem, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "contem", NewValue = value, OldValue = _contem };
                    _contem = value;
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

        IEnumerable<TrabalhoBd.Models.Trabalho.InvestigadorInstituicao> _getInvestigadorInstituicaosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.InvestigadorInstituicao> getInvestigadorInstituicaosResult
        {
            get
            {
                return _getInvestigadorInstituicaosResult;
            }
            set
            {
                if (!object.Equals(_getInvestigadorInstituicaosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvestigadorInstituicaosResult", NewValue = value, OldValue = _getInvestigadorInstituicaosResult };
                    _getInvestigadorInstituicaosResult = value;
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
            contem = new TrabalhoBd.Models.Trabalho.Contem(){};

            var trabalhoGetProjetosResult = await Trabalho.GetProjetos();
            getProjetosResult = trabalhoGetProjetosResult;

            var trabalhoGetInvestigadorInstituicaosResult = await Trabalho.GetInvestigadorInstituicaos();
            getInvestigadorInstituicaosResult = trabalhoGetInvestigadorInstituicaosResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Contem args)
        {
            try
            {
                var trabalhoCreateContemResult = await Trabalho.CreateContem(contem);
                DialogService.Close(contem);
            }
            catch (System.Exception trabalhoCreateContemException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Contem!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
