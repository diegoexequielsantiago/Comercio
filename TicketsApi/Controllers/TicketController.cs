using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketDataService;
using TicketsApi.Models;

namespace TicketsApi.Controllers
{
    public class TicketController : ApiController
    {
        [HttpGet]
        [Route("listaTickets")]
        // input: null
        //method: Llama al servicio el cuál lista los ticket
        //Output: Listado de tickets
        public List<Ticket> ticketListar()
        {
            TicketService.TicketService ticketService = new TicketService.TicketService();
            List<Ticket> listaTickets = ticketService.getAll();
            return listaTickets;
        }

        // input: atributos Ticket
        //method: Llama al servicio el cual agrega Tickets
        //Output: Ticket creado
        [HttpGet]
        [Route("addTicket")]
        public Ticket addTicket(string descripcionTicket, int codigoTicket, int idCliente, int idTipoFactura)
        {
            TicketService.TicketService ticketservice = new TicketService.TicketService();
            TicketService.TipoFacturaService tipofacturaservice = new TicketService.TipoFacturaService();
            TipoFactura  tipofactura= tipofacturaservice.find(idTipoFactura);
            Ticket ticketnew = ticketservice.addTicket( descripcionTicket , codigoTicket , idCliente, tipofactura);
            return ticketnew;
        }

        //input: clase ticketModel
        //Llama al servicio el cual agrega el ticket con todos sus detalles incluidos
        //Devuelvo el ticket con sus detalles
        [HttpPost]
        [Route("addTicketComplete")]
        public Ticket addTicketComplete(TicketComplete ticketCompleto)
        {

            //Servicios Utilizados Ticket, Detalle y TipoFactura
            TicketService.TicketService ticketservice = new TicketService.TicketService();
            TicketService.TipoFacturaService tipofacturaservice = new TicketService.TipoFacturaService();
            TicketService.TicketDetalleService ticketDetalleService = new TicketService.TicketDetalleService();
            //Busco el TipoFactura
            TipoFactura tipoFactura = tipofacturaservice.find(ticketCompleto.idTipoFactura);
            //new de la lista de detalle de tickets
            List<TicketDetalle> listaTicketDetalles = new List<TicketDetalle>();
            //Creo el ticket con la Lista de ticket detalle vacia
            Ticket ticketnew = ticketservice.addTicket(ticketCompleto.descripcion, ticketCompleto.codigo, ticketCompleto.idCliente, tipoFactura, listaTicketDetalles);
            //Recorro la lista de ticket detalleComplete para armar el Ticket detalle y agregarlo a la lista
            foreach (TicketDetalleComplete detalle in ticketCompleto.listaTicketDetalleComplete) 
            {   
                ticketDetalleService.addTicketDetalle(detalle.idProducto, detalle.precioUnitario, detalle.cantidad, ticketnew);
            }
            //devuelto ticket nuevo creado con detalles inclusive
            return ticketnew;
        }


        // input: idTicket
        // method: Busca Ticket de la lista de tickets
        // Output: Devuelve Objeto Ticket
        [HttpGet]
        [Route("findTicket")]
        public Ticket find(int idTicket)
        {
            TicketService.TicketService ticketservice = new TicketService.TicketService();
            Ticket ticketBuscado = ticketservice.find(idTicket);
            return ticketBuscado;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos del Ticket
        //Output: Ticket Modificado
        [HttpGet]
        [Route("updateTicket")]
        public Ticket updateTicket(int idTicket, string descripcionTicket, int codigoTicket, int idCliente)
        {
            TicketService.TicketService ticketservice = new TicketService.TicketService();
            Ticket ticketmodificado = ticketservice.updateTicket(idTicket , descripcionTicket, codigoTicket , idCliente);
            return ticketmodificado;
        }

        // input: idTicket a buscar
        //method: Llama al servicio el cual elimina el Ticket buscado
        //Output: Lista Tickets sin el Eliminado
        [HttpGet]
        [Route("removeTicket")]
        public List<Ticket> removeTicket(int idTicket)
        {
            TicketService.TicketService ticketservice = new TicketService.TicketService();
            ticketservice.removeTicket(idTicket);
            return ticketservice.getAll();


        }
    }
}
