//����1-5�����ò��������嵥��
using System;
namespace  P1_5{  
class Test
{
	static void Swap1(int x, int y) //��ֵ����
{
		int temp = x;
		x = y;
		y = temp;
	}
static void Swap2(ref int x, ref int y) //���ò���
{
		int temp = x;
		x = y;
		y = temp;
	}
	static void Main()
   {
		int a= 3, b = 4;
        Swap1(a, b);
		Console.WriteLine("a = {0}, b = {1}", a, b);
        a=13; b =14;
		Swap2(ref a, ref b);
		Console.WriteLine("a = {0}, b = {1}", a, b);
		Console.ReadLine();
	}
}
}
