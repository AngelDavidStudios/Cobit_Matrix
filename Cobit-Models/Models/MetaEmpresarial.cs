using System.ComponentModel.DataAnnotations;

namespace Cobit_Matrix.Models;

public class MetaEmpresarial
{
    [Key]
    public int IdEmpresarial { get; set; }
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
}