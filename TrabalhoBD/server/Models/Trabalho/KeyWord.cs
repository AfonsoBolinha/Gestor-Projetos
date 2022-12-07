using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("KeyWords", Schema = "dbo")]
  public partial class KeyWord
  {
    public string PalavraChave
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID_Projeto
    {
      get;
      set;
    }
  }
}
