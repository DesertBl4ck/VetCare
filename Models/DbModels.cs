using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetCare.Models;

public class Mascota
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "La especie es obligatoria")]
    [StringLength(50)]
    public string Especie { get; set; } = string.Empty;

    [StringLength(50)]
    public string? Raza { get; set; }

    [Required(ErrorMessage = "El nombre del dueño es obligatorio")]
    [StringLength(100)]
    public string NombreDueno { get; set; } = string.Empty;

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [Phone(ErrorMessage = "Teléfono inválido")]
    [StringLength(20)]
    public string Telefono { get; set; } = string.Empty;

    [EmailAddress(ErrorMessage = "Email inválido")]
    [StringLength(150)]
    public string? Email { get; set; }

    public DateTime FechaRegistro { get; set; } = DateTime.Now;

    public ICollection<Cita> Citas { get; set; } = new List<Cita>();
}

public class Cita
{
    public int Id { get; set; }

    [Required]
    public int MascotaId { get; set; }

    [Required(ErrorMessage = "La fecha es obligatoria")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "El estado es obligatorio")]
    [StringLength(30)]
    public string Estado { get; set; } = "Programada";

    [StringLength(300)]
    public string? Notas { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Total { get; set; }

    public Mascota? Mascota { get; set; }
    public ICollection<DetalleServicio> Detalles { get; set; } = new List<DetalleServicio>();
}

public class DetalleServicio
{
    public int Id { get; set; }

    [Required]
    public int CitaId { get; set; }

    public int ServicioApiId { get; set; }

    [StringLength(150)]
    public string NombreServicio { get; set; } = string.Empty;

    public int Cantidad { get; set; } = 1;

    [Column(TypeName = "decimal(10,2)")]
    public decimal Precio { get; set; }

    public Cita? Cita { get; set; }
}