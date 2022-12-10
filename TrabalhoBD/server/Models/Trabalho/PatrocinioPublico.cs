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
    public string Nome
    {
      get;
      set;
    }
    public string Sigla
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
    public string Morada
    {
      get;
      set;
    }
    public string URL
    {
      get;
      set;
    }
    public string Pais
    {
      get;
      set;
    }
    public string Designacao
    {
      get;
      set;
    }
  }
}
