using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Investigador", Schema = "dbo")]
  public partial class Investigador
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
    public int Num_Funcionario
    {
      get;
      set;
    }
    public string ORCID
    {
      get;
      set;
    }
    public int ID_Instituicao
    {
      get;
      set;
    }
    public int? Tempo_Total
    {
      get;
      set;
    }
  }
}
