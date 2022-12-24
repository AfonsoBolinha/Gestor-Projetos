using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Publicacao_Projeto", Schema = "dbo")]
  public partial class PublicacaoProjeto
  {
    public int ID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Nome_Investigador
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string Nome_Projeto
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
    public string URL
    {
      get;
      set;
    }
  }
}
