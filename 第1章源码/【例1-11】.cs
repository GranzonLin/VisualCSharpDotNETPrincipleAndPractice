//����1-11��ͨ�����Է���������������ԡ�
using System;
namespace  P1_11
{
	public class Button 
	{ 
		private string caption; 
		public string Caption 
		{   
			get 
			{              // get������
				return caption; 
			} 
			set 
			{              // set������
				caption = value; 
			}
		}
		public static void Main() 
		//��������Ķ��壬�Ϳ��Զ�Button���ж�ȡ����������Caption����
		{
			Button b = new Button(); 
			b.Caption = "china";       // ����Caption
			string s = b.Caption;       // ��ȡCaption
			b.Caption += "people";   // ��ȡ������
			Console.ReadLine();
		} 
	}
}
