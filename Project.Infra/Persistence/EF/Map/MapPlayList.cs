﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Project.Domain.Entities;

namespace Project.Infra.Persistence.EF.Map
{
    public class MapPlayList : IEntityTypeConfiguration<PlayList>
    {
        public void Configure(EntityTypeBuilder<PlayList> builder)
        {

            builder.ToTable("PlayList");
            //Foreikey
            builder.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");

            //Propriedades
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }
    }
}
