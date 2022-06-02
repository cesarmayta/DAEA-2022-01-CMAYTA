using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Objects;
using System.Globalization;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Data.Common;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {

            using (AdventureWorksEntities AWEntities = new AdventureWorksEntities())
            {
                var products = AWEntities.Product;

                //IQueryable<string> productNames = from p in products
                //                                  select p.Name;

                //Console.WriteLine("Ejercicio 01 - Productos: ");
                //foreach(var productName in productNames)
                //{
                //    Console.WriteLine(productName);
                //}
                //Console.ReadKey();

                ////ejercicios 02
                //IQueryable<string> productNames2 = products.Select(p => p.Name);
                //Console.WriteLine("Ejercicios 02 - Productos: ");
                //foreach (var productName in productNames2)
                //{
                //    Console.WriteLine(productName);
                //}
                //Console.ReadKey();

                //ejercicios 03
                IQueryable<Product> productsQuery = from p in products
                                                    select p;
                IQueryable<Product> largeProducts = productsQuery.Where(p => p.Size == "L");
                Console.WriteLine("Productos de tamaño L : ");
                foreach(var product in largeProducts)
                {
                    Console.WriteLine(product.Name);
                }
                Console.ReadKey();
            }

            

        }
    }
}
