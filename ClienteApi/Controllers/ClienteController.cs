using ClienteDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClienteApi.Controllers
{
    public class ClienteController : ApiController
    {

        // input: null
        //method: Llama al servicio el cuál lista los clientes
        //Output: Listado de clientes
        [HttpGet]
        [Route("listaClientes")]
        public List<Cliente> clienteListar()
        {
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            List<Cliente> listaclientes = clienteservice.getAll();
            return listaclientes;
        }
       // input: atributos cliente
        //method: Llama al servicio el cual agrega clientes
        //Output: Cliente creado
        [ HttpGet]
        [Route("addCliente")]
        public Cliente addCliente(int numeroCliente, string nombreCliente, int idLocalidad)
        {
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            Localidad localidad = localidadservice.find(idLocalidad);
            Cliente clientenew = clienteservice.addCliente(numeroCliente ,nombreCliente, localidad);
            return clientenew;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos del cliente
        //Output: Cliente modificado
        [HttpGet]
        [Route("updateCliente")]
        public Cliente updateCliente(int idCliente, string nombreCliente, string telefono, string direccion, string correo, int idLocalidad)
        {
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            Localidad loc = localidadservice.find(idLocalidad);
            Cliente clientemodificado = clienteservice.updateCliente( idCliente , nombreCliente , telefono , direccion , correo , loc);
            return clientemodificado;
        }
        
        // input: Id cliente a eliminar
        //method: Elimina el cliente de la lista y devuelve el mismo
        //Output: Cliente modificado
        [HttpGet]
        [Route("removeCliente")]
        public List<Cliente> removeCliente(int idCliente)
        {
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            clienteservice.removeCliente(idCliente);
            return clienteservice.getAll();
            
            
        }

        // input: id del Cliente a buscar
        //method: Llama al servicio el cuál busca el cliente con la id ingresada
        //Output: Cliente Buscado
        [HttpGet]
        [Route("findCliente")]
        public Cliente findCliente(int idCliente)
        {
            ClienteService.ClienteService clienteservice = new ClienteService.ClienteService();
            Cliente clienteBuscado = clienteservice.find(idCliente);
            return clienteBuscado;
        }
    }

       
}
