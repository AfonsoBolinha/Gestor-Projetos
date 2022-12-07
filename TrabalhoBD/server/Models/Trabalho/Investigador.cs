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
    [ConcurrencyCheck]
    public string Nome
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int Num_Funcionario
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public string ORCID
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int ID_Instituicao
    {
      get;
      set;
    }
    [ConcurrencyCheck]
    public int? Tempo_Total
    {
      get;
      set;
    }
  }
}
