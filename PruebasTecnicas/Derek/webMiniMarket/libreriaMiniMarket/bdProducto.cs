using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libreriaMiniMarket;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace libreriaMiniMarket
{
    public class bdProducto
    {
        private clsProducto clsproducto;
        private List<clsProducto> listproducto;

        private dbMiniMarketEntities1 dbMinimarket;
        private productos producto;

        //Clases
        private bdCategoria bdcategoria;
        private bdProveedor bdProveedor;
        private bdMarca bdMarca;
        private bdMedida bdMedida;

        private Boolean respuesta;
        private int numero;        

        public List<clsProducto> consultarProducto()
        {
            listproducto = new List<clsProducto>();
            try
            {                

                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();

                var query = dbMinimarket.consultaProductos();

                foreach (var item in query)
                {
                    clsproducto = new clsProducto();
                    bdcategoria = new bdCategoria();
                    bdProveedor = new bdProveedor();
                    bdMarca = new bdMarca();
                    bdMedida = new bdMedida();

                    clsproducto.ID = item.id;
                    clsproducto.DESCRIPCION = item.descripcion;
                    clsproducto.ID_CATEGORIA = item.id_categoria;                    
                    clsproducto.DESCRIPCION_CATEGORIA = item.descripcion_categoria;
                    clsproducto.ID_PROVEEDOR = item.id_proveedor;
                    clsproducto.DESCRIPCION_PROVEEDOR = item.descripcion_proveedor;
                    clsproducto.ID_MARCA = item.id_marca;
                    clsproducto.DESCRIPCION_MARCA= item.descripcion_marca;
                    clsproducto.ID_MEDIDA = item.id_medida;
                    clsproducto.DESCRIPCION_MEDIDA = item.descripcion_medida;
                    clsproducto.CANTIDAD = item.cantidad;
                    clsproducto.PRECIO_UNITARIO = item.precio_unitario;

                    //Clases
                    clsproducto.LISTCATEGORIA = bdcategoria.consultarCategoria();
                    clsproducto.LISTPROVEEDOR = bdProveedor.consultarProveedor();
                    clsproducto.LISTMARCA= bdMarca.consultarMarca();
                    clsproducto.LISTMEDIDA = bdMedida.consultarMedida();

                    listproducto.Add(clsproducto);
                }
                dbMinimarket.Database.Connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listproducto;

        }
        public clsProducto consultarProductoxID(int id)
        {
            clsproducto = new clsProducto();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();

                var query = dbMinimarket.consultaProductosxID(id);

                foreach (var item in query)
                {
                    clsproducto.ID = item.id;
                    clsproducto.DESCRIPCION = item.descripcion;
                    clsproducto.ID_CATEGORIA = item.id_categoria;
                    clsproducto.DESCRIPCION_CATEGORIA = item.descripcion_categoria;
                    clsproducto.ID_PROVEEDOR = item.id_proveedor;
                    clsproducto.DESCRIPCION_PROVEEDOR = item.descripcion_proveedor;
                    clsproducto.ID_MARCA = item.id_marca;
                    clsproducto.DESCRIPCION_MARCA = item.descripcion_marca;
                    clsproducto.ID_MEDIDA = item.id_medida;
                    clsproducto.DESCRIPCION_MEDIDA = item.descripcion_medida;
                    clsproducto.CANTIDAD = item.cantidad;
                    clsproducto.PRECIO_UNITARIO = item.precio_unitario;
                }

                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsproducto;

        }
        public int consultarProductoMAXID()
        {
            numero = 0;
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                numero = dbMinimarket.productos.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public Boolean guardarProducto(clsProducto cls)
        {
            numero = consultarProductoMAXID();
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                producto = new productos();
                producto.id = numero;
                producto.descripcion = cls.DESCRIPCION;
                producto.id_categoria = cls.ID_CATEGORIA;
                producto.id_proveedor = cls.ID_PROVEEDOR;
                producto.id_marca = cls.ID_MARCA;
                producto.id_medida = cls.ID_MEDIDA;
                producto.cantidad = cls.CANTIDAD;
                producto.precio_unitario = cls.PRECIO_UNITARIO;

                dbMinimarket.productos.Add(producto);
                dbMinimarket.SaveChanges();

                respuesta = true;
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
        public Boolean actualizarProducto(clsProducto cls)
        {
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                
                producto = new productos();
                producto = dbMinimarket.productos.Single(x => x.id == cls.ID);
                producto.descripcion = cls.DESCRIPCION;
                producto.id_categoria = cls.ID_CATEGORIA;
                producto.id_proveedor = cls.ID_PROVEEDOR;
                producto.id_marca = cls.ID_MARCA;
                producto.id_medida = cls.ID_MEDIDA;
                producto.cantidad = cls.CANTIDAD;
                producto.precio_unitario = cls.PRECIO_UNITARIO;

                dbMinimarket.SaveChanges();

                respuesta = true;
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
    }
}
