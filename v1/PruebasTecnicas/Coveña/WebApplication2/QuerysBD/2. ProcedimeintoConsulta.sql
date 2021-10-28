create procedure ConsultaProductos
as

select c.Id,c.Descripcion,c.Categoria,c.Proveedor,c.Marca,c.Modelo,c.Cantidad, c.PrecioUnitario from Productos c