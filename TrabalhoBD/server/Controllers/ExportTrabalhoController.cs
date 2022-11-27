using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrabalhoBd.Data;

namespace TrabalhoBd
{
    public partial class ExportTrabalhoController : ExportController
    {
        private readonly TrabalhoContext context;
        private readonly TrabalhoService service;
        public ExportTrabalhoController(TrabalhoContext context, TrabalhoService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/Trabalho/areacientificas/csv")]
        [HttpGet("/export/Trabalho/areacientificas/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAreaCientificasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetAreaCientificas(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/areacientificas/excel")]
        [HttpGet("/export/Trabalho/areacientificas/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportAreaCientificasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetAreaCientificas(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/contems/csv")]
        [HttpGet("/export/Trabalho/contems/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportContemsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetContems(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/contems/excel")]
        [HttpGet("/export/Trabalho/contems/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportContemsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetContems(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/instituicaos/csv")]
        [HttpGet("/export/Trabalho/instituicaos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInstituicaosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInstituicaos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/instituicaos/excel")]
        [HttpGet("/export/Trabalho/instituicaos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInstituicaosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInstituicaos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/investigadors/csv")]
        [HttpGet("/export/Trabalho/investigadors/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvestigadors(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/investigadors/excel")]
        [HttpGet("/export/Trabalho/investigadors/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvestigadors(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/keywords/csv")]
        [HttpGet("/export/Trabalho/keywords/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportKeyWordsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetKeyWords(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/keywords/excel")]
        [HttpGet("/export/Trabalho/keywords/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportKeyWordsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetKeyWords(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/patrocinaprogramas/csv")]
        [HttpGet("/export/Trabalho/patrocinaprogramas/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinaProgramasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrocinaProgramas(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrocinaprogramas/excel")]
        [HttpGet("/export/Trabalho/patrocinaprogramas/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinaProgramasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrocinaProgramas(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/patrocinadors/csv")]
        [HttpGet("/export/Trabalho/patrocinadors/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinadorsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrocinadors(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrocinadors/excel")]
        [HttpGet("/export/Trabalho/patrocinadors/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinadorsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrocinadors(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/patrocinadorprivados/csv")]
        [HttpGet("/export/Trabalho/patrocinadorprivados/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinadorPrivadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrocinadorPrivados(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrocinadorprivados/excel")]
        [HttpGet("/export/Trabalho/patrocinadorprivados/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinadorPrivadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrocinadorPrivados(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/patrociniopublicos/csv")]
        [HttpGet("/export/Trabalho/patrociniopublicos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinioPublicosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrocinioPublicos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrociniopublicos/excel")]
        [HttpGet("/export/Trabalho/patrociniopublicos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrocinioPublicosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrocinioPublicos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/pertence1s/csv")]
        [HttpGet("/export/Trabalho/pertence1s/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPertence1sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPertence1S(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/pertence1s/excel")]
        [HttpGet("/export/Trabalho/pertence1s/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPertence1sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPertence1S(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/pertence2s/csv")]
        [HttpGet("/export/Trabalho/pertence2s/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPertence2sToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPertence2S(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/pertence2s/excel")]
        [HttpGet("/export/Trabalho/pertence2s/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPertence2sToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPertence2S(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/projectstates/csv")]
        [HttpGet("/export/Trabalho/projectstates/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjectStatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjectStates(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/projectstates/excel")]
        [HttpGet("/export/Trabalho/projectstates/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjectStatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjectStates(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/projetos/csv")]
        [HttpGet("/export/Trabalho/projetos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjetos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/projetos/excel")]
        [HttpGet("/export/Trabalho/projetos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjetos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/responsavels/csv")]
        [HttpGet("/export/Trabalho/responsavels/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportResponsavelsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetResponsavels(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/responsavels/excel")]
        [HttpGet("/export/Trabalho/responsavels/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportResponsavelsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetResponsavels(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/unidadecurriculars/csv")]
        [HttpGet("/export/Trabalho/unidadecurriculars/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUnidadeCurricularsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUnidadeCurriculars(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/unidadecurriculars/excel")]
        [HttpGet("/export/Trabalho/unidadecurriculars/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUnidadeCurricularsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUnidadeCurriculars(), Request.Query), fileName);
        }
    }
}
