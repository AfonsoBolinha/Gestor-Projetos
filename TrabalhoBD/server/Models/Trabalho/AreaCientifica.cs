using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("AreaCientifica", Schema = "dbo")]
  public partial class AreaCientifica
  {
    public string Area
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
