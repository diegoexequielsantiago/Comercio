using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketDataService;

namespace TicketsApi.Controllers
{
    public class TicketDetalleController : ApiController
    {
        [HttpGet]
        [Route("listaTicketDetalles")]
        // input: null
        //method: Llama al servicio el cuál lista los detalles de tickets
        //Output: Listado de tickets detalles
        public List<TicketDetalle> ticketDetalleListar()
        {
            TicketService.TicketDetalleService ticketDetalleService = new TicketService.TicketDetalleService();
            List<TicketDetalle> listaDetalleTickets = ticketDetalleService.getAll();
            return listaDetalleTickets;
        }

        // input: atributos TicketDetalle
        //method: Llama al servicio el cual agrega TicketsDetalle
        //Output: TicketDetalle creado
        [HttpGet]
        [Route("addTicketDetalle")]
        public TicketDetalle addTicketDetalle(int idProductoDetalle, decimal precioUnitarioTicketDetalle, int cantidadTicketDetalle, int idTicket)
        {
            TicketService.TicketService ticketService = new TicketService.TicketService();
            Ticket miTicket = ticketService.find(idTicket);
            TicketService.TicketDetalleService ticketdetalleservice = new TicketService.TicketDetalleService();
            TicketDetalle ticketdetallenew = ticketdetalleservice.addTicketDetalle(idProductoDetalle, precioUnitarioTicketDetalle, cantidadTicketDetalle, miTicket);
            return ticketdetallenew;
        }

        // input: idTicketDetalle
        // method: Busca TicketDetalle de la lista de ticketDetalle
        // Output: Devuelve Objeto TicketDetalle
        [HttpGet]
        [Route("findTicketDetalle")]
        public TicketDetalle find(int idTicketDetalle)
        {
            TicketService.TicketDetalleService ticketDetalleService = new TicketService.TicketDetalleService();
            TicketDetalle ticketDetalleBuscado = ticketDetalleService.find(idTicketDetalle);
            return ticketDetalleBuscado;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos del TicketDetalle
        //Output: TicketDetalle modificado
        [HttpGet]
        [Route("updateTicketDetalle")]
        public TicketDetalle updateTicketDetalle(int idTicketDetalle, decimal precioUnitarioTicketDetalle, int cantidadTicketDetalle )
        {
            TicketService.TicketDetalleService ticketDetalleService = new TicketService.TicketDetalleService();
            TicketDetalle ticketDetalleModificado = ticketDetalleService.updateTicketDetalle(idTicketDetalle , precioUnitarioTicketDetalle , cantidadTicketDetalle);
            return ticketDetalleModificado;
        }

        // Input: idTicketDetalle a buscar
        // Method: Llama al servicio el cual elimina el TicketDetalle buscado
        // Output: Lista TicketDetalles sin el Eliminado
        [HttpGet]
        [Route("removeTicketDetalle")]
        public List<TicketDetalle> removeTicketDetalle(int idTicketDetalle)
        {
            TicketService.TicketDetalleService ticketDetalleService = new TicketService.TicketDetalleService();
            ticketDetalleService.removeTicketDetalle(idTicketDetalle);
            return ticketDetalleService.getAll();


        }
    }
}
