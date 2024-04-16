using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;

namespace Proyecto1.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuarios(string Correo, string Contraseña);

        Task<Usuario> SaveUsuarios(Usuario modelo);
    }
}
