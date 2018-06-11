--- VERDES

exec EN_CASA_ANDABA.buscarHoteles SysAdmin, 1

exec EN_CASA_ANDABA.altaRol 'Rol'
select * from EN_CASA_ANDABA.Roles R where R.rol_nombre = 'Rol'

exec EN_CASA_ANDABA.altaCliente 1111475, 'DNI', 'Cosme', 'Fulanito', 'cosmefulanito@gmail.com', 
	'Argentino', '1992-07-19', 'Medrano', '951', '5', 'D', null, null, null
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 1111475

exec EN_CASA_ANDABA.altaHabitacion 219, 6, 'N', 'Base Simple', 2, 'Habitacion'
select * from EN_CASA_ANDABA.Habitaciones HA where HA.hab_numero = 219

exec EN_CASA_ANDABA.modificacionHabitacion 333, 219, 6, 'N', 'Base Simple', 2, 'Habitacion modificada', 1
select * from EN_CASA_ANDABA.Habitaciones HA where HA.hab_numero = 219

--- ROJOS

exec EN_CASA_ANDABA.altaUsuario 'SysAdmin', null, 'admin', '12345678', 'admin', 'admin',
	'admin@en_casa_andaba.com', '4000-0000', 'Pasaporte', 12345678, '2018-01-01', 'admin'
select * from EN_CASA_ANDABA.Usuarios

exec EN_CASA_ANDABA.modificacionHabitacion 1, 2, 6, 'N', 'Base Simple', 1, 'cambio', 1

exec EN_CASA_ANDABA.altaFuncionalidadRol 1, 1

exec EN_CASA_ANDABA.modificacionCliente 1111475, 'Libreta Civica', 'name', 'surname', 'mail', 'ARGENTINO',
	'1992-07-19', 'calle', '6445', '19', 'A', null, null, null, 1

exec EN_CASA_ANDABA.altaReserva '2018-06-10 22:11:41.593', '2018-01-21', '2018-01-22', 'Base Triple',
	'All inclusive', 1111475, 'Pasaporte', 1

exec EN_CASA_ANDABA.altaReservaHabitacion 1, 1, 104361

exec EN_CASA_ANDABA.modificacionReserva 33513, '2018-01-01', '2018-01-21', '2018-01-22', 'Base Simple',
	'All inclusive', 1111475, 1, 1