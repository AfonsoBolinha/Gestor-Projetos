using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Project_State", Schema = "dbo")]
  public partial class ProjectState
  {
    public string Nome
    {
      get;
      set;
    }
    public string State
    {
      get;
      set;
    }
    public int Total_Cost
    {
      get;
      set;
    }
    public int Max_Cost
    {
      get;
      set;
    }
  }
}
