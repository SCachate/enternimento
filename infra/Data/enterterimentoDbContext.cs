﻿using filmes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace infra.Data
{
    public class enterterimentoDbContext : IdentityDbContext<UsersModel>
    {
        public enterterimentoDbContext (DbContextOptions<enterterimentoDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
