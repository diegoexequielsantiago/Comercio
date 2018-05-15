using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteDataService
{
    public class ConectionFactory //clase singleton
    {
        // atributo de la clase basedatos
        private static BaseClientes baseclientes;


        //metodo para obtener siempre la misma instancia de la clase base de datos
        public static BaseClientes getBaseClientes()
        {
            //si no la obtuve en otro llamado anterior al metodo la creo. Sinó obtengo la misma instancia
            if (baseclientes == null)
                baseclientes = new BaseClientes();
            return baseclientes;
        }

    }
}
