-- LOGIN.CS

select usu_estado, usu_id 
from EN_CASA_ANDABA.Usuarios 
where usu_username = 'admin' and usu_password = hashbytes('SHA2_256', 'w23e')
-- oK!


select count (*) ryu_rol_id 
from EN_CASA_ANDABA.Roles_Usuarios 
where ryu_usu_id = 1
-- oK!

select fyr_fun_id
from EN_CASA_ANDABA.Funcionalidades_Roles
where fyr_rol_id = (select ryu_rol_id 
from EN_CASA_ANDABA.Roles_Usuarios 
where ryu_usu_id = 1)
-- oK!

--AbmHabitacion
--Alta.CS

select "hot_calle+hot_calle_nro from EN_CASA_ANDABA.Hoteles where hot_id = " /*+ aca iria el abm login del hotel*/
