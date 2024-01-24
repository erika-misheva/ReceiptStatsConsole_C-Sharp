using ReceiptStatsConsole.DataAccess;


namespace ReceiptStatsConsole.Services
{
    public static class Services
    {
        static List<Product> GetDomesticsAlphabeticly(List<Product> products)
        {
            return products.Where(p => p.Domestic == true).OrderBy(p=> p.Name).ToList();
        }
        static List<Product> GetImportedAlphabeticly(List<Product> products)
        {
            return products.Where(p => p.Domestic == false).ToList();
        }
        static double TotalPrice ( List<Product> products)
        {
            return products.Sum(p => p.Price); 
        }
        static int CountOfProducts( List<Product> products )
        {
            return products.Count();
        }

        static void PrintProductDetails(List<Product> products, string category)
        {
            Console.WriteLine($". {category}");

            foreach (var product in products)
            {
                Console.WriteLine($"   ... {product.Name}");
                Console.WriteLine($"   Price: ${product.Price}");

                if (!string.IsNullOrWhiteSpace(product.Description))
                {
                    Console.WriteLine($"   {product.Description.Substring(0, 10)}...");
                }

                Console.WriteLine($"   Weight: {(product.Weight.HasValue ? product.Weight.ToString() + "g" : "N/A")}");
            }
        }
        public static void PrintReceiptDetails(List<Product> products)
        {
            var domesticProducts = GetDomesticsAlphabeticly(products);
            var importedProducts = GetImportedAlphabeticly(products);

         
            PrintProductDetails(domesticProducts, "Domestic");

           
            PrintProductDetails(importedProducts, "Imported");

            
            Console.WriteLine($"Domestic cost: ${TotalPrice(domesticProducts)}");
            Console.WriteLine($"Imported cost: ${TotalPrice(importedProducts)}");
            Console.WriteLine($"Domestic count: {CountOfProducts(domesticProducts)}");
            Console.WriteLine($"Imported count: {CountOfProducts(importedProducts)}");
        }

    }
}
