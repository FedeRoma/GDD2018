-- ****************** SqlDBM: Microsoft SQL Server ******************
-- ******************************************************************

DROP TABLE [Items_Facturas];
GO


DROP TABLE [Clientes_Estadias];
GO


DROP TABLE [Facturas];
GO


DROP TABLE [Reservas_Habitaciones];
GO


DROP TABLE [Usuarios_ReservasCancelaciones];
GO


DROP TABLE [Usuarios_ReservasModificaciones];
GO


DROP TABLE [Estadias];
GO


DROP TABLE [Hoteles_Usuarios];
GO


DROP TABLE [Roles_Usuarios];
GO


DROP TABLE [Reservas];
GO


DROP TABLE [ClientesErrores];
GO


DROP TABLE [BajasHotel];
GO


DROP TABLE [Funcionalidades_Roles];
GO


DROP TABLE [Usuarios];
GO


DROP TABLE [Habitaciones];
GO


DROP TABLE [Regimenes_Hoteles];
GO


DROP TABLE [Clientes];
GO


DROP TABLE [Documentos];
GO


DROP TABLE [Tarjetas];
GO


DROP TABLE [MediosPago];
GO


DROP TABLE [Funcionalidades];
GO


DROP TABLE [Roles];
GO


DROP TABLE [Estados];
GO


DROP TABLE [Consumibles];
GO


DROP TABLE [TiposHabitaciones];
GO


DROP TABLE [Regimenes];
GO


DROP TABLE [Hoteles];
GO


--************************************** [Documentos]

CREATE TABLE [Documentos]
(
 [doc_id]   INT IDENTITY (1, 1) NOT NULL ,
 [doc_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Documentos] PRIMARY KEY CLUSTERED ([doc_id] ASC)
);
GO



--************************************** [Tarjetas]

CREATE TABLE [Tarjetas]
(
 [tar_id]      INT IDENTITY (1, 1) NOT NULL ,
 [tar_emisor]  VARCHAR(50) NOT NULL ,
 [tar_banco]   VARCHAR(50) NOT NULL ,
 [tar_numero]  BIGINT NOT NULL ,
 [tar_titular] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Tarjetas] PRIMARY KEY CLUSTERED ([tar_id] ASC)
);
GO



--************************************** [MediosPago]

CREATE TABLE [MediosPago]
(
 [med_id]   INT IDENTITY (1, 1) NOT NULL ,
 [med_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_MedioPago] PRIMARY KEY CLUSTERED ([med_id] ASC)
);
GO



--************************************** [Funcionalidades]

CREATE TABLE [Funcionalidades]
(
 [fun_id]   INT IDENTITY (1, 1) NOT NULL ,
 [fun_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Funcionalidad] PRIMARY KEY CLUSTERED ([fun_id] ASC)
);
GO



--************************************** [Roles]

CREATE TABLE [Roles]
(
 [rol_id]     INT IDENTITY (1, 1) NOT NULL ,
 [rol_nombre] VARCHAR(50) NOT NULL ,
 [rol_estado] BIT NOT NULL ,

 CONSTRAINT [PK_Rol] PRIMARY KEY CLUSTERED ([rol_id] ASC)
);
GO



--************************************** [Estados]

