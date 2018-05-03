using System;
using System.Collections.Generic;
using System.Text;

namespace TicketDataService
{
    public class TicketDetalle
    {
        //atributos

        public int id { get; }
        public int idproducto;
        Ticket ticket;
        public int cantidad;
        public decimal preciounitario;
        public int idTicket;


        //constructor con ID
        public TicketDetalle(int id, int idProductoDetalle, decimal preciou, int cant, Ticket miticket)
        {
            this.id = id;
            this.idproducto = idProductoDetalle;
            this.preciounitario = preciou;
            this.cantidad = cant;
            this.ticket = miticket;
            this.ticket.addTicketDetalle(this);
            this.idTicket = ticket.id;

        }

        //obtengo el precio total del detalle, es decir precio unitario más cantidad
        public decimal getTotal()
        {
            return this.preciounitario + cantidad;
        }
        //To String de Ticket Detalle
        public override string ToString()
        {
            string imprimir;
            imprimir = ("Precio Unitario:" + this.preciounitario + " cantidad:" + this.cantidad);
            return imprimir;
        }

    }
}
