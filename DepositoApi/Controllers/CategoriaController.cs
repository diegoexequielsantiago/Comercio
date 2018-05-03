using DepositoDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace DepositoApi.Controllers
{
    public class CategoriaController : ApiController
    {
        [HttpGet]
        [Route("listaCategoriaProducto")]
        // input: null
        //method: Llama al servicio el cuál lista las localidades
        //Output: Listado de clientes
        public List<Categoria> categoriaListar()
        {
            DepositoService.CategoriaService categoriaService = new DepositoService.CategoriaService();
            List<Categoria> listaCategorias = categoriaService.getAll();
            return listaCategorias;
        }

        // input: atributos de la Categoria
        //method: Llama al servicio el cual agrega una Categoria
        //Output: Categoria creada
        [HttpGet]
        [Route("addCategoriaProducto")]
        public Categoria addCategoria( int codigoCategoriaProducto, string descripcionCategoriaProducto)
        {
            DepositoService.CategoriaService categoriaservice = new DepositoService.CategoriaService();
            Categoria categorianew = categoriaservice.addCategoria(codigoCategoriaProducto , descripcionCategoriaProducto);
            return categorianew;
        }

        // input: idCategoriaProducto
        // method: Busca Categoria de producto
        // Output: Devuelve Objeto CategoriaProducto
        [HttpGet]
        [Route("findCategoriaProducto")]
        public Categoria find(int idCategoriaProducto)
        {
            DepositoService.CategoriaService categoriaservice = new DepositoService.CategoriaService();
            Categoria categoriaBuscada = categoriaservice.find(idCategoriaProducto);
            return categoriaBuscada;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos de la CategoriaProducto
        //Output: CategoriaProducto Modificada
        [HttpGet]
        [Route("updateCategoriaProducto")]
        public Categoria updateCategoria( int idCategoriaProducto , int codigoCategoriaProducto, string descripcionCategoriaProducto)
        {
            DepositoService.CategoriaService categoriaservice = new DepositoService.CategoriaService();
            Categoria categoriamodificada = categoriaservice.updateCategoria(idCategoriaProducto, codigoCategoriaProducto, descripcionCategoriaProducto);
            return categoriamodificada;
        }

        // input: idCategoria a buscar
        //method: Llama al servicio el cual elimina la Categoria buscada
        //Output: Lista Categorias sin la Eliminada
        [HttpGet]
        [Route("removeCategoriaProducto")]
        public List<Categoria> removeCategoria(int idCategoriaProducto)
        {
            DepositoService.CategoriaService categoriaservice = new DepositoService.CategoriaService();
            categoriaservice.removeCategoria(idCategoriaProducto);
            return categoriaservice.getAll();


        }






    }
}
