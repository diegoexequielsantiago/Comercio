using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TicketDataService
{
    public class Ticket
    {
        //atributos
        public int id { get; }
        public int codigo;
        public string descripcion;
        public decimal precioTotal;
        public DateTime fechaImpresion;
        public int idCliente;
        TipoFactura tipoticket;
        public int idTipoFactura;
        public List<TicketDetalle> listaticketdetalle = new List<TicketDetalle>();

        //Constructor
        public Ticket(string desc, int cod, int cliente, TipoFactura tipof)
        {
            this.descripcion = desc;
            this.codigo = cod;
            this.fechaImpresion = DateTime.Now;
            this.idCliente = cliente;
            this.tipoticket = tipof;
            this.tipoticket.addTicket(this);
            this.idTipoFactura = tipoticket.id;

            //falta calcular precio total acá
        }

        //Constructor con ID

        public Ticket(int idTicket, string desc, int cod, int cliente, TipoFactura tipof)
        {
            this.id = idTicket;
            this.descripcion = desc;
            this.codigo = cod;
            this.fechaImpresion = DateTime.Now;
            this.idCliente = cliente;
            this.tipoticket = tipof;
            this.tipoticket.addTicket(this);
            this.idTipoFactura = tipoticket.id;

            //falta calcular precio total acá
        }

        // metodo para agregar linea detalle al ticket
        public void addTicketDetalle(TicketDetalle detalleticket)
        {
            this.listaticketdetalle.Add(detalleticket);
        }
        public decimal getTotal()
        {

            return this.listaticketdetalle.Sum(d => d.getTotal());
        }

        //To String de la clase ticket
        public override string ToString()
        {
            string imprimir;
            imprimir = ("Codigo:" + this.codigo + " Descripción:" + this.descripcion + " Fecha de Impreción:" + this.fechaImpresion + " Tipo de Ticket:" + this.tipoticket);
            return imprimir;
        }

        // Input: TipoFactura
        // Method: Seteo el TipoFactura que viene como parametro a this clase
        // Output: Devuelvo la clase modificada
        public Ticket setTipoFactura(TipoFactura tipoFactura)
        {
            // Elimino su propio producto a la categoria de la lista de producto antes de reemplazarla
            this.tipoticket.removeTicket(this);
            this.tipoticket = tipoFactura;
            this.tipoticket.addTicket(this);
            this.idTipoFactura = this.tipoticket.id;
            return this;
        }

        public void setTicketDetalle(List<TicketDetalle> listaTicketDetalles)
        {
            this.listaticketdetalle = listaTicketDetalles;     
        }
    }
}
