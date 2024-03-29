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
    public partial class AddPatrocinioPublicoComponent : ComponentBase
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

        TrabalhoBd.Models.Trabalho.PatrocinioPublico _patrociniopublico;
        protected TrabalhoBd.Models.Trabalho.PatrocinioPublico patrociniopublico
        {
            get
            {
                return _patrociniopublico;
            }
            set
            {
                if (!object.Equals(_patrociniopublico, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "patrociniopublico", NewValue = value, OldValue = _patrociniopublico };
                    _patrociniopublico = value;
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
            patrociniopublico = new TrabalhoBd.Models.Trabalho.PatrocinioPublico(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(TrabalhoBd.Models.Trabalho.PatrocinioPublico args)
        {
            try
            {
                var trabalhoCreatePatrocinioPublicoResult = await Trabalho.CreatePatrocinioPublico(patrociniopublico);
                DialogService.Close(patrociniopublico);
            }
            catch (System.Exception trabalhoCreatePatrocinioPublicoException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new PatrocinioPublico!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
