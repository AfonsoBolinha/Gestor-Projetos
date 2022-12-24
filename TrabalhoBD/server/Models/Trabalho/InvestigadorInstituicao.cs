using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Investigador_Instituicao", Schema = "dbo")]
  public partial class InvestigadorInstituicao
  {
    public string Nome_Investigador
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID_Investigador
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Nome
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
