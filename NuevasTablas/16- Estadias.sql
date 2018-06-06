use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Estadias
PRINT 'Migrando Estadias...'
Insert into Estadias(
					 est_res_id,
					 est_usu_alta,
					 est_checkin,
					 est_checkout,
					 est_cant_noches,
					 est_precio,
					 est_usu_salida,
					 est_dias_sobrantes
					 )
(select distinct 
					m.Reserva_Codigo,
					u.usu_id,
					m.Estadia_Fecha_Inicio,		
					dateadd(day,m.Estadia_Cant_Noches,Estadia_Fecha_Inicio),		
					m.Estadia_Cant_Noches,
					(((m.regimen_precio*m.habitacion_tipo_porcentual)+(hotel_cantEstrella*hotel_recarga_estrella))*m.Estadia_Cant_Noches),
					u.usu_id,
					datediff(day,dateadd(day,m.Estadia_Cant_Noches,Estadia_Fecha_Inicio),r.res_fin)				
from				Reservas r,
					gd_esquema.Maestra m,
					Usuarios u
where				m.Reserva_Codigo = r.res_id and
					u.usu_id = r.res_usu_id and
					m.Estadia_Fecha_Inicio is not null
)
PRINT 'Estadias Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
