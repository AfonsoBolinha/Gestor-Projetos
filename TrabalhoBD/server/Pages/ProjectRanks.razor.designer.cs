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
    public partial class ProjectRanksComponent : ComponentBase
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
        protected RadzenDataGrid<TrabalhoBd.Models.Trabalho.RatingProj> datagrid0;

        IEnumerable<TrabalhoBd.Models.Trabalho.RatingProj> _getRatingProjsResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.RatingProj> getRatingProjsResult
        {
            get
            {
                return _getRatingProjsResult;
            }
            set
            {
                if (!object.Equals(_getRatingProjsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRatingProjsResult", NewValue = value, OldValue = _getRatingProjsResult };
                    _getRatingProjsResult = value;
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
            var trabalhoGetRatingProjsResult = await Trabalho.GetRatingProjs();
            getRatingProjsResult = trabalhoGetRatingProjsResult;
        }
    }
}
