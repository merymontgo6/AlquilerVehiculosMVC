using AlquilerVehiculosMVC.modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculosMVC.vista
{
    internal  static class ClienteView
    {
        public  static Hashtable addCliente()
        {
            Hashtable clienteHash = new Hashtable();

            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine();

            Console.WriteLine("Nif: ");
            string nif = Console.ReadLine();

            clienteHash.Add("Nombre", nombre);
            clienteHash.Add("Nif", nif);

            return clienteHash;
        }



        public static void mostrarClientes(List<string> listaClientes)
        {
            Console.WriteLine("Nif:\tNombre:");
            
            foreach (string cliente in listaClientes)
            {
                Console.WriteLine(cliente);
            }
        }
    }
}
