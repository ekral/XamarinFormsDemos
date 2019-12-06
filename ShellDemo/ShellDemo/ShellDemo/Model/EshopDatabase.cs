using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShellDemo.Model
{
    public class EshopDatabase
    {
        // vlozte nugetu sqlite-net-pcl
        // Pridejte do tridy Product primary key ProductId
        // Pridejte do tridy Product bezparametricky konstruktor
        // Vytvorte slozku Model a pridejte do ni tuto tridu
        private SQLiteAsyncConnection connection;

        public EshopDatabase(string fileName)
        {
            string dbPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            // System.IO.File.Delete(dbPath);
            connection = new SQLiteAsyncConnection(dbPath);
        }

        public Task<CreateTableResult> EnsureCreated()
        {
            return connection.CreateTableAsync<Produkt>();
        }

        public Task<List<Produkt>> GetAllProductsAsync()
        {
            return connection.Table<Produkt>().ToListAsync();
        }

        public Task<List<Produkt>> GetExpensiveProductsAsync()
        {
            return connection.QueryAsync<Produkt>("SELECT * FROM [Produkt] WHERE [Cena] > 1000");
        }

        public Task<int> InsertProductAsync(Produkt item)
        {
            return connection.InsertAsync(item);
        }

        public Task<int> DeleteProductAsync(int produktId)
        {
            return connection.DeleteAsync<Produkt>(produktId);
        }

        public Task<int> UpdateProductAsync(Produkt item)
        {
            return connection.UpdateAsync(item);
        }


    }
}