CREATE TABLE [Estados]
(
 [estados_id]   INT IDENTITY (1, 1) NOT NULL ,
 [estados_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED ([estados_id] ASC)
);
GO



--************************************** [Consumibles]

CREATE TABLE [Consumibles]
(
 [con_id]     INT NOT NULL ,
 [con_desc]   VARCHAR(50) NOT NULL ,
 [con_precio] INT NOT NULL ,

 CONSTRAINT [PK_Consumibles] PRIMARY KEY CLUSTERED ([con_id] ASC)
);
GO



--************************************** [TiposHabitaciones]

CREATE TABLE [TiposHabitaciones]
(
 [tip_id]         INT NOT NULL ,
 [tip_nombre]     VARCHAR(50) NOT NULL ,
 [tip_porcentual] INT NOT NULL ,
 [tip_personas]   INT NOT NULL ,

 CONSTRAINT [PK_TiposHabitaciones] PRIMARY KEY CLUSTERED ([tip_id] ASC)
);
GO



--************************************** [Regimenes]

CREATE TABLE [Regimenes]
(
 [reg_id]         INT IDENTITY (1, 1) NOT NULL ,
 [reg_desc]       VARCHAR(50) NOT NULL ,
 [reg_precio]     INT NOT NULL ,
 [reg_habilitado] BIT NULL ,

 CONSTRAINT [PK_TipoHoteles] PRIMARY KEY CLUSTERED ([reg_id] ASC)
);
GO



--************************************** [Hoteles]

CREATE TABLE [Hoteles]
(
 [hot_id]         INT IDENTITY (1, 1) NOT NULL ,
 [hot_nombre]     VARCHAR(50) NULL ,
 [hot_estrellas]  INT NULL ,
 [hot_calle]      VARCHAR(50) NULL ,
 [hot_calle_nro]  INT NULL ,
 [hot_ciudad]     VARCHAR(50) NULL ,
 [hot_pais]       VARCHAR(50) NULL ,
 [hot_mail]       VARCHAR(50) NULL ,
 [hot_telefono]   VARCHAR(50) NULL ,
 [hot_fecha_cre]  DATE NULL ,
 [hot_habilitado] BIT NULL ,

 CONSTRAINT [PK_Hoteles] PRIMARY KEY CLUSTERED ([hot_id] ASC)
);
GO



--************************************** [ClientesErrores]

CREATE TABLE [ClientesErrores]
(
 [cye_id]            INT IDENTITY (1, 1) NOT NULL ,
 [cye_doc_id]        INT NOT NULL ,
 [cye_documento]     BIGINT NOT NULL ,
 [cye_nombre]        VARCHAR(50) NOT NULL ,
 [cye_apellido]      VARCHAR(50) NOT NULL ,
 [cye_mail]          VARCHAR(50) NOT NULL ,
 [cye_nacionalidad]  VARCHAR(50) NOT NULL ,
 [cye_fecha_nac]     DATE NOT NULL ,
 [cye_habilitado]    BIT NULL ,
 [cye_calle]         VARCHAR(50) NULL ,
 [cye_calle_nro]     INT NULL ,
 [cye_piso]          NVARCHAR(10) NULL ,
 [cye_depto]         NVARCHAR(10) NULL ,
 [cye_dir_localidad] VARCHAR(50) NULL ,
 [cye_dir_pais]      VARCHAR(50) NULL ,
 [cye_telefono]      NVARCHAR(50) NULL ,
 [cye_error]         VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Clientes_Errores] PRIMARY KEY CLUSTERED ([cye_id] ASC),
 CONSTRAINT [FK_630] FOREIGN KEY ([cye_doc_id])
  REFERENCES [Documentos]([doc_id])
);
GO


--SKIP Index: [fkIdx_630]


--************************************** [BajasHotel]

CREATE TABLE [BajasHotel]
(
 [baj_id]           INT IDENTITY (1, 1) NOT NULL ,
 [baj_hot_id]       INT NOT NULL ,
 [baj_fecha_inicio] DATE NOT NULL ,
 [baj_fecha_fin]    DATE NOT NULL ,
 [baj_motivo]       VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_BajasHotel] PRIMARY KEY CLUSTERED ([baj_id] ASC),
 CONSTRAINT [FK_493] FOREIGN KEY ([baj_hot_id])
  REFERENCES [Hoteles]([hot_id])
);
GO


--SKIP Index: [fkIdx_493]


--************************************** [Funcionalidades_Roles]

CREATE TABLE [Funcionalidades_Roles]
(
 [fyr_rol_id] INT NOT NULL ,
 [fyr_fun_id] INT NOT NULL ,

 CONSTRAINT [FK_258] FOREIGN KEY ([fyr_rol_id])
  REFERENCES [Roles]([rol_id]),
 CONSTRAINT [FK_262] FOREIGN KEY ([fyr_fun_id])
  REFERENCES [Funcionalidades]([fun_id])
);
GO


--SKIP Index: [fkIdx_258]

--SKIP Index: [fkIdx_262]


--************************************** [Usuarios]

CREATE TABLE [Usuarios]
(
 [usu_id]        INT IDENTITY (1, 1) NOT NULL ,
 [usu_nombre]    VARCHAR(50) NOT NULL ,
 [usu_password]  VARCHAR(50) NOT NULL ,
 [usu_estado]    VARCHAR(50) NOT NULL ,
 [usu_apellido]  VARCHAR(50) NOT NULL ,
 [usu_mail]      VARCHAR(50) NOT NULL ,
 [usu_tel]       VARCHAR(50) NOT NULL ,
 [usu_fecha_nac] DATE NOT NULL ,
 [usu_documento] BIGINT NOT NULL ,
 [usu_intentos]  INT NOT NULL ,
 [usu_direccion] VARCHAR(50) NOT NULL ,
 [usu_username]  VARCHAR(50) NOT NULL ,
 [usu_doc_id]    INT NOT NULL ,

 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([usu_id] ASC),
 CONSTRAINT [FK_643] FOREIGN KEY ([usu_doc_id])
  REFERENCES [Documentos]([doc_id])
);
GO


