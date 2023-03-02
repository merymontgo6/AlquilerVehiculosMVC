using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlquilerVehiculosMVC.vista;
using AlquilerVehiculosMVC.modelo;

namespace AlquilerVehiculosMVC.controlador
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //NO HACE FALTA ESTO PORQUE SE REALIZA AL PRINCIPIO DEL COMPILADOR
            //View vista = new View();
            //Datos modelo = new Datos();
            //Controlador controlador = new Controlador(modelo, vista);
            //controlador.gestionMenu();



            Controlador controlador = new Controlador();
            controlador.gestionMenu();

            //Con el new se crea un objeto
            //Una vez el objeto es creado se envía por parámetros al controlador
            //El controlador los recibe y ya se puede mencionar los objetos para acceder a los métodos
            //Ejemplo: controlador: datos.ListaClientes(); es pq datos es un objeto que se ha creado y enviado que ahora puede ser mencionado en otras clases.
        }
    }
}
