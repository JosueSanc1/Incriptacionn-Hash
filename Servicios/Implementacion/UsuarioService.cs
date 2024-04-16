using Microsoft.EntityFrameworkCore;
using Proyecto1.Models;
using Proyecto1.Servicios.Contrato;

namespace Proyecto1.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ProyectoControlDiabetesWebContext _dbContext;

        public UsuarioService(ProyectoControlDiabetesWebContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuarios(string Correo, string Contraseña)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.Correo == Correo && u.Contraseña == Contraseña).FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuarios(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
