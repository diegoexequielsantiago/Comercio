using System;
using System.Collections.Generic;
using System.Text;

namespace TicketDataService
{
    public class ConectionFactory
    {
        // atributo de la clase basedatos
        private static BaseTickets basetickets;
        //metodo para obtener siempre la misma instancia de la clase base de datos
        public static BaseTickets getBaseTickets()
        {
            //si no la obtuve en otro llamado anterior al metodo la creo. Sinó obtengo la misma instancia
            if (basetickets == null)
                basetickets = new BaseTickets();
            return basetickets;
        }
    }
}
