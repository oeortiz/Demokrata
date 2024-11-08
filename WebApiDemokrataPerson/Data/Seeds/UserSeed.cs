using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiDemokrataPerson.Models;

namespace WebApiDemokrataPerson.Data.Seeds
{
    public class UserSeed:IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User() { UserId = 1, Nombre = "Juan", SegundoNombre = "Manuel", Apellido = "Perez", SegundoApellido = "Ortega", FechaNacimiento = new DateOnly(1968, 10, 08), Sueldo = 7500000,         FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") },
                new User() { UserId = 2, Nombre = "Angel", SegundoNombre = "Nicolas", Apellido = "Rincon", SegundoApellido = "Ruiz", FechaNacimiento = new DateOnly(1985, 09, 20), Sueldo = 3000000,         FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") },
                new User() { UserId = 3, Nombre = "Anderson", SegundoNombre = "Manuel", Apellido = "Suarez", SegundoApellido = "", FechaNacimiento = new DateOnly(1980, 09, 20), Sueldo = 3000000, FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") },
                new User() { UserId = 4, Nombre = "Andrea", SegundoNombre = "", Apellido = "Vanegas", SegundoApellido = "", FechaNacimiento = new DateOnly(1998, 05, 20), Sueldo = 1000000, FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") },
                new User() { UserId = 5, Nombre = "Paula", SegundoNombre = "", Apellido = "Reyes", SegundoApellido = "", FechaNacimiento = new DateOnly(1993, 02, 15), Sueldo = 1000000, FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") },
                new User() { UserId = 6, Nombre = "Tatiana", SegundoNombre = "Milena", Apellido = "Sanchez", SegundoApellido = "Maldonado", FechaNacimiento = new DateOnly(1993, 05, 15), Sueldo = 4000000, FechaCreacion = DateTime.Parse("2024/11/08 11:40:00"), FechaActualizacion = DateTime.Parse("2024/11/08 11:40:00") }
                );
        }
    }
}
