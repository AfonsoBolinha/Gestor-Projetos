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
    public partial class PesoPatrociniosComponent : ComponentBase
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

        IEnumerable<TrabalhoBd.Models.Trabalho.PesoPatrocinioPublico> _getPesoPatrocinioPublicosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.PesoPatrocinioPublico> getPesoPatrocinioPublicosResult
        {
            get
            {
                return _getPesoPatrocinioPublicosResult;
            }
            set
            {
                if (!object.Equals(_getPesoPatrocinioPublicosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPesoPatrocinioPublicosResult", NewValue = value, OldValue = _getPesoPatrocinioPublicosResult };
                    _getPesoPatrocinioPublicosResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TrabalhoBd.Models.Trabalho.PesoPatrocinioPrivado> _getPesoPatrocinioPrivadosResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.PesoPatrocinioPrivado> getPesoPatrocinioPrivadosResult
        {
            get
            {
                return _getPesoPatrocinioPrivadosResult;
            }
            set
            {
                if (!object.Equals(_getPesoPatrocinioPrivadosResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getPesoPatrocinioPrivadosResult", NewValue = value, OldValue = _getPesoPatrocinioPrivadosResult };
                    _getPesoPatrocinioPrivadosResult = value;
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
            var trabalhoGetPesoPatrocinioPublicosResult = await Trabalho.GetPesoPatrocinioPublicos();
            getPesoPatrocinioPublicosResult = trabalhoGetPesoPatrocinioPublicosResult;

            var trabalhoGetPesoPatrocinioPrivadosResult = await Trabalho.GetPesoPatrocinioPrivados();
            getPesoPatrocinioPrivadosResult = trabalhoGetPesoPatrocinioPrivadosResult;
        }
    }
}
