using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDataService
{
    public class Localidad
    {
        //atributos

        public int id { get; }
        public int codigoPostal;
        // public int id { set; private get;                     } Caso raro set publico get privado. Normalmente se da lo contrario
        public string descripcion;
        public List<Cliente> listaClientes = new List<Cliente>();

        //constructor con ID
        public Localidad(int id, int cod, string desc)
        {
            this.descripcion = desc;
            this.codigoPostal = cod;
            this.id = id;
        }

        //constructor sin ID
        public Localidad( int cod, string desc)
        {
            this.descripcion = desc;
            this.codigoPostal = cod;
          
        }
        //agrego un cliente a la lista localidades
        public void addCliente(Cliente cliente)
        {
            this.listaClientes.Add(cliente);

        }

        //Elimino un cliente a la lista localidades
        public void removeCliente(Cliente cliente)
        {
            this.listaClientes.Remove(cliente);

        }

        //to String de Localidad
        public override string ToString()
        {
            string imprimir;
            imprimir = (this.descripcion + this.codigoPostal);
            return imprimir;
        }
    }
}
