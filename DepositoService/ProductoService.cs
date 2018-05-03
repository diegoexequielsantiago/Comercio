using DepositoDataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DepositoService
{
    public class ProductoService
    {
        //Método para obtener listado de tickets
        public List<Producto> getAll()
        {
            return ConectionFactory.getBaseDatos().listaProductos;
        }

        // input: Atributos Producto
        // method: Crea un Producto en la base con los atributos
        // Output: Devuelto dicho Producto
        public Producto addProducto(string descripcion, int codigo, string codigoBarra, int proveedor, decimal precio, Categoria categoriaproducto)
        {
            List<Producto> listaProductos = ConectionFactory.getBaseDatos().listaProductos;
            Producto productonew = new Producto (listaProductos.Count, descripcion, codigo, codigoBarra, proveedor, precio, categoriaproducto);
            listaProductos.Add(productonew);
            return productonew;
        }

        // input: idProducto
        // method: Busca Producto
        // Output: Devuelve Objeto buscado
        public Producto find(int idProducto)
        {
            List<Producto> listaProductos = ConectionFactory.getBaseDatos().listaProductos;
            return listaProductos.FirstOrDefault(producto => (producto.id == idProducto));
        }

        // input: Atributos Producto a actualizar
        // method: Crea un Producto en la base con los atributos pasados por parámetro
        // Output: Devuelve dicha Producto
        public Producto updateProducto(int idProducto, string descripcionProducto, int codigoProducto, string codigoBarra, int proveedor, decimal precio)
        {
            Producto producto = this.find(idProducto);
            //atributos a actualizar
            producto.descripcion = descripcionProducto;
            producto.codigo = codigoProducto;
            producto.codigoBarra = codigoBarra;
            producto.idProveedor = proveedor;
            producto.precioUnitario = precio;
            return producto;

        }

        // input: Producto a eliminar
        // method: elimina el Producto de la DB
        // Output: Producto eliminado
        public List<Producto> removeProducto(int idProducto)
        {
            //Busco el Producto a eliminar
            Producto productoBuscado = this.find(idProducto);
            //remuevo al producto de la lista de productos de la categoria
            CategoriaService categoriaService = new CategoriaService();
            Categoria categoriaProducto = categoriaService.find(productoBuscado.idCategoria);
            categoriaProducto.removeProducto(productoBuscado);
            //Remuevo la categoria de la lista Categorias
            ConectionFactory.getBaseDatos().listaProductos.Remove(productoBuscado);
            return ConectionFactory.getBaseDatos().listaProductos;

        }

        // input: Categoria a eliminar de la lista de Productos
        // method: Recorro la lista de productos borrando la categoria eliminada a los productos que pertenescan a la misma
        // Output: 
        public void eliminarCategoria(Categoria categoriaEliminada)
        {
            // Obtengo listado de productos
            List<Producto> listaProductos = this.getAll();
            // Busco la categoria con descripción de "la categoria fue eliminada que tiene el ID=0"
            CategoriaService categoriaService = new CategoriaService();
            Categoria categoriaNula = categoriaService.find(0);
            // Recorro listado de productos
            for (int i = 0; i < listaProductos.Count; i++)
            {
                //Variable local del indice
                Producto productolocal = listaProductos[i];
                //Pregunto si la localidad eliminada es la del cliente 
                if (productolocal.idCategoria == categoriaEliminada.id)
                {
                    productolocal.setCategoria(categoriaNula);
                }

            }

        }
    }
}