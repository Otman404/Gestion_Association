CREATE trigger trgr_add_donation on Payement
after Insert 
as
begin

declare @a decimal
set @a = (select somme_argent from inserted)
update Membre
set SommeDons = SommeDons + @a
where id = inserted.membre_id

--UPDATE m
--SET m.SommeDons =  i.somme_argent + m.SommeDons
--FROM Membre m
--left JOIN inserted i
--	ON m.id = i.membre_id

insert into Donation (id_membre,id_payement,Montant)
select i.membre_id,i.id,i.somme_argent from Inserted i

end