using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculosMVC.vista
{
    internal class View
    {

        public string vistaMenu()
        {
            string opcion;
            Console.WriteLine("1. Alta vehiculos");
            Console.WriteLine("2. Alta clientes");
            Console.WriteLine("3. Mostrar vehiculos");
            Console.WriteLine("4. Mostrar clientes");
            Console.WriteLine("5. Mostrar vehiculos por tipo");
            Console.WriteLine("6. Grabar CSV vehiculos");
            Console.WriteLine("7. Leer CSV vehiculos");
            Console.WriteLine("8. Cargar CSV vehiculos");
            Console.WriteLine("0. Salir");
            opcion = pedirOpcionMenu();
            return opcion;
        }

        private string pedirOpcionMenu()
        {
            string opcion;
            do
            {
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();
            } while (!"0123456789".Contains(opcion));

            return opcion;

        }
    }
}
