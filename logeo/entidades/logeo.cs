using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace logeo.entidades
{
    public class Entidades
    {

        int ident;

        public int Ident
        {
            get { return ident; }
            set { ident = value; }
        }

        int centro;

        public int Centro
        {
            get { return centro; }
            set { centro = value; }
        }


        string txtusuario;

        public string Usuario
        {
            get { return txtusuario; }
            set { txtusuario = value; }
        }

        string txtclave;

        public string Clave
        {
            get { return txtclave; }
            set { txtclave = value; }
        }

        string txtfecha_nac;

        public string FechaNacimiento
        {
            get { return txtfecha_nac; }
            set { txtfecha_nac = value; }
        }

        string ip;

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        int reseteado;

        public int Reseteado
        {
            get { return reseteado; }
            set { reseteado = value; }
        }

        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string asunto_mail;

        public string Asunto_mail
        {
            get { return asunto_mail; }
            set { asunto_mail = value; }
        }

        string mensaje_mail;

        public string Mensaje_mail
        {
            get { return mensaje_mail; }
            set { mensaje_mail = value; }
        }

        string ruta;

        public string Ruta
        {
            get { return ruta; }
            set { ruta = value; }
        }

        string remitente;

        public string Remitente
        {
            get { return remitente; }
            set { remitente = value; }
        }
    }
}