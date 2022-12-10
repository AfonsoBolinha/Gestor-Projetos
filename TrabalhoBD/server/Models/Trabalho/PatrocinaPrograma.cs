using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Patrocina_Programa", Schema = "dbo")]
  public partial class PatrocinaPrograma
  {
    public int ID_Programa_Patrocinador
    {
      get;
      set;
    }
    public int ID_Projeto
    {
      get;
      set;
    }
    public int Montante
    {
      get;
      set;
    }
  }
}
