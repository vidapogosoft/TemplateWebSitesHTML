using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libreriaMiniMarket;

namespace libreriaMiniMarket
{
    public class bdProveedor
    {
        private clsProveedor clsproveedor;
        private List<clsProveedor> listproveedor;

        private dbMiniMarketEntities1 dbMinimarket;
        private proveedor proveedor;

        private Boolean respuesta;
        private int numero;

        public List<clsProveedor> consultarProveedor()
        {
            listproveedor = new List<clsProveedor>();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                var query = from p in dbMinimarket.proveedor
                            orderby p.id
                            select p;

                foreach (var item in query)
                {
                    clsproveedor = new clsProveedor();
                    clsproveedor.ID = item.id;
                    clsproveedor.DESCRIPCION = item.descripcion;
                    clsproveedor.ESTADO = item.estado;

                    listproveedor.Add(clsproveedor);
                }
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listproveedor;

        }
        public clsProveedor consultarProveedorxID(int id)
        {
            clsproveedor = new clsProveedor();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();

                var query = from p in dbMinimarket.proveedor
                            where p.id == id
                            select p;

                foreach (var item in query)
                {
                    clsproveedor.ID = item.id;
                    clsproveedor.DESCRIPCION = item.descripcion;
                    clsproveedor.ESTADO = item.estado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsproveedor;

        }
        public int consultarProveedorMAXID()
        {
            numero = 0;
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                numero = dbMinimarket.proveedor.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public Boolean guardarProveedor(clsProveedor cls)
        {
            numero = consultarProveedorMAXID();
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                proveedor = new proveedor();
                proveedor.id = cls.ID;
                proveedor.descripcion = cls.DESCRIPCION;
                proveedor.estado = cls.ESTADO;

                dbMinimarket.proveedor.Add(proveedor);
                dbMinimarket.SaveChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
        public Boolean actualizarCliente(clsCategoria cls)
        {
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                proveedor = dbMinimarket.proveedor.Single(x => x.id == cls.ID);
                proveedor.descripcion = cls.DESCRIPCION;
                proveedor.estado = cls.ESTADO;

                dbMinimarket.SaveChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
    }
}
