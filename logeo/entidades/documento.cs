using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logeo.entidades
{
    public class documento
    {
        int ident;

        public int Ident
        {
            get { return ident; }
            set { ident = value; }
        }

        string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

    }
    public class centro
    {
        int identcentro;

        public int Identcentro
        {
            get { return identcentro; }
            set { identcentro = value; }
        }

        string nombrecentro;

        public string Nombrecentro
        {
            get { return nombrecentro; }
            set { nombrecentro = value; }
        }

    }
}