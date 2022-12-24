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
        [HttpGet("/export/Trabalho/investigadorinstituicaos/csv")]
        [HttpGet("/export/Trabalho/investigadorinstituicaos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorInstituicaosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvestigadorInstituicaos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/investigadorinstituicaos/excel")]
        [HttpGet("/export/Trabalho/investigadorinstituicaos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorInstituicaosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvestigadorInstituicaos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/investigadorprojetos/csv")]
        [HttpGet("/export/Trabalho/investigadorprojetos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorProjetosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvestigadorProjetos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/investigadorprojetos/excel")]
        [HttpGet("/export/Trabalho/investigadorprojetos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorProjetosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvestigadorProjetos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/investigadorstatuses/csv")]
        [HttpGet("/export/Trabalho/investigadorstatuses/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorStatusesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetInvestigadorStatuses(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/investigadorstatuses/excel")]
        [HttpGet("/export/Trabalho/investigadorstatuses/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportInvestigadorStatusesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetInvestigadorStatuses(), Request.Query), fileName);
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
        [HttpGet("/export/Trabalho/patrociniosprivados/csv")]
        [HttpGet("/export/Trabalho/patrociniosprivados/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrociniosPrivadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrociniosPrivados(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrociniosprivados/excel")]
        [HttpGet("/export/Trabalho/patrociniosprivados/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrociniosPrivadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrociniosPrivados(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/patrociniospublicos/csv")]
        [HttpGet("/export/Trabalho/patrociniospublicos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrociniosPublicosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPatrociniosPublicos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/patrociniospublicos/excel")]
        [HttpGet("/export/Trabalho/patrociniospublicos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPatrociniosPublicosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPatrociniosPublicos(), Request.Query), fileName);
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
        [HttpGet("/export/Trabalho/pesopatrocinioprivados/csv")]
        [HttpGet("/export/Trabalho/pesopatrocinioprivados/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPesoPatrocinioPrivadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPesoPatrocinioPrivados(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/pesopatrocinioprivados/excel")]
        [HttpGet("/export/Trabalho/pesopatrocinioprivados/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPesoPatrocinioPrivadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPesoPatrocinioPrivados(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/pesopatrociniopublicos/csv")]
        [HttpGet("/export/Trabalho/pesopatrociniopublicos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPesoPatrocinioPublicosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPesoPatrocinioPublicos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/pesopatrociniopublicos/excel")]
        [HttpGet("/export/Trabalho/pesopatrociniopublicos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPesoPatrocinioPublicosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPesoPatrocinioPublicos(), Request.Query), fileName);
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
        [HttpGet("/export/Trabalho/projetopatrocinioprivados/csv")]
        [HttpGet("/export/Trabalho/projetopatrocinioprivados/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetoPatrocinioPrivadosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjetoPatrocinioPrivados(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/projetopatrocinioprivados/excel")]
        [HttpGet("/export/Trabalho/projetopatrocinioprivados/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetoPatrocinioPrivadosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjetoPatrocinioPrivados(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/projetopatrocinioprogramas/csv")]
        [HttpGet("/export/Trabalho/projetopatrocinioprogramas/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetoPatrocinioProgramasToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetProjetoPatrocinioProgramas(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/projetopatrocinioprogramas/excel")]
        [HttpGet("/export/Trabalho/projetopatrocinioprogramas/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportProjetoPatrocinioProgramasToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetProjetoPatrocinioProgramas(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/publicacaos/csv")]
        [HttpGet("/export/Trabalho/publicacaos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPublicacaosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPublicacaos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/publicacaos/excel")]
        [HttpGet("/export/Trabalho/publicacaos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPublicacaosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPublicacaos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/publicacaoprojetos/csv")]
        [HttpGet("/export/Trabalho/publicacaoprojetos/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPublicacaoProjetosToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetPublicacaoProjetos(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/publicacaoprojetos/excel")]
        [HttpGet("/export/Trabalho/publicacaoprojetos/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportPublicacaoProjetosToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetPublicacaoProjetos(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/ratingprojs/csv")]
        [HttpGet("/export/Trabalho/ratingprojs/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRatingProjsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetRatingProjs(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/ratingprojs/excel")]
        [HttpGet("/export/Trabalho/ratingprojs/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportRatingProjsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetRatingProjs(), Request.Query), fileName);
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
        [HttpGet("/export/Trabalho/ucs/csv")]
        [HttpGet("/export/Trabalho/ucs/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUcsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUcs(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/ucs/excel")]
        [HttpGet("/export/Trabalho/ucs/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUcsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUcs(), Request.Query), fileName);
        }
        [HttpGet("/export/Trabalho/ucranks/csv")]
        [HttpGet("/export/Trabalho/ucranks/csv(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUcRanksToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetUcRanks(), Request.Query), fileName);
        }

        [HttpGet("/export/Trabalho/ucranks/excel")]
        [HttpGet("/export/Trabalho/ucranks/excel(fileName='{fileName}')")]
        public async System.Threading.Tasks.Task<FileStreamResult> ExportUcRanksToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetUcRanks(), Request.Query), fileName);
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
