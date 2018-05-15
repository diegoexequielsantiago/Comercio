using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ClienteDataService
{
    public class BaseClientes: DbContext
    {

        //constructor
        public BaseClientes(): base("BaseClientes")
        {
            //crearLocalidad();
            //crearCliente();
        }

        //Creo la lista de clientes
        public DbSet<Cliente> listaClientes { get; set; }

        //Instancio lista localidades
        public DbSet<Localidad> listaLocalidad { get; set; }

        //Creo los clientes y lo meto a la lista
        private void crearCliente()
        {
            //creo cliente 1
            Cliente client1 = new Cliente(listaClientes.Count(),100,"Santiago Diego", listaLocalidad.ElementAt(1));
            listaClientes.Add(client1);
            //creo cliente 2
            Cliente client2 = new Cliente(listaClientes.Count(),124, "Alexis Zygalsky", listaLocalidad.ElementAt(2));
            listaClientes.Add(client2);
            //creo cliente 3
            Cliente client3 = new Cliente(listaClientes.Count(),244, "Martinez Horacio", listaLocalidad.ElementAt(3));
            listaClientes.Add(client3);

        }
        
        

        //metodo para agregar a la lista los productos
        private void crearLocalidad()
        {
            //creo categoria 1 para las localidades eliminadas
            Localidad loc1 = new Localidad(0, 0000, "La localidad fué eliminada");
            listaLocalidad.Add(loc1);
            //creo categoria 2
            Localidad loc2 = new Localidad(1, 7500 ,"Tres Arroyos");
            listaLocalidad.Add(loc2);
            //creo categoria 3
            Localidad loc3 = new Localidad(2, 1900, "La Plata");
            listaLocalidad.Add(loc3);
            //creo categoria 3
            Localidad loc4 = new Localidad(3, 7600, "Mar Del Plata");
            listaLocalidad.Add(loc4);

        }
    }
}
