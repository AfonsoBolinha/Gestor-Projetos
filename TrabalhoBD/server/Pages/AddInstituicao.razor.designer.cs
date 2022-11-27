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
    public partial class AddInstituicaoComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.Instituicao _instituicao;
        protected TrabalhoBd.Models.Trabalho.Instituicao instituicao
        {
            get
            {
                return _instituicao;
            }
            set
            {
                if (!object.Equals(_instituicao, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "instituicao", NewValue = value, OldValue = _instituicao };
                    _instituicao = value;
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
            instituicao = new TrabalhoBd.Models.Trabalho.Instituicao(){};

            var trabalhoGetInstituicaosResult = await Trabalho.GetInstituicaos();
            getInstituicaosResult = trabalhoGetInstituicaosResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Instituicao args)
        {
            try
            {
                var trabalhoCreateInstituicaoResult = await Trabalho.CreateInstituicao(instituicao);
                DialogService.Close(instituicao);
            }
            catch (System.Exception trabalhoCreateInstituicaoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Instituicao!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
