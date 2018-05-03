using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoDataService
{
    public class BaseDatos
    {
        //constructor
        public BaseDatos()
        {
            crearCategoria();
            crearProductos();

        }

        //Instancio lista productos
        public List<Producto> listaProductos = new List<Producto>();

        //Instancio lista categorias
        public List<Categoria> listaCategoria = new List<Categoria>();

        //metodo para agregar a la lista los productos
        private void crearProductos()
        {
            //creo producto 1
            Producto prod1 = new Producto(listaProductos.Count, "Arroz gallo de oro, largo fino  x1000gs", 1, "1111010101001001", 1, 46/3, this.listaCategoria[1]);
            listaProductos.Add(prod1);
            //creo producto 2
            Producto prod2 = new Producto(listaProductos.Count, "Fideos Marolio, Estilo Rigatti x1000gs", 2, "110100101111", 2, 49/2, this.listaCategoria[2]);
            listaProductos.Add(prod2);
            //creo producto 3
            Producto prod3 = new Producto(listaProductos.Count,"Atun desmenuzado al natural marca Campagnola  x350gs", 3, "10100000100", 1, 23/2, this.listaCategoria[3]);
            listaProductos.Add(prod3);
        }

        //metodo para agregar a la lista los productos
        private void crearCategoria()
        {
            //Categoria 0 La categoria eliminada
            Categoria cat0 = new Categoria(0, 0001, "La categoria fue eliminada");
            listaCategoria.Add(cat0);

            //Categoria 1
            Categoria cat1 = new Categoria(1, 2201, "Granos");
            listaCategoria.Add(cat1);
            //Categoria 2
            Categoria cat2 = new Categoria(2, 1001, "Pastas");
            listaCategoria.Add(cat2);
            //Categoria 3
            Categoria cat3 = new Categoria(3, 5235, "Enlatados");
            listaCategoria.Add(cat3);

        }
    }
}
