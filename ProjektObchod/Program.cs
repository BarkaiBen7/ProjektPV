namespace ProjektObchod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataAccess DataAccess = new DataAccess();

            var newProduct = new Product
            {
                Name = "Nový Produkt",
                Price = 49.99f,
                InStock = true
            };
            DataAccess.InsertProduct(newProduct);
        }
    }
}
