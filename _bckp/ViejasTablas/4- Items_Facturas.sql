use GD1C2018

/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Items_Facturas
ALTER TABLE Items_Facturas NOCHECK CONSTRAINT ALL

PRINT 'Migrando Items_Facturas...'
INSERT INTO Items_Facturas
		select consumible_codigo,factura_nro,sum(item_factura_monto),sum(item_factura_cantidad) from gd_esquema.maestra
	where consumible_codigo is not null
	group by consumible_codigo, factura_nro
PRINT 'Items_Facturas Migrados Papaaaa...'

ALTER TABLE Items_Facturas NOCHECK CONSTRAINT ALL
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/