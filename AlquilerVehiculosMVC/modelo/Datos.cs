using System;
using System.Collections;
using System.Collections.Generic;
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
    }


}
