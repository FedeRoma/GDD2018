--- VERDES
----------------------------------
--- altaCliente ------------------
----------------------------------
--- debe guardar un registro
exec EN_CASA_ANDABA.altaCliente 123456, 'Documento Nacional de Identidad', 'Cosme', 'Fulanito', 'cosmefulanito@gmail.com', 
	'ARGENTINO', '1992-07-19', 'Av. Medrano', '951', '5', 'D', null, null, null
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 123456
--- no debe guardar registro, ya que no existe el tipo de documento "DNI"
exec EN_CASA_ANDABA.altaCliente 654321, 'DNI', 'Cosme', 'Fulanito', 'cosmefulanito@gmail.com', 
	'ARGENTINO', '1992-07-19', 'Av. Medrano', '951', '5', 'D', null, null, null
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 654321
--- no debe guardar registro, ya que está duplicado el documento
exec EN_CASA_ANDABA.altaCliente 123456, 'Documento Nacional de Identidad', 'John', 'Doe', 'cosmefulanito@gmail.com', 
	'ARGENTINO', '1992-07-19', 'Av. Medrano', '951', '5', 'D', null, null, null
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 123456
-- debe guardar un registro ya que aunque el documento está, es de otro tipo del existente
exec EN_CASA_ANDABA.altaCliente 123456, 'Libreta de Enrolamiento', 'Cosme', 'Fulanito', 'cosmefulanito@gmail.com', 
	'ARGENTINO', '1992-07-19', 'Av. Medrano', '951', '5', 'D', null, null, null
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 123456
----------------------------------
--- modificacionCliente ----------
----------------------------------
exec EN_CASA_ANDABA.modificacionCliente 123456, 'Cosme', 'Modificado', 'cosmefulanito@gmail.com', 
	'ARGENTINO', '1992-07-19', 'Av. Medrano', '951', '5', 'D', 'CABA', 'Argentina', null, 1
select * from EN_CASA_ANDABA.Clientes C where C.cli_documento = 123456










--- PROBAR

exec EN_CASA_ANDABA.altaHabitacion 219, 6, 'N', 'Base Simple', 2, 'Habitacion'
select * from EN_CASA_ANDABA.Habitaciones HA where HA.hab_numero = 219

exec EN_CASA_ANDABA.modificacionHabitacion 333, 219, 6, 'N', 'Base Simple', 2, 'Habitacion modificada', 1
select * from EN_CASA_ANDABA.Habitaciones HA where HA.hab_numero = 219

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


-- ROJOS