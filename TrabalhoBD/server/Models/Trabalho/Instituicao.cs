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
    [ConcurrencyCheck]
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Morada
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Email
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Tel
    {
      get;
      set;
    }
  }
}
