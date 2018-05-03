using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketsApi.Models
{

    public class TicketComplete
    {
        //Atributos
        public string descripcion;
        public int codigo;
        public int idCliente;
        public int idTipoFactura;
        public List<TicketDetalleComplete> listaTicketDetalleComplete = new List<TicketDetalleComplete>();

        //constructor vacio
        public TicketComplete()
        {
           
        }

        //constructor
        public TicketComplete (string descripcionTicketComplete, int codigoTicketComplete , int idClienteTicketComplete, int idTipoFacturaTicketComplete, List<TicketDetalleComplete> listaDetalles)
        {
            this.descripcion = descripcionTicketComplete;
            this.codigo = codigoTicketComplete;
            this.idCliente = idClienteTicketComplete;
            this.idTipoFactura = idTipoFacturaTicketComplete;
            this.listaTicketDetalleComplete = listaDetalles;
        }
    }

    public class TicketDetalleComplete

    {
        //Atributos
        public int idProducto;
        public int cantidad;
        public decimal precioUnitario;

        //Constructor
        public TicketDetalleComplete (int idProductoTicketDetalleComplete, int cantidadTicketDetalleComplete, decimal precioUnitarioTicketDetalleComplete)
        {
            this.idProducto = idProductoTicketDetalleComplete;
            this.cantidad = cantidadTicketDetalleComplete;
            this.precioUnitario = precioUnitarioTicketDetalleComplete;
        }
    }
}