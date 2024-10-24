using Panaderia.Enums;

namespace Panaderia.Models
{
    public static class Menu
    {
        static List<Action> Acciones = new List<Action>()
        {
            AgregarProductos,
            EliminarUnProducto,
            ActualizarProducto,
            MostrarTodosLosProductos,
            MostrarTotal,

        };


        public static void MostrarMenu()
        {
            bool salir = false;

            while (!salir)
            {
                Console.WriteLine("\n --- Menú ---\n" +
                    "1. Agregar Producto\n" +
                    "2. Eliminar Producto\n" +
                    "3. Modificar Producto\n" +
                    "4. Mostrar Producto\n" +
                    "5. Mostrar Total \n" +
                    "6. Salir\n");
                Console.Write("Seleccione una opcion: ");
                string opcion = Console.ReadLine();

                if (int.TryParse(opcion, out int indice) && indice >= 1 && indice <= Acciones.Count + 1)
                {
                    if (indice == Acciones.Count + 1)
                    {
                        salir = true;
                    }
                    else
                    {
                        Acciones[indice - 1].Invoke();
                    }
                }
            }
        }

        public static void AgregarProductos()
        {
            Console.Write("ingrese el nombre del producto: ");
            var nombre = Console.ReadLine();

            Console.Write("ingrese el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Console.WriteLine("ingrese su categoria: ");
            foreach (var item in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Categorias categoria = (Categorias)seleccion;

            ProductosHorneados productito = new ProductosHorneados(nombre, precio, categoria);
            GestionInventario.productos.Add(productito);
        }
        public static void EliminarUnProducto()
        {
            Console.Write("ingrese el nombre del producto a eliminar: ");
            string nombre = Console.ReadLine();

            GestionInventario.EliminarUnProducto(nombre);
        }
        public static void ActualizarProducto()
        {
            Console.Write("ingrese el nombre del producto: ");
            var nombre = Console.ReadLine();

            Console.Write("ingrese el precio del producto: ");
            double precio = double.Parse(Console.ReadLine());

            Console.WriteLine("ingrese su categoria: ");
            foreach (var item in Enum.GetValues(typeof(Categorias)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            int seleccion = int.Parse(Console.ReadLine());
            Categorias categoria = (Categorias)seleccion;

            GestionInventario.ActualizarProducto(nombre, precio, categoria);

        }

        public static void MostrarTodosLosProductos()
        {
            GestionInventario.MostrarTodosLosProductos();
        }

        public static void MostrarTotal()
        {
            GestionInventario.MostrarTotal();
        }

        

        

    }
}
