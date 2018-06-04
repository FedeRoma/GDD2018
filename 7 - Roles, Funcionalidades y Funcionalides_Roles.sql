--ROLES
INSERT INTO Roles (rol_nombre, rol_estado)
VALUES	
/*01*/	('Administrador', 1),
/*02*/	('Recepcionista', 1),
/*03*/	('Guest', 1),
/*04*/	('SysAdmin', 1);
GO

--FUNCIONALIDADES
INSERT INTO Funcionalidades (fun_nombre, fun_tipo)
VALUES
/*01*/	('crearRol', 'alta de rol'),
/*02*/	('borrarRol', 'baja de rol'),
/*03*/	('editarRol', 'modificación de rol'),
/*04*/	('crearFuncionalidad', 'alta de funcionalidad'),
/*05*/	('borrarFuncionalidad', 'baja de funcionalidad'),
/*06*/	('habilitarRol', 'habilitación de rol'),
/*07*/	('inhabilitarRol','inhabilitación de rol'),
/*08*/	('listarRoles', 'ver lista de roles disponibles'),
/*09*/	('crearReserva', 'alta de reserva hotelera'),
/*10*/	('editarReserva', 'modificación de reserva hotelera'),
/*11*/	('habilitarUsuario', 'habilitación de usuario'),
/*12*/	('inhabilitarUsuario','inhabilitación de usuario'),
/*13*/	('crearUsuario', 'alta de usuario'),
/*14*/	('editarUsuario', 'modificación de usuario'),
/*15*/	('nuevaPassword', 'modificación de contraseña'),
/*16*/	('crearCliente', 'alta de cliente'),
/*17*/	('borrarCliente', 'baja de cliente'),
/*18*/	('editarCliente', 'modificación de cliente'),
/*19*/	('habilitarCliente', 'habilitación de cliente'),
/*20*/	('inhabilitarCliente', 'inhabilitación de cliente'),
/*21*/	('listarClientes', 'ver lista de clientes disponibles'),
/*22*/	('crearHotel', 'alta de hotel'),
/*23*/	('borrarHotel', 'baja de hotel'),
/*24*/	('editarHotel', 'modificación de hotel'),
/*25*/	('listarHoteles', 'ver lista de hoteles disponibles'),
/*26*/	('crearHabitacion', 'alta de habitación'),
/*27*/	('borrarHabitacion', 'baja de habitación'),
/*28*/	('editarHabitacion', 'modificación de habitación'),
/*29*/	('crearRegimenEstadia', 'alta de régimen de estadía'),
/*30*/	('borrarRegimenEstadia', 'baja de régimen de estadía'),
/*31*/	('editarRegimenEstadia', 'modificación de régimen de estadía'),
/*32*/	('listarRegimenEstadia', 'ver regímenes de estadía disponibles en hotel'),
/*33*/	('cancelarReserva', 'baja de reserva hotelera'),
/*34*/	('checkIn', 'ingreso al hotel'),
/*35*/	('checkOut', 'egreso del hotel'),
/*36*/	('agregarConsumible', 'agregar item consumible'),
/*37*/	('quitarConsumible', 'quitar item consumible'),
/*38*/	('facturarEstadia', 'generar factura'),
/*39*/	('listadoEstadistico', 'consultar el TOP 5');
GO

--FUNCIONALIDADES POR ROL
INSERT INTO Funcionalidades_Roles (fyr_rol_id, fyr_fun_id)
VALUES 
	--del Administrador
	(1, 1),		--(Administrador, crearRol)
	(1, 2),		--(Administrador, borrarRol)
	(1, 3),		--(Administrador, editarRol)
	(1, 4),		--(Administrador, crearFuncionalidad)
	(1, 5),		--(Administrador, borrarFuncionalidad)
	(1, 6),		--(Administrador, habilitarRol)
	(1, 7),		--(Administrador, inhabilitarRol)
	(1, 8),		--(Administrador, listarRoles)
	(1, 13),	--(Administrador, crearUsuario)
	(1, 14),	--(Administrador, editarUsuario)
	(1, 15),	--(Administrador, nuevaPassword)
	(1, 19),	--(Administrador, habilitarCliente)
	(1, 20),	--(Administrador, inhabilitarCliente)
	(1, 21),	--(Administrador, listarClientes)
	(1, 22),	--(Administrador, crearHotel)
	(1, 23),	--(Administrador, borrarHotel)
	(1, 24),	--(Administrador, editarHotel)
	(1, 25),	--(Administrador, listarHoteles)
	(1, 26),	--(Administrador, crearHabitacion)
	(1, 27),	--(Administrador, borrarHabitacion)
	(1, 28),	--(Administrador, editarHabitacion)
	(1, 29),	--(Administrador, crearRegimenEstadia)
	(1, 30),	--(Administrador, borrarRegimenEstadia)
	(1, 31),	--(Administrador, editarRegimenEstadia)
	--del Recepcionista
	(2, 9),		--(Recepcionista, crearReserva)	
	(2, 10),	--(Recepcionista, editarReserva)
	(2, 15),	--(Recepcionista, nuevaPassword)
	(2, 16),	--(Recepcionista, crearCliente)
	(2, 17),	--(Recepcionista, borrarCliente)
	(2, 18),	--(Recepcionista, editarCliente)
	(2, 19),	--(Recepcionista, habilitarCliente)
	(2, 20),	--(Recepcionista, inhabilitarCliente)
	(2, 21),	--(Recepcionista, listarClientes)
	(2, 32),	--(Recepcionista, listarRegimenEstadia)
	(2, 33),	--(Recepcionista, cancelarReserva)
	(2, 34),	--(Recepcionista, checkIn)
	(2, 35),	--(Recepcionista, checkOut)
	(2, 36),	--(Recepcionista, agregarConsumible)
	(2, 37),	--(Recepcionista, quitarConsumible)
	(2, 38),	--(Recepcionista, facturarEstadia)
	(2, 39),	--(Recepcionista, listadoEstadistico)
	--del huésped (Guest)
	(3, 9),		--(Guest, crearReserva)	
	(3, 10),	--(Guest, editarReserva)
	(3, 15),	--(Guest, nuevaPassword)
	(3, 25),	--(Guest, listarHoteles)
	(3, 32),	--(Guest, listarRegimenEstadia)
	(3, 33),	--(Guest, cancelarReserva)
	--del administrador general (SysAdmin)
	(4, 1),	(4, 2),	(4, 3),	(4, 4),	(4, 5),	(4, 6),	(4, 7),	(4, 8),	(4, 9),	
	(4, 10), (4, 11), (4, 12), (4, 13), (4, 14), (4, 15), (4, 16), (4, 17),	(4, 18), (4, 19),
	(4, 20), (4, 21), (4, 22), (4, 23), (4, 24), (4, 25), (4, 26), (4, 27),	(4, 28), (4, 29),
	(4, 30), (4, 31), (4, 32), (4, 33), (4, 34), (4, 35), (4, 36), (4, 37),	(4, 38), (4, 39);
GO
