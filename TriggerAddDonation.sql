alter trigger trgr_add_donation on Payement
after Insert 
as
begin



UPDATE m
SET m.SommeDons += i.somme_argent
FROM Membre m
INNER JOIN inserted i
	ON m.id = i.membre_id

insert into Donation (id_membre,id_payement,Montant)
select i.membre_id,i.id,i.somme_argent from Inserted i

end