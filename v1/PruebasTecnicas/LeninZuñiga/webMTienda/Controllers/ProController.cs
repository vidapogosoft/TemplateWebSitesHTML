using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using libreriaMiniMarket;
using System.Net.Http;
using System.Net.Http.Headers;
using WebGrease.Css.Ast.Selectors;

namespace webMTienda.Controllers
{
    public class ProController : Controller
    {
        public clsProducto clsProducto;
        public List<clsProducto> listProducto;
        public List<SelectListItem> misCategorias;
        public List<SelectListItem> misProveedores;
        public List<SelectListItem> misMarcas;
        public List<SelectListItem> misMedidas;

        // GET: Pro
        public ActionResult Index()
        {
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

            return View(listProducto);
        }

        // GET: Pro/Details/5
        public ActionResult Details(int id)
        {
            clsProducto = new clsProducto();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44336/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Producto" + '/' + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = result.Content.ReadAsAsync<clsProducto>();
                    readTask.Wait();

                    clsProducto = readTask.Result;

                }
            }

            return View(clsProducto);
        }

        // GET: Pro/Create
        public ActionResult Create()
        {
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

                    #region "Consultar Clases"
                    misCategorias = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTCATEGORIA)
                    {
                        misCategorias.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString() ,
                        });
                    }

                    misProveedores = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTPROVEEDOR)
                    {
                        misProveedores.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }

                    misMarcas = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTMARCA)
                    {
                        misMarcas.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }

                    misMedidas = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTMEDIDA)
                    {
                        misMedidas.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }
                    #endregion

                    ViewData["misCategorias"] = misCategorias;
                    ViewData["misProveedores"] = misProveedores;
                    ViewData["misMarcas"] = misMarcas;
                    ViewData["misMedidas"] = misMedidas;
                }
            }

            return View();
        }        

        // POST: Pro/Create
        [HttpPost]
        public ActionResult Create(clsProducto cls)
        {
            try
            {
                // TODO: Add insert logic here
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

                        //respuesta = true;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //lblError.Text = "Error al guardar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage;
                        //lblError.Visible = true;
                        return View("Error al guardar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage);
                    }
                }

            }
            catch
            {
                return View();
            }
        }

        // GET: Pro/Edit/5
        public ActionResult Edit(int id)
        {
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

                    #region "Consultar Clases"
                    misCategorias = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTCATEGORIA)
                    {
                        misCategorias.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }

                    misProveedores = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTPROVEEDOR)
                    {
                        misProveedores.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }

                    misMarcas = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTMARCA)
                    {
                        misMarcas.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }

                    misMedidas = new List<SelectListItem>();

                    foreach (var item in listProducto[0].LISTMEDIDA)
                    {
                        misMedidas.Add(new SelectListItem
                        {
                            Text = item.DESCRIPCION,
                            Value = item.ID.ToString(),
                        });
                    }
                    #endregion

                    ViewData["misCategorias"] = misCategorias;
                    ViewData["misProveedores"] = misProveedores;
                    ViewData["misMarcas"] = misMarcas;
                    ViewData["misMedidas"] = misMedidas;
                }
            }

            return View();
        }

        // POST: Pro/Edit/5
        [HttpPost]
        public ActionResult Edit(clsProducto cls)
        {
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
                        //respuesta = true;
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        //lblError.Text = "Error al modificar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage;
                        //lblError.Visible = true;
                        return View("Error al modificar. Error: " + result.StatusCode + " Descripción:" + result.RequestMessage);
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Pro/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pro/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
