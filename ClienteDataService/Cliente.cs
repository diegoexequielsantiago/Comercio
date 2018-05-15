using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDataService
{
    public class Cliente
    {
        //atributos
        public int id { get; }
        public int numeroCliente { get; }
        public string nombreCompleto;
        public string telefono;
        public string direccion;
        public string correo;
        Localidad Localidad;
        public int idlocalidad { get; set; }

        //constructor        
        private Cliente(int numero, string nombre, Localidad loc)
        {
            this.numeroCliente = numero;
            this.Localidad = loc;
            this.Localidad.addCliente(this);
            this.nombreCompleto = nombre;
            this.idlocalidad = Localidad.id;
        }

        //Constructor Completo       
        public Cliente(int numeroC, string nombre, string tel, string dir, string mail, Localidad loc)
        {
            this.numeroCliente = numeroC;
            this.Localidad = loc;
            this.Localidad.addCliente(this);
            this.nombreCompleto = nombre;
            this.idlocalidad = Localidad.id;
            this.telefono = tel;
            this.direccion = dir;
            this.correo = mail;
        }

        //constructor con ID        
        public Cliente(int idCliente, int numero, string nombre, Localidad loc)
        {
            this.id = idCliente;
            this.numeroCliente = numero;
            this.Localidad = loc;
            this.Localidad.addCliente(this);
            this.nombreCompleto = nombre;
            this.idlocalidad = Localidad.id;
        }

        //Constructor Completo con ID
        public Cliente(int idCliente, int numeroC, string nombre, string tel, string dir, string mail, Localidad loc)
        {
            this.id = idCliente;
            this.numeroCliente = numeroC;
            this.Localidad = loc;
            this.Localidad.addCliente(this);
            this.nombreCompleto = nombre;
            this.idlocalidad = Localidad.id;
            this.telefono = tel;
            this.direccion = dir;
            this.correo = mail;
        }
        //To String de la clase Cliente
        public override string ToString()
        {
            string imprimir;
            imprimir = (this.nombreCompleto);
            return imprimir;
        }

        // Input: Localidad           
        // Method: Seteo la localidad  que viene como parametro a this clase
        // Output: Devuelvo la clase modificada      
        public Cliente setLocalidad(Localidad loc)
        {
            // Elimino su propio cliente a la localidad de la lista de clientes antes de reemplazarla
            this.Localidad.removeCliente(this);
            this.Localidad = loc;
            this.Localidad.addCliente(this);
            this.idlocalidad = this.Localidad.id;
            return this;
        }

    }
}