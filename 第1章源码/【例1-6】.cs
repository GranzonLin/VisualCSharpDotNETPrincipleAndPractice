//����1-6���������ʹ����ͬ�Ĵ洢λ�ó����嵥��
using System;
namespace  P1_6
{  
	public class same_ref
	{
		public string s;
		public void F(ref string a, ref string b) 
		{
			
			a = "Two";
			b = "Three";
		}
		static void Main () 
		{
			same_ref c=new same_ref();
			c.F(ref c.s, ref c.s);
			Console.WriteLine("s = {0}", c.s);
			Console.ReadLine();
		}
	}
}
