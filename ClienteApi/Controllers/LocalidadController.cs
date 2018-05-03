using ClienteDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ClienteApi.Controllers
{
    public class LocalidadController : ApiController
    {
        [HttpGet]
        [Route("listaLocalidades")]
        // input: null
        //method: Llama al servicio el cuál lista los clientes
        //Output: Listado de clientes
        public List<Localidad> localidadListar()
        {
            ClienteService.LocalidadService localidadService = new ClienteService.LocalidadService();
            List<Localidad> listaLocalidades = localidadService.getAll();
            return listaLocalidades;
        }

        // input: id de la Localidad a buscar
        //method: Llama al servicio el cuál busca la localidad con la id ingresada
        //Output: Localidad Buscada
        [HttpGet]
        [Route("findLocalidad")]
        public Localidad findLocalidad(int idLocalidad)
        {
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            Localidad localidadBuscada = localidadservice.find(idLocalidad);
            return localidadBuscada;
        }

        // input: atributos de la Localidad
        //method: Llama al servicio el cual agrega una Localidad
        //Output: Localidad creada
        [HttpGet]
        [Route("addLocalidad")]
        public Localidad addLocalidad (int codigoPostal, string descripcion)
        {
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            Localidad localidadnew = localidadservice.addLocalidad( codigoPostal, descripcion);
            return localidadnew;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos de la localidad
        //Output: Localidad Modificada
        [HttpGet]
        [Route("updateLocalidad")]
        public Localidad updateLocalidad(int idLocalidad, int codigoPostal, string descripcion)
        {
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            Localidad localidadmodificada = localidadservice.updateLocalidad( idLocalidad , codigoPostal , descripcion);
            return localidadmodificada;
        }
        // input: idlocalidad a buscar
        //method: Llama al servicio el cual elimina la localidad buscada
        //Output: Localidad Eliminada
        [HttpGet]
        [Route("removeLocalidad")]
        public List<Localidad> removeLocalidad(int idLocalidad)
        {
            ClienteService.LocalidadService localidadservice = new ClienteService.LocalidadService();
            localidadservice.removeLocalidad(idLocalidad);
            return localidadservice.getAll();


        }


    }
}
