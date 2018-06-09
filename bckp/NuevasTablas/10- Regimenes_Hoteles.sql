use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Regimenes_Hoteles
PRINT 'Migrando Regimenes_Hoteles...'
insert into Regimenes_Hoteles(
					ryh_hot_id,
					ryh_reg_id
					)
select distinct (select hot_id from Hoteles where Hotel_Calle=hot_calle and Hotel_Ciudad=hot_ciudad),
				(select reg_id from Regimenes where  Regimen_Descripcion = reg_desc and reg_precio =Regimen_Precio )
from 		gd_esquema.Maestra
GO
PRINT 'Regimenes_Hoteles Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
