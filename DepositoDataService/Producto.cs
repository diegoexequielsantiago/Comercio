using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoDataService
{
    public class Producto
    {
        //atributos
        public int id { get; }
        public int codigo;
        public string descripcion;
        public decimal precioUnitario;
        public string codigoBarra;
        public DateTime fechaIngreso;
        public int idProveedor;
        Categoria categoria;
        public int idCategoria { get; private set; }

        //constructor
        public Producto(string desc, int cod, string codBarra, int proveedor, decimal precio, Categoria categoriaproducto)
        {
            this.descripcion = desc;
            this.codigo = cod;
            this.codigoBarra = codBarra;
            this.fechaIngreso = DateTime.Now;
            this.idProveedor = proveedor;
            this.precioUnitario = precio;
            this.categoria = categoriaproducto;
            this.idCategoria = this.categoria.id;
            this.categoria.addProducto(this);

        }

        //To String de la clase producto 
        public override string ToString()
        {
            string imprimir;
            imprimir = ("Codigo:" + this.codigo + " Descripción:" + this.descripcion);
            return imprimir;
        }

        //constructor con ID
        public Producto(int idProducto, string desc, int cod, string codBarra, int proveedor, decimal precio, Categoria categoriaproducto)
        {
            this.id = idProducto;
            this.descripcion = desc;
            this.codigo = cod;
            this.codigoBarra = codBarra;
            this.fechaIngreso = DateTime.Now;
            this.idProveedor = proveedor;
            this.precioUnitario = precio;
            this.categoria = categoriaproducto;
            this.idCategoria = this.categoria.id;
            this.categoria.addProducto(this);
        }

        // Input: Categoria
        // Method: Seteo la categoria que viene como parametro a this clase
        // Output: Devuelvo la clase modificada
        public Producto setCategoria(Categoria categoria)
        {
            // Elimino su propio producto a la categoria de la lista de producto antes de reemplazarla
            this.categoria.removeProducto(this);
            this.categoria = categoria;
            this.categoria.addProducto(this);
            this.idCategoria = this.categoria.id;
            return this;
        }


    }
}
