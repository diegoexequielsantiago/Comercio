using DepositoDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DepositoApi.Controllers
{
    public class ProductoController : ApiController
    {

        // input: null
        //method: Llama al servicio el cuál lista las localidades
        //Output: Listado de clientes
        [HttpGet]
        [Route("listaProductos")]
        public List<Producto> productoListar()
        {
            DepositoService.ProductoService productoService = new DepositoService.ProductoService();
            List<Producto> listaProductos = productoService.getAll();
            return listaProductos;
        }

        // input: atributos Producto
        //method: Llama al servicio el cual agrega Productos
        //Output: Producto Creado creado
        [HttpGet]
        [Route("addProducto")]
        public Producto addProducto(string descripcionProducto, int codigoProducto, string codigoBarra, int idProveedor, decimal precioUnitario, int idCategoria)
        {
            DepositoService.ProductoService productoservice = new DepositoService.ProductoService();
            DepositoService.CategoriaService categoriaservice = new DepositoService.CategoriaService();
            Categoria categoria = categoriaservice.find(idCategoria);
            Producto productonew = productoservice.addProducto( descripcionProducto, codigoProducto , codigoBarra , idProveedor , precioUnitario , categoria);
            return productonew;
        }

        // input: idProducto
        // method: Busca Producto de producto
        // Output: Devuelve Objeto Producto
        [HttpGet]
        [Route("findProducto")]
        public Producto find(int idProducto)
        {
            DepositoService.ProductoService productoservice = new DepositoService.ProductoService();
            Producto productoBuscado = productoservice.find(idProducto);
            return productoBuscado;
        }

        // input: atributos a modificar
        //method: Llama al servicio el cual modifica atributos del Producto
        //Output: Producto Modificado
        [HttpGet]
        [Route("updateProducto")]
        public Producto updateProducto(int idProducto, string descripcionProducto, int codigoProducto, string codigoBarra, int idProveedor, decimal precioUnitario)
        {
            DepositoService.ProductoService productoservice = new DepositoService.ProductoService();
            Producto productomodificado = productoservice.updateProducto(idProducto, descripcionProducto, codigoProducto, codigoBarra, idProveedor, precioUnitario);
            return productomodificado;
        }

        // input: idProducto a buscar
        //method: Llama al servicio el cual elimina el Producto buscado
        //Output: Lista Productos sin el Eliminado
        [HttpGet]
        [Route("removeProducto")]
        public List<Producto> removeProducto(int idProducto)
        {
            DepositoService.ProductoService productoservice = new DepositoService.ProductoService();
            productoservice.removeProducto(idProducto);
            return productoservice.getAll();


        }
    }

    
}
