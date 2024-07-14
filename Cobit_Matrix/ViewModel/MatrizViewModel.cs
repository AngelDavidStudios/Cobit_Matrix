using Cobit_Matrix.Models;

namespace Cobit_Matrix.ViewModel;

public class MatrizViewModel
{
    public IEnumerable<MetaAlineamiento> MetaAlineamientos { get; set; }
    public IEnumerable<MetaEmpresarial> MetaEmpresariales { get; set; }
    public IEnumerable<ObjetivosGobierno> ObjetivosGobierno { get; set; }
}