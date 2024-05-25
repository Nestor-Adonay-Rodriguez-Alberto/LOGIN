using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entidades
{
    public class Usuario
    {
        // ATRIBUTOS:

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Usuario { get; set; }


        [Required(ErrorMessage ="Ingrese Su Nombre Completo.")]
        public string NombreCompleto { get; set; }


        [Required(ErrorMessage ="Ingrese Un Nombre De Usuario. Ejemplo -> Pepe04")]
        public string NombreUsuario { get; set; }


        [Required(ErrorMessage ="Ingrese Su Fecha De Nacimiento.")]
        public DateTime FechaNacimiento { get; set; }


        [Required(ErrorMessage = "Email Es Oblicatorio.")]
        [DataType(DataType.EmailAddress)]
        public string Gmail { get; set; }


        [Required(ErrorMessage = "Ingrese Una Contraseña Segura.")]
        [StringLength(10,MinimumLength =5,ErrorMessage ="La Contraseña Debe Tener Entre 5 y 10 Caracteres.")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }


        [Required(ErrorMessage = "Ingrese Una Contraseña Segura.")]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "La Contraseña Debe Tener Entre 5 y 10 Caracteres.")]
        [Compare("Contraseña",ErrorMessage ="La Contraseña No Coinciden.")]
        [DataType(DataType.Password)]
        [NotMapped]
        public string ConfirmarContraseña { get; set; }


        [Required(ErrorMessage ="Ingrese Su Género.")]
        public string Genero { get; set; }


        [Required(ErrorMessage ="Ingrese Donde Esta Residiendo.")]
        public string Residencia { get; set; }


        public string RolUsuario { get; set; }


        public byte[]? Fotografia { get; set; }
    }
}
