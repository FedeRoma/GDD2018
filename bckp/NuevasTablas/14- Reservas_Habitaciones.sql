use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Reservas_Habitaciones
PRINT 'Migrando Reservas_Habitaciones...'
insert into Reservas_Habitaciones(
					ryh_hab_id,
					ryh_hab_hot_id,
					ryh_res_id
					)
select				distinct Ha.hab_id,
					Ho.hot_id,
					M.reserva_codigo
from 		gd_esquema.Maestra M, habitaciones Ha, hoteles Ho
where		Ho.hot_calle = M.hotel_calle
and			Ho.hot_calle_nro = M.hotel_nro_calle
and			Ha.hab_hot_id = Ho.hot_id
and			Ha.hab_numero = M.Habitacion_Numero
and			Ha.hab_piso = M.Habitacion_Piso
order by reserva_codigo
GO
PRINT 'Reservas_Habitaciones Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/