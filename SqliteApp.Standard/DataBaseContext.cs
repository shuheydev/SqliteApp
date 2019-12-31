using Microsoft.EntityFrameworkCore;
using System;

namespace SqliteApp.Standard
{
    public class DataBaseContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        private readonly string _databasePath;

        public DataBaseContext(string databasePath)
        {
            _databasePath = databasePath;

            //DBが存在しない場合は作成する.
            //すでにある場合は何もしない.
            //Migrationが行われるということか.
            //Database.EnsureDeleted();//これでDBが削除される
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_databasePath}");
        }
    }
}
