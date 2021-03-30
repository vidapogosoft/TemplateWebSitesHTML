--usar trigget

create trigger Tr_Historial_Producto
on productos
for update
as
begin 
insert into HistorialProductos (id,Descripcion,Categoria,Proveedor,Marca,Modelo,Cantidad, actividad,fecharegistro) select id,Descripcion,Categoria,Proveedor,Marca,Modelo,Cantidad, 'se edita registro', fecharegistro
from inserted
end
