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
    public partial class EditInstituicaoComponent : ComponentBase
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

        [Parameter]
        public dynamic ID { get; set; }

        bool _hasChanges;
        protected bool hasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (!object.Equals(_hasChanges, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "hasChanges", NewValue = value, OldValue = _hasChanges };
                    _hasChanges = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (!object.Equals(_canEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "canEdit", NewValue = value, OldValue = _canEdit };
                    _canEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

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

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Load();
        }
        protected async System.Threading.Tasks.Task Load()
        {
            hasChanges = false;

            canEdit = true;

            var trabalhoGetInstituicaoByIdResult = await Trabalho.GetInstituicaoById(Convert.ChangeType(ID, Type.GetTypeCode(typeof(int))));
            instituicao = trabalhoGetInstituicaoByIdResult;
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            UriHelper.NavigateTo("mostrar-instituicao");
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            Trabalho.Reset();

            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Instituicao args)
        {
            try
            {
                var trabalhoUpdateInstituicaoResult = await Trabalho.UpdateInstituicao(Convert.ChangeType(ID, Type.GetTypeCode(typeof(int))), instituicao);
                if (trabalhoUpdateInstituicaoResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                UriHelper.NavigateTo("mostrar-instituicao");
                }
            }
            catch (System.Exception trabalhoUpdateInstituicaoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update Instituicao" });

            hasChanges = trabalhoUpdateInstituicaoException is DbUpdateConcurrencyException;

            if (!(trabalhoUpdateInstituicaoException is DbUpdateConcurrencyException)) {
                canEdit = false;
            }
            }
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("mostrar-instituicao");
        }
    }
}
