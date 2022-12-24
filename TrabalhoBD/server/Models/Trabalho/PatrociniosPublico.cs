using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Patrocinios_Publicos", Schema = "dbo")]
  public partial class PatrociniosPublico
  {
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Montante
    {
      get;
      set;
    }
  }
}
