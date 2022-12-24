using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("InvestigadorStatus", Schema = "dbo")]
  public partial class InvestigadorStatus
  {
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Papel
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Tempo_Gasto
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? Tempo_Total
    {
      get;
      set;
    }
  }
}
