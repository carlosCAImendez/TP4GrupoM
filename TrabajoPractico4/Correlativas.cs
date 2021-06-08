using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPractico4
{
    class Correlativas
    {
        public int nroMateria { get; set; }
        public int correlativa1 { get; set; }
        public int correlativa2 { get; set; }

        public Correlativas(int nroMateria, int correlativa1, int correlativa2)
        {
            this.nroMateria = nroMateria;
            this.correlativa1 = correlativa1;
            this.correlativa2 = correlativa2;

        }

        public static List<Correlativas> ListaCorrelativas()
        {
            List<Correlativas> ListadeCorrelativas = new()
            {
                new Correlativas(1275,0,0), //int a las tecn
                new Correlativas(651,1275,0), // logica
                new Correlativas(658,1275,0), // Metodologia
                new Correlativas(1601,1275,0), //Ingenieria de software
                new Correlativas(1653,1275,0), //tecno de los computadores
                new Correlativas(655,1653,0), //Tecno de las comunicaciones
                new Correlativas(1652,651,0), // teoria de los leng
                new Correlativas(1654,1652,0), // CAI
                new Correlativas(657,651,0),  //Sistemas de datos
                new Correlativas(1659,658,0), //Auditoria
                new Correlativas(740,655,0), // Redes
                new Correlativas(1799,1601,0), // Gestion de recursos informaticos
                new Correlativas(1660,1654,740) // act prof.



            };



            return ListadeCorrelativas;
        }

    }
}
