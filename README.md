# GDD2018

Script inicio: Crea tablas
El resto son migraciones

<b>Cosas realizadas:</b>
<br>
Migracion Hoteles
<br>
Migracion Clientes
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
Migracion Items_Facturas - <b>Hecho</b> Omito constraint para migrar
<br>
Migracion Estadias - <b>Hecho</b> Saco una validacion de nulo para poder migrar
<br>
Migracion Reservas - <b>Hecho</b> Saco varias validaciones de nulos y Omito constraint para migrar
<br>
Migracion Estados - <b>Hecho</b>
<br>
Migracion Funcionalidades - <b>Hecho</b>
<br>
Migracion Roles - <b>Hecho</b>
<br>
Migracion Funcionalidades_Roles - <b>Hecho</b>
<br>
Migracion Inhabilitaciones_Hoteles - <b>NULL</b>
<br>
Migracion Inhabilitaciones - <b>NULL</b>
<br>
Migracion Roles_Usuarios - <b>NULL</b>
<br>
Migracion Status - <b>NULL</b>
<br>  
Migracion Status_Habitaciones - <b>NULL</b>
<br>
Migracion Usuarios
<br>
Migracion Facturas
<br>

A tener en cuenta:
- Ver validacion de mail (Unique en el DER pero no en la BD)
- campo Hotel_recarga_estrella no migrado
- campo Habitacion_tipo_porcentual no migrado

Federico Romano tareas realizando: Factura

Mati y Pablo: Usuarios

ESTUDIAR C#
Pablo se puso la 10
