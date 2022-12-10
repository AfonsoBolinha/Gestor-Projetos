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
    public int ID_Investigador
    {
      get;
      set;
    }
    public string Papel
    {
      get;
      set;
    }
    public int Tempo_Gasto
    {
      get;
      set;
    }
    public int Tempo_Limite
    {
      get;
      set;
    }
  }
}
