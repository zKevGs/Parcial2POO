using Panaderia.Enums;

namespace Panaderia.Models
{
    public static class GestionInventario
    {

        public static List<ProductosHorneados> productos = new();
        public static readonly string Inventario = "Inventario.txt";

        public static void AgregarProductos(ProductosHorneados producto)
        {
           var productito = productos.Find(p => p.Nombre == producto.Nombre);

            if (productito != null) { Console.WriteLine("producto ya existente"); }
            else { productos.Add(producto); Console.WriteLine("producto agregado con exito"); }
            GuardarDato(producto);
        }

        public static void MostrarTodosLosProductos()
        {
            if(productos.Count == 0) { Console.WriteLine("no hay productos en el inventario"); }
            else
            {
                Console.WriteLine("productos en el inventario: ");
                foreach(var inventario in productos)
                {
                    Console.WriteLine(inventario);
                }
            }
        }

        public static void MostrarTotal()
        {
            double total = 0;

            foreach(var producto in productos)
            {
                total += producto.Precio;
            }
            Console.WriteLine($"precio total: {total}");
        }

        public static void EliminarUnProducto(string nombre)
        {
            var producto = productos.Find(p => p.Nombre == nombre);

            if(producto == null) { Console.WriteLine("producto no encontrado"); }
            else
            {
                productos.Remove(producto);
                Console.WriteLine("producto eliminado con exito");
                GuardarDatos();
            }
            
        }
        public static void ActualizarProducto(string nombre, double nuevoPrecio, Categorias nuevaCategoria)
        {
            var productito = productos.Find(p => p.Nombre == nombre);

            if (productito == null) { Console.WriteLine("producto no encontrado"); }
            else
            {
                productos.Remove(productito);
                ProductosHorneados nuevoProducto = new ProductosHorneados(nombre, nuevoPrecio, nuevaCategoria);
                productos.Add(nuevoProducto);
                GuardarDatos();
                Console.WriteLine("producto actualizado");

            }
        }

        public static void CargarDatos()
        {

            try
            {
                if (File.Exists(Inventario))
                {
                    var linea = File.ReadAllText(Inventario);

                    foreach (var lineas in linea)
                    {
                        var datos = linea.Split(", ");
                        string nombre = datos[0];
                        int precio = int.Parse(datos[1]);

                        Categorias categoriaa = (Categorias)Enum.Parse(typeof(Categorias), datos[1]);

                        ProductosHorneados producto = new(nombre, precio, categoriaa);

                        productos.Add(producto);

                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void GuardarDato(ProductosHorneados producto)
        {
            using StreamWriter writer = new StreamWriter(Inventario, true);
            writer.WriteLine(producto);
        }

        public static void GuardarDatos()
        {
            List<string> lineas = Inventario.Select(x => x.ToString()).ToList();
            File.WriteAllLines(Inventario, lineas);
        }

    }
}
