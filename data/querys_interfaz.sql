exec EN_CASA_ANDABA.buscarHoteles 'Administrador General' ,1

select *
from EN_CASA_ANDABA.Usuarios
where usu_id = 2

select R.rol_nombre 
from EN_CASA_ANDABA.Roles_Usuarios RU, EN_CASA_ANDABA.Roles R 
where RU.ryu_rol_id = R.rol_id and RU.ryu_usu_id = 2 and R.rol_estado = 1

select distinct hot_calle from EN_CASA_ANDABA.Hoteles where hot_id = 1

select distinct F.fun_desc 
from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Funcionalidades_Roles FR, EN_CASA_ANDABA.Roles R 
where R.rol_nombre = 'Guest' and R.rol_id = FR.fyr_rol_id and FR.fyr_fun_id = F.fun_id

select distinct hot_id ID, hot_calle NOMBRE 
from EN_CASA_ANDABA.Hoteles H, EN_CASA_ANDABA.Hoteles_Usuarios HU 
where H.hot_id = HU.hyu_hot_id and HU.hyu_usu_id = 1

select distinct F.fun_desc 
from EN_CASA_ANDABA.Funcionalidades F, EN_CASA_ANDABA.Roles R, EN_CASA_ANDABA.Roles_Usuarios RyU, EN_CASA_ANDABA.Funcionalidades_Roles FyR, EN_CASA_ANDABA.Hoteles_Usuarios HyU 
where R.rol_nombre = 'Administrador General' and R.rol_id = RyU.ryu_rol_id and R.rol_id = FyR.fyr_rol_id and FyR.fyr_fun_id = F.fun_id and RyU.ryu_usu_id = 1 and HyU.hyu_usu_id = RyU.ryu_usu_id and HyU.hyu_hot_id = 1


--AbmHabitacion
--Alta.CS

--select "hot_calle+hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " /*+ aca iria el abm login del hotel*/

