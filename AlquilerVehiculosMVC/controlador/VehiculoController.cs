using AlquilerVehiculosMVC.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerVehiculosMVC.controlador
{
    internal class VehiculoController
    {
        Datos datos;

        public VehiculoController(Datos datos)
        {
            this.datos = datos;
        }
    }
}
