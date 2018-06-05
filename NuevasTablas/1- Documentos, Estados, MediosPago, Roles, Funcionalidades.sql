use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Creando Documentos
PRINT 'Creando Documentos...'
INSERT INTO Documentos (doc_desc)
VALUES
/*1*/('Pasaporte'),
/*2*/('Documento Nacional de Identidad'),
/*3*/('Libreta Civica'),
/*4*/('Libreta de Enrolamiento')
GO
PRINT 'Documentos Creados'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Creando Estados
PRINT 'Creando Estados...'
INSERT INTO Estados (estados_desc)
VALUES
/*1*/('RESERVA CORRECTA'),
/*2*/('RESERVA MODIFICADA'),
/*3*/('RESERVA CANCELADA MAESTRA'),
/*4*/('RESERVA CANCELADA POR RECEPCION'),
/*5*/('RESERVA CANCELADA POR CLIENTE'),
/*6*/('RESERVA CANCELADA POR NO-SHOW'),
/*7*/('RESERVA CON INGRESO')
GO
PRINT 'Estados Creados'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Creando MediosPago
PRINT 'Creando MediosPago...'
insert into MediosPago (med_desc)
	values ('EFECTIVO');
	
insert into MediosPago (med_desc)
	values ('TARJETA');
GO
PRINT 'MediosPago Creados'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Creando Roles
PRINT 'Creando Roles...'
INSERT INTO Roles (rol_nombre,rol_estado)
VALUES
/*1*/('SYSADMIN',1),
/*2*/('ADMINISTRADOR',1),
/*3*/('RECEPCIONISTA',1),
/*4*/('GUEST',1)
GO
PRINT 'Roles Creados'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- Creando Funcionalidades
PRINT 'Creando Funcionalidades...'
INSERT INTO Funcionalidades (fun_desc)
VALUES
/*1*/('ABM ROL'),
/*2*/('ABM USUARIO'),
/*3*/('ABM CLIENTE'),
/*4*/('ABM HOTEL'),
/*5*/('ABM HABITACION'),
/*6*/('ABM REGIMEN'),
/*7*/('GENERAR RESERVA'),
/*8*/('MODIFICAR RESERVA'),
/*9*/('BAJA RESERVA'),
/*10*/('REGISTRAR ESTADIA'),
/*11*/('REGISTRAR CONSUMIBLES'),
/*12*/('LISTADO ESTADISTICO')
GO
PRINT 'Funcionalidades Creadas'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/