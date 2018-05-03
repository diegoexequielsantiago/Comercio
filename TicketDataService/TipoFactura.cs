using System;
using System.Collections.Generic;
using System.Text;

namespace TicketDataService
{
    public class TipoFactura
    {
        //atributos

        public int id { get; }
        public string descripcion;
        List<Ticket> listatickets = new List<Ticket>();

        //constructor con ID
        public TipoFactura(int id, string desc)
        {
            this.descripcion = desc;
            this.id = id;
        }
        //constructor sin ID
        public TipoFactura(string desc)
        {
            this.descripcion = desc;
         
        }


        //Agrego un ticket a la lista, relación uno a muchos
        public void addTicket(Ticket factura)
        {
            this.listatickets.Add(factura);
        }
        //To String de la clase Tipo Factura
        public override string ToString()
        {
            string imprimir;
            imprimir = ("Descripción:" + this.descripcion);
            return imprimir;
        }

        //Elimino un Ticket a la lista de TipoFactura
        public void removeTicket(Ticket ticket)
        {
            this.listatickets.Remove(ticket);

        }

    }
}
