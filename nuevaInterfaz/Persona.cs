using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nuevaInterfaz
{
    class Persona
    {
        private string nombre;
        private string rut;
        private int edad;

        public Persona(string nombre, string rut, int edad)
        {
            this.nombre = nombre;
            this.rut = rut;
            this.edad = edad;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Rut { get => rut; set => rut = value; }
        public int Edad { get => edad; set => edad = value; }

        //método ToString() sobre escrito, de ésta manera, cuando visualizemos el objeto, se mostrará con el formato que retorne
        public override string ToString()
        {
            string mostrar = String.Format("{0}, {1}, {2}", Nombre, Rut, Edad);
            return mostrar;
        }
    }
}
