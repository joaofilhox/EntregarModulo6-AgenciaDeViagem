using AgenciaDeViagem.Model;
using Microsoft.EntityFrameworkCore;

namespace AgenciaDeViagem.Data
{


  public class DataContext : DbContext
  {

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }



    public DbSet<Destino> AgenciaDeViagem { get; set; }





  }



}