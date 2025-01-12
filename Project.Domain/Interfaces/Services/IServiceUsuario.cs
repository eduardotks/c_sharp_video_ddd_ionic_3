﻿using Project.Domain.Arguments.Usuario;
using Project.Domain.Interfaces.Services.Base;

namespace Project.Domain.Interfaces.Services
{
    public interface IServiceUsuario : IServiceBase
    {
        AdicionarUsuarioResponse AdicionarUsuario(AdicionarUsuarioRequest request);
        AutenticarUsuarioResponse AutenticarUsuario(AutenticarUsuarioRequest request);
    }
}
