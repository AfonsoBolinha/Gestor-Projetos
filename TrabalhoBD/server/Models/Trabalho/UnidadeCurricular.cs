using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoBd.Models.Trabalho
{
  [Table("Unidade_Curricular", Schema = "dbo")]
  public partial class UnidadeCurricular
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
    public int ID_Instituicao
    {
      get;
      set;
    }
  }
}
