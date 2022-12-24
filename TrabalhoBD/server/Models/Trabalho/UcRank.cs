using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("UCRank", Schema = "dbo")]
  public partial class UcRank
  {
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int NumPessoas
    {
      get;
      set;
    }
  }
}
