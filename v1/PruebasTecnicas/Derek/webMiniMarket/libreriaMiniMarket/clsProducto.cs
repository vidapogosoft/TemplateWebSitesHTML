using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaMiniMarket
{
    [Serializable]
    public class clsProducto
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string descripcion;

        public string DESCRIPCION
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        private int id_categoria;

        public int ID_CATEGORIA
        {
            get { return id_categoria; }
            set { id_categoria = value; }
        }

        private string descripcion_categoria;

        public string DESCRIPCION_CATEGORIA
        {
            get { return descripcion_categoria; }
            set { descripcion_categoria = value; }
        }

        private int id_proveedor;

        public int ID_PROVEEDOR
        {
            get { return id_proveedor; }
            set { id_proveedor = value; }
        }

        private string descripcion_proveedor;

        public string DESCRIPCION_PROVEEDOR
        {
            get { return descripcion_proveedor; }
            set { descripcion_proveedor = value; }
        }

        private int id_marca;

        public int ID_MARCA
        {
            get { return id_marca; }
            set { id_marca = value; }
        }

        private string descripcion_marca;

        public string DESCRIPCION_MARCA
        {
            get { return descripcion_marca; }
            set { descripcion_marca = value; }
        }

        private int id_medida;

        public int ID_MEDIDA
        {
            get { return id_medida; }
            set { id_medida = value; }
        }

        private string descripcion_medida;

        public string DESCRIPCION_MEDIDA
        {
            get { return descripcion_medida; }
            set { descripcion_medida = value; }
        }

        private double cantidad;

        public double CANTIDAD
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        private double precio_unitario;

        public double PRECIO_UNITARIO
        {
            get { return precio_unitario; }
            set { precio_unitario = value; }
        }

        #region "Clases"
        private List<clsCategoria> listcategoria;

        public List<clsCategoria> LISTCATEGORIA
        {
            get { return listcategoria; }
            set { listcategoria = value; }
        }

        private List<clsProveedor> listproveedor;

        public List<clsProveedor> LISTPROVEEDOR
        {
            get { return listproveedor; }
            set { listproveedor = value; }
        }

        private List<clsMarca> listmarca;

        public List<clsMarca> LISTMARCA
        {
            get { return listmarca; }
            set { listmarca = value; }
        }

        private List<clsMedida> listmedida;

        public List<clsMedida> LISTMEDIDA
        {
            get { return listmedida; }
            set { listmedida = value; }
        }
        #endregion

        public clsProducto()
        {
            this.id = 0;
            this.descripcion = "";
            this.id_categoria = 0;
            this.descripcion_categoria = "";
            this.id_proveedor = 0;
            this.descripcion_proveedor = "";
            this.id_marca = 0;
            this.descripcion_marca = "";
            this.id_medida = 0;
            this.descripcion_medida = "";
            this.cantidad = 0;
            this.precio_unitario = 0;
            this.listcategoria = new List<clsCategoria>();
            this.listproveedor = new List<clsProveedor>();
            this.listmarca = new List<clsMarca>();
            this.listmedida = new List<clsMedida>();
        }

        public clsProducto(int ID,
                            String DESCRIPCION,
                            int ID_CATEGORIA,
                            string DESCRIPCION_CATEGORIA,
                            int ID_PROVEEDOR,
                            string DESCRIPCION_PROVEEDOR,
                            int ID_MARCA,
                            string DESCRIPCION_MARCA,
                            int ID_MEDIDA,
                            string DESCRIPCION_MEDIDA,
                            double CANTIDAD,
                            double PRECIO_UNITARIO,
                            List<clsCategoria> LISTCATEGORIA,
                            List<clsProveedor> LISTPROVEEDOR,
                            List<clsMarca> LISTMARCA,
                            List<clsMedida> LISTMEDIDA
                            )
        {
            this.id = ID;
            this.descripcion = DESCRIPCION;
            this.id_categoria = ID_CATEGORIA;
            this.descripcion_categoria = DESCRIPCION_CATEGORIA;
            this.id_proveedor = ID_PROVEEDOR;
            this.descripcion_proveedor = DESCRIPCION_PROVEEDOR;
            this.id_marca = ID_MARCA;
            this.descripcion_marca = DESCRIPCION_MARCA;
            this.id_medida = ID_MEDIDA;
            this.descripcion_medida = DESCRIPCION_MEDIDA;
            this.cantidad = CANTIDAD;
            this.precio_unitario = PRECIO_UNITARIO;

            this.listcategoria = LISTCATEGORIA;
            this.listproveedor = LISTPROVEEDOR;
            this.listmarca = LISTMARCA;
            this.listmedida = LISTMEDIDA;
        }
    }
}
