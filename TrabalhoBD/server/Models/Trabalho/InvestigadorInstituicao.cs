using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Investigador_Instituicao", Schema = "dbo")]
  public partial class InvestigadorInstituicao
  {
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NomeInst
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID
    {
      get;
      set;
    }
  }
}
