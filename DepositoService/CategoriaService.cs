using DepositoDataService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DepositoService
{
    public class CategoriaService
    {
        //Método para obtener listado de categorias
        public List<Categoria> getAll()
        {
            return ConectionFactory.getBaseDatos().listaCategoria;
        }

        // input: idCategoria
        // method: Busca Categoria
        // Output: Devuelve Objeto buscado
        public Categoria find(int idCategoria)
        {
            List<Categoria> listaCategorias = ConectionFactory.getBaseDatos().listaCategoria;
            return listaCategorias.FirstOrDefault(categoria => (categoria.id == idCategoria));
        }

        // input: Atributos Categoria
        // method: Crea una Categoria en la base con los atributos pasados por parámetro
        // Output: Devuelvo dicha Categoria
        public Categoria addCategoria( int codigo, string descripcion)
        {
            List<Categoria> listaCategoria = ConectionFactory.getBaseDatos().listaCategoria;
            Categoria categorianew = new Categoria(listaCategoria.Count, codigo , descripcion);
            listaCategoria.Add(categorianew);
            return categorianew;
        }

        // input: Atributos CategoriaProducto a actualizar
        // method: Crea una CategoriaProducto en la base con los atributos pasados por parámetro
        // Output: Devuelve dicha CategoriaProducto
        public Categoria updateCategoria(int idCategoria, int codigoCategoria, string descripcionCategoria)
        {
            Categoria categoria = this.find(idCategoria);
            //atributos a actualizar
            categoria.codigo = codigoCategoria;
            categoria.descripcion = descripcionCategoria;
            return categoria;

        }

        // input: Categoria a eliminar
        // method: elimina la Categoria de la DB
        // Output: Categoria eliminada
        public List<Categoria> removeCategoria(int idCategoria)
        {
            //Busco a la Categoria a eliminar
            Categoria categoriaBuscada = this.find(idCategoria);
            //Recorro la lista Productos borrando de su Categoria si es igual a la buscada
            ProductoService productoService = new ProductoService();
            productoService.eliminarCategoria(categoriaBuscada);
            //Remuevo la categoria de la lista Categorias
            ConectionFactory.getBaseDatos().listaCategoria.Remove(categoriaBuscada);
            return ConectionFactory.getBaseDatos().listaCategoria;

        }

    }
}
