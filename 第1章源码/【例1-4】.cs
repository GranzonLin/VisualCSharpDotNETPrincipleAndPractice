//����1-4�������һ�����ӣ�˵��ʵ����Ա�;�̬���ݳ�Ա��Ӧ�á�
using System;
namespace  P1_4{  
public class Myclass
{
	private int A, B, C;
	static int Sum;
	public Myclass(int a, int b, int c)
	{
		A = a;
		B = b;
		C = c;
		Sum += A+B+C;
	}
	public Myclass()
	{
	}
	public void GetNumber()
	{
		Console.WriteLine("Number={0}��{1}��{2} " , A ,B,C); 
	}
	public void GetSum()
	{
		Console.WriteLine("Sum={0} " , Sum); 
	}
	public static void Main()
	{
		Myclass M=new Myclass (3, 7, 10);
		Myclass	N=new Myclass(14, 9, 11);
		M.GetNumber();
		N.GetNumber();
		M.GetSum();
		N.GetSum();
		Console.ReadLine();
	}
}
}
