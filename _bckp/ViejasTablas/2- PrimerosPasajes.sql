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
DROP TABLE #TemporalClientesRepetidos;
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Consumibles
PRINT 'Migrando Consumibles...'
INSERT INTO Consumibles
		select distinct Consumible_Codigo,Consumible_Descripcion,Consumible_Precio from gd_esquema.Maestra where Consumible_Codigo is not null
PRINT 'Consumibles Migrados Papaaaa...'

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/	


-- TRASPASO DE DATOS DE gd_esquema.Maestra A TIPOS_HABITACIONES
PRINT 'Migrando TiposHabitaciones...'
INSERT INTO TiposHabitaciones
	select distinct Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion
	from gd_esquema.Maestra m 
PRINT 'TiposHabitaciones Migrados Papaaaa...'

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/


-- Crear tabla temporal de Habitaciones

-- eliminando si existe
IF OBJECT_ID( N'tempdb..#TemporalHabitaciones') IS NOT NULL
DROP TABLE #TemporalHabitaciones;
GO

-- creando la tabla temporal
CREATE TABLE #TemporalHabitaciones (
	
	[hab_hot_ciudad] nvarchar(255) NOT NULL,
	[hab_hot_calle] nvarchar(255) NOT NULL,
	[hab_tip_id] [int] NOT NULL,
	[hab_numero] [int] NOT NULL,
	[hab_piso] [int] NOT NULL,
	[hab_vista] [char](1) NOT NULL,
	[hab_desc] [varchar](50) NULL,
	[hab_habilitado] [bit] NULL
);
GO

-- insertando los datos actuales de la tabla proyecto
INSERT INTO #TemporalHabitaciones(hab_hot_ciudad,hab_hot_calle,hab_tip_id,hab_numero,hab_piso,hab_vista,hab_desc,hab_habilitado)
select m.Hotel_Ciudad,m.Hotel_Calle, Habitacion_Tipo_Codigo, Habitacion_Numero,Habitacion_Piso, Habitacion_Frente,null,null
	from gd_esquema.Maestra m 
	group by m.Hotel_Ciudad,m.Hotel_Calle,Habitacion_Tipo_Codigo, Habitacion_Numero,Habitacion_Piso, Habitacion_Frente
	order by Hotel_Calle,Habitacion_Piso,Habitacion_Numero
GO


-- TRASPASO DE DATOS DE gd_esquema.Maestra A HABITACIONES
PRINT 'Migrando Habitaciones...'

INSERT INTO Habitaciones(hab_hot_id,hab_tip_id,hab_numero,hab_piso,hab_vista,hab_desc,hab_habilitado)
	select (select top 1 hot_id from Hoteles h where hab_hot_ciudad=h.hot_ciudad and hab_hot_calle = h.hot_calle),hab_tip_id,hab_numero,hab_piso,hab_vista,hab_desc,hab_habilitado 
	from #TemporalHabitaciones
	
PRINT 'Habitaciones Migrados Papaaaa...'

drop TABLE #TemporalHabitaciones
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

-- TRASPASO DE DATOS DE gd_esquema.Maestra A Regimenes
PRINT 'Migrando Regimenes...'
INSERT INTO Regimenes
		select distinct Regimen_Descripcion,Regimen_Precio,NULL from gd_esquema.Maestra
PRINT 'Regimenes Migrados Papaaaa...'

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Regimen_Hotel
PRINT 'Migrando Regimenes_Hoteles..'
INSERT INTO Regimenes_Hoteles
		select distinct (select hot_id from Hoteles where Hotel_Calle=hot_calle and Hotel_Ciudad=hot_ciudad),
		(select reg_id from Regimenes where  Regimen_Descripcion = reg_desc and reg_precio =Regimen_Precio )
		from gd_esquema.Maestra
PRINT 'Regimen_Hotel Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/



/*Clientes consumibles
Estadia
Estados
Factura
Funcionalidad
inhabilitado
*/







/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
--Funciones de Ayuda
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
	/*
	 select * from gd_esquema.Maestra m where m.Cliente_Pasaporte_Nro =  5833450

		
	
	--Selects de chequeo!

	select * from hoteles 
	select * from clientes 
	select * from TiposHabitaciones
	select * from Habitaciones,tiposHabitaciones where hab_tip_id = tip_id
	select * from #TemporalHabitaciones
	select * from #TemporalClientesRepetidos
	select * from regimenes,regimen_hotel,hoteles where hot_id = ryh_hot_id and reg_id = ryh_reg_id and hot_id = 3

	
	select distinct Reserva_Codigo,Reserva_Cant_Noches,Reserva_Fecha_Inicio from gd_esquema.Maestra

select distinct m1.Reserva_Codigo from gd_esquema.Maestra m1, gd_esquema.Maestra m2 
where m1.Reserva_Codigo = m2.Reserva_Codigo and m1.Cliente_Pasaporte_Nro <> m2.Cliente_Pasaporte_Nro 
		order by m1.Reserva_Codigo

		
	
	select top 1 hot_id,h.hot_calle,hab_hot_calle,h.hot_ciudad,hab_hot_ciudad from Hoteles h, #TemporalHabitaciones where 'Bahía Blanca'=h.hot_ciudad and 'Avenida Eva Perón' = h.hot_calle
	order by hot_id
	*/
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

