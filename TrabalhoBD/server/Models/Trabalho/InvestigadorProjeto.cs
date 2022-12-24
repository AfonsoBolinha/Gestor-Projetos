using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Investigador_Projeto", Schema = "dbo")]
  public partial class InvestigadorProjeto
  {
    public string NomeInvestigador
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NomeProjeto
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ORCID
    {
      get;
      set;
    }
  }
}
