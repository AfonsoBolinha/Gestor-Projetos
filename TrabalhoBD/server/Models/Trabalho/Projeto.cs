using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Projeto", Schema = "dbo")]
  public partial class Projeto
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID
    {
      get;
      set;
    }
    public string Nome
    {
      get;
      set;
    }
    public string Short_Name
    {
      get;
      set;
    }
    public string Descricao
    {
      get;
      set;
    }
    public int ID_UC
    {
      get;
      set;
    }
    public int Max_Cost
    {
      get;
      set;
    }
    public int Total_Cost
    {
      get;
      set;
    }
    public string DOI
    {
      get;
      set;
    }
    public string State
    {
      get;
      set;
    }
    public DateTime Data_Init
    {
      get;
      set;
    }
    public DateTime? Data_Fin
    {
      get;
      set;
    }
    public string Cientific_Domain
    {
      get;
      set;
    }
    public int ID_IR
    {
      get;
      set;
    }
  }
}
