using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_P3.Models
{
    internal class Empleados
    {
    }

    public class Empleado
    {
        public int empleadoID { get; set; }
        public string nombreEmpleado { get; set; }
        public string cargoEmpleado { get; set; }
        public int edadEmpleado { get; set; }
        public double sueldoEmpleado { get; set; }
        public int sedeID { get; set; }
        public object sede { get; set; }
    }
}
