using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("ProjetoPatrocinioPrivado", Schema = "dbo")]
  public partial class ProjetoPatrocinioPrivado
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
