﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Infraestructura.MiniMarket.DataModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class minimarketEntities : DbContext
    {
        public minimarketEntities()
            : base("name=minimarketEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tcategoria> tcategoria { get; set; }
        public virtual DbSet<tmarca> tmarca { get; set; }
        public virtual DbSet<tproducto> tproducto { get; set; }
        public virtual DbSet<tproveedor> tproveedor { get; set; }
    
        public virtual ObjectResult<consultarCategoria_SP_Result> consultarCategoria_SP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarCategoria_SP_Result>("consultarCategoria_SP");
        }
    
        public virtual ObjectResult<consultarMarca_SP_Result> consultarMarca_SP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarMarca_SP_Result>("consultarMarca_SP");
        }
    
        public virtual ObjectResult<consultarProducto_SP_Result> consultarProducto_SP(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarProducto_SP_Result>("consultarProducto_SP", idProductoParameter);
        }
    
        public virtual ObjectResult<consultarProveedor_SP_Result> consultarProveedor_SP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarProveedor_SP_Result>("consultarProveedor_SP");
        }
    
        public virtual ObjectResult<consultarProducto_SP1_Result> consultarProducto_SP1(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("idProducto", idProducto) :
                new ObjectParameter("idProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarProducto_SP1_Result>("consultarProducto_SP1", idProductoParameter);
        }
    
        public virtual ObjectResult<consultarProductoTodos_SP_Result> consultarProductoTodos_SP()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarProductoTodos_SP_Result>("consultarProductoTodos_SP");
        }
    
        public virtual ObjectResult<consultarProductoTodos_SP_Result> consultarProductoTodos_SP1()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<consultarProductoTodos_SP_Result>("consultarProductoTodos_SP1");
        }

        public System.Data.Entity.DbSet<Dominio.MiniMarket.Entidades.Productos> Productos { get; set; }
    }
}