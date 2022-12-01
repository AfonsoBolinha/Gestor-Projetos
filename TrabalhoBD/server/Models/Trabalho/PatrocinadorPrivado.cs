using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Patrocinador_Privado", Schema = "dbo")]
  public partial class PatrocinadorPrivado
  {
    public int ID_Patrocinador
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
    [ConcurrencyCheck]
    public int Montante
    {
      get;
      set;
    }
  }
}
