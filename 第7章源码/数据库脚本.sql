create database stumanage
go
use stumanage
go
create table scores( --������
	stu_id nchar(10) PRIMARY KEY,
	stu_name nchar(10) not null,
	english_score int check(english_score<100),
	math_score int,
	computer_score int,
	physics_score int 
)
go
insert into scores values ('1','��1','60','70','80','90')
insert into scores values ('2','��2','61','71','81','91')
insert into scores values ('3','��3','62','72','82','92')
insert into scores values ('4','��4','63','73','83','93')
insert into scores values ('5','��5','64','74','84','94')
insert into scores values ('6','��6','65','75','85','95')
insert into scores values ('7','��7','66','76','86','96')
insert into scores values ('8','��8','67','77','87','97')
insert into scores values ('9','��9','68','78','88','98')
insert into scores values ('10','��10','69','79','89','99')
insert into scores values ('11','��11','70','80','90','100')
insert into scores values ('12','��12','71','81','91','101')
insert into scores values ('13','��13','72','82','92','102')
insert into scores values ('14','��14','73','83','93','103')
insert into scores values ('15','��15','74','84','94','104')
insert into scores values ('16','��16','75','85','95','105')
insert into scores values ('17','��17','76','86','96','106')
insert into scores values ('18','��18','77','87','97','107')
insert into scores values ('19','��19','78','88','98','108')
insert into scores values ('20','��20','79','89','99','109')