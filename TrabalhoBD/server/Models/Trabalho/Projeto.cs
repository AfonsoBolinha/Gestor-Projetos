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
    [ConcurrencyCheck]
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Short_Name
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Descricao
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID_UC
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Max_Cost
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Total_Cost
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string DOI
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string State
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime Data_Init
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public DateTime? Data_Fin
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Cientific_Domain
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID_IR
    {
      get;
      set;
    }
  }
}
