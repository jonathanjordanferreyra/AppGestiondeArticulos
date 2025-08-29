using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ArticuloNegocio
    {

        //Metodo que devuelve una lista de articulos
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                 
                datos.SetearConsulta("select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C where A.IdCategoria = C.Id and A.IdMarca = M.Id");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    //Valido si no es null, conforme si la columna admite un DBNULL.
                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (!(datos.Lector["Codigo"] is DBNull))
                    {
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }
                        aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
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
        
        //Metodo que agrega un articulo a la BD
        public void Agregar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("insert into ARTICULOS (Codigo,Nombre,Descripcion,IdCategoria,IdMarca,ImagenUrl,Precio) values (@Codigo,@Nombre,@Descripcion,@IdCategoria,@IdMarca,@ImagenUrl,@Precio)");
                datos.SetearParametros("@Codigo",articulo.Codigo);
                datos.SetearParametros("@Nombre", articulo.Nombre);
                datos.SetearParametros("@Descripcion", articulo.Descripcion);
                datos.SetearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.SetearParametros("@IdMarca", articulo.Marca.Id);
                datos.SetearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.SetearParametros("@Precio", articulo.Precio);
                datos.EjecutarAccion();

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
        //Método para modificar un articulo
        public void Modificar(Articulo articuloSeleccionado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("update ARTICULOS set Codigo = @Codigo,Nombre = @Nombre,Descripcion = @Descripcion,IdMarca = @IdMarca, IdCategoria = @IdCategoria,ImagenUrl = @ImagenUrl, Precio = @Precio where Id = @Id");
                datos.SetearParametros("@Codigo", articuloSeleccionado.Codigo);
                datos.SetearParametros("@Nombre", articuloSeleccionado.Nombre);
                datos.SetearParametros("@Descripcion", articuloSeleccionado.Descripcion);
                datos.SetearParametros("@IdMarca", articuloSeleccionado.Marca.Id);
                datos.SetearParametros("@IdCategoria", articuloSeleccionado.Categoria.Id);
                datos.SetearParametros("@ImagenUrl", articuloSeleccionado.ImagenUrl);
                datos.SetearParametros("@Precio", articuloSeleccionado.Precio);
                datos.SetearParametros("@Id", articuloSeleccionado.Id);

                datos.EjecutarAccion();
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
        public void Eliminar (int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos ();
                datos.SetearConsulta("delete from ARTICULOS where Id = @Id ");
                datos.SetearParametros("@Id", id);
                datos.EjecutarAccion();
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C where A.IdCategoria = C.Id and A.IdMarca = M.Id and ";
                switch (campo)
                {
                    case "Código":
                        if (criterio == "Empieza con")
                        {
                            consulta += "A.Codigo like '" + filtro + "%' ";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Codigo like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Codigo like '%" + filtro + "%'";
                        }
                        break;

                    case "Nombre":
                        if (criterio == "Empieza con")
                        {
                            consulta += "A.Nombre like '" + filtro + "%' ";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Nombre like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Nombre like '%" + filtro + "%'";
                        }
                        break;
                    case "Descripción":
                        if (criterio == "Empieza con")
                        {
                            consulta += "A.Descripcion like '" + filtro + "%' ";
                        }
                        else if (criterio == "Termina con")
                        {
                            consulta += "A.Descripcion like '%" + filtro + "'";
                        }
                        else
                        {
                            consulta += "A.Descripcion like '%" + filtro + "%'";
                        }
                        break;
                    case "Marca":
                        consulta += "M.Descripcion = '" + criterio + "'";
                        break;
                    default:
                        consulta += "C.Descripcion = '" + criterio + "'";
                        break;
                }
                datos.SetearConsulta(consulta);
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    //Valido si no es null, conforme si la columna admite un DBNULL.
                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (!(datos.Lector["Codigo"] is DBNull))
                    {
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    if (!(datos.Lector["Precio"] is DBNull))
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }
                    aux.Marca = new Marca();
                    if (!(datos.Lector["IdMarca"] is DBNull))
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
