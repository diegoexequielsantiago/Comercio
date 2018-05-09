using ClienteDataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClienteService
{
    public class ClienteService
    {
        //Método para obtener listado de Clientes
        public List<Cliente> getAll()
        {
            return ConectionFactory.getBaseClientes().listaClientes.ToList();
        }

        // input: Atributos Cliente indispensables
        // method: Crea un Cliente en la base con los atributos pasados por parámetro
        // Output: Devuelto dicho Cliente
        public Cliente addCliente(int numeroCliente, string nombre, Localidad localidadCliente)
        {
            int id = ConectionFactory.getBaseClientes().listaClientes.Count();
            Cliente clientenew = new Cliente(id, numeroCliente, nombre, localidadCliente);
            return clientenew;
        }

        // input: Cliente a eliminar
        // method: elimina el cliente de la DB
        // Output: Cliente eliminado
        public List<Cliente> removeCliente(int idCliente) 
        {  
            //Busco al cliente a eliminar
            Cliente clienteBuscado = this.find(idCliente);
            //remuevo al cliente de la lista de cliente de la localidad
            LocalidadService localidadService = new LocalidadService();
            Localidad localidadCliente = localidadService.find(clienteBuscado.idlocalidad);
            localidadCliente.removeCliente(clienteBuscado);
            //Remuevo al cliente de la lista de clientes
            ConectionFactory.getBaseClientes().listaClientes.Remove(clienteBuscado);
            return ConectionFactory.getBaseClientes().listaClientes.ToList();
        }

        // input: Id del cliente a Buscar
        // method: busca el cliente con la id
        // Output: Devuelve el mismo
        public Cliente find(int idcliente)
        {
            List<Cliente> listacliente = ConectionFactory.getBaseClientes().listaClientes.ToList();
            return listacliente.FirstOrDefault(cliente => (cliente.id == idcliente));
        }

        // input: Atributos Cliente a actualizar
        // method: Crea un Cliente en la base con los atributos pasados por parámetro
        // Output: Devuelve dicho Cliente
        public Cliente updateCliente(int idCliente, string nombreCliente, string telefono, string direccion, string correo, Localidad localidad)
        {
            Cliente cliente = this.find(idCliente);
            //atributos a actualizar
            cliente.nombreCompleto = nombreCliente;
            cliente.telefono = telefono;
            cliente.direccion = direccion;
            cliente.correo = correo; 
            if (localidad.id != cliente.idlocalidad)
            {
                cliente.setLocalidad(localidad); 
            }
            return cliente;
    
        }

        // input: Atributos Cliente detallados
        // method: Crea un Cliente en la base con los atributos pasados por parámetro
        // Output: Devuelto dicho Cliente
        public void addClienteDetallado(int numeroCliente, string nombreCliente, string teléfono, string dirección, string correo, Localidad loc)
        {
            Cliente clientenew = new Cliente(numeroCliente, nombreCliente, teléfono, dirección, correo, loc);
            ConectionFactory.getBaseClientes().listaClientes.Add(clientenew);
         
        }

        // input: Localidad a eliminar de la lista clientes
        // method: Recorro la lista de cliente borrando la localidad eliminada a los clientes que pertenescan a la misma
        // Output: 
        public void eliminarLocalidad(Localidad localidadEliminada)
        {
            // Obtengo listado de clientes
            List<Cliente> listaClientes = this.getAll();
            // Busco la localidad con descripción de "la localidad fue eliminada que tiene el ID=0"
            LocalidadService localidadService = new LocalidadService();
            Localidad localidadNula = localidadService.find(0);
            // Recorro listado de cliente
            for (int i = 0; i < listaClientes.Count; i++)
            {
                //Variable local del indice
                Cliente clientelocal = listaClientes[i];
                //Pregunto si la localidad eliminada es la del cliente 
                if (clientelocal.idlocalidad == localidadEliminada.id)
                {
                    clientelocal.setLocalidad(localidadNula);
                }

            }

        }




    }
}
