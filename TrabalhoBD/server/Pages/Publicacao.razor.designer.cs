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
    public partial class PublicacaoComponent : ComponentBase
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
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.Publicacao> grid0;

        IEnumerable<TrabalhoBd.Models.Trabalho.Publicacao> _getPublicacaosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Publicacao> getPublicacaosResult
        {
            get
            {
                return _getPublicacaosResult;
            }
            set
            {
                if (!object.Equals(_getPublicacaosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPublicacaosResult", NewValue = value, OldValue = _getPublicacaosResult };
                    _getPublicacaosResult = value;
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
            var trabalhoGetPublicacaosResult = await Trabalho.GetPublicacaos(int.Parse($"{}"), int.Parse($"{}"));
            getPublicacaosResult = trabalhoGetPublicacaosResult;
        }
    }
}
