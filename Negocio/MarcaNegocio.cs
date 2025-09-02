using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class MarcaNegocio
    {
        //Metodo que trae las marcas de la DB para cargar el combo box
        public List<Marca> listar()
        {
            List<Marca > lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select Id,Descripcion from MARCAS");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        //Metodo para agregar Marca a la DB
        public void Agregar(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                List<Marca>MarcasExistentes = listar();
                if(MarcasExistentes.Any(x => x.Descripcion.ToUpper() == nuevaMarca.Descripcion.ToUpper()))
                {
                    throw new Exception("Esta marca ya existe, ingrese una nueva.");
                }

                datos.SetearConsulta("insert into MARCAS (Descripcion) values (@Descripcion)");
                datos.SetearParametros("@Descripcion", nuevaMarca.Descripcion);
                datos.EjecutarAccion();
            }

            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
