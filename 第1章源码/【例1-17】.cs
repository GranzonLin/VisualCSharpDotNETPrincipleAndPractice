//����1-17���ӿ�ʾ����
using System;
namespace P1_17{
    interface IMyExample1 
    { 
        int add(int x,int y);
    }
    interface IMyExample2
    {
        string Point { get; set; }
    }
    class mytest : IMyExample1, IMyExample2
    {
        private string mystr;
        public mytest(string s)
        { mystr = s; }
        //ʵ�ֽӿ�IMyExample1��add(int x,int y)����
        public int add(int x,int y)
        {
            return x+y;
        }
        //ʵ�ֽӿ�IMyExample2��Point ����
        public string Point 
        {
            get{return mystr;}
            set{mystr=value;}
        }
    }
    class TestClass
    {
        static void Main(string[] args)
        {
            mytest a = new mytest("hello");
            Console.WriteLine(a.add(23, 4));
            Console.WriteLine(a.Point);
            Console.ReadLine();
        }
    }   
}
