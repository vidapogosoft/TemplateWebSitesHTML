using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libreriaMiniMarket;

namespace libreriaMiniMarket
{
    public class bdMarca
    {
        private clsMarca clsmarca;
        private List<clsMarca> listmarca;

        private dbMiniMarketEntities1 dbMinimarket;
        private marca marca;

        private Boolean respuesta;
        private int numero;

        public List<clsMarca> consultarMarca()
        {
            listmarca = new List<clsMarca>();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                var query = from p in dbMinimarket.marca
                            orderby p.id
                            select p;

                foreach (var item in query)
                {
                    clsmarca = new clsMarca();
                    clsmarca.ID = item.id;
                    clsmarca.DESCRIPCION = item.descripcion;
                    clsmarca.ESTADO = item.estado;

                    listmarca.Add(clsmarca);
                }
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listmarca;

        }
        public clsMarca consultarMarcaxID(int id)
        {
            clsmarca = new clsMarca();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                var query = from p in dbMinimarket.marca
                            where p.id == id
                            select p;

                foreach (var item in query)
                {
                    clsmarca.ID = item.id;
                    clsmarca.DESCRIPCION = item.descripcion;
                    clsmarca.ESTADO = item.estado;
                }
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsmarca;

        }
        public int consultarMarcaMAXID()
        {
            numero = 0;
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                numero = dbMinimarket.marca.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public Boolean guardarMarca(clsMarca cls)
        {
            numero = consultarMarcaMAXID();
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                marca = new marca();
                marca.id = cls.ID;
                marca.descripcion = cls.DESCRIPCION;
                marca.estado = cls.ESTADO;

                dbMinimarket.marca.Add(marca);
                dbMinimarket.SaveChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
        public Boolean actualizarCliente(clsMarca cls)
        {
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                marca = dbMinimarket.marca.Single(x => x.id == cls.ID);
                marca.descripcion = cls.DESCRIPCION;
                marca.estado = cls.ESTADO;

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
