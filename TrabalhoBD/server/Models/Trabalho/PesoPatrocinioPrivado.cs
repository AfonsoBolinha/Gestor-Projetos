using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("PesoPatrocinioPrivado", Schema = "dbo")]
  public partial class PesoPatrocinioPrivado
  {
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Financiamento
    {
      get;
      set;
    }
  }
}
