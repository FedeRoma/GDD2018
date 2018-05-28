--FUNCIONALIDADES
INSERT INTO Funcionalidad (fun_desc)
VALUES	
/*01*/	('alta usuario'),
/*02*/	('modificar usuario'),
/*03*/	('alta rol'),
/*04*/	('baja rol'),
/*05*/	('modificar rol'),
/*06*/	('habilitar usuario'),
/*07*/	('inhabilitar usuario'),
/*08*/	('reservar habitación'),
/*09*/	('modificar reserva'),
/*10*/	('anular reserva'),
/*11*/	('modificar contraseña');
GO

--ROLES
INSERT INTO Rol (rol_nombre, rol_estado)
VALUES	
/*01*/	('Administrador', 1),
/*02*/	('Recepcionista', 1),
/*03*/	('Guest', 1),
/*04*/	('SysAdmin', 1);
GO

--FUNCIONALIDADES POR ROL
INSERT INTO Funcionalidad_Rol (fyr_rol_id, fyr_fun_id)
VALUES 
	--del administrador
	(1, 1), --alta usuario
	(1, 2), --modificar usuario
	(1, 3), --alta rol
	(1, 4), --baja rol
	(1, 5), --modificar rol
	(1, 6), --habilitar usuario
	(1, 7), --inhabilitar usuario
	(1, 11), --modificar contraseña
	--del recepcionista
	(2, 10), --anular reserva
	(2, 11), --modificar contraseña
	--del invitado (guest)
	(3, 8), --reservar habitación
	(3, 9), --modificar reserva
	--SysAdmin
	(4, 1),	(4, 2),	(4, 3),	(4, 4),	(4, 5),	
	(4, 6),	(4, 7),	(4, 8),	(4, 9),	(4, 10),
	(4, 11);
GO

INSERT INTO Usuario