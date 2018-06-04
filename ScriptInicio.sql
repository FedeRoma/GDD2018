DROP TABLE [Items_Facturas];
GO


DROP TABLE [Facturas];
GO


DROP TABLE [Estadias];
GO


DROP TABLE [Status_Habitaciones];
GO


DROP TABLE [Roles_Usuarios];
GO


DROP TABLE [Reservas];
GO


DROP TABLE [Funcionalidades_Roles];
GO


DROP TABLE [Usuarios];
GO


DROP TABLE [Habitaciones];
GO


DROP TABLE [Inhabilitaciones_Hoteles];
GO


DROP TABLE [Regimenes_Hoteles];
GO


DROP TABLE [Clientes];
GO


DROP TABLE [Status];
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


DROP TABLE [Inhabilitaciones];
GO


DROP TABLE [Regimenes];
GO


DROP TABLE [Hoteles];
GO


--************************************** [Status]

CREATE TABLE [Status]
(
 [sta_id]   INT IDENTITY (1, 1) NOT NULL ,
 [sta_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_StatusHabitacion] PRIMARY KEY CLUSTERED ([sta_id] ASC)
);
GO



--************************************** [Funcionalidades]

CREATE TABLE [Funcionalidades]
(
 [fun_id]     INT IDENTITY (1, 1) NOT NULL ,
 [fun_nombre] VARCHAR(50) NOT NULL ,
 [fun_tipo]   VARCHAR(50) NOT NULL ,

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
 [est_id]     INT IDENTITY (1, 1) NOT NULL ,
 [est_desc]   VARCHAR(50) NOT NULL ,
 
 CONSTRAINT [PK_Estados] PRIMARY KEY CLUSTERED ([est_id] ASC)
);
GO



--************************************** [Consumibles]

CREATE TABLE [Consumibles]
(
 [con_id]     INT NOT NULL ,
 [con_descr]  VARCHAR(50) NOT NULL ,
 [con_precio] INT NOT NULL ,

 CONSTRAINT [PK_Consumibles] PRIMARY KEY CLUSTERED ([con_id] ASC)
);
GO



--************************************** [TiposHabitaciones]

CREATE TABLE [TiposHabitaciones]
(
 [tip_id]     INT NOT NULL ,
 [tip_nombre] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_TiposHabitaciones] PRIMARY KEY CLUSTERED ([tip_id] ASC)
);
GO



--************************************** [Inhabilitaciones]

CREATE TABLE [Inhabilitaciones]
(
 [inh_id]   INT IDENTITY (1, 1) NOT NULL ,
 [inh_desc] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Inhabilitaciones] PRIMARY KEY CLUSTERED ([inh_id] ASC)
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
 [hot_id]          INT IDENTITY (1, 1) NOT NULL ,
 [hot_nombre]      VARCHAR(50) NULL ,
 [hot_estrellas]   INT NULL ,
 [hot_calle]       VARCHAR(50) NULL ,
 [hot_calle_nro]   INT NULL ,
 [hot_ciudad]      VARCHAR(50) NULL ,
 [hot_pais]        VARCHAR(50) NULL ,
 [hot_mail]        VARCHAR(50) NULL ,
 [hot_telefono]    VARCHAR(50) NULL ,
 [hot_fecha_cre]   DATE NULL ,
 [hot_habilitado]  BIT NULL ,
 [hot_inhab_desde] DATE NULL ,
 [hot_inhab_hasta] DATE NULL ,

 CONSTRAINT [PK_Hoteles] PRIMARY KEY CLUSTERED ([hot_id] ASC)
);
GO



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
 [usu_tipo_doc]  VARCHAR(10) NOT NULL ,
 [usu_documento] BIGINT NOT NULL ,
 [usu_intentos]  INT NOT NULL ,
 [usu_hot_id]    INT NOT NULL ,
 [usu_direccion] VARCHAR(50) NOT NULL ,

 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([usu_id] ASC),
 CONSTRAINT [FK_273] FOREIGN KEY ([usu_hot_id])
  REFERENCES [Hoteles]([hot_id])
);
GO


--SKIP Index: [fkIdx_273]


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


--************************************** [Inhabilitaciones_Hoteles]

CREATE TABLE [Inhabilitaciones_Hoteles]
(
 [iyh_hot_id]      INT NOT NULL ,
 [iyh_inh_id]      INT NOT NULL ,
 [inh_fecha_desde] DATE NOT NULL ,
 [inh_fecha_hasta] DATE NOT NULL ,
 [iyh_id]          INT IDENTITY (1, 1) NOT NULL ,

 CONSTRAINT [PK_Inahbilitacion_Hoteles] PRIMARY KEY CLUSTERED ([iyh_id] ASC),
 CONSTRAINT [FK_109] FOREIGN KEY ([iyh_hot_id])
  REFERENCES [Hoteles]([hot_id]),
 CONSTRAINT [FK_113] FOREIGN KEY ([iyh_inh_id])
  REFERENCES [Inhabilitaciones]([inh_id])
);
GO


--SKIP Index: [fkIdx_109]

--SKIP Index: [fkIdx_113]


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
 [cli_tipo_doc]      VARCHAR(20) NOT NULL ,
 [cli_documento]     BIGINT NOT NULL ,
 [cli_hot_id]        INT NOT NULL ,
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

 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED ([cli_tipo_doc] ASC, [cli_documento] ASC),
 CONSTRAINT [FK_18] FOREIGN KEY ([cli_hot_id])
  REFERENCES [Hoteles]([hot_id])
);
GO


