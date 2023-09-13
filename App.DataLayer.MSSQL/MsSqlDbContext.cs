using App.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace App.DataLayer.MSSQL
{
    public class MsSqlDbContext : ApplicationDbContext
    {
        public MsSqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}