using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStudies.Model;

namespace MyStudies.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Aqui é onde transformamos nosso objeto Subject em uma tabela
        public DbSet<Subject> Subjects => Set<Subject>();

        /// Aqui é onde transformamos nosso objeto Subject em uma tabela
        public DbSet<Study> Studies => Set<Study>();

        /// Aqui é onde transformamos nosso objeto FlashCard em uma tabela
        public DbSet<FlashCard> FlashCards => Set<FlashCard>();
    }
}