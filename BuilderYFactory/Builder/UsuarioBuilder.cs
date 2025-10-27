namespace BuilderYFactory.Builder;

public class UsuarioBuilder
{
    private Usuario _usuario = new();

    public UsuarioBuilder ConNombre(string nombre)
    {
        _usuario.Nombre = nombre;
        return this;
    }

    public UsuarioBuilder ConApellido(string apellido)
    {
        _usuario.Apellido = apellido;
        return this;
    }

    public UsuarioBuilder ConEdad(int edad)
    {
        _usuario.Edad = edad;
        return this;
    }

    public UsuarioBuilder DePais(string pais)
    {
        _usuario.Pais = pais;
        return this;
    }

    public UsuarioBuilder ConProfesion(string profesion)
    {
        _usuario.Profesion = profesion;
        return this;
    }

    public UsuarioBuilder ConEmail(string email)
    {
        _usuario.Email = email;
        return this;
    }

    public Usuario Build()
    {
        return _usuario;
    }
}