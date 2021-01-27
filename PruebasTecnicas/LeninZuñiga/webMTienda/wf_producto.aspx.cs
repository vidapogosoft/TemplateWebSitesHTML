using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using libreriaMiniMarket;
using System.Net.Http;
using System.Net.Http.Headers;

namespace webMTienda.Views.Producto
{
    public partial class wf_producto : System.Web.UI.Page
    {
        public clsProducto clsProducto;
        public List<clsProducto> listProducto;

        #region "API"        
        public List<clsProducto> consultarProductos() {
            
            listProducto = new List<clsProducto>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44336/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Producto");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<List<clsProducto>>();
                    readTask.Wait();

                    listProducto = readTask.Result;
                    
                }
            }            

            return listProducto;
        }
        public Boolean guardarProductos(clsProducto cls) {
            Boolean respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/");
                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<clsProducto>("Producto", cls);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {

                        var readTask = result.Content.ReadAsAsync<clsProducto>();
                        readTask.Wait();

                        respuesta = true;
                    }
                    else
                    {
                        lblError.Text = "Error al guardar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage;
                        lblError.Visible = true;
                    }
                }               
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al guardar. Error: " + ex.Message;
                lblError.Visible = true;
            }
            return respuesta;
        }
        public Boolean modificarProductos(clsProducto cls)
        {
            Boolean respuesta = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:44336/api/");
                    //HTTP PUT
                    var putTask = client.PutAsJsonAsync<clsProducto>("Producto", cls);
                    putTask.Wait();

                    var result = putTask.Result;
                    if (result.IsSuccessStatusCode)
                    {                        
                        respuesta = true;
                    }
                    else {                        
                        lblError.Text = "Error al modificar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage;
                        lblError.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error al modificar. Error: " + ex.Message;
                lblError.Visible = true;
            }
            return respuesta;
        }
        #endregion
        public void nuevo()
        {
            try
            {
                lblError.Visible = false;
                lblMensaje.Visible = false;
                btnFinalizar.Enabled = true;

                listProducto = new List<clsProducto>();
                listProducto = consultarProductos();

                txtIdProducto.Text = (listProducto[listProducto.Count - 1].ID + 1).ToString();

                txtDescripcion.Text = "";
                txtCategoria.Text = "";
                txtProveedor.Text = "";
                txtMarca.Text = "";
                txtMedida.Text = "";
                txtCantidad.Text = "";
                txtPrecioUnitario.Text = "";

            }
            catch (Exception ex)
            {

            }
        }
        public Boolean validar() {            
            Boolean Retornar = false;

            try
            {
                Boolean encuentra = true;
                string mensaje = "";

                if (txtIdProducto.Text == "")
                {
                    mensaje = "Cedula en blanco";
                    encuentra = false;
                }

                if (txtDescripcion.Text == "")
                {
                    mensaje = "Descripción en blanco";
                    encuentra = false;
                }

                if (txtCategoria.Text == "")
                {
                    mensaje = "Categoria en blanco";
                    encuentra = false;
                }

                if (txtProveedor.Text == "")
                {
                    mensaje = "Proveedor en blanco";
                    encuentra = false;
                }

                if (txtMarca.Text == "")
                {
                    mensaje = "Marca en blanco";
                    encuentra = false;
                }

                if (txtMedida.Text == "")
                {
                    mensaje = "Medida en blanco";
                    encuentra = false;
                }

                if (txtCantidad.Text == "")
                {
                    mensaje = "Cantidad en blanco";
                    encuentra = false;
                }

                if (txtPrecioUnitario.Text == "")
                {
                    mensaje = "Prcio Unitario en blanco";
                    encuentra = false;
                }

                if (encuentra || mensaje == "")
                {
                    Retornar = true;
                }
                else {
                    lblError.Text = mensaje;
                    lblError.Visible = true;
                }                

            }
            catch (Exception ex)
            {
                lblError.Text = "Error desde validar." + ex.Message;
                lblError.Visible = true;
            }

            return Retornar;
        }
        public Boolean Finalizar() {
            Boolean retornar = false;
            lblError.Visible = false;
            lblMensaje.Visible = false;

            try
            {
                if (validar())
                {
                    clsProducto = new clsProducto();
                    clsProducto.ID = int.Parse(txtIdProducto.Text);
                    clsProducto.DESCRIPCION = txtDescripcion.Text;
                    clsProducto.ID_CATEGORIA = int.Parse(txtCategoria.Text);
                    clsProducto.ID_PROVEEDOR = int.Parse(txtProveedor.Text);
                    clsProducto.ID_MARCA = int.Parse(txtMarca.Text);
                    clsProducto.ID_MEDIDA = int.Parse(txtMedida.Text);
                    clsProducto.CANTIDAD = double.Parse(txtCantidad.Text);
                    clsProducto.PRECIO_UNITARIO = double.Parse(txtPrecioUnitario.Text.Replace('.', ','));                    

                    if (guardarProductos(clsProducto))
                    {
                        retornar = true;
                        lblMensaje.Text = "SE GRABO EXITOSAMENTE LA INFORMACIÓN";
                        lblMensaje.Visible = true;
                    }                    
                }
            }
            catch (Exception ex)
            {
                                
            }
            return retornar;
        }
        public Boolean Modificar()
        {
            Boolean retornar = false;
            lblError.Visible = false;
            lblMensaje.Visible = false;

            try
            {
                if (validar())
                {
                    clsProducto = new clsProducto();
                    clsProducto.ID = int.Parse(txtIdProducto.Text);
                    clsProducto.DESCRIPCION = txtDescripcion.Text;
                    clsProducto.ID_CATEGORIA = int.Parse(txtCategoria.Text);
                    clsProducto.ID_PROVEEDOR = int.Parse(txtProveedor.Text);
                    clsProducto.ID_MARCA = int.Parse(txtMarca.Text);
                    clsProducto.ID_MEDIDA = int.Parse(txtMedida.Text);
                    clsProducto.CANTIDAD = double.Parse(txtCantidad.Text);
                    clsProducto.PRECIO_UNITARIO = double.Parse(txtPrecioUnitario.Text.Replace('.', ','));

                    if (modificarProductos(clsProducto))
                    {
                        retornar = true;
                        lblMensaje.Text = "SE MODIFICO EXITOSAMENTE LA INFORMACIÓN";
                        lblMensaje.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return retornar;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    nuevo();
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error desde Load" + ex.Message;
                lblError.Visible = true;
            }
        }
        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            Finalizar();
        }
        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevo();
        }
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Modificar();
        }
    }
}