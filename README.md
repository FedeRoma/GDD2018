# GDD2018

Script inicio: Crea tablas
El resto son migraciones

<b>Cosas realizadas:</b>
<br>
Migracion HOTELES
<br>
Migracion CLIENTES
<br>
Temporal #TemporalClientesRepetidos con los pasaportes problematicos.
<br>
Migracion Consumibles
<br>
Migracion TiposHabitaciones
<br>
Migracion Habitaciones
<br>
Migracion Regimenes
<br>
Migracion Regimenes_Hoteles
<br>

<b>Faltantes:</b>
<br>
Migracion Items_Facturas - Me saltee la constraint para poder migrar
<br>
Migracion Estadias - Saco una validacion de nulo para poder migrar
<br>
Migracion Reservas - Saco varias validaciones de nulos y me salteo una constraint para poder migrar
<br>
Migracion Estados - 
<br>
Migracion Facturas
<br>
Migracion Funcionalidades - <b>Hecho</b>
<br>
Migracion Funcionalidades_Roles - <b>Hecho</b>
<br>
Migracion Inhabilitaciones_Hoteles -- NULL
<br>
Migracion Inhabilitaciones -- NULL
<br>
Migracion Roles - <b>Hecho</b>
<br>
Migracion Roles_Usuarios -- NULL
<br>
Migracion Status -- NULL
<br>  
Migracion Status_Habitaciones - NULL
<br>
Migracion Usuarios
<br>

A tener en cuenta, campos no migrados:
- Hotel_recarga_estrella
- Habitacion_tipo_porcentual

Federico Romano tareas realizando:
Factura (fijate que faltan campos fecha y total)

Mati y Pablo:
Estados Roles y Usuarios

ESTUDIAR C#
Pablo se puso la 10

-- Ver validacion de mail (Unique en el DER pero no en la BD)
