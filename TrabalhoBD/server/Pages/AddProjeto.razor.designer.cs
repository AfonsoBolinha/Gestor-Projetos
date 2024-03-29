﻿using System;
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
    public partial class AddProjetoComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.Projeto _projeto;
        protected TrabalhoBd.Models.Trabalho.Projeto projeto
        {
            get
            {
                return _projeto;
            }
            set
            {
                if (!object.Equals(_projeto, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "projeto", NewValue = value, OldValue = _projeto };
                    _projeto = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TrabalhoBd.Models.Trabalho.Uc> _getUcsResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Uc> getUcsResult
        {
            get
            {
                return _getUcsResult;
            }
            set
            {
                if (!object.Equals(_getUcsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getUcsResult", NewValue = value, OldValue = _getUcsResult };
                    _getUcsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<TrabalhoBd.Models.Trabalho.Investigador> _getInvestigadorsResult;
        protected IEnumerable<TrabalhoBd.Models.Trabalho.Investigador> getInvestigadorsResult
        {
            get
            {
                return _getInvestigadorsResult;
            }
            set
            {
                if (!object.Equals(_getInvestigadorsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getInvestigadorsResult", NewValue = value, OldValue = _getInvestigadorsResult };
                    _getInvestigadorsResult = value;
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
            projeto = new TrabalhoBd.Models.Trabalho.Projeto(){};

            var trabalhoGetUcsResult = await Trabalho.GetUcs();
            getUcsResult = trabalhoGetUcsResult;

            var trabalhoGetInvestigadorsResult = await Trabalho.GetInvestigadors();
            getInvestigadorsResult = trabalhoGetInvestigadorsResult;
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.Projeto args)
        {
            try
            {
                var trabalhoCreateProjetoResult = await Trabalho.CreateProjeto(projeto);
                DialogService.Close(projeto);
            }
            catch (System.Exception trabalhoCreateProjetoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new Projeto!" });
            }
        }

        protected async System.Threading.Tasks.Task Button1Click(MouseEventArgs args)
        {
            UriHelper.NavigateTo("add-contem");
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
