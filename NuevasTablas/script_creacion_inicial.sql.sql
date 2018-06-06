use [GD1C2018]
GO

----------	ESQUEMA

create schema [EN_CASA_ANDABA] AUTHORIZATION [gdHotel2018] 
GO

----------	TABLAS

create table EN_CASA_ANDABA.Documentos (
	doc_id INT IDENTITY (1, 1) NOT NULL,
	doc_desc VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.Tarjetas (
	tar_id INT IDENTITY (1, 1) NOT NULL,
	tar_emisor VARCHAR(50) NOT NULL,
	tar_banco VARCHAR(50) NOT NULL,
	tar_numero BIGINT NOT NULL,
	tar_titular VARCHAR(50) NOT NULL)	

create table EN_CASA_ANDABA.MediosPago (
	med_id INT IDENTITY (1, 1) NOT NULL,
	med_desc VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.StatusHabitacion (
	sta_id INT IDENTITY (1, 1) NOT NULL,
	sta_desc VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.Funcionalidades (
	fun_id INT IDENTITY (1, 1) NOT NULL,
	fun_desc VARCHAR(50) NOT NULL)	

create table EN_CASA_ANDABA.Roles (
	rol_id INT IDENTITY (1, 1) NOT NULL,
	rol_nombre VARCHAR(50) NOT NULL,
	rol_estado BIT NOT NULL)

create table EN_CASA_ANDABA.Estados (
	estados_id INT IDENTITY (1, 1) NOT NULL,
	estados_desc VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.Consumibles (
	con_id INT NOT NULL,
	con_desc VARCHAR(50) NOT NULL,
	con_precio INT NOT NULL)

create table EN_CASA_ANDABA.TiposHabitaciones (
	tip_id INT NOT NULL,
	tip_nombre VARCHAR(50) NOT NULL,
	tip_porcentual INT NOT NULL,
	tip_personas INT NOT NULL)

create table EN_CASA_ANDABA.Inhabilitaciones (
	inh_id INT IDENTITY (1, 1) NOT NULL,
	inh_desc VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.Regimenes (
	reg_id INT IDENTITY (1, 1) NOT NULL,
	reg_desc VARCHAR(50) NOT NULL,
	reg_precio INT NOT NULL,
	reg_habilitado BIT NULL)

create table EN_CASA_ANDABA.Hoteles (
	hot_id INT IDENTITY (1, 1) NOT NULL,
	hot_nombre VARCHAR(50) NULL,
	hot_estrellas INT NULL,
	hot_calle VARCHAR(50) NULL,
	hot_calle_nro INT NULL,
	hot_ciudad VARCHAR(50) NULL,
	hot_pais VARCHAR(50) NULL,
	hot_mail VARCHAR(50) NULL,
	hot_telefono VARCHAR(50) NULL,
	hot_fecha_cre DATE NULL,
	hot_habilitado BIT NULL)

create table EN_CASA_ANDABA.Inhabilitaciones_Hoteles (
	iyh_hot_id INT NOT NULL,
	iyh_inh_id INT NOT NULL,
	inh_fecha_desde DATE NOT NULL,
	inh_fecha_hasta DATE NOT NULL,
	iyh_id INT IDENTITY (1, 1) NOT NULL)

create table EN_CASA_ANDABA.BajasHotel (
	baj_id INT IDENTITY (1, 1) NOT NULL,
	baj_hot_id INT NOT NULL,
	baj_fecha_inicio DATE NOT NULL,
	baj_fecha_fin DATE NOT NULL,
	baj_motivo VARCHAR(50) NOT NULL)

create table EN_CASA_ANDABA.Usuarios (
	usu_id INT IDENTITY (1, 1) NOT NULL,
	usu_nombre VARCHAR(50) NOT NULL,
	usu_password VARCHAR(50) NOT NULL,
	usu_estado VARCHAR(50) NOT NULL,
	usu_apellido VARCHAR(50) NOT NULL,
	usu_mail VARCHAR(50) NOT NULL,
	usu_tel VARCHAR(50) NOT NULL,
	usu_fecha_nac DATE NOT NULL,
	usu_documento BIGINT NOT NULL,
	usu_intentos INT NOT NULL,
	usu_direccion VARCHAR(50) NOT NULL,
	usu_username VARCHAR(50) NOT NULL,
	usu_doc_id INT NOT NULL)

create table EN_CASA_ANDABA.Habitaciones (
	hab_id INT IDENTITY (1, 1) NOT NULL,
	hab_hot_id INT NOT NULL,
	hab_tip_id INT NOT NULL,
	hab_numero INT NOT NULL,
	hab_piso INT NOT NULL,
	hab_vista CHAR(1) NOT NULL,
	hab_desc VARCHAR(50) NULL,
	hab_habilitado BIT NULL)

create table EN_CASA_ANDABA.Regimenes_Hotel (
	ryh_hot_id INT NOT NULL,
	ryh_reg_id INT NOT NULL,
	ryh_id INT IDENTITY (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Clientes (
	cli_documento BIGINT NOT NULL,
	cli_doc_id INT NOT NULL,
	cli_nombre VARCHAR(50) NOT NULL,
	cli_apellido VARCHAR(50) NOT NULL,
	cli_mail VARCHAR(50) NOT NULL,
	cli_nacionalidad VARCHAR(50) NOT NULL,
	cli_fecha_nac DATE NOT NULL,
	cli_habilitado BIT NULL,
	cli_calle VARCHAR(50) NULL,
	cli_calle_nro INT NULL,
	cli_piso NVARCHAR(10) NULL,
	cli_depto NVARCHAR(10) NULL,
	cli_dir_localidad VARCHAR(50) NULL,
	cli_dir_pais VARCHAR(50) NULL,
	cli_telefono NVARCHAR(50) NULL)

create table EN_CASA_ANDABA.Clientes_errores (
	cye_doc_id INT NOT NULL,
	cye_documento BIGINT NOT NULL,
	cye_nombre VARCHAR(50) NOT NULL,
	cye_apellido VARCHAR(50) NOT NULL,
	cye_mail VARCHAR(50) NOT NULL,
	cye_nacionalidad VARCHAR(50) NOT NULL,
	cye_fecha_nach DATE NOT NULL,
	cye_habilitado BIT NOT NULL,
	cye_calle VARCHAR(50) NOT NULL,
	cye_calle_nro INT NOT NULL,
	cye_piso NVARCHAR(10) NOT NULL,
	cye_depto NVARCHAR(10) NOT NULL,
	cye_dir_localidad VARCHAR(50) NOT NULL,
	cye_dir_pais VARCHAR(50) NOT NULL,
	cye_telefono NVARCHAR(50) NOT NULL,
	cye_id INT IDENTITY (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Hoteles_Usuarios (
	hyu_usu_id INT NOT NULL,
	hyu_hot_id INT NOT NULL,
	hyu_id INT IDENTITY (1, 1) NOT NULL)

create table EN_CASA_ANDABA.Status_Habitaciones (
	syh_sta_id INT NOT NULL,
	syh_hab_id INT NOT NULL,
	syh_hab_hot_id INT NOT NULL,
	syh_fecha_inicio DATE NOT NULL,
	syh_fecha_fin DATE NOT NULL)


----------	PK

alter table EN_CASA_ANDABA.Documentos 
	ADD CONSTRAINT PK_Documentos PRIMARY KEY CLUSTERED (doc_id ASC)

alter table EN_CASA_ANDABA.Tarjetas
	ADD CONSTRAINT PK_Tarjetas PRIMARY KEY CLUSTERED (tar_id ASC)

alter table EN_CASA_ANDABA.MediosPago
	ADD CONSTRAINT PK_MediosPago PRIMARY KEY CLUSTERED (med_id ASC)

alter table EN_CASA_ANDABA.StatusHabitacion
	ADD CONSTRAINT PK_StatusHabitacion PRIMARY KEY CLUSTERED (sta_id ASC)

alter table EN_CASA_ANDABA.Funcionalidades
	ADD CONSTRAINT PK_Funcionalidades PRIMARY KEY CLUSTERED (fun_id ASC)

alter table EN_CASA_ANDABA.Roles
	ADD CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (rol_id ASC)

alter table EN_CASA_ANDABA.Estados
	ADD CONSTRAINT PK_Estados PRIMARY KEY CLUSTERED (estados_id ASC)

alter table EN_CASA_ANDABA.Consumibles
	ADD CONSTRAINT PK_Consumibles PRIMARY KEY CLUSTERED (con_id ASC)

alter table EN_CASA_ANDABA.TiposHabitaciones
	ADD CONSTRAINT PK_TiposHabitaciones PRIMARY KEY CLUSTERED (tip_id ASC)

alter table EN_CASA_ANDABA.Inhabilitaciones
	ADD CONSTRAINT PK_Inhabilitaciones PRIMARY KEY CLUSTERED (inh_id ASC)

alter table EN_CASA_ANDABA.Regimenes
	ADD CONSTRAINT PK_Regimenes PRIMARY KEY CLUSTERED (reg_id ASC)

alter table EN_CASA_ANDABA.Hoteles
	ADD CONSTRAINT PK_Hoteles PRIMARY KEY CLUSTERED (hot_id ASC)

alter table EN_CASA_ANDABA.Inhabilitaciones_Hoteles
	ADD CONSTRAINT PK_Inhabilitaciones_Hoteles PRIMARY KEY CLUSTERED (iyh_id ASC)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT PK_BajasHotel PRIMARY KEY CLUSTERED (baj_id ASC)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT PK_Usuarios PRIMARY KEY CLUSTERED (usu_id ASC)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT PK_Habitaciones PRIMARY KEY CLUSTERED (hab_id ASC, hab_hot_id ASC)

alter table EN_CASA_ANDABA.Regimenes_Hotel
	ADD CONSTRAINT PK_Regimenes_Hotel PRIMARY KEY CLUSTERED (ryh_id ASC)

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT PK_Clientes PRIMARY KEY CLUSTERED (cli_documento ASC, cli_doc_id ASC)

alter table EN_CASA_ANDABA.Clientes_errores
	ADD CONSTRAINT PK_Clientes_errores PRIMARY KEY CLUSTERED (cye_id ASC)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT PK_Hoteles_Usuarios PRIMARY KEY CLUSTERED (hyu_id ASC)

alter table EN_CASA_ANDABA.Status_Habitaciones
	ADD CONSTRAINT PK_Status_Habitaciones PRIMARY KEY CLUSTERED (syh_sta_id ASC, syh_hab_id ASC, syh_hab_hot_id ASC)

----------	FK

alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_fyr_rol_id FOREIGN KEY (fyr_rol_id)
		REFERENCES EN_CASA_ANDABA.Roles(rol_id)
alter table EN_CASA_ANDABA.Funcionalidades_Roles
	ADD CONSTRAINT FK_Funcionalidades_Roles_fyr_fun_id FOREIGN KEY (fyr_fun_id)
		REFERENCES EN_CASA_ANDABA.Funcionalidades(fun_id)

alter table EN_CASA_ANDABA.Inhabilitaciones_Hoteles
	ADD CONSTRAINT FK_Inhabilitaciones_Hoteles_iyh_hot_id FOREIGN KEY (iyh_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Inhabilitaciones_Hoteles
	ADD CONSTRAINT FK_Inhabilitaciones_Hoteles_iyh_inh_id FOREIGN KEY (iyh_inh_id)
		REFERENCES EN_CASA_ANDABA.Inhabilitaciones(inh_id)

alter table EN_CASA_ANDABA.BajasHotel
	ADD CONSTRAINT FK_BajasHotel FOREIGN KEY (baj_hot_id) 
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Usuarios
	ADD CONSTRAINT FK_Usuarios FOREIGN KEY (usu_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_hab_hot_id FOREIGN KEY (hab_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Habitaciones
	ADD CONSTRAINT FK_Habitaciones_tip_id FOREIGN KEY (hab_tip_id)
		REFERENCES EN_CASA_ANDABA.TiposHabitaciones(tip_id)

alter table EN_CASA_ANDABA.Regimenes_Hotel
	ADD CONSTRAINT FK_Regimenes_Hotel_ryh_hot_id FOREIGN KEY (ryh_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)
alter table EN_CASA_ANDABA.Regimenes_Hotel
	ADD CONSTRAINT FK_Regimenes_Hotel_ryh_reg_id FOREIGN KEY (ryh_reg_id)
		REFERENCES EN_CASA_ANDABA.Regimenes(reg_id)

alter table EN_CASA_ANDABA.Clientes
	ADD CONSTRAINT FK_Clientes FOREIGN KEY (cli_doc_id)
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Clientes_errores
	ADD CONSTRAINT FK_Clientes_errores FOREIGN KEY (cye_doc_id) 
		REFERENCES EN_CASA_ANDABA.Documentos(doc_id)

alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_hyu_usu_id FOREIGN KEY (hyu_usu_id)
		REFERENCES EN_CASA_ANDABA.Usuarios(usu_id)
alter table EN_CASA_ANDABA.Hoteles_Usuarios
	ADD CONSTRAINT FK_Hoteles_Usuarios_hyu_hot_id FOREIGN KEY (hyu_hot_id)
		REFERENCES EN_CASA_ANDABA.Hoteles(hot_id)

alter table EN_CASA_ANDABA.Status_Habitaciones
	ADD CONSTRAINT FK_Status_Habitaciones_syh_sta_id FOREIGN KEY (syh_sta_id)
		REFERENCES EN_CASA.ANDABA.StatusHabitacion(sta_id)
alter table EN_CASA_ANDABA.Status_Habitaciones
	ADD CONSTRAINT FK_Status_Habitaciones_syh_hab_id_syh_hab_hot_id FOREIGN KEY (syh_hab_id, syh_hab_hot_id)
  REFERENCES EN_CASA_ANDABA.Habitaciones(hab_id, hab_hot_id)

/*
drop table EN_CASA_ANDABA.BajasHotel
drop table EN_CASA_ANDABA.Clientes
drop table EN_CASA_ANDABA.Clientes_errores
drop table EN_CASA_ANDABA.Consumibles
drop table EN_CASA_ANDABA.Documentos
drop table EN_CASA_ANDABA.Estados
drop table EN_CASA_ANDABA.Funcionalidades
drop table EN_CASA_ANDABA.Habitaciones
drop table EN_CASA_ANDABA.Hoteles
drop table EN_CASA_ANDABA.Inhabilitaciones
drop table EN_CASA_ANDABA.Inhabilitaciones_Hoteles
drop table EN_CASA_ANDABA.MediosPago
drop table EN_CASA_ANDABA.Regimenes
drop table EN_CASA_ANDABA.Regimenes_Hotel
drop table EN_CASA_ANDABA.Roles
drop table EN_CASA_ANDABA.StatusHabitacion
drop table EN_CASA_ANDABA.Tarjetas
drop table EN_CASA_ANDABA.TiposHabitaciones
drop table EN_CASA_ANDABA.Usuarios
drop schema EN_CASA_ANDABA
GO
*/

CREATE TABLE [Roles_Usuarios]
(
 [ryu_usu_id] INT NOT NULL ,
 [ryu_rol_id] INT NOT NULL ,

 CONSTRAINT [FK_250] FOREIGN KEY ([ryu_usu_id])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_254] FOREIGN KEY ([ryu_rol_id])
  REFERENCES [Roles]([rol_id])
);
GO

CREATE TABLE [Reservas]
(
 [res_id]             INT NOT NULL ,
 [res_estados_id]     INT NOT NULL ,
 [res_fecha]          DATETIME NOT NULL ,
 [res_inicio]         DATE NOT NULL ,
 [res_fin]            DATE NOT NULL ,
 [res_tip_id]         INT NOT NULL ,
 [res_reg_id]         INT NOT NULL ,
 [res_cli_documento]  BIGINT NOT NULL ,
 [res_usu_id]         INT NOT NULL ,
 [res_fac_cli_doc_id] INT NOT NULL ,
 [res_cye_id]         INT NOT NULL ,

 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED ([res_id] ASC),
 CONSTRAINT [FK_155] FOREIGN KEY ([res_tip_id])
  REFERENCES [TiposHabitaciones]([tip_id]),
 CONSTRAINT [FK_159] FOREIGN KEY ([res_reg_id])
  REFERENCES [Regimenes]([reg_id]),
 CONSTRAINT [FK_163] FOREIGN KEY ([res_cli_documento], [res_fac_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_374] FOREIGN KEY ([res_estados_id])
  REFERENCES [Estados]([estados_id]),
 CONSTRAINT [FK_533] FOREIGN KEY ([res_usu_id])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_592] FOREIGN KEY ([res_cye_id])
  REFERENCES [Clientes_Errores]([cye_id])
);
GO

CREATE TABLE [Reservas_Habitaciones]
(
 [ryh_hab_id]     INT NOT NULL ,
 [ryh_hab_hot_id] INT NOT NULL ,
 [ryh_res_id]     INT NOT NULL ,

 CONSTRAINT [FK_539] FOREIGN KEY ([ryh_hab_id], [ryh_hab_hot_id])
  REFERENCES [Habitaciones]([hab_id], [hab_hot_id]),
 CONSTRAINT [FK_544] FOREIGN KEY ([ryh_res_id])
  REFERENCES [Reservas]([res_id])
);
GO

CREATE TABLE [Usuarios_ReservasCancelaciones]
(
 [urc_id]     INT IDENTITY (1, 1) NOT NULL ,
 [urc_res_id] INT NOT NULL ,
 [urc_usu_id] INT NOT NULL ,
 [urc_fecha]  DATE NOT NULL ,
 [urc_motivo] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Usuarios_Reservas_Cancelaciones] PRIMARY KEY CLUSTERED ([urc_id] ASC),
 CONSTRAINT [FK_511] FOREIGN KEY ([urc_res_id])
  REFERENCES [Reservas]([res_id]),
 CONSTRAINT [FK_515] FOREIGN KEY ([urc_usu_id])
  REFERENCES [Usuarios]([usu_id])
);
GO

CREATE TABLE [Usuarios_ReservasModificaciones]
(
 [urm_id]     INT IDENTITY (1, 1) NOT NULL ,
 [urm_res_id] INT NOT NULL ,
 [urm_usu_id] INT NOT NULL ,
 [urm_fecha]  DATE NOT NULL ,

 CONSTRAINT [PK_Usuarios_ReservasModificaciones] PRIMARY KEY CLUSTERED ([urm_id] ASC),
 CONSTRAINT [FK_519] FOREIGN KEY ([urm_res_id])
  REFERENCES [Reservas]([res_id]),
 CONSTRAINT [FK_523] FOREIGN KEY ([urm_usu_id])
  REFERENCES [Usuarios]([usu_id])
);
GO

CREATE TABLE [Estadias]
(
 [est_res_id]         INT NOT NULL ,
 [est_usu_alta]       INT NOT NULL ,
 [est_checkin]        DATE NULL ,
 [est_checkout]       DATE NULL ,
 [est_cant_noches]    INT NULL ,
 [est_precio_noche]   INT NOT NULL ,
 [est_usu_salida]     INT NOT NULL ,
 [est_dias_sobrantes] INT NOT NULL ,

 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED ([est_res_id] ASC),
 CONSTRAINT [FK_394] FOREIGN KEY ([est_res_id])
  REFERENCES [Reservas]([res_id]),
 CONSTRAINT [FK_401] FOREIGN KEY ([est_usu_alta])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_553] FOREIGN KEY ([est_usu_salida])
  REFERENCES [Usuarios]([usu_id])
);
GO

CREATE TABLE [Clientes_Estadias]
(
 [cye_cli_documento] BIGINT NOT NULL ,
 [cye_est_res_id]    INT NOT NULL ,
 [cye_hab_id]        INT NOT NULL ,
 [cye_hab_hot_id]    INT NOT NULL ,
 [cye_cli_doc_id]    INT NOT NULL ,

 CONSTRAINT [FK_560] FOREIGN KEY ([cye_cli_documento], [cye_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_565] FOREIGN KEY ([cye_est_res_id])
  REFERENCES [Estadias]([est_res_id]),
 CONSTRAINT [FK_569] FOREIGN KEY ([cye_hab_id], [cye_hab_hot_id])
  REFERENCES [Habitaciones]([hab_id], [hab_hot_id])
);
GO

CREATE TABLE [Facturas]
(
 [fac_id]            INT IDENTITY (1, 1) NOT NULL ,
 [fac_cli_documento] BIGINT NOT NULL ,
 [fac_tipo_pago]     VARCHAR(50) NOT NULL ,
 [fac_fecha]         DATE NOT NULL ,
 [fac_total]         INT NOT NULL ,
 [fac_est_res_id]    INT NOT NULL ,
 [fac_med_id]        INT NOT NULL ,
 [fac_tar_id]        INT NOT NULL ,
 [fac_cli_doc_id]    INT NOT NULL ,
 [cye_id]            INT NOT NULL ,

 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED ([fac_id] ASC),
 CONSTRAINT [FK_340] FOREIGN KEY ([fac_cli_documento], [fac_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_462] FOREIGN KEY ([fac_est_res_id])
  REFERENCES [Estadias]([est_res_id]),
 CONSTRAINT [FK_597] FOREIGN KEY ([cye_id])
  REFERENCES [Clientes_Errores]([cye_id]),
 CONSTRAINT [FK_604] FOREIGN KEY ([fac_med_id])
  REFERENCES [MediosPago]([med_id]),
 CONSTRAINT [FK_621] FOREIGN KEY ([fac_tar_id])
  REFERENCES [Tarjetas]([tar_id])
);
GO

CREATE TABLE [Items_Facturas]
(
 [iyf_id]       INT IDENTITY (1, 1) NOT NULL ,
 [iyf_con_id]   INT NULL ,
 [iyf_fac_id]   INT NULL ,
 [iyf_cantidad] INT NULL ,
 [iyf_monto]    INT NULL ,

 CONSTRAINT [PK_Clientes_Consumibles] PRIMARY KEY CLUSTERED ([iyf_id] ASC),
 CONSTRAINT [FK_354] FOREIGN KEY ([iyf_con_id])
  REFERENCES [Consumibles]([con_id]),
 CONSTRAINT [FK_455] FOREIGN KEY ([iyf_fac_id])
  REFERENCES [Facturas]([fac_id])
);
GO
*/