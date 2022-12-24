using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("PesoPatrocinioPublico", Schema = "dbo")]
  public partial class PesoPatrocinioPublico
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
