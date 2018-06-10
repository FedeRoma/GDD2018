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

-- insertando los CLIENTES CON PASAPORTE REPETIDO EN LA TABLA TEMPORAL
INSERT INTO #TemporalClientesRepetidos(pasaporte_repetido)
select distinct m1.Cliente_Pasaporte_Nro from gd_esquema.Maestra m1, gd_esquema.Maestra m2 where m1.Cliente_Pasaporte_Nro = m2.Cliente_Pasaporte_Nro and m1.Cliente_Nombre <> m2.Cliente_Nombre 
		order by m1.Cliente_Pasaporte_Nro
GO
-- insertando los CLIENTES CON MAIL REPETIDO EN LA TABLA TEMPORAL
INSERT INTO #TemporalClientesRepetidos(pasaporte_repetido)
select distinct m1.Cliente_Pasaporte_Nro from gd_esquema.Maestra m1, gd_esquema.Maestra m2 where m1.Cliente_Mail = m2.Cliente_Mail and m1.Cliente_Nombre <> m2.Cliente_Nombre 
		order by m1.Cliente_Pasaporte_Nro
GO

--ACA QUEDE LABURANDO CON LOS REPETIDOS DE MAIL
/*
select tipoDoc,nroDoc,apellido,nombre,fecha_nac,mail,direccion,nacionalidad,
	habilitado,telefono,'mail duplicado'
from GESTION_DE_GATOS.Cliente
Where idCli >
(select MIN(idCli)
from GESTION_DE_GATOS.Cliente as auxCli
where Cliente.mail = auxCli.mail

*/

/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Clientes_Errores
PRINT 'Migrando Clientes Errores...'
INSERT INTO Clientes_Errores
	select distinct 1,Cliente_Pasaporte_Nro,
	Cliente_Nombre,Cliente_Apellido,Cliente_Mail,Cliente_Nacionalidad,Cliente_Fecha_Nac,1,
	Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,null,null,null,'Documento Repetido'
	from gd_esquema.Maestra m where m.cliente_pasaporte_nro in(select * from #TemporalClientesRepetidos)
PRINT 'Clientes Errores Migrados Papaaaa...'



/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Clientes
PRINT 'Migrando Clientes...'
INSERT INTO Clientes
	select distinct Cliente_Pasaporte_Nro,1,
	Cliente_Nombre,Cliente_Apellido,Cliente_Mail,Cliente_Nacionalidad,Cliente_Fecha_Nac,1,
	Cliente_Dom_Calle,Cliente_Nro_Calle,Cliente_Piso,Cliente_Depto,null,null,null
	from gd_esquema.Maestra m where m.cliente_pasaporte_nro not in(select * from #TemporalClientesRepetidos)
PRINT 'Clientes Migrados Papaaaa...'
DROP TABLE #TemporalClientesRepetidos;

-- Agrego ahora la condicion de que mails sea unico en clientes

Alter table Clientes
add constraint cli_mail UNIQUE (cli_mail);