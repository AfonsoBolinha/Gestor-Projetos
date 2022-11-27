using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Pertence1", Schema = "dbo")]
  public partial class Pertence1
  {
    public int ID_Investigador
    {
      get;
      set;
    }
    public int ID_UC
    {
      get;
      set;
    }
    public int ID_Projeto
    {
      get;
      set;
    }
  }
}
