using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace libreriaMiniMarket
{
    [Serializable]
    public class clsCategoria
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

        private string estado;

        public string ESTADO
        {
            get { return estado; }
            set { estado = value; }
        }

        public clsCategoria() {
            this.id = 0;
            this.descripcion = "";
            this.estado = "";
        }

        public clsCategoria(int ID,
                            string DESCRIPCION,
                            string ESTADO)
        {
            this.id = ID;
            this.descripcion = DESCRIPCION;
            this.estado = ESTADO;
        }
    }
}
