use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Items_Facturas
-- Guiandonos por el consumible_precio, consideramos que item_factura_monto es item_factura_cantidad y item_factura_cantidad es item_factura_monto
PRINT 'Migrando Items_Facturas...'
ALTER TABLE Items_Facturas NOCHECK CONSTRAINT ALL
insert into Items_Facturas(
					iyf_con_id,
					iyf_fac_id,
					iyf_cantidad,
					iyf_monto
					)
select distinct consumible_codigo,
				factura_nro,
				sum(item_factura_monto),
				sum(item_factura_cantidad)
from 		gd_esquema.Maestra
where consumible_codigo is not null
group by consumible_codigo, factura_nro
order by factura_nro,consumible_codigo
GO
PRINT 'Items_Facturas Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/