//����1-21����2006��1��1�յ������Ѿ����˶����죿
using System;
public class Test
{
	public static void Main()
	{
		string[] weekDays={"������","����һ","���ڶ�","������","������","������","������"};
		DateTime now=DateTime.Now;
		Console.WriteLine("{0:������yyyy��M��d�գ�H��m},{1}",
                          now,weekDays[(int)now.DayOfWeek]);
		DateTime start=new DateTime(2006,1,1);
		TimeSpan times=now-start;
		Console.WriteLine("��2006��1��1���������Ѿ�����{0}�죡",
                         times.Days);
		Console.Read();
	}
} 
