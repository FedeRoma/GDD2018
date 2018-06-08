use [GD1C2018]
GO

----------	ESQUEMA

create schema [EN_CASA_ANDABA] AUTHORIZATION [gdHotel2018] 
GO

----------	TABLAS

create table EN_CASA_ANDABA.Clientes (
	cli_documento bigint NOT NULL,
	cli_doc_id int NOT NULL,
	cli_nombre varchar(50) NOT NULL,
	cli_apellido varchar(50) NOT NULL,
	cli_mail varchar(50) NOT NULL,
	cli_nacionalidad varchar(50) NOT NULL,
	cli_fecha_nac date NOT NULL,
	cli_habilitado bit NULL,
	cli_calle varchar(50) NULL,
	cli_calle_nro int NULL,
	cli_piso nvarchar(10) NULL,
	cli_depto nvarchar(10) NULL,
	cli_dir_localidad varchar(50) NULL,
	cli_dir_pais varchar(50) NULL,
	cli_telefono nvarchar(50) NULL)

create table EN_CASA_ANDABA.Clientes_Estadias (
	cye_cli_documento bigint NULL,
	cye_est_res_id int NOT NULL,
	cye_hab_id int NOT NULL,
	cye_hab_hot_id int NOT NULL,
	cye_cli_doc_id int NULL,
	cye_cye_id int NULL)

