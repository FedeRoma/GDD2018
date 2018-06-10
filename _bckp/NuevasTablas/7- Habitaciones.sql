use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Habitaciones
PRINT 'Migrando Habitaciones...'
insert into Habitaciones(
					hab_hot_id,
					hab_tip_id,
					hab_numero,
					hab_piso,
					hab_vista,
					hab_habilitado
					)
select distinct H.hot_id,
				M.habitacion_tipo_codigo,
				M.Habitacion_Numero,
				M.Habitacion_Piso,
				M.Habitacion_Frente,
				1
from 		gd_esquema.Maestra M,
			Hoteles H
where 	H.hot_calle = M.hotel_calle
and		H.hot_calle_nro = M.hotel_nro_calle
order by m.habitacion_tipo_codigo, H.hot_id
GO
PRINT 'Habitaciones Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/