//����1-3��������������嵥��
using System;
namespace P1_3
{
    public class employee
    {
        private int No;
        private string name;
        private char sex;
        private string address;
        public employee(int n, string na, char s, string addr)
        {
            No = n; name = na;
            sex = s; address = addr;
        }
        public void disp_employee()
        {
            Console.WriteLine("ְ���ţ�{0} ְ��������{1}", No, name);
            Console.WriteLine("�Ա�{0} סַ��{1}", sex, address);
        }
        public static void Main() { Console.ReadLine(); }
    }
}
