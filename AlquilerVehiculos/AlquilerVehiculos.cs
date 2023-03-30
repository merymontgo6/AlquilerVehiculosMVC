using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculos
{
    internal class AlquilerVehiculos
    {

        public void inicio()
        {
           
            VehiculosRent vehiculosRent = new VehiculosRent();

            bool salir = false;
            string opcion;
            do
            {
                Console.WriteLine("1. Crear vehiculos");
                Console.WriteLine("2. Mostrar vehiculos");
                Console.WriteLine("3. Mostrar solo coches");
                Console.WriteLine("4. Eliminar vehiculo");
                Console.WriteLine("5. Alta contrato");
                Console.WriteLine("6. Listar contratos");
                Console.WriteLine("7. Grabar clientes en CSV");
                Console.WriteLine("8. Leer fichero CSV y mostrar por pantalla");
                Console.WriteLine("9. Cargar fichero CSV");
                Console.WriteLine("10. Mostrar Clientes");
                Console.WriteLine("0. Salir");
                opcion = pedirOpcionMenu();
                switch (opcion)
                {
                    case "1":
                        crearVehiculos(vehiculosRent);
                        break;
                    case "2":
                        mostrarVehiculos(vehiculosRent);
                        break;
                    case "3":
                        mostrarSoloCoches(vehiculosRent);
                        break;
                    case "4":
                        eliminarVehiculo(vehiculosRent);
                        break;
                    case "5":
                        altaContrato(vehiculosRent);
                        break;
                    case "6":
                        listarContratos(vehiculosRent);
                        break;
                    case "7":
                        grabarCSV(vehiculosRent);
                        break;
                    case "8":
                        leerCSV(vehiculosRent);
                        break;
                    case "9":
                        cargarCSVenList(vehiculosRent);
                        break;
                    case "10":
                        mostrarClientes(vehiculosRent);
                        break;
                    case "0":
                        salir = true;
                        break;
                }

            } while (!salir);
        }

        string pedirOpcionMenu()
        {
            string opcion;
            do
            {
                Console.Write("Opcion: ");
                opcion = Console.ReadLine();
            } while (!"012345678910".Contains(opcion));

            return opcion;

        }

        public void crearVehiculos(VehiculosRent vehiculosRent)
        {

            Coche coche1 = new Coche();
            coche1.Matricula = "1111ZZZ";
            coche1.Marca = "Nisan";
            coche1.Model = "Juke";
            coche1.Puertas = 5;


            Moto moto1 = new Moto();
            moto1.Matricula = "2222XXX";
            moto1.Marca = "Ducati";
            moto1.Model = "Panigale R";
            moto1.Cc = 1199;

            Camion camion1 = new Camion();
            camion1.Matricula = "3333YYY";
            camion1.Marca = "Mercedes";
            camion1.Model = "K1";
            camion1.Kg = 2500;

            Flota flota = new Flota();
            flota.NombreZona = "Zaragoza";

            flota.addVehiculos(coche1);
            flota.addVehiculos(moto1);
            flota.addVehiculos(camion1);

            if (vehiculosRent.addFlota(flota) >= 0)
            {
                Console.WriteLine("\nLa flota se ha añadido correctamente\n");
            }
            else { Console.WriteLine("\nERROR: La flota NO ha añadido correctamente\n"); }

            Cliente cliente1 = new Cliente();
            cliente1.Nif = "11111111A";
            cliente1.Nombre = "Josep";

            Cliente cliente2 = new Cliente();
            cliente2.Nif = "22222222B";
            cliente2.Nombre = "Ricardo";

            vehiculosRent.addCliente(cliente1);
            vehiculosRent.addCliente(cliente2);

            Agencia agencia = new Agencia();
            agencia.Nombre = "Agencia Lepanto";
            agencia.Flota = flota;
            vehiculosRent.addAgencia(agencia);


        }
        public void altaContrato(VehiculosRent vehiculosRent)
        {
            string nif, matricula, fechaInicio, fechaFin;
            Cliente cliente;
            Agencia agencia;
            Vehiculo vehiculo;
            Decimal precio;
            agencia = vehiculosRent.getAgenciaByNombre("Agencia Lepanto");

            Console.Write("Nif del cliente: ");
            nif = Console.ReadLine();
            cliente = vehiculosRent.getClienteByNif(nif);
            if(cliente == null)
            {
                Console.WriteLine("El cliente no existe");
            }
            else
            {
                Console.WriteLine("Bienvenido/a " + cliente.Nombre);
                Console.Write("\nMatricula: ");
                matricula = Console.ReadLine();
                vehiculo = agencia.Flota.getVehiculoByMatricula(matricula);
                if(vehiculo == null)
                {
                    Console.WriteLine("El vehiculo no existe");
                }
                else
                {
                    Console.Write("Fecha inicio: ");
                    fechaInicio = Console.ReadLine();
                    Console.Write("Fecha fin: ");
                    fechaFin = Console.ReadLine();
                    Console.Write("Precio: ");
                    precio = Decimal.Parse(Console.ReadLine()); 

                    ContratoAlquiler contrato = new ContratoAlquiler();
                    contrato.Cliente = cliente;
                    contrato.Vehiculo = vehiculo;
                    contrato.FechaInicio = DateTime.Parse(fechaInicio);
                    contrato.FechaFin = DateTime.Parse(fechaFin);
                    contrato.PrecioDia = precio;    

                    agencia.addContrato(contrato);
                }
            }
        }
        public void listarContratos(VehiculosRent vehiculosRent)
        {
            foreach(Agencia agencia in vehiculosRent.Agencias)
            {
                foreach(ContratoAlquiler contratoAlquiler in agencia.ListaContratos)
                {
                    Console.WriteLine("Nombre:" + contratoAlquiler.Cliente.Nombre );
                    Console.WriteLine("Matricula:" + contratoAlquiler.Vehiculo.Matricula);
                    Console.WriteLine("Fecha Inicio:" + contratoAlquiler.FechaInicio);
                    Console.WriteLine("Fecha Fin:" + contratoAlquiler.FechaFin);
                    Console.WriteLine("Precio:" + contratoAlquiler.PrecioDia);
                    Console.WriteLine("Total dias: " + contratoAlquiler.nDias());
                    Console.WriteLine("Coste total: " + contratoAlquiler.costeTotal());

                    Console.WriteLine(contratoAlquiler);

                }

            }

        }
        public void mostrarVehiculos(VehiculosRent vehiculosRent)
        {
            Console.WriteLine();
            foreach (Flota flota in vehiculosRent.Flotas)
            {
                foreach (Vehiculo veh in flota.getVehiculos())
                {
                    Console.WriteLine(veh.ToString());
                }
            }
            Console.WriteLine();
        }
        public void mostrarSoloCoches(VehiculosRent vehiculosRent)
        {
            Console.WriteLine();
            foreach (Flota flota in vehiculosRent.Flotas)
            {
                foreach (Vehiculo vehiculo in flota.getVehiculos())
                {
                    if (vehiculo is Coche)
                    {
                        Console.WriteLine(vehiculo.ToString());
                    }
                }
            }
            Console.WriteLine();
        }
        public void eliminarVehiculo(VehiculosRent vehiculosRent)
        {
            string matricula;

            Console.Write("Matricula: ");
            matricula = Console.ReadLine();

            foreach (Flota flota in vehiculosRent.Flotas)
            {
                if (flota.removeVehiculo(matricula))
                {
                    Console.WriteLine("El vehiculo se ha eliminado de la flota " + flota.NombreZona);
                }
            }
        }

        public void grabarCSV(VehiculosRent vehiculosRent)
        {
            StreamWriter fitxer = new StreamWriter(@"c:\CSV\clientes.csv");
            // Escrivim les dades de l'array en format CSV
            string texto = "";

            foreach (Cliente cliente in vehiculosRent.ListaClientes)
            {
                texto = cliente.Nif + "," + cliente.Nombre;
                fitxer.WriteLine(texto);
            }

            fitxer.Close();

            Console.WriteLine("Les dades s'han escrit al fitxer.");
        }

        public void leerCSV(VehiculosRent vehiculosRent)
        {
            string fichero = @"C:\csv\clientes.csv";
            StreamReader archivo = new StreamReader(fichero);
            string linea;
            // Si el archivo no tiene encabezado, elimina la siguiente línea

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

        public void cargarCSVenList(VehiculosRent vehiculosRent)
        {
            vehiculosRent.ListaClientes.Clear();
            Cliente cliente;

            string fichero = @"C:\csv\clientes.csv";
            StreamReader archivo = new StreamReader(fichero);
            string linea;
            linea = archivo.ReadLine();
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(',');
                cliente = new Cliente();
                cliente.Nif = fila[0];
                cliente.Nombre = fila[1];
                vehiculosRent.addCliente(cliente);
            }
        }

        public void mostrarClientes(VehiculosRent vehiculosRent)
        {
            foreach (Cliente cliente in vehiculosRent.ListaClientes)
            {
                Console.WriteLine(cliente.Nif + "\t" + cliente.Nombre);
            }

        }
    }

}

