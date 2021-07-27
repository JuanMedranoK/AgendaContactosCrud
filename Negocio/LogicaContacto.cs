using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dato;
using Entidad;
using System.Threading.Tasks;

namespace Negocio
{
    public class LogicaContacto
    {
        ConectarContactos conecta = new ConectarContactos();
        public List<Contactos> ListarClientes(string buscar)
        {
            return conecta.BuscarContactos(buscar);
        }

        public void InsertarContactos(Contactos contactos)
        {
            conecta.InsertarContactos(contactos);
        }

        public void EditarContactos(Contactos contactos)
        {
            conecta.EditarContactos(contactos);
        }

        public void EliminarContactos(Contactos contactos)
        {
            conecta.EliminarContactos(contactos);
        }
    }
}
