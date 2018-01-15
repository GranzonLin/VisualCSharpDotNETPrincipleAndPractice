//����1-14��ͨ���鷽��ʵ������ʱ�Ķ�̬�ԡ���������������һ��Vehicle������Ҫ����Drive����������������ʲô���ĳ���Bike��Car��Jeep���������ǵ�Drive��ʽ��ͬ����������Ǵ��ݸ����ǵ�Vehicle��ʵ����ͨ������ʱ�Ķ�̬�ԣ��Ϳ��Ե��������Լ���Drive������
using System;
namespace P1_14
{
	public class Vehicle  
	{    
		protected float speed;  	
		public Vehicle(float s)  
		{  
			speed=s; 		
		}
		public Vehicle()  
		{  	
		} 
		public void ShowSpeed()       //�������ķ��鷽��
		{  
			Console.WriteLine("Vehicle speed: {0}  ", speed );
		}  
		public virtual void  Drive()  //���������鷽��
		{
			Console.WriteLine("drive ");
		}  
	}    
	public class Car :Vehicle    
	{    
		public Car(int s)
		{
				speed=s;
		}
		public override void Drive() //����������鷽�� 
		{
			Console.WriteLine("car drive by four wheel"); 
		}
		new public void ShowSpeed()  
		{  
			Console.WriteLine("car speed: {0}  ", speed );
		} 

	}    
	class Bike:Vehicle    
	{    
		new public  void Drive()  //����������鷽�� 
		{
			Console.WriteLine("car drive by two wheel "); 
		}
	}    
	public  class  TestVirtual
	{
		public static void test(Vehicle c )
		{
			c.Drive();              //�����鷽��
			c. ShowSpeed();        //����Vehicle������ķ��鷽��
		}
		public static void Main() 
		{
			Vehicle a=new Vehicle(120);  
			Car b=new Car(140);
			test(a);
			test(b);
			string a1=Console.ReadLine();
		}
	}
}
