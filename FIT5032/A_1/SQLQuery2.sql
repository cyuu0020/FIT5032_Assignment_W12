 
create view [Hall_View] as 
select  b.*, c.rating1, d.UserName
from dbo.Hall as b 
join  dbo.AspNetUsers as d on  b.OwnerId = d.Id
left join  (select AVG(a.rating) as rating1, a.hallId as hid  
		from dbo.Booking as a group by a.hallId ) as c
		on  b.Id  = c.hid    


 