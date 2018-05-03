using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TicketDataService;

namespace TicketsApi.Controllers
{
    public class TipoFacturaController : ApiController
    {
        [HttpGet]
        [Route("listaTipoFacturas")]
        // input: null
        //method: Llama al servicio el cuál lista los Tipos de Factura
        //Output: Listado de tipoFactura
        public List<TipoFactura> tipoFacturaListar()
        {
            TicketService.TipoFacturaService tipoFacturaService = new TicketService.TipoFacturaService();
            List<TipoFactura> listaTipoFacturas = tipoFacturaService.getAll();
            return listaTipoFacturas;
        }

        // input: atributos TipoFactura
        //method: Llama al servicio el cual agrega TipoFacturas
        //Output: Ticket creado
        [HttpGet]
        [Route("addTipoFactura")]
        public TipoFactura addTipoFactura(string descripcionTipoFactura)
        {
            TicketService.TipoFacturaService tipofacturaservice = new TicketService.TipoFacturaService();
            TipoFactura tipofacturanew = tipofacturaservice.addTipoFactura(descripcionTipoFactura);
            return tipofacturanew;
        }

        // input: idTipoFactura
        // method: Busca TipoFactura de la lista de tipoFacturas
        // Output: Devuelve Objeto TipoFactura
        [HttpGet]
        [Route("findTipoFactura")]
        public TipoFactura find(int idTipoFactura)
        {
            TicketService.TipoFacturaService tipoFacturaService = new TicketService.TipoFacturaService();
            TipoFactura tipoFacturaBuscado = tipoFacturaService.find(idTipoFactura);
            return tipoFacturaBuscado;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos del TipoFactura
        //Output: TipoFactura modificado
        [HttpGet]
        [Route("updateTipoFactura")]
        public TipoFactura updateTipoFactura(int idTipoFactura, string descripcionTipoFactura)
        {
            TicketService.TipoFacturaService tipoFacturaService = new TicketService.TipoFacturaService();
            TipoFactura tipoFacturaModificado = tipoFacturaService.updateTipoFactura(idTipoFactura, descripcionTipoFactura);
            return tipoFacturaModificado;
        }

        // Input: idTipoFactura a buscar
        // Method: Llama al servicio el cual elimina el TipoFactura buscado
        // Output: Lista TipoFactura sin el Eliminado
        [HttpGet]
        [Route("removeTipoFactura")]
        public List<TipoFactura> removeTipoFactura(int idTipoFactura)
        {
            TicketService.TipoFacturaService tipoFacturaService = new TicketService.TipoFacturaService();
            tipoFacturaService.removeTipoFactura(idTipoFactura);
            return tipoFacturaService.getAll();


        }
    }
}
