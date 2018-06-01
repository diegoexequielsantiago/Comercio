using ClienteDataService;
using ClienteService;
using System;
using System.Collections.Generic;

namespace Consola
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Instancio una base clientes
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            List<Cliente> listaclientes = clienteservice.getAll();
            //imprimo la cantidad de clientes
            Console.WriteLine("cantidad de clientes" + listaclientes.Count);

            //Imprimo clientes con su localidad 
            for (int i = 0; i < listaclientes.Count; i++)
            {
                Console.WriteLine(listaclientes[i].nombreCompleto);
                // Console.WriteLine(listaclientes[i].Localidad);

            }
            //Instancio una base productos
            DepositoService.ProductoService prod = new DepositoService.ProductoService();
            //Imprimo cantidad de productos
            Console.WriteLine("Cantidad de Productos " + prod.getAll().Count);
            //Instancio una base de tickets
            TicketService.TicketService comprobante = new TicketService.TicketService();
            //imrpimo cantidad de tickets
            Console.WriteLine("cantidad de tickets " + comprobante.getAll().Count);

            //Instancio una base de categorias
            DepositoService.CategoriaService categoria = new DepositoService.CategoriaService();
            //imrpimo cantidad de Categorias
            Console.WriteLine("cantidad de categorias " + categoria.getAll().Count);

            //ID ES SOLO LECTURA 
            Console.WriteLine(categoria.getAll()[0].id);

            //para que no se cierre la consola
            Console.ReadKey();
        }
    }
}
