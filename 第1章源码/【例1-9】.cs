//����1-9����ʾ��̬�����ͷǾ�̬�����Ĺ���
using System;
namespace  P1_9
{
	class Test
	{
		private int x;
		static private int y;
		public void Fn()       // �Ǿ�̬����
		{      
			x = 1;			// �൱�� this.x = 1
			y = 1;			// �൱��Test.y = 1
			Console.WriteLine("x = {0}; y={1}" , x , y);
		}
		public static void Gn()   //��̬����
		{ 
			//x = 2;			// Error, ��̬�������ܷ��ʷǾ�̬��Աx
			y = 2;	
			Console.WriteLine(" y={0}" ,  y);
		}
		static void Main() 
		{
			Test t = new Test();
            t.Fn();
			Test.Gn();
			t.x = 2;			// Ok
			//t.y = 1;			// Error, ����ͨ��ʵ�����ʾ�̬��Ա
			//Test.x = 1;		// Error, ����ͨ����������ʵ����Ա
			Test.y =2;		// Ok
			Console.WriteLine("x = {0}; y={1}" , t.x , Test.y);
			string a1;
			a1=Console.ReadLine();
		}
	}
}
