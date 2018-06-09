use GD1C2018
/*-----------------------------------------------------------------------------------------------------------------------------------------------------------------*/
-- TRASPASO DE DATOS DE gd_esquema.Maestra A Regimenes
PRINT 'Migrando Regimenes...'
insert into Regimenes(
					reg_desc,
					reg_precio,
					reg_habilitado
					)
select distinct Regimen_Descripcion,Regimen_Precio,1 from gd_esquema.Maestra
GO
PRINT 'Regimenes migrados Papaaaa...'
/*------------------------------------------------------------------------------------------------------------------------------------------------------------------*/