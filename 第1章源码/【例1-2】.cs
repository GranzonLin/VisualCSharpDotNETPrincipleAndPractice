//����1-2���쳣�������
using System;
namespace ConsoleApplication2
{
    class Test
    {
        static void F()
        {
            try
            {
                G();
            }
            catch (Exception err)
            {
                Console.WriteLine("����F�в���: " + err.Message);
                throw;  //�����׳���ǰ������ catch �鴦����쳣err
            }
        }
        static void G()
        {
            throw new Exception("����G���׳����쳣��");
        }
        static void Main()
        {
            try
            {
                F();
            }
            catch (Exception err)
            {
                Console.WriteLine("����Main�в���:" + err.Message);
            }
            Console.ReadLine();
        }
    }
}
