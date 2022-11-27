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
    public partial class AddPatrocinadorPrivadoComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.Patrocinador _patrocinador;
        protected TrabalhoBd.Models.Trabalho.Patrocinador patrocinador
        {
            get
            {
                return _patrocinador;
            }
            set
            {
                if (!object.Equals(_patrocinador, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "patrocinador", NewValue = value, OldValue = _patrocinador };
                    _patrocinador = value;
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
            patrocinador = new TrabalhoBd.Models.Trabalho.Patrocinador(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Patrocinador args)
        {
            try
            {
                var trabalhoCreatePatrocinadorResult = await Trabalho.CreatePatrocinador(patrocinador);
                DialogService.Close(patrocinador);
            }
            catch (System.Exception trabalhoCreatePatrocinadorException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Patrocinador!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
