using System.ComponentModel.DataAnnotations;

namespace Cobit_Matrix.Models;

public class ObjetivosGobierno
{
    [Key]
    public int IdGobierno { get; set; }
    public string Codigo { get; set; }
    public string Descripcion { get; set; }
}