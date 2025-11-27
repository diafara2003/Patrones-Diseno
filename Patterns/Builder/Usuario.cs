using System.Runtime.CompilerServices;

namespace BuilderYFactory.Builder;

public record Usuario()
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public string Pais { get; set; }
    public string Profesion { get; set; }
    public string Email { get; set; }
}
//public record Usuario(string Nombre, string Apellido, int Edad, string Pais, string Profesion, string Email);
// 