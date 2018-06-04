use GD1C2018
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Estadias
PRINT 'Migrando Estadias...'
ALTER TABLE Estadias
ALTER COLUMN est_usu_encargado int NULL -- Estoy quitando la validación para este insert
INSERT INTO Estadias
	select reserva_codigo,null,estadia_fecha_inicio,dateadd(day,estadia_cant_noches,estadia_fecha_inicio),estadia_cant_noches,item_factura_cantidad from gd_esquema.maestra
	where factura_nro is not null and consumible_codigo is null

PRINT 'Estadias Migrados Papaaaa...'
ALTER TABLE Estadias
ALTER COLUMN est_usu_encargado int NOT NULL
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/	
