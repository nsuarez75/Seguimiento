using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Seguimiento.MVVM.Model
{
    internal class IncidenciaContext : DbContext
    {

        public DbSet<Incidencia> Incidencias { get; set; }

        public string DbPath { get; }

        public IncidenciaContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "incidencias.db");

        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

    }

   
}
