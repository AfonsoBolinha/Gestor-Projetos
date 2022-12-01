using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Contem", Schema = "dbo")]
  public partial class Contem
  {
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
    [ConcurrencyCheck]
    public string Papel
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Tempo_Gasto
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Tempo_Limite
    {
      get;
      set;
    }
  }
}
