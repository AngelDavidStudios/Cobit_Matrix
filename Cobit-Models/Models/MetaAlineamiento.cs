using System.ComponentModel.DataAnnotations;

namespace Cobit_Matrix.Models;

public class MetaAlineamiento
{
    [Key]
    public int IdAlineamiento { get; set; }
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
}