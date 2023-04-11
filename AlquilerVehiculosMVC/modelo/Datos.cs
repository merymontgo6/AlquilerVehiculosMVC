using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculosMVC.modelo
{
    internal class Datos
    {
        List<Vehiculo> vehiculos;
        List<Cliente> clientes;

        public Datos() //Constructor 
        {
            vehiculos = new List<Vehiculo>();
            clientes = new List<Cliente>();
        }

        public List<string> listaClientes()
        {
            List<string> listaclientes = new List<string>();
            foreach (Cliente cliente in clientes)
            {
                listaclientes.Add(cliente.ToString());
            }
            return listaclientes;
        }

        public List <string> listaVehiculos()
        {
            List<string> listaVehiculos = new List<string>();
            foreach(Vehiculo vehiculo in vehiculos)
            {
                listaVehiculos.Add(vehiculo.Matricula + "\t" + vehiculo.Marca + "\t" + vehiculo.Model + "\t" + vehiculo.GetType().Name); 
                //El GetType te dice el nombre de la clase, en este caso muestra el tipo como Coche, Moto o Camión.
            }
            return listaVehiculos;
        }

        public List<string> listaVehiculosByTipo(int tipo)
        {
            List <string> vehiculoEncontrado = new List<string>();

            switch(tipo)
            {
                case 1:
                    foreach(Vehiculo vehiculo in vehiculos)
                    {
                        if (vehiculo is Coche)
                        {
                            vehiculoEncontrado.Add(vehiculo.ToString());
                        }
                    }
                    break;
                case 2:
                    foreach (Vehiculo vehiculo in vehiculos)
                    {
                        if (vehiculo is Moto)
                        {
                            vehiculoEncontrado.Add(vehiculo.ToString());
                        }
                    }
                    break;
                case 3:
                    foreach (Vehiculo vehiculo in vehiculos)
                    {
                        if (vehiculo is Camion)
                        {
                            vehiculoEncontrado.Add(vehiculo.ToString());
                        }
                    }
                    break;
            }
            return vehiculoEncontrado;
        }

        public void addCliente(Hashtable clienteHash)
        {
            Cliente cliente = new Cliente();
            cliente.Nombre = (string)clienteHash["Nombre"];
            cliente.Nif = (string)clienteHash["Nif"];
            clientes.Add(cliente); 
        }

        public void addCoche(Hashtable vehiculoHash)
        {
            Coche coche = new Coche();
            coche.Matricula = (string)vehiculoHash["Matricula"];
            coche.Marca = (string)vehiculoHash["Marca"];
            coche.Model = (string)vehiculoHash["Model"];
            coche.Puertas = (int)vehiculoHash["Puertas"];
            coche.Plazas = (int)vehiculoHash["Plazas"];
            vehiculos.Add(coche);
        }
        public void addMoto(Hashtable vehiculoHash)
        {
            Moto moto = new Moto();
            moto.Matricula = (string)vehiculoHash["Matricula"];
            moto.Marca = (string)vehiculoHash["Marca"];
            moto.Model = (string)vehiculoHash["Model"];
            moto.Cc = (int)vehiculoHash["cc"];

            vehiculos.Add(moto);
        }
        public void addCamion(Hashtable vehiculoHash)
        {
            Camion camion = new Camion();
            camion.Matricula = (string)vehiculoHash["Matricula"];
            camion.Marca = (string)vehiculoHash["Marca"];
            camion.Model = (string)vehiculoHash["Model"];
            camion.Kg = (int)vehiculoHash["kg"];

            vehiculos.Add(camion);
        }

        public void grabarCSV()
        {
            StreamWriter fitxer = new StreamWriter(@"c:\CSV\vehiculos.csv");
            
            string texto = "";

            foreach (Vehiculo vehiculo in vehiculos)
            {
                texto = vehiculo.Matricula + "," + vehiculo.Marca + "," + vehiculo.Model + "," + vehiculo.GetType().Name;
                if (vehiculo is Coche)
                {
                    
                }
                fitxer.WriteLine(texto);
            }

            fitxer.Close();
        }

        public void cargarCSV()
        {
            vehiculos.Clear();
            Vehiculo vehiculo;

            string fichero = @"C:\csv\vehiculos.csv";
            StreamReader archivo = new StreamReader(fichero);
            string linea;
            linea = archivo.ReadLine();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(',');
                vehiculo = new Vehiculo();
                vehiculo.Matricula = fila[0];
                vehiculo.Marca = fila[1];
                vehiculo.Model = fila[2];
                vehiculos.Add(vehiculo);
            }
        }
    }
}
