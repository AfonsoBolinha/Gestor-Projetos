using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Publicacao", Schema = "dbo")]
  public partial class Publicacao
  {
    public string Titulo
    {
      get;
      set;
    }
    public string Descricao
    {
      get;
      set;
    }
    public string URL_Publicacao
    {
      get;
      set;
    }
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
  }
}
