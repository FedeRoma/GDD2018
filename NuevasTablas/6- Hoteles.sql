use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Consumibles
PRINT 'Migrando Consumibles...'
insert into Hoteles(
					hot_estrellas,
					hot_calle,
					hot_calle_nro,
					hot_ciudad,
					hot_habilitado)
				
select distinct 	hotel_cantestrella,
					hotel_calle,
					hotel_nro_calle,
					hotel_ciudad,
					1

from gd_esquema.Maestra
GO
PRINT 'Consumibles Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/