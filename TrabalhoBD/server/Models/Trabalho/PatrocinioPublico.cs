using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("PatrocinioPublico", Schema = "dbo")]
  public partial class PatrocinioPublico
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
    public string Sigla
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
    [ConcurrencyCheck]
    public string Morada
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
    public string Pais
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Designacao
    {
      get;
      set;
    }
  }
}
