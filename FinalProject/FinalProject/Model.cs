using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace FinalProject
{
    public class Conexion : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public DbSet<Accidente> Accidentes {get; set;}
         public DbSet<Involucrado> Involucrados {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=reportes.db");
    }

    public class Accidente{
        public int AccidenteId {get; set;}
        public string Fecha {get; set;}
        public string Hora {get; set;}
        public string Lugar {get; set;}
        public string Longitud {get; set;}
        public string Latitud {get; set;}
        public string Descripcion{get;set;}

         public List<Involucrado> Involucrados { get; } = new List<Involucrado>();
    }

    public class Involucrado{

        public int InvolucradoId {get;set;}
        public string Nombre {get; set;}
         public string Apellido {get; set;}
          public string Telefono {get; set;}
           public string Correo {get; set;}
            public string Cedula {get; set;}

            public int AccidenteId {get;set;}
            public Accidente Accidente {get;set;}

    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}