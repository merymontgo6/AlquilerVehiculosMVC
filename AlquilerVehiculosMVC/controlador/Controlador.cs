using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerVehiculosMVC.vista;
using AlquilerVehiculosMVC.modelo;
using System.Collections;

namespace AlquilerVehiculosMVC.controlador
{
    internal class Controlador
    {
        Datos datos;
        View vista;

        public Controlador(Datos datos, View vista)
        {
            this.datos = datos;
            this.vista = vista;
        }
        public Controlador()
        {
            datos = new Datos();
            vista = new View();
        }
        public void gestionMenu()
        {
            bool salir = false;
            string opcion;
         
            do
            {
                opcion = vista.vistaMenu();
                switch (opcion)
                {
                    case "1":
                        altaVehiculo();
                        break;
                    case "2":
                        altaCliente();
                        break;
                    case "3":
                        mostrarVehiculos();
                        break;
                    case "4":
                        mostrarClientes();
                        break;
                    case "5":
                        mostrarVehiculoByTipo();
                        break;
                    case "0":
                        salir = true;
                        break;
                }

            } while (!salir);
        }

        private void altaVehiculo() //métodos privados pq son solo del controlador
        {
            int tipoVehiculo;
            tipoVehiculo = VehiculosView.seleccionarTipoVehiculo();
            Hashtable vehiculoHash;

            switch (tipoVehiculo)
            {
                case 1:
                    vehiculoHash = VehiculosView.addVehiculo(tipoVehiculo);
                    datos.addCoche(vehiculoHash);
                    break;

                case 2:
                    vehiculoHash = VehiculosView.addVehiculo(tipoVehiculo);
                    datos.addMoto(vehiculoHash);
                    break;

                case 3:
                    vehiculoHash = VehiculosView.addVehiculo(tipoVehiculo);
                    datos.addCamion(vehiculoHash);
                    break;
            }
        }

        private void altaCliente() //métodos privados pq son solo del controlador
        {
            Hashtable clienteHash;

            clienteHash = ClienteView.addCliente();
            datos.addCliente(clienteHash);

            //Se puede hacer en la misma línea, es decir:
            //Hastable clienteHash = ClienteView.addCliente();
        }

        private void mostrarClientes()
        {
            ClienteView.mostrarClientes(datos.listaClientes());
        }

        private void mostrarVehiculos()
        {
            VehiculosView.mostrarVehiculos(datos.listaVehiculos());
        }

        private void mostrarVehiculoByTipo()
        {
            int tipoVehiculo;
            tipoVehiculo = VehiculosView.seleccionarTipoVehiculo();
            List<string> listaVehiculos = datos.listaVehiculosByTipo(tipoVehiculo);
            VehiculosView.mostrarVehiculos(listaVehiculos);

            //VehiculosView.mostrarVehiculos(datos.listaVehiculosByTipo(tipoVehiculo));
        }
    }
}

