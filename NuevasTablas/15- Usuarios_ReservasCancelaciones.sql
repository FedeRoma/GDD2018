use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Usuarios_ReservasCancelaciones
PRINT 'Migrando Usuarios_ReservasCancelaciones...'
insert into Usuarios_ReservasCancelaciones(
											urc_res_id,
											urc_usu_id,
											urc_fecha,
											urc_motivo
											)
select										distinct res_id,
											usu_id,
											res_fecha,
											'Cancelación tabla maestra'
from 		reservas r,
			usuarios u,
			estados e
where		r.res_estados_id = e.estados_id
and			e.estados_desc = 'RESERVA CANCELADA MAESTRA'
and			U.usu_username = 'admin'
GO
PRINT 'Usuarios_ReservasCancelaciones Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
