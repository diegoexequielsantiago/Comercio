using System;
using System.Collections.Generic;
using System.Text;

namespace TicketDataService
{
    public class BaseTickets

    {
        //Instancio lista TipoFactura
        public List<TipoFactura> listaTipoFactura = new List<TipoFactura>();

        //Instancio lista de ticket
        public List<Ticket> listaTickets = new List<Ticket>();

        //Instancio lista TicketDetalle
        public List<TicketDetalle> listaTicketDetalle = new List<TicketDetalle>();

        //constructor
        public BaseTickets()
        {
            crearTipoFactura();
            crearTickets();
            crearTicketDetalle();
        }




        //Método privado para crear tickets simulando base
        private void crearTickets()
        {



            //Ingreso un ticket a la base
            Ticket comprobante1 = new Ticket(0 ,"Arroz g.Oro 1k x4 + Fid.Mar 1k x5 + At DN.Camp 350g x8-----Total $450", 1, 1, this.listaTipoFactura[0]);
            listaTickets.Add(comprobante1);

            //Ingreso un ticket a la base
            Ticket comprobante2 = new Ticket(1, "Arroz g.Oro 1k x10 + Fid.Mar 1k x10 + At DN.Camp 350g x8-----Total $800", 2, 2, this.listaTipoFactura[1]);
            listaTickets.Add(comprobante2);

            //Ingreso un ticket a la base
            Ticket comprobante3 = new Ticket(2, "Arroz g.Oro 1k x1 + Fid.Mar 1k x1 + At DN.Camp 350g x2-----Total $120", 3, 3 , this.listaTipoFactura[2]);
            listaTickets.Add(comprobante3);

        }
        //metodo para agregar a la lista los TipoFacturas
        private void crearTipoFactura()
        {
            //Creo factura 0 una factura que fue eliminada, marcador
            TipoFactura tipo0 = new TipoFactura(0, "Factura eliminada");
            listaTipoFactura.Add(tipo0);

            //Creo factura A
            TipoFactura tipo1 = new TipoFactura(1, "Factura A");
            listaTipoFactura.Add(tipo1);
            //Creo factura B
            TipoFactura tipo2 = new TipoFactura(2, "Factura B");
            listaTipoFactura.Add(tipo2);
            //Creo factura A
            TipoFactura tipo3 = new TipoFactura(3, "Factura C");
            listaTipoFactura.Add(tipo3);
        }
        //metodo para agregar a la lista los Ticket Detalles
        private void crearTicketDetalle()
        {
            //declaracion variable detail
            TicketDetalle detail;

            //creo un TicketDetalle y lo agrego al ticket
            detail = new TicketDetalle(0, 0, 49/2, 4, listaTickets[0]);
            this.listaTicketDetalle.Add(detail);

            //creo un TicketDetalle
            detail = new TicketDetalle(1, 1, 33/2, 3, listaTickets[1]);
            this.listaTicketDetalle.Add(detail);

            //creo un TicketDetalle
            detail = new TicketDetalle(2, 2, 15, 2, listaTickets[2]);
            this.listaTicketDetalle.Add(detail);



        }
    }
}
