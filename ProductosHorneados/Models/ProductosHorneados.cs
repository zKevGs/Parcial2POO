using Panaderia.Enums;

namespace Panaderia.Models
{
    public class ProductosHorneados
    {
        private string _nombre;
        private double _precio;
        private Categorias _categorias;
        public string Nombre => _nombre;
        public double Precio => _precio;
        public Categorias Categorias => _categorias;

        public ProductosHorneados(string nombre, double precio, Categorias categoria)
        {
            _nombre = nombre;
            _precio = precio;
            _categorias = categoria;
        }

        public override string ToString()
        {
            return $"{Nombre}, {Precio}, {Categorias}";
        }

    }
}
