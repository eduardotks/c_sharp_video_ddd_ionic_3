﻿using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using Project.Domain.Extensions;
using Project.Domain.Entities.Base;
using Project.Domain.ValueObjects;

namespace Project.Domain.Entities
{
    public class Usuario : EntityBase
    {
        protected Usuario()
        {

        }
        public Usuario(Email email, string senha)
        {
            Email = email;
            Senha = senha;

            //Criptografo a senha
            Senha = Senha.ConvertToMD5();

            AddNotifications(email);
        }

        public Usuario(Nome nome, Email email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;

            new AddNotifications<Usuario>(this).IfNullOrInvalidLength(x => x.Senha, 3, 32);

            //Criptografo a senha
            Senha = Senha.ConvertToMD5();

            AddNotifications(nome, email);
        }

        public Nome Nome { get; private set; }
        public Email Email { get; private set; }
        public string Senha { get; private set; }
    }
}
