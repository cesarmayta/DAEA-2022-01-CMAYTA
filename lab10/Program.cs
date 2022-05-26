using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Origen de datos
            NorthwndDataContext context = new NorthwndDataContext();

            //Ejecución de consulta
            //ejercicio 1
             var query = from p in context.Products
                        select p;

            Console.WriteLine("======== EJERCICIO 1 ===========");
            foreach (var prod in query)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);
            }

            //ejercicio 2
            var query2 = from p in context.Products
                        where p.Categories.CategoryName == "Beverages"
                        select p;

            Console.WriteLine("======== EJERCICIO 2 ===========");
            foreach (var prod in query2)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice, prod.ProductName);
            }

            //ejercicio 3
            var query3 = from p in context.Products
                        where p.UnitPrice < 20
                        select p;

            Console.WriteLine("======== EJERCICIO 3 ===========");
            foreach (var prod in query3)
            {
                Console.WriteLine("ID={0} \t Price={1} \t Name={2}", prod.ProductID, prod.UnitPrice,prod.ProductName);
            }

            Console.ReadKey();

            //INSERTAR REGISTROS

            //Creación de consulta
            //Products np = new Products();
            //np.ProductName = "Peruvian Coffee";
            //np.SupplierID = 20;
            //np.CategoryID = 1;
            //np.QuantityPerUnit = "10 pkgs";
            //np.UnitPrice = 25;

            ////Ejecución de consulta
            //context.Products.InsertOnSubmit(np);
            //context.SubmitChanges();
            //Console.WriteLine("Nuevo registro en bd : " + np.ProductID);

            //MODIFICAR REGISTROS
            var product =  (from p in context.Products
                            where p.ProductName == "Tofu"
                            select p).FirstOrDefault();

            product.UnitPrice = 150;
            product.UnitsInStock = 15;
            product.Discontinued = true;

            //Ejecucíón de consulta
            context.SubmitChanges();
            Console.WriteLine("registro actualizado : " + product.ProductID);

            Console.ReadKey();

            //ELIMINAR UN PRODUCTO
            var productDel = (from p in context.Products
                              where p.ProductID == 78
                              select p).FirstOrDefault();

            //Ejecución de consulta
            context.Products.DeleteOnSubmit(productDel);
            context.SubmitChanges();
            Console.WriteLine("Registro eliminado ");

            Console.ReadKey();
        }
    }
}
