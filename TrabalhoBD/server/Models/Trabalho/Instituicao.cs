using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Instituição", Schema = "dbo")]
  public partial class Instituicao
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
    public string Morada
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public int Tel
    {
      get;
      set;
    }
  }
}
