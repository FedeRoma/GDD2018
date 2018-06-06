use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Inhabilitaciones
PRINT 'Migrando Inhabilitaciones...'
insert into Inhabilitaciones(
					inh_desc
					)
VALUES
/*1*/('Mantenimiento'),
/*2*/('Ampliaciones'),
/*3*/('Otro')
GO
PRINT 'Inhabilitaciones Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/