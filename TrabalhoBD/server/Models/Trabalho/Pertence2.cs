using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Pertence2", Schema = "dbo")]
  public partial class Pertence2
  {
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
