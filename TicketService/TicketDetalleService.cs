using System;
using System.Collections.Generic;
using System.Text;
using TicketDataService;
using System.Linq;

namespace TicketService
{
    public class TicketDetalleService
    {
        //metodo para obtener listado de TipoFactura de la ba
        public List<TicketDetalle> getAll()
        {
            return ConectionFactory.getBaseTickets().listaTicketDetalle;
        }


        // input: Atributos del DetalleTicket
        // method: Crea una DetalleTicket en la base con los atributos pasados por parámetro
        // Output: Devuelto dicho DetalleTicket creado
        public TicketDetalle addTicketDetalle (int idProducto, decimal preciounitario, int cantidad, Ticket miticket)
        {
            List<TicketDetalle> listaTicketDetalle = ConectionFactory.getBaseTickets().listaTicketDetalle;
            TicketDetalle ticketdetallenew = new TicketDetalle(listaTicketDetalle.Count, idProducto , preciounitario, cantidad, miticket);
            listaTicketDetalle.Add(ticketdetallenew);
            return ticketdetallenew;
        }

        // input: idTicketDetalle
        // method: Busca TicketDetalle
        // Output: Devuelve Objeto buscado
        public TicketDetalle find(int idTicketDetalle)
        {
            List<TicketDetalle> listaTicketDetalles = ConectionFactory.getBaseTickets().listaTicketDetalle;
            return listaTicketDetalles.FirstOrDefault(TicketDetalle => (TicketDetalle.id == idTicketDetalle));
        }

        // input: Atributos de TicketDetalle a actualizar
        // method: Crea un TicketDetalle en la base con los atributos pasados por parámetro
        // Output: Devuelve dicho TicketDetalle
        public TicketDetalle updateTicketDetalle(int idTicketDetalle, decimal precioUnitarioTicketDetalle, int cantidadTicketDetalle)
        {
            TicketDetalle ticketDetalle = this.find(idTicketDetalle);
            //atributos a actualizar
            ticketDetalle.preciounitario = precioUnitarioTicketDetalle;
            ticketDetalle.cantidad = cantidadTicketDetalle;
            return ticketDetalle;

        }

        // input: TicketDetalle a eliminar
        // method: elimina el TicketDetalle de la DB
        // Output: TicketDetalle eliminado
        public List<TicketDetalle> removeTicketDetalle(int idTicketDetalle)
        {
            //Busco el TicketDetalle a eliminar
            TicketDetalle ticketDetalleBuscado = this.find(idTicketDetalle);
            //Remuevo el Ticket de la lista de TicketDetalles
            ConectionFactory.getBaseTickets().listaTicketDetalle.Remove(ticketDetalleBuscado);
            return ConectionFactory.getBaseTickets().listaTicketDetalle;

        }
    }
}
