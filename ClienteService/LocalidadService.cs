using ClienteDataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClienteService
{
    public class LocalidadService
    {
        //Método para obtener listado de tickets
        public List<Localidad> getAll()
        {
            return ConectionFactory.getBaseClientes().listaLocalidad;
        }

        // input: idLocalidad
        // method: Busca Localidad
        // Output: Devuelve Objeto
        public Localidad find(int idlocalidad)
        {
            List<Localidad> listaLocalidades = ConectionFactory.getBaseClientes().listaLocalidad;
            return listaLocalidades.FirstOrDefault(localidad => (localidad.id == idlocalidad));
        }

        // input: Atributos Localidad
        // method: Crea una Localidad en la base con los atributos pasados por parámetro
        // Output: Devuelto dicha Localidad
        public Localidad addLocalidad(int codigoPostal, string descripcion)
        {
            int id = ConectionFactory.getBaseClientes().listaLocalidad.Count;
            Localidad localidadnew = new Localidad(id, codigoPostal , descripcion);
            ConectionFactory.getBaseClientes().listaLocalidad.Add(localidadnew);
            return localidadnew;
        }

        // input: Atributos Localidad a actualizar
        // method: Crea una Localidad en la base con los atributos pasados por parámetro
        // Output: Devuelve dicha Localidad
        public Localidad updateLocalidad(int idLocalidad, int codigoP, string desc)
        {
            Localidad localidad = this.find(idLocalidad);
            //atributos a actualizar
            localidad.codigoPostal = codigoP;
            localidad.descripcion = desc;
            return localidad;

        }

        // input: Localidad a eliminar
        // method: elimina la localidad de la DB
        // Output: Loclaidad eliminada
        public List<Localidad> removeLocalidad(int idLocalidad)
        {
            //Busco a la localidad a eliminar
            Localidad localidadBuscada = this.find(idLocalidad);
            //Recorro la lista clientes borrando de su localidad si es igual a la buscada
            ClienteService clienteService = new ClienteService();
            clienteService.eliminarLocalidad(localidadBuscada);
            //Remuevo la localidad de la lista localidades
            ConectionFactory.getBaseClientes().listaLocalidad.Remove(localidadBuscada);
            return ConectionFactory.getBaseClientes().listaLocalidad;
        }
    }
}
