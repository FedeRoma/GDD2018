use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Usuarios
PRINT 'Migrando Usuarios...'
insert into Usuarios(
					usu_nombre,
					usu_password,
					usu_estado,
					usu_apellido,
					usu_mail,
					usu_tel,
					usu_fecha_nac,
					usu_documento,
					usu_intentos,
					usu_direccion,
					usu_username,
					usu_doc_id
					)
values				(
					'admin',
					hashbytes('SHA2_256', CAST(12345678 as NVARCHAR(50))),
					1,
					'admin',
					'admin@en_casa_andaba.com',
					'4000-0000',
					getdate(),
					12345678,
					0,
					'admin',
					'admin',
					1
					)
-- Rol de admin: SYSADMIN
insert into Roles_Usuarios(
						   ryu_usu_id,
						   ryu_rol_id
							)
						  (select u.usu_id,r.rol_id
						   from usuarios u, roles r 
						   where u.usu_username = 'admin'
						   and rol_nombre = 'SYSADMIN'
						  )
-- Hoteles del admin: TODOS
insert into Hoteles_Usuarios(
						   hyu_usu_id,
						   hyu_hot_id
							)
						  (select u.usu_id,h.hot_id
						   from usuarios u, hoteles h 
						   where u.usu_username = 'admin'
						  )
GO
PRINT 'Usuarios Migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/