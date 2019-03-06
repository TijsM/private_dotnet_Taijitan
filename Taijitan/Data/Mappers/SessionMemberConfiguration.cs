﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taijitan.Models.Domain;

namespace Taijitan.Data.Mappers
{
    public class SessionMemberConfiguration : IEntityTypeConfiguration<SessionMember>
    {
        public void Configure(EntityTypeBuilder<SessionMember> builder)
        {
            builder.ToTable("SessionMember");
            builder.HasKey(sm => new {sm.SessionId, sm.MemberId });

            builder
                .HasOne<Member>(sm => sm.Member)
                .WithMany(m => m.SessionMembers)
                .HasForeignKey(sm => sm.MemberId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne<Session>(sm => sm.Session)
                .WithMany(m => m.SessionMembers)
                .HasForeignKey(sm => sm.SessionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            
   
        }
    }
}
