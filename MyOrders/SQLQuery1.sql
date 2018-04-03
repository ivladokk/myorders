ALTER TABLE Orders ADD ContrAgentID int null, NumberKP varchar(500) null,ProviderID int;  


ALTER TABLE Orders ADD ProviderID int
go


select * from Status



create procedure GoodsReport
as begin
select	isnull(A.Name,'') as N'Клиент',
		ISNULL(O.Provider,A2.Name) as N'Поставщик',
		isnull(O.NumberKP,'') as N'Номер КП',
		O.AcceptNum as N'Номер подтверждения',
		S.StatusValue as N'Статус',
		O.OrderDate as N'Дата доставки по СО',
		O.ControlDate as N'Контрольная дата',
		DATEPART(wk,O.ControlDate) as N'Номер недели'

from Orders O
left join ContrAgents A on A.ContrAgentID=O.ContrAgentID
left join ContrAgents A2 on A2.ContrAgentID=O.ProviderID
inner join Status S on S.StatusID=O.Status
end