using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("RatingProj", Schema = "dbo")]
  public partial class RatingProj
  {
    public string Nome
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
    public int Participantes
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int NumPublicacoes
    {
      get;
      set;
    }
  }
}