--SKIP Index: [fkIdx_643]


--************************************** [Habitaciones]

CREATE TABLE [Habitaciones]
(
 [hab_id]         INT IDENTITY (1, 1) NOT NULL ,
 [hab_hot_id]     INT NOT NULL ,
 [hab_tip_id]     INT NOT NULL ,
 [hab_numero]     INT NOT NULL ,
 [hab_piso]       INT NOT NULL ,
 [hab_vista]      CHAR(1) NOT NULL ,
 [hab_desc]       VARCHAR(50) NULL ,
 [hab_habilitado] BIT NULL ,

 CONSTRAINT [PK_Habitaciones] PRIMARY KEY CLUSTERED ([hab_id] ASC, [hab_hot_id] ASC),
 CONSTRAINT [FK_133] FOREIGN KEY ([hab_hot_id])
  REFERENCES [Hoteles]([hot_id]),
 CONSTRAINT [FK_137] FOREIGN KEY ([hab_tip_id])
  REFERENCES [TiposHabitaciones]([tip_id])
);
GO


--SKIP Index: [fkIdx_133]

--SKIP Index: [fkIdx_137]


--************************************** [Regimenes_Hoteles]

CREATE TABLE [Regimenes_Hoteles]
(
 [ryh_hot_id] INT NOT NULL ,
 [ryh_reg_id] INT NOT NULL ,
 [ryh_id]     INT IDENTITY (1, 1) NOT NULL ,

 CONSTRAINT [PK_Regimenes_Hoteles] PRIMARY KEY CLUSTERED ([ryh_id] ASC),
 CONSTRAINT [FK_83] FOREIGN KEY ([ryh_hot_id])
  REFERENCES [Hoteles]([hot_id]),
 CONSTRAINT [FK_87] FOREIGN KEY ([ryh_reg_id])
  REFERENCES [Regimenes]([reg_id])
);
GO


--SKIP Index: [fkIdx_83]

--SKIP Index: [fkIdx_87]


--************************************** [Clientes]

CREATE TABLE [Clientes]
(
 [cli_documento]     BIGINT NOT NULL ,
 [cli_doc_id]        INT NOT NULL ,
 [cli_nombre]        VARCHAR(50) NOT NULL ,
 [cli_apellido]      VARCHAR(50) NOT NULL ,
 [cli_mail]          VARCHAR(50) NOT NULL ,
 [cli_nacionalidad]  VARCHAR(50) NOT NULL ,
 [cli_fecha_nac]     DATE NOT NULL ,
 [cli_habilitado]    BIT NULL ,
 [cli_calle]         VARCHAR(50) NULL ,
 [cli_calle_nro]     INT NULL ,
 [cli_piso]          NVARCHAR(10) NULL ,
 [cli_depto]         NVARCHAR(10) NULL ,
 [cli_dir_localidad] VARCHAR(50) NULL ,
 [cli_dir_pais]      VARCHAR(50) NULL ,
 [cli_telefono]      NVARCHAR(50) NULL ,

 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([cli_documento] ASC, [cli_doc_id] ASC),
 CONSTRAINT [FK_636] FOREIGN KEY ([cli_doc_id])
  REFERENCES [Documentos]([doc_id])
);
GO


--SKIP Index: [fkIdx_636]


--************************************** [Hoteles_Usuarios]

CREATE TABLE [Hoteles_Usuarios]
(
 [hyu_usu_id] INT NOT NULL ,
 [hyu_hot_id] INT NOT NULL ,
 [hyu_id]     INT IDENTITY (1, 1) NOT NULL ,

 CONSTRAINT [PK_Hoteles_Usuarios] PRIMARY KEY CLUSTERED ([hyu_id] ASC),
 CONSTRAINT [FK_481] FOREIGN KEY ([hyu_usu_id])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_649] FOREIGN KEY ([hyu_hot_id])
  REFERENCES [Hoteles]([hot_id])
);
GO


--SKIP Index: [fkIdx_481]

--SKIP Index: [fkIdx_649]


--************************************** [Roles_Usuarios]

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


--SKIP Index: [fkIdx_250]

--SKIP Index: [fkIdx_254]


--************************************** [Reservas]

