using Microsoft.EntityFrameworkCore;
using Nascente.Domain.Entities;

namespace Nascente.Infrastructure.DataAcess;

public class CashFlowDBContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=@Password123;";
        var version = new Version(8, 0, 41);
        var serverVersion = new MySqlServerVersion(version);
        optionsBuilder.UseMySql(connectionString, serverVersion);
    }
}
