using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.MiniMarket.Entidades; 
using Infraestructura.MiniMarket.DataModel;


namespace Infraestructura.MiniMarket.DAO
{
    public class Producto  
    {

        minimarketEntities contexto = new minimarketEntities();

      //Consultar un producto por LinQ
        public tproducto ConsultarProducto(int id)
        {

            try
            {
                var producto = from u in contexto.tproducto
                               where u.id == id
                               select u;

                return producto.FirstOrDefault();

            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.StackTrace);

                return null;
            }
        }

        //Consulto un producto por SP
        public Productos ConsultarProductoSP(int id)
        {
            consultarProducto_SP1_Result resultadoBD = new consultarProducto_SP1_Result();
            try
            {
                resultadoBD = contexto.consultarProducto_SP1(id).FirstOrDefault();

                //Mapeo la clase de la BD a la clase de dominio

                Productos productos = new Productos();

                productos.id = resultadoBD.id;

                productos.Descripcion = resultadoBD.descripcion;

                productos.Medidas = resultadoBD.medidas;


                productos.Cantidad = resultadoBD.cantidad;


                productos.Precio = resultadoBD.precio;

                productos.Marca = resultadoBD.descripcion;

                productos.Categoria = resultadoBD.descripcion;

                productos.Proveedor = resultadoBD.nombre;


                return productos;

            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.StackTrace);

                return null;
            }
        }


        //Consulto todos los productos por SP
        public List<Productos> ConsultarProductoSPTodos()
        {
            IEnumerable<consultarProductoTodos_SP_Result> resultadoBD;

            List<Productos> resultadoConsulta = new List<Productos>();
            try
            {
                resultadoBD = contexto.consultarProductoTodos_SP().ToList();

                //Mapeo la clase de la BD a la clase de dominio

                foreach (var item in resultadoBD)
                {
                    Productos productos = new Productos();

                    productos.id = item.id;

                    productos.Descripcion = item.descripcion;

                    productos.Medidas = item.medidas;


                    productos.Cantidad = item.cantidad;


                    productos.Precio = item.precio;

                    productos.Marca = item.descripcion;

                    productos.Categoria = item.descripcion;

                    productos.Proveedor = item.nombre;

                    resultadoConsulta.Add(productos);

                }



                return resultadoConsulta;

            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.StackTrace);

                return null;
            }
        }

        public void CrearProducto(Productos productos)
        {

            try
            {

                //Mapeo la clase del dominio  a la clase de BD
                tproducto modelo = new tproducto();

                modelo.id = productos.id;
                modelo.descripcion = productos.Descripcion;
                modelo.medidas = productos.Medidas;
                modelo.cantidad = productos.Cantidad;
                modelo.precio = productos.Precio;
                modelo.marcaid = productos.Marcaid;
                modelo.categoriaid = productos.Categoriaid;
                modelo.proveedorid = productos.Proveedorid;


                contexto.tproducto.Add(modelo);

                contexto.SaveChanges();

            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.StackTrace);
            }
        }

        public void ActualizarProducto(Productos modelo)
        {

            try
            {

                //Mapeo la clase de la BD a la clase de dominio

                tproducto productos = new tproducto();

                productos.id = modelo.id;

                productos.descripcion = modelo.Descripcion;

                productos.medidas = modelo.Medidas;


                productos.cantidad = modelo.Cantidad;


                productos.precio = modelo.Precio;

                productos.marcaid = modelo.Marcaid;

                productos.categoriaid = modelo.Categoriaid;

                productos.proveedorid = modelo.Proveedorid;




                contexto.Entry(productos).State = System.Data.Entity.EntityState.Modified;


                contexto.SaveChanges();

            }
            catch (Exception e)
            {

                Console.WriteLine("Error" + e.StackTrace);
            }
        }
    }
}
