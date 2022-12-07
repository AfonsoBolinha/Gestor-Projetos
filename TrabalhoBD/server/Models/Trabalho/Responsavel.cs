using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Responsavel", Schema = "dbo")]
  public partial class Responsavel
  {
    public int ID_Investigador
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
    public int Tempo_Responsavel
    {
      get;
      set;
    }
  }
}
