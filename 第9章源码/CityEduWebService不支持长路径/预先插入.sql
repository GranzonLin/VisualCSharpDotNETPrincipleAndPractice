if db_id('CityEduManage') is null
	create database CityEduManage
go
use CityEduManage


/*ѧУ����*/
insert into School_Type values(0,'Сѧ',6)
insert into School_Type values(1,'����',3)
insert into School_Type values(2,'����',3)
insert into School_Type values(3,'����',6)
insert into School_Type values(4,'����һ����',9)
/*�꼶*/
insert into Class_Type values(0,'1�꼶',0)
insert into Class_Type values(1,'2�꼶',0)
insert into Class_Type values(2,'3�꼶',0)
insert into Class_Type values(3,'4�꼶',0)
insert into Class_Type values(4,'5�꼶',0)
insert into Class_Type values(5,'6�꼶',0)
/*�꼶*/
insert into Class_Type values(6,'��1',1)
insert into Class_Type values(7,'��2',1)
insert into Class_Type values(8,'��3',1)
/*�꼶*/
insert into Class_Type values(9,'��1',2)
insert into Class_Type values(10,'��2',2)
insert into Class_Type values(11,'��3',2)
/*�꼶*/
insert into Class_Type values(12,'��1',3)
insert into Class_Type values(13,'��2',3)
insert into Class_Type values(14,'��3',3)
insert into Class_Type values(15,'��1',3)
insert into Class_Type values(16,'��2',3)
insert into Class_Type values(17,'��3',3)
/*�꼶*/
insert into Class_Type values(18,'1�꼶',4)
insert into Class_Type values(19,'2�꼶',4)
insert into Class_Type values(20,'3�꼶',4)
insert into Class_Type values(21,'4�꼶',4)
insert into Class_Type values(22,'5�꼶',4)
insert into Class_Type values(23,'6�꼶',4)
insert into Class_Type values(24,'��1',4)
insert into Class_Type values(25,'��2',4)
insert into Class_Type values(26,'��3',4)
/*�꼶*/
insert into QuXian values(0,'��ԭ��')
insert into QuXian values(1,'������')
insert into QuXian values(2,'�ܳ���')
insert into QuXian values(3,'��ˮ��')
insert into QuXian values(4,'�ݼ���')
insert into QuXian values(5,'������')
insert into QuXian values(6,'���ÿ�����')
insert into QuXian values(7,'֣��������������')
insert into QuXian values(8,'��֣����')
insert into QuXian values(9,'���������´�����')
insert into Office values(0,'�������Ҿ�ί��İ��´�',9)
/*�û�*/
insert into Users values('Admin','Admin',0)
go