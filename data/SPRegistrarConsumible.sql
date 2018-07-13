create procedure EN_CASA_ANDABA.RegistrarConsumbleEstadia
@estadia numeric(18,0),
@cons numeric(18,0),
@hab numeric(18,0)
as
begin
declare @respuesta numeric(18,0)
declare @item numeric(18,0)
declare @descri nvarchar(255)
declare @factu numeric(18,0)
declare @precio numeric(18,0)
begin tran ta
begin try
		set @precio = (select con_precio from EN_CASA_ANDABA.Consumibles where con_id = @cons)
		set @descri = (	select con_desc from EN_CASA_ANDABA.Consumibles where con_id = @cons)
		set @factu = (select fac_id from EN_CASA_ANDABA.Facturas where fac_est_res_id = @estadia)
		if( exists(select iyf_id from EN_CASA_ANDABA.Items_Facturas where  iyf_fac_id = @factu))
		begin
		set @item = (select iyf_id from EN_CASA_ANDABA.Items_Facturas where  iyf_fac_id = @factu)
		update EN_CASA_ANDABA.Items_Facturas 
		set iyf_monto = iyf_monto + @precio,
		iyf_cantidad = iyf_cantidad + 1
		where iyf_id=@item
		end
		else
		begin
		insert into EN_CASA_ANDABA.Items_Facturas(iyf_fac_id,iyf_cantidad,iyf_monto)
		values(@factu,1,@precio,@descri)
		set @item = (select iyf_id from EN_CASA_ANDABA.Items_Facturas where iyf_fac_id = @factu)
		end
		set @respuesta = 1
		select @respuesta as respuesta
commit tran ta
end try
begin catch
rollback tran ta
set @respuesta = 0
select @respuesta as respuesta
end catch
end
go