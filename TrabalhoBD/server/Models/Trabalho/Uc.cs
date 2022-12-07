using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("UC", Schema = "dbo")]
  public partial class Uc
  {
    public int ID
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
    public string Nome
    {
      get;
      set;
    }
  }
}
