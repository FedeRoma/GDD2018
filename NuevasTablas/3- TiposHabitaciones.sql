use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A TiposHabitaciones
PRINT 'Migrando TiposHabitaciones...'
insert into TiposHabitaciones (
						tip_id,
						tip_nombre,
						tip_porcentual,
						tip_personas)
select distinct 	Habitacion_Tipo_codigo,
					Habitacion_Tipo_descripcion,
					Habitacion_Tipo_porcentual,
					1
from gd_esquema.Maestra
-- Actualizo la cantidad de personas
update TiposHabitaciones
	set tip_personas = case when tip_nombre = 'Base Simple' Then 1
							when tip_nombre = 'Base Doble' Then 2
							when tip_nombre = 'Base Triple' Then 3
							when tip_nombre = 'Base Cuadruple' Then 4
							else 5 end
GO
PRINT 'TiposHabitaciones migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/