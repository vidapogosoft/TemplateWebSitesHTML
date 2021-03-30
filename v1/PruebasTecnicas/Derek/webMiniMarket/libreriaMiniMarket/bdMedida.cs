using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libreriaMiniMarket;

namespace libreriaMiniMarket
{
    public class bdMedida
    {
        private clsMedida clsmedida;
        private List<clsMedida> listmedida;

        private dbMiniMarketEntities1 dbMinimarket;
        private medida medida;

        private Boolean respuesta;
        private int numero;

        public List<clsMedida> consultarMedida()
        {
            listmedida = new List<clsMedida>();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();

                var query = from p in dbMinimarket.medida
                            orderby p.id
                            select p;

                foreach (var item in query)
                {
                    clsmedida = new clsMedida();
                    clsmedida.ID = item.id;
                    clsmedida.DESCRIPCION = item.descripcion;
                    clsmedida.ESTADO = item.estado;

                    listmedida.Add(clsmedida);
                }
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listmedida;

        }
        public clsMedida consultarMedidaxID(int id)
        {
            clsmedida = new clsMedida();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();

                var query = from p in dbMinimarket.medida
                            where p.id == id
                            select p;

                foreach (var item in query)
                {
                    clsmedida.ID = item.id;
                    clsmedida.DESCRIPCION = item.descripcion;
                    clsmedida.ESTADO = item.estado;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return clsmedida;

        }
        public int consultarMedidaMAXID()
        {
            numero = 0;
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                numero = dbMinimarket.medida.OrderByDescending(u => u.id).FirstOrDefault().id + 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public Boolean guardarMedida(clsMedida cls)
        {
            numero = consultarMedidaMAXID();
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                medida = new medida();
                medida.id = cls.ID;
                medida.descripcion = cls.DESCRIPCION;
                medida.estado = cls.ESTADO;

                dbMinimarket.medida.Add(medida);
                dbMinimarket.SaveChanges();

                respuesta = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Error:" + ex.Message);
            }

            return respuesta;
        }
        public Boolean actualizarMedida(clsMedida cls)
        {
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                medida = dbMinimarket.medida.Single(x => x.id == cls.ID);
                medida.descripcion = cls.DESCRIPCION;
                medida.estado = cls.ESTADO;

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