CREATE TABLE [Reservas]
(
 [res_id]            INT NOT NULL ,
 [res_estados_id]    INT NOT NULL ,
 [res_fecha]         DATETIME NOT NULL ,
 [res_inicio]        DATE NOT NULL ,
 [res_fin]           DATE NOT NULL ,
 [res_tip_id]        INT NOT NULL ,
 [res_reg_id]        INT NOT NULL ,
 [res_cli_documento] BIGINT NOT NULL ,
 [res_usu_id]        INT NOT NULL ,
 [res_cli_doc_id]    INT NULL ,
 [res_cye_id]        INT NULL ,

 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED ([res_id] ASC),
 CONSTRAINT [FK_155] FOREIGN KEY ([res_tip_id])
  REFERENCES [TiposHabitaciones]([tip_id]),
 CONSTRAINT [FK_159] FOREIGN KEY ([res_reg_id])
  REFERENCES [Regimenes]([reg_id]),
 CONSTRAINT [FK_163] FOREIGN KEY ([res_cli_documento], [res_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_374] FOREIGN KEY ([res_estados_id])
  REFERENCES [Estados]([estados_id]),
 CONSTRAINT [FK_533] FOREIGN KEY ([res_usu_id])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_592] FOREIGN KEY ([res_cye_id])
  REFERENCES [ClientesErrores]([cye_id])
);
GO


--SKIP Index: [fkIdx_155]

--SKIP Index: [fkIdx_159]

--SKIP Index: [fkIdx_163]

--SKIP Index: [fkIdx_374]

--SKIP Index: [fkIdx_533]

--SKIP Index: [fkIdx_592]


--************************************** [Reservas_Habitaciones]

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


--SKIP Index: [fkIdx_539]

--SKIP Index: [fkIdx_544]


--************************************** [Usuarios_ReservasCancelaciones]

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


--SKIP Index: [fkIdx_511]

--SKIP Index: [fkIdx_515]


--************************************** [Usuarios_ReservasModificaciones]

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


--SKIP Index: [fkIdx_519]

--SKIP Index: [fkIdx_523]


--************************************** [Estadias]

CREATE TABLE [Estadias]
(
 [est_res_id]         INT NOT NULL ,
 [est_usu_alta]       INT NOT NULL ,
 [est_checkin]        DATE NULL ,
 [est_checkout]       DATE NULL ,
 [est_cant_noches]    INT NULL ,
 [est_precio]         INT NOT NULL ,
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


--SKIP Index: [fkIdx_394]

--SKIP Index: [fkIdx_401]

--SKIP Index: [fkIdx_553]


--************************************** [Clientes_Estadias]

CREATE TABLE [Clientes_Estadias]
(
 [cye_cli_documento] BIGINT NULL ,
 [cye_est_res_id]    INT NOT NULL ,
 [cye_hab_id]        INT NOT NULL ,
 [cye_hab_hot_id]    INT NOT NULL ,
 [cye_cli_doc_id]    INT NULL ,
 [cye_cye_id]        INT NULL ,

 CONSTRAINT [FK_560] FOREIGN KEY ([cye_cli_documento], [cye_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_565] FOREIGN KEY ([cye_est_res_id])
  REFERENCES [Estadias]([est_res_id]),
 CONSTRAINT [FK_569] FOREIGN KEY ([cye_hab_id], [cye_hab_hot_id])
  REFERENCES [Habitaciones]([hab_id], [hab_hot_id]),
 CONSTRAINT [FK_658] FOREIGN KEY ([cye_cye_id])
  REFERENCES [ClientesErrores]([cye_id])
);
GO


--SKIP Index: [fkIdx_560]

--SKIP Index: [fkIdx_565]

--SKIP Index: [fkIdx_569]

--SKIP Index: [fkIdx_658]


--************************************** [Facturas]

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
 [fac_cye_id]        INT NOT NULL ,

 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED ([fac_id] ASC),
 CONSTRAINT [FK_340] FOREIGN KEY ([fac_cli_documento], [fac_cli_doc_id])
  REFERENCES [Clientes]([cli_documento], [cli_doc_id]),
 CONSTRAINT [FK_462] FOREIGN KEY ([fac_est_res_id])
  REFERENCES [Estadias]([est_res_id]),
 CONSTRAINT [FK_597] FOREIGN KEY ([fac_cye_id])
  REFERENCES [ClientesErrores]([cye_id]),
 CONSTRAINT [FK_604] FOREIGN KEY ([fac_med_id])
  REFERENCES [MediosPago]([med_id]),
 CONSTRAINT [FK_621] FOREIGN KEY ([fac_tar_id])
  REFERENCES [Tarjetas]([tar_id])
);
GO


--SKIP Index: [fkIdx_340]

--SKIP Index: [fkIdx_462]

--SKIP Index: [fkIdx_597]

--SKIP Index: [fkIdx_605]

--SKIP Index: [fkIdx_621]


--************************************** [Items_Facturas]

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


--SKIP Index: [fkIdx_354]

--SKIP Index: [fkIdx_455]