--SKIP Index: [fkIdx_18]


--************************************** [Status_Habitaciones]

CREATE TABLE [Status_Habitaciones]
(
 [syh_sta_id]       INT NOT NULL ,
 [syh_hab_id]       INT NOT NULL ,
 [syh_hab_hot_id]   INT NOT NULL ,
 [syh_fecha_inicio] DATE NOT NULL ,
 [syh_fecha_fin]    DATE NOT NULL ,

 CONSTRAINT [PK_Status_Habitacion] PRIMARY KEY CLUSTERED ([syh_sta_id] ASC, [syh_hab_id] ASC, [syh_hab_hot_id] ASC),
 CONSTRAINT [FK_288] FOREIGN KEY ([syh_sta_id])
  REFERENCES [Status]([sta_id]),
 CONSTRAINT [FK_292] FOREIGN KEY ([syh_hab_id], [syh_hab_hot_id])
  REFERENCES [Habitaciones]([hab_id], [hab_hot_id])
);
GO


--SKIP Index: [fkIdx_288]

--SKIP Index: [fkIdx_292]


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
 [res_est_id]        INT NOT NULL ,
 [res_fecha]         DATETIME NOT NULL ,
 [res_inicio]        DATE NOT NULL ,
 [res_fin]           DATE NOT NULL ,
 [res_checkin]       DATE NOT NULL ,
 [res_checkout]      DATE NOT NULL ,
 [res_tip_id]        INT NOT NULL ,
 [res_reg_id]        INT NOT NULL ,
 [res_cli_tipo_doc]  VARCHAR(20) NOT NULL ,
 [res_cli_documento] BIGINT NOT NULL ,
 [res_usu_encargado] INT NOT NULL ,
 [res_hab_id]        INT NOT NULL ,
 [res_hab_hot_id]    INT NOT NULL ,

 CONSTRAINT [PK_Reservas] PRIMARY KEY CLUSTERED ([res_id] ASC),
 CONSTRAINT [FK_155] FOREIGN KEY ([res_tip_id])
  REFERENCES [TiposHabitaciones]([tip_id]),
 CONSTRAINT [FK_159] FOREIGN KEY ([res_reg_id])
  REFERENCES [Regimenes]([reg_id]),
 CONSTRAINT [FK_163] FOREIGN KEY ([res_cli_tipo_doc], [res_cli_documento])
  REFERENCES [Clientes]([cli_tipo_doc], [cli_documento]),
 CONSTRAINT [FK_327] FOREIGN KEY ([res_usu_encargado])
  REFERENCES [Usuarios]([usu_id]),
 CONSTRAINT [FK_374] FOREIGN KEY ([res_est_id])
  REFERENCES [Estados]([est_id]),
 CONSTRAINT [FK_385] FOREIGN KEY ([res_hab_id], [res_hab_hot_id])
  REFERENCES [Habitaciones]([hab_id], [hab_hot_id])
);
GO


--SKIP Index: [fkIdx_155]

--SKIP Index: [fkIdx_159]

--SKIP Index: [fkIdx_163]

--SKIP Index: [fkIdx_327]

--SKIP Index: [fkIdx_374]

--SKIP Index: [fkIdx_385]


--************************************** [Estadias]

CREATE TABLE [Estadias]
(
 [est_id]            INT IDENTITY (1, 1) NOT NULL ,
 [est_res_id]        INT NOT NULL ,
 [est_usu_encargado] INT NOT NULL ,
 [est_checkin]       DATE NULL ,
 [est_checkout]      DATE NULL ,
 [est_cant_noches]   INT NULL ,
 [est_monto]         INT NOT NULL ,

 CONSTRAINT [PK_Estadia] PRIMARY KEY CLUSTERED ([est_id] ASC),
 CONSTRAINT [FK_394] FOREIGN KEY ([est_res_id])
  REFERENCES [Reservas]([res_id]),
 CONSTRAINT [FK_401] FOREIGN KEY ([est_usu_encargado])
  REFERENCES [Usuarios]([usu_id])
);
GO


--SKIP Index: [fkIdx_394]

--SKIP Index: [fkIdx_401]


--************************************** [Facturas]

CREATE TABLE [Facturas]
(
 [fac_id]            INT IDENTITY (1, 1) NOT NULL ,
 [fac_cli_tipo_doc]  VARCHAR(20) NOT NULL ,
 [fac_cli_documento] BIGINT NOT NULL ,
 [fac_tipo_pago]     VARCHAR(50) NOT NULL ,
 [fac_est_id]        INT NOT NULL ,

 CONSTRAINT [PK_factura] PRIMARY KEY CLUSTERED ([fac_id] ASC),
 CONSTRAINT [FK_340] FOREIGN KEY ([fac_cli_tipo_doc], [fac_cli_documento])
  REFERENCES [Clientes]([cli_tipo_doc], [cli_documento]),
 CONSTRAINT [FK_462] FOREIGN KEY ([fac_est_id])
  REFERENCES [Estadias]([est_id])
);
GO


--SKIP Index: [fkIdx_340]

--SKIP Index: [fkIdx_462]


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


