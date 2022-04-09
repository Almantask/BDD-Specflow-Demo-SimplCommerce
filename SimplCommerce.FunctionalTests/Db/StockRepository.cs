using Microsoft.Data.SqlClient;

namespace SimplCommerce.FunctionalTests.Db
{
    public static class StockRepository
    {
        // TODO: use product id.

        public static int GetProductQuantityInStock(string product)
        {
            // Product name must be unique.
            // In reality, this might not be the case and you should use an id instead.
            const string sql = $@"SELECT Stock.Quantity
                          FROM Inventory_Stock as Stock
                          INNER JOIN Catalog_Product as Product
                          ON Stock.ProductId = Product.Id
                          where Product.Name = @product'";

            using var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var cmd = new SqlCommand(sql, connection);
            var param = new SqlParameter("@product", product);
            cmd.Parameters.Add(param);
            return (int)cmd.ExecuteScalar();
        }

        public static void UpdateStock(string product, int quantity)
        {
            // Product name must be unique.
            // In reality, this might not be the case and you should use an id instead.
            const string sql = $@"UPDATE SET Stock.Quantity = @quantity
                          FROM Inventory_Stock as Stock
                          INNER JOIN Catalog_Product as Product
                          ON Stock.ProductId = Product.Id
                          where Product.Name = @product'";

            using var connection = new SqlConnection(Constants.ConnectionString);
            connection.Open();
            var cmd = new SqlCommand(sql, connection);
            var param1 = new SqlParameter("@product", product);
            var param2 = new SqlParameter("@quantity", quantity);
            cmd.Parameters.Add(param1);
            cmd.Parameters.Add(param2);
            cmd.ExecuteNonQuery();
        }
    }
}
