namespace VetCare.Models;

public class ServicioApi
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public decimal Precio { get; set; }
    public int Duracion { get; set; }
    public bool RequiereCita { get; set; }
    public string Especialidad { get; set; } = string.Empty;
    public int EspecialidadId { get; set; }
}

public class EspecialidadApi
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
}