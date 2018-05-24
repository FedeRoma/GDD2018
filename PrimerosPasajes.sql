use GD1C2018

/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Hoteles
PRINT 'Migrando Hoteles...'
INSERT INTO Hoteles
		select distinct null,Hotel_CantEstrella,Hotel_Calle,Hotel_Nro_Calle,Hotel_Ciudad,null,null,null,null,null,null,null from gd_esquema.Maestra
PRINT 'Hoteles Migrados Papaaaa...'

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Crear tabla temporal de clientes repetidos con los valores actuales del campo Cliente_Pasaporte_nro

-- eliminando si existe
IF OBJECT_ID( N'tempdb..#TemporalClientesRepetidos') IS NOT NULL
DROP TABLE #TemporalClientesRepetidos;
GO

-- creando la tabla temporal
CREATE TABLE #TemporalClientesRepetidos (
	pasaporte_repetido numeric(18,0)
);
GO

-- insertando los datos actuales de la tabla proyecto
INSERT INTO #TemporalClientesRepetidos(pasaporte_repetido)
select distinct m1.Cliente_Pasaporte_Nro from gd_esquema.Maestra m1, gd_esquema.Maestra m2 where m1.Cliente_Pasaporte_Nro = m2.Cliente_Pasaporte_Nro and m1.Cliente_Nombre <> m2.Cliente_Nombre 
		order by m1.Cliente_Pasaporte_Nro
GO
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Clientes
PRINT 'Migrando Clientes...'
INSERT INTO Clientes
	select distinct 'Pasaporte',Cliente_Pasaporte_Nro,(select hot_id from hoteles where hot_calle = m.Hotel_Calle and hot_ciudad = m.Hotel_Ciudad),
	Cliente_Nombre,Cliente_Apellido,Cliente_Mail,Cliente_Nacionalidad,Cliente_Fecha_Nac,1,
	Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,null,null,null
	from gd_esquema.Maestra m where m.cliente_pasaporte_nro not in(select * from #TemporalClientesRepetidos)
PRINT 'Clientes Migrados Papaaaa...'

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
	

	














/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
--Funciones de Ayuda
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
	
	select distinct 'Pasaporte',Cliente_Pasaporte_Nro,(select hot_id from hoteles where hot_calle = m.Hotel_Calle and hot_ciudad = m.Hotel_Ciudad),
	Cliente_Nombre,Cliente_Apellido,Cliente_Mail,Cliente_Nacionalidad,Cliente_Fecha_Nac,1,
	Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,null,null,null
	 from gd_esquema.Maestra m

	
	 select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro =  5833450
	  select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro = 8573690
	  select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro =  9616602
	   select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro = 10968810
	    select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro = 13197523
	  select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro = 17144724
		
		select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro = 17993372
		select max(cliente_pasaporte_nro) from gd_esquema.Maestra
		
	
	select * from hoteles 
	select * from clientes 

	delete from hoteles
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

