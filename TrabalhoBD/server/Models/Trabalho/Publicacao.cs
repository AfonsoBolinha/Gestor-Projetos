using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Publicacao", Schema = "dbo")]
  public partial class Publicacao
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Titulo
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
    public string URL
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
    public int ID_Investigador
    {
      get;
      set;
    }
  }
}
