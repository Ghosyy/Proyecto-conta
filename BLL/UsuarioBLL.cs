using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAL;

namespace BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL usuarioDal = new UsuarioDAL();

        public Usuario Autenticar(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El usuario y la contraseña son obligatorios.");
            }

            return usuarioDal.Login(username, password);
        }
    }
}