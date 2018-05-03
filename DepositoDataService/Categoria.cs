using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoDataService
{
    public class Categoria
    {
        //atributos

        public int id { get; }
        public int codigo;
        public string descripcion;
        public List<Producto> listaproductos = new List<Producto>();

        //constructor con ID
        public Categoria(int id, int cod, string desc)
        {
            this.descripcion = desc;
            this.codigo = cod;
            this.id = id;
        }

        //constructor sin ID
        public Categoria( int cod, string desc)
        {
            this.descripcion = desc;
            this.codigo = cod;
        }
        //Agrega producto a lista de producto en la categorìa
        public void addProducto(Producto producto)
        {
            this.listaproductos.Add(producto);
        }
        //to String de la clase Categoria
        public override string ToString()
        {
            string imprimir;
            imprimir = ("Código:" + this.codigo + " Descripción" + this.descripcion );
            return imprimir;
        }

        //Elimino un producto a la lista Categorias
        public void removeProducto(Producto producto)
        {
            this.listaproductos.Remove(producto);

        }
    }

    
}
