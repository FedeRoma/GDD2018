--DROPs
drop table EN_CASA_ANDABA.Items_Facturas
drop table EN_CASA_ANDABA.Consumibles
drop table EN_CASA_ANDABA.Facturas
drop table EN_CASA_ANDABA.MediosPago
drop table EN_CASA_ANDABA.Tarjetas
drop table EN_CASA_ANDABA.BajasHotel
drop table EN_CASA_ANDABA.Hoteles_Usuarios
drop table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
drop table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
drop table EN_CASA_ANDABA.Regimenes_Hoteles
drop table EN_CASA_ANDABA.Funcionalidades_Roles
drop table EN_CASA_ANDABA.Funcionalidades
drop table EN_CASA_ANDABA.Clientes_Estadias
drop table EN_CASA_ANDABA.Reservas_Habitaciones
drop table EN_CASA_ANDABA.Habitaciones
drop table EN_CASA_ANDABA.Hoteles
drop table EN_CASA_ANDABA.Roles_Usuarios
drop table EN_CASA_ANDABA.Roles
drop table EN_CASA_ANDABA.Estadias
drop table EN_CASA_ANDABA.Reservas
drop table EN_CASA_ANDABA.Usuarios
drop table EN_CASA_ANDABA.Clientes
drop table EN_CASA_ANDABA.ClientesErrores
drop table EN_CASA_ANDABA.Regimenes
drop table EN_CASA_ANDABA.Estados
drop table EN_CASA_ANDABA.TiposHabitaciones
drop table EN_CASA_ANDABA.Documentos
PRINT 'Chau Tablas!'
drop procedure EN_CASA_ANDABA.buscarHoteles
drop procedure EN_CASA_ANDABA.altaUsuario
drop procedure EN_CASA_ANDABA.altaHabitacion
drop procedure EN_CASA_ANDABA.modificacionHabitacion
drop procedure EN_CASA_ANDABA.altaCliente
drop procedure EN_CASA_ANDABA.modificacionCliente
drop procedure EN_CASA_ANDABA.altaRol
drop procedure EN_CASA_ANDABA.altaFuncionalidadRol
drop procedure EN_CASA_ANDABA.altaReserva
drop procedure EN_CASA_ANDABA.modificacionReserva
drop procedure EN_CASA_ANDABA.altaReservaHabitacion
drop procedure EN_CASA_ANDABA.top5_hoteles_reservas_canceladas
drop procedure EN_CASA_ANDABA.top5_hoteles_consumibles_facturados
drop procedure EN_CASA_ANDABA.top5_hoteles_dias_fuera_de_servicio
drop procedure EN_CASA_ANDABA.top5_clientes_puntos
drop procedure EN_CASA_ANDABA.top5_habitaciones_veces_ocupadas
PRINT 'Chau Store Procedures!'
drop schema EN_CASA_ANDABA
PRINT 'Chau Esquema!'