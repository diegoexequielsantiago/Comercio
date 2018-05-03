using System;
using System.Collections.Generic;
using System.Text;

namespace DepositoDataService
{
    public class ConectionFactory //clase singleton
    {
        // atributo de la clase basedatos
        private static BaseDatos basedatos;
        //metodo para obtener siempre la misma instancia de la clase base de datos
        public static BaseDatos getBaseDatos()
        {
            //si no la obtuve en otro llamado anterior al metodo la creo. Sinó obtengo la misma instancia
            if (basedatos == null)
                basedatos = new BaseDatos();
            return basedatos;
        }

    }
}
