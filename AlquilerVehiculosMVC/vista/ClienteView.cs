using AlquilerVehiculosMVC.controlador;
using AlquilerVehiculosMVC.modelo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculosMVC.vista
{
    internal   class ClienteView
    {
        ClienteController clienteController;
        public ClienteView(ClienteController clienteController)
        {
            this.clienteController = clienteController;
        }
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

        public void leerCSV()
        {
            string fichero = @"C:\csv\clientes.csv";
            StreamReader archivo = new StreamReader(fichero);
            string linea;

            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(',');

                for (int i = 0; i < fila.Length; i++)
                {
                    Console.Write(fila[i] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
