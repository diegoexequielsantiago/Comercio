using System;
using System.Collections.Generic;
using System.Text;
using TicketDataService;
using System.Linq;

namespace TicketService
{
    public class TicketService
    {
        //Método para obtener listado de tickets
        public List<Ticket> getAll()
        {
            return ConectionFactory.getBaseTickets().listaTickets;
        }

        // input: Atributos Ticket
        // method: Crea un Ticket en la base con los atributos pasados por parámetro
        // Output: Devuelto dicho Ticket creado
        public Ticket addTicket(string descripcion, int codigo, int idCliente, TipoFactura tipofactura)
        {
            List<Ticket> listaTickets =  ConectionFactory.getBaseTickets().listaTickets;
            Ticket ticketnew = new Ticket(listaTickets.Count, descripcion, codigo , idCliente , tipofactura);
            listaTickets.Add(ticketnew);
            tipofactura.addTicket(ticketnew);
            return ticketnew;
        }

        // input: Atributos Ticket
        // method: Crea un Ticket en la base con los atributos pasados por parámetro
        // Output: Devuelto dicho Ticket creado
        public Ticket addTicket(string descripcion, int codigo, int idCliente, TipoFactura tipofactura, List<TicketDetalle> listaTicketDetalle)
        {
            List<Ticket> listaTickets = ConectionFactory.getBaseTickets().listaTickets;
            Ticket ticketnew = new Ticket(listaTickets.Count, descripcion, codigo, idCliente, tipofactura);
            listaTickets.Add(ticketnew);
            tipofactura.addTicket(ticketnew);
            ticketnew.setTicketDetalle(listaTicketDetalle);
            return ticketnew;
        }

        // input: idTicket
        // method: Busca Ticket
        // Output: Devuelve Objeto buscado
        public Ticket find(int idTicket)
        {
            List<Ticket> listaTickets = ConectionFactory.getBaseTickets().listaTickets;
            return listaTickets.FirstOrDefault(ticket => (ticket.id == idTicket));
        }

        // input: Atributos de Ticket a actualizar
        // method: Crea un Ticket en la base con los atributos pasados por parámetro
        // Output: Devuelve dicho Ticket
        public Ticket updateTicket(int idTicket, string descripcionTicket, int codigoTicket, int idCliente)
        {
            Ticket ticket = this.find(idTicket);
            //atributos a actualizar
            ticket.codigo = codigoTicket;
            ticket.descripcion = descripcionTicket;
            ticket.idCliente = idCliente;
            return ticket;

        }

        // input: Ticket a eliminar
        // method: elimina el ticket de la DB
        // Output: Ticket eliminado
        public List<Ticket> removeTicket(int idTicket)
        {
            //Busco el Ticket a eliminar
            Ticket ticketBuscado = this.find(idTicket);
            //remuevo al ticket de la lista de Tickets del TipoFactura
            TipoFacturaService tipoFacturaService = new TipoFacturaService();
            TipoFactura tipoFacturaTicket = tipoFacturaService.find(ticketBuscado.idTipoFactura);
            tipoFacturaTicket.removeTicket(ticketBuscado);
            //Remuevo el Ticket de la lista de Tickets
            ConectionFactory.getBaseTickets().listaTickets.Remove(ticketBuscado);
            return ConectionFactory.getBaseTickets().listaTickets;

        }

        // input: Tipo Factura a eliminar de la lista de Tickets
        // method: Recorro la lista de tickets borrando el TipoFactura eliminado a los tickets que pertenescan a la misma
        // Output: 
        public void eliminarTipoFactura(TipoFactura tipoFacturaEliminado)
        {
            // Obtengo listado de Tickets
            List<Ticket> listaTickets = this.getAll();
            // Busco el TipoFactura con descripción de "el TipoFactura fue eliminado que tiene el ID=0"
            TipoFacturaService tipoFacturaService = new TipoFacturaService();
            TipoFactura tipoFacturaNulo = tipoFacturaService.find(0);
            // Recorro listado de Tickets
            for (int i = 0; i < listaTickets.Count; i++)
            {
                //Variable local del indice
                Ticket ticketlocal = listaTickets[i];
                //Pregunto si el tipoFactura eliminado es el del cliente 
                if (ticketlocal.idTipoFactura == tipoFacturaEliminado.id)
                {
                    ticketlocal.setTipoFactura(tipoFacturaNulo);
                }

            }

        }


    }
}
