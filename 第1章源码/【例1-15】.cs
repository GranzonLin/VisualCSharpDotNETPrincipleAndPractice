//����1-15��ʵ��ί�л��Ƶ�C#���ӡ�
using System;
namespace P1_15
{
    //����1�� ����һ��ί��MyDelegate
    public delegate void MyDelegate(string input);
    //����2������2���������������ʽ�Ͳ���1��������ί�еĲ���������ͬ
    class MyClass1
    {
        public void delegateMethod1(string input)
        {
            Console.WriteLine("This is delegateMethod1 and the input is {0}", input);
        }
        public void delegateMethod2(string input)
        {
            Console.WriteLine("This is delegateMethod2 and the input is {0}", input);
        }
    }
    //����3������һ��ί�ж���d3��������ķ�����������
    class MyClass2
    {
        public MyDelegate createDelegate()
        {
            MyClass1 c2 = new MyClass1();
            MyDelegate d1 = new MyDelegate(c2.delegateMethod1);
            MyDelegate d2 = new MyDelegate(c2.delegateMethod2);
            MyDelegate d3 = d1 + d2;
            return d3;
        }
   //����4��ͨ��ί�ж���d���ð��������еķ���
        public void callDelegate(MyDelegate d, string input)
        {
            d(input);
        }
    }
    class Driver
    {
        static void Main(string[] args)
        {
            MyClass2 c2 = new MyClass2();
            MyDelegate d = c2.createDelegate();
            c2.callDelegate(d, "Calling the delegate");
            Console.ReadLine(); 
        }
    }
}
