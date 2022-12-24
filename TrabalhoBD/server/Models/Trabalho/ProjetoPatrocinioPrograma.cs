using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("ProjetoPatrocinioPrograma", Schema = "dbo")]
  public partial class ProjetoPatrocinioPrograma
  {
    public string NomeProj
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string NomePatrocinio
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Montante
    {
      get;
      set;
    }
  }
}
