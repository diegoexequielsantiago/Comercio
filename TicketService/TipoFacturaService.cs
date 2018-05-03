using System;
using System.Collections.Generic;
using System.Text;
using TicketDataService;
using System.Linq;

namespace TicketService
{
    public class TipoFacturaService
    {
        //metodo para obtener listado de TipoFactura de la base 
        public List<TipoFactura> getAll()
        {
            return ConectionFactory.getBaseTickets().listaTipoFactura;
        }

        // input: Atributos TipoFactura
        // method: Crea un TipoFactura en la base con los atributos pasados por parámetro
        // Output: Devuelvo dicho TipoFactura
        public TipoFactura addTipoFactura( string descripcionTipoFactura)
        {
            List<TipoFactura> listaTipoFactura = ConectionFactory.getBaseTickets().listaTipoFactura;
            TipoFactura tipofacturanew = new TipoFactura(listaTipoFactura.Count, descripcionTipoFactura);
            listaTipoFactura.Add(tipofacturanew);
            return tipofacturanew;
        }
        // input: idTipoFactura
        // method: Busca TipoFactura
        // Output: Devuelve Objeto buscado
        public TipoFactura find(int idTipoFactura)
        {
            List<TipoFactura> listaTipoFactura = ConectionFactory.getBaseTickets().listaTipoFactura;
            return listaTipoFactura.FirstOrDefault(tipofactura => (tipofactura.id == idTipoFactura));
        }

        // input: Atributos de TipoFactura a actualizar
        // method: Crea un TipoFactura en la base con los atributos pasados por parámetro
        // Output: Devuelve dicho Ticket
        public TipoFactura updateTipoFactura(int idTipoFactura, string descripcionTipoFactura)
        {
            TipoFactura tipoFactura = this.find(idTipoFactura);
            //atributos a actualizar
            tipoFactura.descripcion = descripcionTipoFactura;
            return tipoFactura;

        }

        // input: TipoFactura a eliminar
        // method: elimina el tipoFactura de la DB
        // Output: TipoFactura eliminado
        public List<TipoFactura> removeTipoFactura(int idTipoFactura)
        {
            //Busco el TipoFactura a eliminar
            TipoFactura tipoFacturaBuscado = this.find(idTipoFactura);
            //Recorro la lista Ticket borrando de su Tipo Factura si es igual a la buscada
            TicketService ticketService = new TicketService();
            ticketService.eliminarTipoFactura(tipoFacturaBuscado);
            //Remuevo el TipoFactura de la lista de TipoFacturas
            ConectionFactory.getBaseTickets().listaTipoFactura.Remove(tipoFacturaBuscado);
            return ConectionFactory.getBaseTickets().listaTipoFactura;

        }
    }
}