create table EN_CASA_ANDABA.ClientesErrores (
	cye_doc_id int NOT NULL,
	cye_documento bigint NOT NULL,
	cye_nombre varchar(50) NOT NULL,
	cye_apellido varchar(50) NOT NULL,
	cye_mail varchar(50) NOT NULL,
	cye_nacionalidad varchar(50) NOT NULL,
	cye_fecha_nach date NOT NULL,
	cye_habilitado bit NULL,
	cye_calle varchar(50) NULL,
	cye_calle_nro int NULL,
	cye_piso nvarchar(10) NULL,
	cye_depto nvarchar(10) NULL,
	cye_dir_localidad varchar(50) NULL,
	cye_dir_pais varchar(50) NULL,
	cye_telefono nvarchar(50) NULL,
	cye_error varchar(50) NOT NULL,
	cye_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Documentos (
	doc_id int identity (1, 1) NOT NULL,
	doc_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Hoteles (
	hot_id int identity (1, 1) NOT NULL,
	hot_nombre varchar(50) NULL,
	hot_estrellas int NULL,
	hot_calle varchar(50) NULL,
	hot_calle_nro int NULL,
	hot_ciudad varchar(50) NULL,
	hot_pais varchar(50) NULL,
	hot_mail varchar(50) NULL,
	hot_telefono varchar(50) NULL,
	hot_fecha_cre date NULL,
	hot_habilitado bit NULL)

create table EN_CASA_ANDABA.BajasHotel (
	baj_id int identity (1, 1) NOT NULL,
	baj_hot_id int NOT NULL,
	baj_fecha_inicio date NOT NULL,
	baj_fecha_fin date NOT NULL,
	baj_motivo varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Habitaciones (
	hab_id int identity (1, 1) NOT NULL,
	hab_hot_id int NOT NULL,
	hab_tip_id int NOT NULL,
	hab_numero int NOT NULL,
	hab_piso int NOT NULL,
	hab_vista char(1) NOT NULL,
	hab_desc varchar(50) NULL,
	hab_habilitado bit NULL)

create table EN_CASA_ANDABA.TiposHabitaciones (
	tip_id int NOT NULL,
	tip_nombre varchar(50) NOT NULL,
	tip_porcentual int NOT NULL,
	tip_personas int NOT NULL)

create table EN_CASA_ANDABA.Hoteles_Usuarios (
	hyu_usu_id int NOT NULL,
	hyu_hot_id int NOT NULL,
	hyu_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Facturas (
	fac_id int identity (1, 1) NOT NULL,
	fac_cli_documento bigint NOT NULL,
	fac_tipo_pago varchar(50) NOT NULL,
	fac_fecha date NOT NULL,
	fac_total int NOT NULL,
	fac_est_res_id int NOT NULL,
	fac_med_id int NOT NULL,
	fac_tar_id int NOT NULL,
	fac_cli_doc_id int NOT NULL,
	fac_cye_id int NOT NULL)

create table EN_CASA_ANDABA.MediosPago (
	med_id int identity (1, 1) NOT NULL,
	med_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Tarjetas (
	tar_id int identity (1, 1) NOT NULL,
	tar_emisor varchar(50) NOT NULL,
	tar_banco varchar(50) NOT NULL,
	tar_numero bigint NOT NULL,
	tar_titular varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Items_Facturas (
	iyf_id int identity (1, 1) NOT NULL,
	iyf_con_id int NULL,
	iyf_fac_id int NULL,
	iyf_cantidad int NULL,
	iyf_monto int NULL)

create table EN_CASA_ANDABA.Consumibles (
	con_id int NOT NULL,
	con_desc varchar(50) NOT NULL,
	con_precio int NOT NULL)

create table EN_CASA_ANDABA.Estadias (
	est_res_id int NOT NULL,
	est_usu_alta int NOT NULL,
	est_checkin date NULL,
	est_checkout date NULL,
	est_cant_noches int NULL,
	est_precio_noche int NOT NULL,
	est_usu_salida int NOT NULL,
	est_dias_sobrantes int NOT NULL)

create table EN_CASA_ANDABA.Reservas (
	res_id int NOT NULL,
	res_estados_id int NOT NULL,
	res_fecha datetime NOT NULL,
	res_inicio date NOT NULL,
	res_fin date NOT NULL,
	res_tip_id int NOT NULL,
	res_reg_id int NOT NULL,
	res_cli_documento bigint NOT NULL,
	res_usu_id int NOT NULL,
	res_fac_cli_doc_id int NOT NULL,
	res_cye_id int NOT NULL)

create table EN_CASA_ANDABA.Reservas_Habitaciones (
	ryh_hab_id int NOT NULL,
	ryh_hab_hot_id int NOT NULL,
	ryh_res_id int NOT NULL)

create table EN_CASA_ANDABA.Estados (
	estados_id int identity (1, 1) NOT NULL,
	estados_desc varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Regimenes (
	reg_id int identity (1, 1) NOT NULL,
	reg_desc varchar(50) NOT NULL,
	reg_precio int NOT NULL,
	reg_habilitado bit NULL)

create table EN_CASA_ANDABA.Regimenes_Hoteles (
	ryh_hot_id int NOT NULL,
	ryh_reg_id int NOT NULL,
	ryh_id int identity (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Usuarios (
	usu_id int identity (1, 1) NOT NULL,
	usu_nombre varchar(50) NOT NULL,
	usu_password varchar(50) NOT NULL,
	usu_estado varchar(50) NOT NULL,
	usu_apellido varchar(50) NOT NULL,
	usu_mail varchar(50) NOT NULL,
	usu_tel varchar(50) NOT NULL,
	usu_fecha_nac date NOT NULL,
	usu_documento bigint NOT NULL,
	usu_intentos int NOT NULL,
	usu_direccion varchar(50) NOT NULL,
	usu_username varchar(50) NOT NULL,
	usu_doc_id int NOT NULL)

create table EN_CASA_ANDABA.Roles_Usuarios (
	ryu_usu_id int NOT NULL,
	ryu_rol_id int NOT NULL)

create table EN_CASA_ANDABA.Roles (
	rol_id int identity (1, 1) NOT NULL,
	rol_nombre varchar(50) NOT NULL,
	rol_estado int NOT NULL)

create table EN_CASA_ANDABA.Funcionalidades_Roles (
	fyr_rol_id int NOT NULL,
	fyr_fun_id int NOT NULL)

create table EN_CASA_ANDABA.Funcionalidades (
	fun_id int identity (1, 1) NOT NULL,
	fun_desc varchar(50) NOT NULL)	

create table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones (
	urc_id int identity (1, 1) NOT NULL,
	urc_res_id int NOT NULL,
	urc_usu_id int NOT NULL,
	urc_fecha date NOT NULL,
	urc_motivo varchar(50) NOT NULL)

create table EN_CASA_ANDABA.Usuarios_ReservasModificaciones (
	urm_id int identity (1, 1) NOT NULL,
	urm_res_id int NOT NULL,
	urm_usu_id int NOT NULL,
	urm_fecha date NOT NULL)

PRINT 'TABLAS CREADAS'

----------	PK

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT PK_Clientes PRIMARY KEY CLUSTERED (cli_documento ASC, cli_doc_id ASC)

alter table EN_CASA_ANDABA.ClientesErrores
	ADD CONSTRAINT PK_Clientes_Errores PRIMARY KEY CLUSTERED (cye_id ASC)

alter table EN_CASA_ANDABA.Documentos 
	ADD CONSTRAINT PK_Documentos PRIMARY KEY CLUSTERED (doc_id ASC)

alter table EN_CASA_ANDABA.Hoteles
	ADD CONSTRAINT PK_Hoteles PRIMARY KEY CLUSTERED (hot_id ASC)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT PK_BajasHotel PRIMARY KEY CLUSTERED (baj_id ASC)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT PK_Habitaciones PRIMARY KEY CLUSTERED (hab_id ASC, hab_hot_id ASC)

alter table EN_CASA_ANDABA.TiposHabitaciones
	ADD CONSTRAINT PK_TiposHabitaciones PRIMARY KEY CLUSTERED (tip_id ASC)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT PK_Hoteles_Usuarios PRIMARY KEY CLUSTERED (hyu_id ASC)

alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT PK_Facturas PRIMARY KEY CLUSTERED (fac_id ASC)

alter table EN_CASA_ANDABA.MediosPago
	ADD CONSTRAINT PK_MediosPago PRIMARY KEY CLUSTERED (med_id ASC)

alter table EN_CASA_ANDABA.Tarjetas
	ADD CONSTRAINT PK_Tarjetas PRIMARY KEY CLUSTERED (tar_id ASC)

alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT PK_Items_Facturas PRIMARY KEY CLUSTERED (iyf_id ASC)

alter table EN_CASA_ANDABA.Consumibles
	ADD CONSTRAINT PK_Consumibles PRIMARY KEY CLUSTERED (con_id ASC)

alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT PK_Estadias PRIMARY KEY CLUSTERED (est_res_id ASC)

alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT PK_Reservas PRIMARY KEY CLUSTERED (res_id ASC)

alter table EN_CASA_ANDABA.Estados
	ADD CONSTRAINT PK_Estados PRIMARY KEY CLUSTERED (estados_id ASC)

alter table EN_CASA_ANDABA.Regimenes
	ADD CONSTRAINT PK_Regimenes PRIMARY KEY CLUSTERED (reg_id ASC)

alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT PK_Regimenes_Hoteles PRIMARY KEY CLUSTERED (ryh_id ASC)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (usu_id ASC)

alter table EN_CASA_ANDABA.Roles
	ADD CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (rol_id ASC)

alter table EN_CASA_ANDABA.Funcionalidades
	ADD CONSTRAINT PK_Funcionalidades PRIMARY KEY CLUSTERED (fun_id ASC)

alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT PK_Usuarios_ReservasCancelaciones PRIMARY KEY CLUSTERED (urc_id ASC)

alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT PK_Usuarios_ReservasModificaciones PRIMARY KEY CLUSTERED (urm_id ASC)
 
PRINT 'PK ASIGNADAS'
				
----------	FK

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT FK_Clientes_Documentos FOREIGN KEY (cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Cliente FOREIGN KEY (cye_cli_documento, cye_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Estadias FOREIGN KEY (cye_est_res_id)
		REFERENCES EN_CASA_ANDABA.Estadias(est_res_id)
alter table EN_CASA_ANDABA.Clientes_Estadias
	ADD CONSTRAINT FK_Clientes_Estadias_Habitaciones FOREIGN KEY (cye_hab_id, cye_hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Habitaciones(hab_id, hab_hot_id)

alter table EN_CASA_ANDABA.ClientesErrores
	ADD CONSTRAINT FK_ClientesErrores_Documentos FOREIGN KEY (cye_doc_id) 
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT FK_BajasHotel_Hoteles FOREIGN KEY (baj_hot_id) 
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_Hoteles FOREIGN KEY (hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_TiposHabitaciones FOREIGN KEY (hab_tip_id)
		REFERENCES EN_CASA_ANDABA.TiposHabitaciones(tip_id)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_Usuarios FOREIGN KEY (hyu_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_Hoteles FOREIGN KEY (hyu_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Clientes FOREIGN KEY (fac_cli_documento, fac_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Estadias FOREIGN KEY (fac_est_res_id)
		REFERENCES EN_CASA_ANDABA.Estadias(est_res_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_ClientesErrores FOREIGN KEY (fac_cye_id)
		REFERENCES EN_CASA_ANDABA.ClientesErrores(cye_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_MediosPago FOREIGN KEY (fac_med_id)
		REFERENCES EN_CASA_ANDABA.MediosPago(med_id)
alter table EN_CASA_ANDABA.Facturas
	ADD CONSTRAINT FK_Facturas_Tarjetas FOREIGN KEY (fac_tar_id)
		REFERENCES EN_CASA_ANDABA.Tarjetas(tar_id)

alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT FK_Items_Facturas_Consumibles FOREIGN KEY (iyf_con_id)
		REFERENCES EN_CASA_ANDABA.Consumibles(con_id)
alter table EN_CASA_ANDABA.Items_Facturas
	ADD CONSTRAINT FK_Items_Facturas_Facturas FOREIGN KEY (iyf_fac_id)
		REFERENCES EN_CASA_ANDABA.Facturas(fac_id)

alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Reservas FOREIGN KEY (est_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Usuarios_Alta FOREIGN KEY (est_usu_alta)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Estadias
	ADD CONSTRAINT FK_Estadias_Usuarios_Salida FOREIGN KEY (est_usu_salida)
  REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
 
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_TiposHabitaciones FOREIGN KEY (res_tip_id)
		REFERENCES EN_CASA_ANDABA.TiposHabitaciones(tip_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Regimenes FOREIGN KEY (res_reg_id)
		REFERENCES EN_CASA_ANDABA.Regimenes(reg_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Clientes FOREIGN KEY (res_cli_documento, res_fac_cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Clientes(cli_documento, cli_doc_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Estados FOREIGN KEY (res_estados_id)
		REFERENCES EN_CASA_ANDABA.Estados(estados_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_Usuarios FOREIGN KEY (res_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Reservas
	ADD CONSTRAINT FK_Reservas_ClientesErrores FOREIGN KEY (res_cye_id)
		REFERENCES EN_CASA_ANDABA.ClientesErrores(cye_id)

alter table EN_CASA_ANDABA.Reservas_Habitaciones
	ADD CONSTRAINT FK_Reservas_Habitaciones_Habitaciones FOREIGN KEY (ryh_hab_id, ryh_hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Habitaciones(hab_id, hab_hot_id)
alter table EN_CASA_ANDABA.Reservas_Habitaciones
	ADD CONSTRAINT FK_Reservas_Habitaciones_Reservas FOREIGN KEY (ryh_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)

alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT FK_Regimenes_Hoteles_Hoteles FOREIGN KEY (ryh_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Regimenes_Hoteles
	ADD CONSTRAINT FK_Regimenes_Hoteles_Regimenes FOREIGN KEY (ryh_reg_id)
		REFERENCES EN_CASA_ANDABA.Regimenes(reg_id)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT FK_Usuarios_Documentos FOREIGN KEY (usu_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Roles_Usuarios
	ADD CONSTRAINT FK_Roles_Usuarios_Usuarios FOREIGN KEY (ryu_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Roles_Usuarios
	ADD CONSTRAINT FK_Roles_Usuarios_Roles FOREIGN KEY (ryu_rol_id)
		REFERENCES EN_CASA_ANDABA.Roles(rol_id)

alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_Roles FOREIGN KEY (fyr_rol_id)
		REFERENCES EN_CASA_ANDABA.Roles(rol_id)
alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_Funcionalidades FOREIGN KEY (fyr_fun_id)
		REFERENCES EN_CASA_ANDABA.Funcionalidades(fun_id)

alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT FK_Usuarios_ReservasCancelaciones_Reservas FOREIGN KEY (urc_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
	ADD CONSTRAINT FK_Usuarios_ReservasCancelaciones_Usuarios FOREIGN KEY (urc_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)

alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT FK_Usuarios_Reservas_Modificaciones_Reservas FOREIGN KEY (urm_res_id)
		REFERENCES EN_CASA_ANDABA.Reservas(res_id)
alter table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
	ADD CONSTRAINT FK_Usuarios_ReservasModificaciones_Usuarios FOREIGN KEY (urm_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)

 
PRINT 'FK ASIGNADAS'

/*	DROPs
drop table EN_CASA_ANDABA.BajasHotel
drop table EN_CASA_ANDABA.Clientes
drop table EN_CASA_ANDABA.Clientes_Estadias
drop table EN_CASA_ANDABA.ClientesErrores
drop table EN_CASA_ANDABA.Consumibles
drop table EN_CASA_ANDABA.Documentos
drop table EN_CASA_ANDABA.Estadias
drop table EN_CASA_ANDABA.Estados
drop table EN_CASA_ANDABA.Facturas
drop table EN_CASA_ANDABA.Funcionalidades
drop table EN_CASA_ANDABA.Funcionalidades_Roles
drop table EN_CASA_ANDABA.Habitaciones
drop table EN_CASA_ANDABA.Hoteles
drop table EN_CASA_ANDABA.Hoteles_Usuarios
drop table EN_CASA_ANDABA.Items_Facturas
drop table EN_CASA_ANDABA.MediosPago
drop table EN_CASA_ANDABA.Regimenes
drop table EN_CASA_ANDABA.Regimenes_Hoteles
drop table EN_CASA_ANDABA.Reservas
drop table EN_CASA_ANDABA.Reservas_Habitaciones
drop table EN_CASA_ANDABA.Roles
drop table EN_CASA_ANDABA.Roles_Usuarios
drop table EN_CASA_ANDABA.Tarjetas
drop table EN_CASA_ANDABA.TiposHabitaciones
drop table EN_CASA_ANDABA.Usuarios
drop table EN_CASA_ANDABA.Usuarios_ReservasCancelaciones
drop table EN_CASA_ANDABA.Usuarios_ReservasModificaciones
drop schema EN_CASA_ANDABA
GO
*/