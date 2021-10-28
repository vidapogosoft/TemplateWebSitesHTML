using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using libreriaMiniMarket;

namespace webMTienda.Controllers
{
    public class ProductoController : ApiController
    {
        public List<clsProducto> listproducto;
        public clsProducto clsproducto;

        public bdProducto bdproducto;

        public ProductoController()
        {

        }        

        // GET: api/Producto
        [HttpGet]
        public List<clsProducto> Get()
        {
            listproducto = new List<clsProducto>();
            bdproducto = new bdProducto();
            listproducto = bdproducto.consultarProducto();
            return listproducto;
        }

        // GET: api/Producto/5
        [HttpGet]
        public clsProducto Get(int id)
        {
            clsproducto = new clsProducto();
            bdproducto = new bdProducto();
            clsproducto = bdproducto.consultarProductoxID(id);

            return clsproducto;
        }

        // POST: api/Producto
        [HttpPost]
        public IHttpActionResult Post([FromBody] clsProducto cls)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bdproducto = new bdProducto();

                    if (bdproducto.guardarProducto(cls))
                    {
                        return StatusCode(HttpStatusCode.Created);
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.BadRequest);
                    }
                }

                return StatusCode(HttpStatusCode.BadRequest);
            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Producto/1
        [HttpPut]
        public IHttpActionResult Put([FromBody] clsProducto cls)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    bdproducto = new bdProducto();
                    clsproducto = new clsProducto();

                    clsproducto = bdproducto.consultarProductoxID(cls.ID);

                    if (clsproducto.ID > 0)
                    {

                        if (bdproducto.actualizarProducto(cls))
                        {
                            return Ok("Se actualizo el registro");
                        }
                        else
                        {
                            return StatusCode(HttpStatusCode.BadRequest);
                        }
                    }
                    else
                    {
                        return StatusCode(HttpStatusCode.BadRequest);
                    }
                }

                return StatusCode(HttpStatusCode.BadRequest);               

            }
            catch (Exception e)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
        }
    }
}
