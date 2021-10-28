using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using libreriaMiniMarket;


namespace libreriaMiniMarket
{
    public class bdCategoria
    {
        private clsCategoria Clscategoria;
        private List<clsCategoria> listcategoria;

        private dbMiniMarketEntities1 dbMinimarket;
        private categoria categoria;        

        private Boolean respuesta;
        private int numero;

        public List<clsCategoria> consultarCategoria()
        {
            listcategoria = new List<clsCategoria>();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();

                var query = from p in dbMinimarket.categoria
                            orderby p.id
                            select p;

                foreach (var item in query)
                {
                    Clscategoria = new clsCategoria();
                    Clscategoria.ID = item.id;
                    Clscategoria.DESCRIPCION = item.descripcion;
                    Clscategoria.ESTADO = item.estado;

                    listcategoria.Add(Clscategoria);
                }
                dbMinimarket.Database.Connection.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return listcategoria;

        }
        public clsCategoria consultarCategoriaxID(int id)
        {
            Clscategoria = new clsCategoria();
            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                dbMinimarket.Database.Connection.Open();
                var query = from p in dbMinimarket.categoria
                            where p.id == id
                            select p;

                foreach (var item in query)
                {                    
                    Clscategoria.ID = item.id;
                    Clscategoria.DESCRIPCION = item.descripcion;
                    Clscategoria.ESTADO = item.estado;                    
                }
                dbMinimarket.Database.Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return Clscategoria;

        }
        public int consultarCategoriaMAXID()
        {
            numero = 0;
            try
            {                                
                dbMinimarket = new dbMiniMarketEntities1();
                numero = dbMinimarket.categoria.OrderByDescending(u => u.id).FirstOrDefault().id + 1;               
            }
            catch (Exception ex)
            {
                Console.WriteLine("{0} Exception caught.", ex);
            }
            return numero;

        }
        public Boolean guardarCategoria(clsCategoria cls)
        {
            numero = consultarCategoriaMAXID();
            respuesta = false;

            try
            {
                dbMinimarket = new dbMiniMarketEntities1();
                categoria = new categoria();
                categoria.id = cls.ID;
                categoria.descripcion = cls.DESCRIPCION;
                categoria.estado = cls.ESTADO;

                dbMinimarket.categoria.Add(categoria);
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
                categoria = dbMinimarket.categoria.Single(x => x.id == cls.ID);
                categoria.descripcion = cls.DESCRIPCION;
                categoria.estado = cls.ESTADO;
                
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
