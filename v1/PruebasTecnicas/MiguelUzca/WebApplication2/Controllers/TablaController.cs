using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using WebApplication2.Models.NewFolder1;

namespace WebApplication2.Controllers
{
    public class TablaController : Controller
    {
        #region Consultar
        // GET: Tabla
        public ActionResult Index()
        {
            List<ListProductos> lst;
            using (InventarioEntities db = new InventarioEntities())
            {

                //lst = (from Product in db.Productos
                //       select new ListProductos
                //       {
                //           Id = Product.Id,
                //           Descripcion = Product.Descripcion,
                //           Categoria = Product.Categoria,
                //           Proveedor = Product.Proveedor,
                //           Marca = Product.Marca,
                //           Modelo = Product.Modelo,
                //           Cantidad = Product.Cantidad,
                //           PrecioUnitario = Product.PrecioUnitario

                //       }).ToList();


                 lst = db.Database.SqlQuery<ListProductos>("SELECT * FROM dbo.Productos").ToList();
                //return PartialView("DetalleGridView", data);

            }
            return View(lst);
        }
        #endregion

        #region Ingresar

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaIngreso model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InventarioEntities db = new InventarioEntities())
                    {
                        var tbl = new Productos();

                        tbl.Id = model.Id;
                         tbl.Descripcion = model.Descripcion;
                         tbl.Categoria = model.Categoria;
                         tbl.Proveedor = model.Proveedor;
                         tbl.Marca = model.Marca;
                         tbl.Modelo = model.Modelo;
                         tbl.Cantidad = model.Cantidad;
                         tbl.PrecioUnitario = model.PrecioUnitario;
                        tbl.fechaRegistro = DateTime.Now;
                        

                        db.Productos.Add(tbl);
                        db.SaveChanges();

                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);
            }
            catch ( Exception ex)
            {
                throw new Exception(ex.Message);
            }
           // return View();
        }


        #endregion


        #region Editar

        public ActionResult Editar(int id)
        {
            TablaIngreso model = new TablaIngreso();
            using (InventarioEntities db = new InventarioEntities())
            {
                var registro = db.Productos.Find(id);
                model.Descripcion = registro.Descripcion;
                model.Categoria = registro.Categoria;
                model.Proveedor = registro.Proveedor;
                model.Marca = registro.Marca;
                model.Modelo = registro.Modelo;
                model.Cantidad = registro.Cantidad;
                model.PrecioUnitario = registro.PrecioUnitario;
                
            }

                return View(model);
        }

      

        [HttpPost]
        public ActionResult Editar(TablaIngreso model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (InventarioEntities db = new InventarioEntities())
                    {
                        var registro = db.Productos.Find(model.Id);
                        registro.Descripcion = model.Descripcion;
                        registro.Categoria = model.Categoria;
                        registro.Proveedor = model.Proveedor;
                        registro.Marca = model.Marca;
                        registro.Modelo = model.Modelo;
                        registro.Cantidad = model.Cantidad;
                        registro.PrecioUnitario = model.PrecioUnitario;
                        registro.fechaRegistro = DateTime.Now;

                        db.Entry(registro).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        
                    }

                    return Redirect("~/Tabla/");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //return View();
        }

        #endregion

        #region eliminar

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            TablaIngreso model = new TablaIngreso();
            using (InventarioEntities db = new InventarioEntities())
            {
                var registro = db.Productos.Find(id);
                db.Productos.Remove(registro);
                db.SaveChanges();
            }

            return Redirect("~/Tabla/");
        }

        #endregion
    }
}