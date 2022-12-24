using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using TrabalhoBd.Data;

namespace TrabalhoBd
{
    public partial class TrabalhoService
    {
        TrabalhoContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly TrabalhoContext context;
        private readonly NavigationManager navigationManager;

        public TrabalhoService(TrabalhoContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);

        public async Task ExportAreaCientificasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/areacientificas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/areacientificas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAreaCientificasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/areacientificas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/areacientificas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAreaCientificasRead(ref IQueryable<Models.Trabalho.AreaCientifica> items);

        public async Task<IQueryable<Models.Trabalho.AreaCientifica>> GetAreaCientificas(Query query = null)
        {
            var items = Context.AreaCientificas.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAreaCientificasRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportContemsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/contems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/contems/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportContemsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/contems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/contems/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnContemsRead(ref IQueryable<Models.Trabalho.Contem> items);

        public async Task<IQueryable<Models.Trabalho.Contem>> GetContems(Query query = null)
        {
            var items = Context.Contems.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnContemsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnContemCreated(Models.Trabalho.Contem item);
        partial void OnAfterContemCreated(Models.Trabalho.Contem item);

        public async Task<Models.Trabalho.Contem> CreateContem(Models.Trabalho.Contem contem)
        {
            OnContemCreated(contem);

            var existingItem = Context.Contems
                              .Where(i => i.ID == contem.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Contems.Add(contem);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(contem).State = EntityState.Detached;
                throw;
            }

            OnAfterContemCreated(contem);

            return contem;
        }
        public async Task ExportInstituicaosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/instituicaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/instituicaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInstituicaosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/instituicaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/instituicaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInstituicaosRead(ref IQueryable<Models.Trabalho.Instituicao> items);

        public async Task<IQueryable<Models.Trabalho.Instituicao>> GetInstituicaos(Query query = null)
        {
            var items = Context.Instituicaos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInstituicaosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInstituicaoCreated(Models.Trabalho.Instituicao item);
        partial void OnAfterInstituicaoCreated(Models.Trabalho.Instituicao item);

        public async Task<Models.Trabalho.Instituicao> CreateInstituicao(Models.Trabalho.Instituicao instituicao)
        {
            OnInstituicaoCreated(instituicao);

            var existingItem = Context.Instituicaos
                              .Where(i => i.ID == instituicao.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Instituicaos.Add(instituicao);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(instituicao).State = EntityState.Detached;
                throw;
            }

            OnAfterInstituicaoCreated(instituicao);

            return instituicao;
        }
        public async Task ExportInvestigadorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvestigadorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvestigadorsRead(ref IQueryable<Models.Trabalho.Investigador> items);

        public async Task<IQueryable<Models.Trabalho.Investigador>> GetInvestigadors(Query query = null)
        {
            var items = Context.Investigadors.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvestigadorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvestigadorCreated(Models.Trabalho.Investigador item);
        partial void OnAfterInvestigadorCreated(Models.Trabalho.Investigador item);

        public async Task<Models.Trabalho.Investigador> CreateInvestigador(Models.Trabalho.Investigador investigador)
        {
            OnInvestigadorCreated(investigador);

            var existingItem = Context.Investigadors
                              .Where(i => i.ID == investigador.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Investigadors.Add(investigador);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(investigador).State = EntityState.Detached;
                throw;
            }

            OnAfterInvestigadorCreated(investigador);

            return investigador;
        }
        public async Task ExportInvestigadorInstituicaosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorinstituicaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorinstituicaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvestigadorInstituicaosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorinstituicaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorinstituicaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvestigadorInstituicaosRead(ref IQueryable<Models.Trabalho.InvestigadorInstituicao> items);

        public async Task<IQueryable<Models.Trabalho.InvestigadorInstituicao>> GetInvestigadorInstituicaos(Query query = null)
        {
            var items = Context.InvestigadorInstituicaos.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvestigadorInstituicaosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInvestigadorProjetosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorprojetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorprojetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvestigadorProjetosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorprojetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorprojetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvestigadorProjetosRead(ref IQueryable<Models.Trabalho.InvestigadorProjeto> items);

        public async Task<IQueryable<Models.Trabalho.InvestigadorProjeto>> GetInvestigadorProjetos(Query query = null)
        {
            var items = Context.InvestigadorProjetos.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvestigadorProjetosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportInvestigadorStatusesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorstatuses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvestigadorStatusesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/investigadorstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/investigadorstatuses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvestigadorStatusesRead(ref IQueryable<Models.Trabalho.InvestigadorStatus> items);

        public async Task<IQueryable<Models.Trabalho.InvestigadorStatus>> GetInvestigadorStatuses(Query query = null)
        {
            var items = Context.InvestigadorStatuses.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvestigadorStatusesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportKeyWordsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/keywords/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/keywords/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportKeyWordsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/keywords/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/keywords/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnKeyWordsRead(ref IQueryable<Models.Trabalho.KeyWord> items);

        public async Task<IQueryable<Models.Trabalho.KeyWord>> GetKeyWords(Query query = null)
        {
            var items = Context.KeyWords.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnKeyWordsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPatrocinaProgramasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinaprogramas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinaprogramas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrocinaProgramasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinaprogramas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinaprogramas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrocinaProgramasRead(ref IQueryable<Models.Trabalho.PatrocinaPrograma> items);

        public async Task<IQueryable<Models.Trabalho.PatrocinaPrograma>> GetPatrocinaProgramas(Query query = null)
        {
            var items = Context.PatrocinaProgramas.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrocinaProgramasRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPatrocinadorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinadors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinadors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrocinadorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinadors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinadors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrocinadorsRead(ref IQueryable<Models.Trabalho.Patrocinador> items);

        public async Task<IQueryable<Models.Trabalho.Patrocinador>> GetPatrocinadors(Query query = null)
        {
            var items = Context.Patrocinadors.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrocinadorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPatrocinadorCreated(Models.Trabalho.Patrocinador item);
        partial void OnAfterPatrocinadorCreated(Models.Trabalho.Patrocinador item);

        public async Task<Models.Trabalho.Patrocinador> CreatePatrocinador(Models.Trabalho.Patrocinador patrocinador)
        {
            OnPatrocinadorCreated(patrocinador);

            var existingItem = Context.Patrocinadors
                              .Where(i => i.ID == patrocinador.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Patrocinadors.Add(patrocinador);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(patrocinador).State = EntityState.Detached;
                throw;
            }

            OnAfterPatrocinadorCreated(patrocinador);

            return patrocinador;
        }
        public async Task ExportPatrocinadorPrivadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinadorprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinadorprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrocinadorPrivadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrocinadorprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrocinadorprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrocinadorPrivadosRead(ref IQueryable<Models.Trabalho.PatrocinadorPrivado> items);

        public async Task<IQueryable<Models.Trabalho.PatrocinadorPrivado>> GetPatrocinadorPrivados(Query query = null)
        {
            var items = Context.PatrocinadorPrivados.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrocinadorPrivadosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPatrocinioPublicosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniopublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniopublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrocinioPublicosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniopublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniopublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrocinioPublicosRead(ref IQueryable<Models.Trabalho.PatrocinioPublico> items);

        public async Task<IQueryable<Models.Trabalho.PatrocinioPublico>> GetPatrocinioPublicos(Query query = null)
        {
            var items = Context.PatrocinioPublicos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrocinioPublicosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPatrocinioPublicoCreated(Models.Trabalho.PatrocinioPublico item);
        partial void OnAfterPatrocinioPublicoCreated(Models.Trabalho.PatrocinioPublico item);

        public async Task<Models.Trabalho.PatrocinioPublico> CreatePatrocinioPublico(Models.Trabalho.PatrocinioPublico patrocinioPublico)
        {
            OnPatrocinioPublicoCreated(patrocinioPublico);

            var existingItem = Context.PatrocinioPublicos
                              .Where(i => i.ID == patrocinioPublico.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PatrocinioPublicos.Add(patrocinioPublico);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(patrocinioPublico).State = EntityState.Detached;
                throw;
            }

            OnAfterPatrocinioPublicoCreated(patrocinioPublico);

            return patrocinioPublico;
        }
        public async Task ExportPatrociniosPrivadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniosprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniosprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrociniosPrivadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniosprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniosprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrociniosPrivadosRead(ref IQueryable<Models.Trabalho.PatrociniosPrivado> items);

        public async Task<IQueryable<Models.Trabalho.PatrociniosPrivado>> GetPatrociniosPrivados(Query query = null)
        {
            var items = Context.PatrociniosPrivados.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrociniosPrivadosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPatrociniosPublicosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniospublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniospublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPatrociniosPublicosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/patrociniospublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/patrociniospublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPatrociniosPublicosRead(ref IQueryable<Models.Trabalho.PatrociniosPublico> items);

        public async Task<IQueryable<Models.Trabalho.PatrociniosPublico>> GetPatrociniosPublicos(Query query = null)
        {
            var items = Context.PatrociniosPublicos.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPatrociniosPublicosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPertence1SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pertence1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pertence1s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPertence1SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pertence1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pertence1s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPertence1sRead(ref IQueryable<Models.Trabalho.Pertence1> items);

        public async Task<IQueryable<Models.Trabalho.Pertence1>> GetPertence1S(Query query = null)
        {
            var items = Context.Pertence1s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPertence1sRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPertence2SToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pertence2s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pertence2s/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPertence2SToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pertence2s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pertence2s/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPertence2sRead(ref IQueryable<Models.Trabalho.Pertence2> items);

        public async Task<IQueryable<Models.Trabalho.Pertence2>> GetPertence2S(Query query = null)
        {
            var items = Context.Pertence2s.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPertence2sRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPesoPatrocinioPrivadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pesopatrocinioprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pesopatrocinioprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPesoPatrocinioPrivadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pesopatrocinioprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pesopatrocinioprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPesoPatrocinioPrivadosRead(ref IQueryable<Models.Trabalho.PesoPatrocinioPrivado> items);

        public async Task<IQueryable<Models.Trabalho.PesoPatrocinioPrivado>> GetPesoPatrocinioPrivados(Query query = null)
        {
            var items = Context.PesoPatrocinioPrivados.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPesoPatrocinioPrivadosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPesoPatrocinioPublicosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pesopatrociniopublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pesopatrociniopublicos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPesoPatrocinioPublicosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/pesopatrociniopublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/pesopatrociniopublicos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPesoPatrocinioPublicosRead(ref IQueryable<Models.Trabalho.PesoPatrocinioPublico> items);

        public async Task<IQueryable<Models.Trabalho.PesoPatrocinioPublico>> GetPesoPatrocinioPublicos(Query query = null)
        {
            var items = Context.PesoPatrocinioPublicos.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPesoPatrocinioPublicosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportProjectStatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projectstates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projectstates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjectStatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projectstates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projectstates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjectStatesRead(ref IQueryable<Models.Trabalho.ProjectState> items);

        public async Task<IQueryable<Models.Trabalho.ProjectState>> GetProjectStates(Query query = null)
        {
            var items = Context.ProjectStates.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProjectStatesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportProjetosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjetosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjetosRead(ref IQueryable<Models.Trabalho.Projeto> items);

        public async Task<IQueryable<Models.Trabalho.Projeto>> GetProjetos(Query query = null)
        {
            var items = Context.Projetos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProjetosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnProjetoCreated(Models.Trabalho.Projeto item);
        partial void OnAfterProjetoCreated(Models.Trabalho.Projeto item);

        public async Task<Models.Trabalho.Projeto> CreateProjeto(Models.Trabalho.Projeto projeto)
        {
            OnProjetoCreated(projeto);

            var existingItem = Context.Projetos
                              .Where(i => i.ID == projeto.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Projetos.Add(projeto);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(projeto).State = EntityState.Detached;
                throw;
            }

            OnAfterProjetoCreated(projeto);

            return projeto;
        }
        public async Task ExportProjetoPatrocinioPrivadosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetopatrocinioprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetopatrocinioprivados/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjetoPatrocinioPrivadosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetopatrocinioprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetopatrocinioprivados/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjetoPatrocinioPrivadosRead(ref IQueryable<Models.Trabalho.ProjetoPatrocinioPrivado> items);

        public async Task<IQueryable<Models.Trabalho.ProjetoPatrocinioPrivado>> GetProjetoPatrocinioPrivados(Query query = null)
        {
            var items = Context.ProjetoPatrocinioPrivados.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProjetoPatrocinioPrivadosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportProjetoPatrocinioProgramasToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetopatrocinioprogramas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetopatrocinioprogramas/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportProjetoPatrocinioProgramasToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/projetopatrocinioprogramas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/projetopatrocinioprogramas/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnProjetoPatrocinioProgramasRead(ref IQueryable<Models.Trabalho.ProjetoPatrocinioPrograma> items);

        public async Task<IQueryable<Models.Trabalho.ProjetoPatrocinioPrograma>> GetProjetoPatrocinioProgramas(Query query = null)
        {
            var items = Context.ProjetoPatrocinioProgramas.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnProjetoPatrocinioProgramasRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPublicacaosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/publicacaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/publicacaos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPublicacaosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/publicacaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/publicacaos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPublicacaosRead(ref IQueryable<Models.Trabalho.Publicacao> items);

        public async Task<IQueryable<Models.Trabalho.Publicacao>> GetPublicacaos(Query query = null)
        {
            var items = Context.Publicacaos.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPublicacaosRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPublicacaoCreated(Models.Trabalho.Publicacao item);
        partial void OnAfterPublicacaoCreated(Models.Trabalho.Publicacao item);

        public async Task<Models.Trabalho.Publicacao> CreatePublicacao(Models.Trabalho.Publicacao publicacao)
        {
            OnPublicacaoCreated(publicacao);

            var existingItem = Context.Publicacaos
                              .Where(i => i.ID == publicacao.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Publicacaos.Add(publicacao);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(publicacao).State = EntityState.Detached;
                throw;
            }

            OnAfterPublicacaoCreated(publicacao);

            return publicacao;
        }
        public async Task ExportPublicacaoProjetosToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/publicacaoprojetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/publicacaoprojetos/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPublicacaoProjetosToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/publicacaoprojetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/publicacaoprojetos/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPublicacaoProjetosRead(ref IQueryable<Models.Trabalho.PublicacaoProjeto> items);

        public async Task<IQueryable<Models.Trabalho.PublicacaoProjeto>> GetPublicacaoProjetos(Query query = null)
        {
            var items = Context.PublicacaoProjetos.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPublicacaoProjetosRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportRatingProjsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ratingprojs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ratingprojs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRatingProjsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ratingprojs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ratingprojs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRatingProjsRead(ref IQueryable<Models.Trabalho.RatingProj> items);

        public async Task<IQueryable<Models.Trabalho.RatingProj>> GetRatingProjs(Query query = null)
        {
            var items = Context.RatingProjs.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRatingProjsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportResponsavelsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/responsavels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/responsavels/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportResponsavelsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/responsavels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/responsavels/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnResponsavelsRead(ref IQueryable<Models.Trabalho.Responsavel> items);

        public async Task<IQueryable<Models.Trabalho.Responsavel>> GetResponsavels(Query query = null)
        {
            var items = Context.Responsavels.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnResponsavelsRead(ref items);

            return await Task.FromResult(items);
        }
      public async Task<int> SpAlterdiagrams(string diagramname, int? owner_id, int? version, string definition)
      {
          OnSpAlterdiagramsDefaultParams(ref diagramname, ref owner_id, ref version, ref definition);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
              new SqlParameter("@version", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = version},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_alterdiagram] @diagramname, @owner_id, @version, @definition", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpAlterdiagramsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpAlterdiagramsDefaultParams(ref string diagramname, ref int? owner_id, ref int? version, ref string definition);
      partial void OnSpAlterdiagramsInvoke(ref int result);
      public async Task<int> SpCreatediagrams(string diagramname, int? owner_id, int? version, string definition)
      {
          OnSpCreatediagramsDefaultParams(ref diagramname, ref owner_id, ref version, ref definition);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
              new SqlParameter("@version", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = version},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_creatediagram] @diagramname, @owner_id, @version, @definition", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpCreatediagramsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpCreatediagramsDefaultParams(ref string diagramname, ref int? owner_id, ref int? version, ref string definition);
      partial void OnSpCreatediagramsInvoke(ref int result);
      public async Task<int> SpDropdiagrams(string diagramname, int? owner_id)
      {
          OnSpDropdiagramsDefaultParams(ref diagramname, ref owner_id);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_dropdiagram] @diagramname, @owner_id", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpDropdiagramsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpDropdiagramsDefaultParams(ref string diagramname, ref int? owner_id);
      partial void OnSpDropdiagramsInvoke(ref int result);
      public async Task<int> SpHelpdiagrams(string diagramname, int? owner_id)
      {
          OnSpHelpdiagramsDefaultParams(ref diagramname, ref owner_id);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_helpdiagrams] @diagramname, @owner_id", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpHelpdiagramsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpHelpdiagramsDefaultParams(ref string diagramname, ref int? owner_id);
      partial void OnSpHelpdiagramsInvoke(ref int result);
      public async Task<int> SpHelpdiagramdefinitions(string diagramname, int? owner_id)
      {
          OnSpHelpdiagramdefinitionsDefaultParams(ref diagramname, ref owner_id);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_helpdiagramdefinition] @diagramname, @owner_id", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpHelpdiagramdefinitionsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpHelpdiagramdefinitionsDefaultParams(ref string diagramname, ref int? owner_id);
      partial void OnSpHelpdiagramdefinitionsInvoke(ref int result);
      public async Task<int> SpRenamediagrams(string diagramname, int? owner_id, string new_diagramname)
      {
          OnSpRenamediagramsDefaultParams(ref diagramname, ref owner_id, ref new_diagramname);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = diagramname},
              new SqlParameter("@owner_id", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = owner_id},
              new SqlParameter("@new_diagramname", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = new_diagramname},
          };

          foreach(var _p in @params)
          {
              if(_p.Direction == ParameterDirection.Input && _p.Value == null)
              {
                  _p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_renamediagram] @diagramname, @owner_id, @new_diagramname", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpRenamediagramsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpRenamediagramsDefaultParams(ref string diagramname, ref int? owner_id, ref string new_diagramname);
      partial void OnSpRenamediagramsInvoke(ref int result);
        public async Task ExportUcsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ucs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ucs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUcsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ucs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ucs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUcsRead(ref IQueryable<Models.Trabalho.Uc> items);

        public async Task<IQueryable<Models.Trabalho.Uc>> GetUcs(Query query = null)
        {
            var items = Context.Ucs.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUcsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportUcRanksToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ucranks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ucranks/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUcRanksToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/ucranks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/ucranks/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUcRanksRead(ref IQueryable<Models.Trabalho.UcRank> items);

        public async Task<IQueryable<Models.Trabalho.UcRank>> GetUcRanks(Query query = null)
        {
            var items = Context.UcRanks.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUcRanksRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportUnidadeCurricularsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/unidadecurriculars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/unidadecurriculars/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUnidadeCurricularsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/trabalho/unidadecurriculars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/trabalho/unidadecurriculars/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUnidadeCurricularsRead(ref IQueryable<Models.Trabalho.UnidadeCurricular> items);

        public async Task<IQueryable<Models.Trabalho.UnidadeCurricular>> GetUnidadeCurriculars(Query query = null)
        {
            var items = Context.UnidadeCurriculars.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p.Trim());
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUnidadeCurricularsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnUnidadeCurricularCreated(Models.Trabalho.UnidadeCurricular item);
        partial void OnAfterUnidadeCurricularCreated(Models.Trabalho.UnidadeCurricular item);

        public async Task<Models.Trabalho.UnidadeCurricular> CreateUnidadeCurricular(Models.Trabalho.UnidadeCurricular unidadeCurricular)
        {
            OnUnidadeCurricularCreated(unidadeCurricular);

            var existingItem = Context.UnidadeCurriculars
                              .Where(i => i.ID == unidadeCurricular.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.UnidadeCurriculars.Add(unidadeCurricular);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(unidadeCurricular).State = EntityState.Detached;
                throw;
            }

            OnAfterUnidadeCurricularCreated(unidadeCurricular);

            return unidadeCurricular;
        }

        partial void OnContemDeleted(Models.Trabalho.Contem item);
        partial void OnAfterContemDeleted(Models.Trabalho.Contem item);

        public async Task<Models.Trabalho.Contem> DeleteContem(int? id)
        {
            var itemToDelete = Context.Contems
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnContemDeleted(itemToDelete);

            Context.Contems.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterContemDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnContemGet(Models.Trabalho.Contem item);

        public async Task<Models.Trabalho.Contem> GetContemById(int? id)
        {
            var items = Context.Contems
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnContemGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Contem> CancelContemChanges(Models.Trabalho.Contem item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnContemUpdated(Models.Trabalho.Contem item);
        partial void OnAfterContemUpdated(Models.Trabalho.Contem item);

        public async Task<Models.Trabalho.Contem> UpdateContem(int? id, Models.Trabalho.Contem contem)
        {
            OnContemUpdated(contem);

            var itemToUpdate = Context.Contems
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(contem);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterContemUpdated(contem);

            return contem;
        }

        partial void OnInstituicaoDeleted(Models.Trabalho.Instituicao item);
        partial void OnAfterInstituicaoDeleted(Models.Trabalho.Instituicao item);

        public async Task<Models.Trabalho.Instituicao> DeleteInstituicao(int? id)
        {
            var itemToDelete = Context.Instituicaos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInstituicaoDeleted(itemToDelete);

            Context.Instituicaos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInstituicaoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInstituicaoGet(Models.Trabalho.Instituicao item);

        public async Task<Models.Trabalho.Instituicao> GetInstituicaoById(int? id)
        {
            var items = Context.Instituicaos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnInstituicaoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Instituicao> CancelInstituicaoChanges(Models.Trabalho.Instituicao item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInstituicaoUpdated(Models.Trabalho.Instituicao item);
        partial void OnAfterInstituicaoUpdated(Models.Trabalho.Instituicao item);

        public async Task<Models.Trabalho.Instituicao> UpdateInstituicao(int? id, Models.Trabalho.Instituicao instituicao)
        {
            OnInstituicaoUpdated(instituicao);

            var itemToUpdate = Context.Instituicaos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(instituicao);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInstituicaoUpdated(instituicao);

            return instituicao;
        }

        partial void OnInvestigadorDeleted(Models.Trabalho.Investigador item);
        partial void OnAfterInvestigadorDeleted(Models.Trabalho.Investigador item);

        public async Task<Models.Trabalho.Investigador> DeleteInvestigador(int? id)
        {
            var itemToDelete = Context.Investigadors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInvestigadorDeleted(itemToDelete);

            Context.Investigadors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvestigadorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInvestigadorGet(Models.Trabalho.Investigador item);

        public async Task<Models.Trabalho.Investigador> GetInvestigadorById(int? id)
        {
            var items = Context.Investigadors
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnInvestigadorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Investigador> CancelInvestigadorChanges(Models.Trabalho.Investigador item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvestigadorUpdated(Models.Trabalho.Investigador item);
        partial void OnAfterInvestigadorUpdated(Models.Trabalho.Investigador item);

        public async Task<Models.Trabalho.Investigador> UpdateInvestigador(int? id, Models.Trabalho.Investigador investigador)
        {
            OnInvestigadorUpdated(investigador);

            var itemToUpdate = Context.Investigadors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(investigador);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInvestigadorUpdated(investigador);

            return investigador;
        }

        partial void OnPatrocinadorDeleted(Models.Trabalho.Patrocinador item);
        partial void OnAfterPatrocinadorDeleted(Models.Trabalho.Patrocinador item);

        public async Task<Models.Trabalho.Patrocinador> DeletePatrocinador(int? id)
        {
            var itemToDelete = Context.Patrocinadors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPatrocinadorDeleted(itemToDelete);

            Context.Patrocinadors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPatrocinadorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPatrocinadorGet(Models.Trabalho.Patrocinador item);

        public async Task<Models.Trabalho.Patrocinador> GetPatrocinadorById(int? id)
        {
            var items = Context.Patrocinadors
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnPatrocinadorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Patrocinador> CancelPatrocinadorChanges(Models.Trabalho.Patrocinador item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPatrocinadorUpdated(Models.Trabalho.Patrocinador item);
        partial void OnAfterPatrocinadorUpdated(Models.Trabalho.Patrocinador item);

        public async Task<Models.Trabalho.Patrocinador> UpdatePatrocinador(int? id, Models.Trabalho.Patrocinador patrocinador)
        {
            OnPatrocinadorUpdated(patrocinador);

            var itemToUpdate = Context.Patrocinadors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(patrocinador);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterPatrocinadorUpdated(patrocinador);

            return patrocinador;
        }

        partial void OnPatrocinioPublicoDeleted(Models.Trabalho.PatrocinioPublico item);
        partial void OnAfterPatrocinioPublicoDeleted(Models.Trabalho.PatrocinioPublico item);

        public async Task<Models.Trabalho.PatrocinioPublico> DeletePatrocinioPublico(int? id)
        {
            var itemToDelete = Context.PatrocinioPublicos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPatrocinioPublicoDeleted(itemToDelete);

            Context.PatrocinioPublicos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPatrocinioPublicoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPatrocinioPublicoGet(Models.Trabalho.PatrocinioPublico item);

        public async Task<Models.Trabalho.PatrocinioPublico> GetPatrocinioPublicoById(int? id)
        {
            var items = Context.PatrocinioPublicos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnPatrocinioPublicoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.PatrocinioPublico> CancelPatrocinioPublicoChanges(Models.Trabalho.PatrocinioPublico item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPatrocinioPublicoUpdated(Models.Trabalho.PatrocinioPublico item);
        partial void OnAfterPatrocinioPublicoUpdated(Models.Trabalho.PatrocinioPublico item);

        public async Task<Models.Trabalho.PatrocinioPublico> UpdatePatrocinioPublico(int? id, Models.Trabalho.PatrocinioPublico patrocinioPublico)
        {
            OnPatrocinioPublicoUpdated(patrocinioPublico);

            var itemToUpdate = Context.PatrocinioPublicos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(patrocinioPublico);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterPatrocinioPublicoUpdated(patrocinioPublico);

            return patrocinioPublico;
        }

        partial void OnProjetoDeleted(Models.Trabalho.Projeto item);
        partial void OnAfterProjetoDeleted(Models.Trabalho.Projeto item);

        public async Task<Models.Trabalho.Projeto> DeleteProjeto(int? id)
        {
            var itemToDelete = Context.Projetos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnProjetoDeleted(itemToDelete);

            Context.Projetos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterProjetoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnProjetoGet(Models.Trabalho.Projeto item);

        public async Task<Models.Trabalho.Projeto> GetProjetoById(int? id)
        {
            var items = Context.Projetos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnProjetoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Projeto> CancelProjetoChanges(Models.Trabalho.Projeto item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnProjetoUpdated(Models.Trabalho.Projeto item);
        partial void OnAfterProjetoUpdated(Models.Trabalho.Projeto item);

        public async Task<Models.Trabalho.Projeto> UpdateProjeto(int? id, Models.Trabalho.Projeto projeto)
        {
            OnProjetoUpdated(projeto);

            var itemToUpdate = Context.Projetos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(projeto);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterProjetoUpdated(projeto);

            return projeto;
        }

        partial void OnPublicacaoDeleted(Models.Trabalho.Publicacao item);
        partial void OnAfterPublicacaoDeleted(Models.Trabalho.Publicacao item);

        public async Task<Models.Trabalho.Publicacao> DeletePublicacao(int? id)
        {
            var itemToDelete = Context.Publicacaos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPublicacaoDeleted(itemToDelete);

            Context.Publicacaos.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPublicacaoDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPublicacaoGet(Models.Trabalho.Publicacao item);

        public async Task<Models.Trabalho.Publicacao> GetPublicacaoById(int? id)
        {
            var items = Context.Publicacaos
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnPublicacaoGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.Publicacao> CancelPublicacaoChanges(Models.Trabalho.Publicacao item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPublicacaoUpdated(Models.Trabalho.Publicacao item);
        partial void OnAfterPublicacaoUpdated(Models.Trabalho.Publicacao item);

        public async Task<Models.Trabalho.Publicacao> UpdatePublicacao(int? id, Models.Trabalho.Publicacao publicacao)
        {
            OnPublicacaoUpdated(publicacao);

            var itemToUpdate = Context.Publicacaos
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(publicacao);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterPublicacaoUpdated(publicacao);

            return publicacao;
        }

        partial void OnUnidadeCurricularDeleted(Models.Trabalho.UnidadeCurricular item);
        partial void OnAfterUnidadeCurricularDeleted(Models.Trabalho.UnidadeCurricular item);

        public async Task<Models.Trabalho.UnidadeCurricular> DeleteUnidadeCurricular(int? id)
        {
            var itemToDelete = Context.UnidadeCurriculars
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnUnidadeCurricularDeleted(itemToDelete);

            Context.UnidadeCurriculars.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterUnidadeCurricularDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnUnidadeCurricularGet(Models.Trabalho.UnidadeCurricular item);

        public async Task<Models.Trabalho.UnidadeCurricular> GetUnidadeCurricularById(int? id)
        {
            var items = Context.UnidadeCurriculars
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnUnidadeCurricularGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.Trabalho.UnidadeCurricular> CancelUnidadeCurricularChanges(Models.Trabalho.UnidadeCurricular item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnUnidadeCurricularUpdated(Models.Trabalho.UnidadeCurricular item);
        partial void OnAfterUnidadeCurricularUpdated(Models.Trabalho.UnidadeCurricular item);

        public async Task<Models.Trabalho.UnidadeCurricular> UpdateUnidadeCurricular(int? id, Models.Trabalho.UnidadeCurricular unidadeCurricular)
        {
            OnUnidadeCurricularUpdated(unidadeCurricular);

            var itemToUpdate = Context.UnidadeCurriculars
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(unidadeCurricular);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterUnidadeCurricularUpdated(unidadeCurricular);

            return unidadeCurricular;
        }
    }
}
