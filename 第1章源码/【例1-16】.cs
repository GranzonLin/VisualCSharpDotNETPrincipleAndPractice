//����1-16��ʹ��C#�¼�����ʵ�ֲ�����ǰʱ������ӡ�
using System;
namespace P1_16{
public class EventClass
{
//��������һ��ί������CustomEventHandler
    public delegate void CustomEventHandler(object sender, EventArgs e);
    //��ί�����������¼�CustomEvent
    public event CustomEventHandler CustomEvent;
    public void InvokeEvent() 
    {
        if (CustomEvent != null) //�ж��¼����¼��������Ƿ���ϵ����
        CustomEvent(this, EventArgs.Empty);//�����¼�
    }
}
class TestClass
{
//�����¼�������
private static void CustomEvent1(object sender, EventArgs e)
{
    Console.WriteLine("Fire Event1 is{0}",DateTime.Now);
}
private static void CustomEvent2(object sender, EventArgs e)
{
    Console.WriteLine("Fire Event2 is{0}",DateTime.Now);
}
static void Main(string[] args)
{
EventClass my = new EventClass();
// ���¼�CustomEvent���¼�������CustomEvent1��ϵ����
my.CustomEvent += new EventClass.CustomEventHandler(CustomEvent1);
my.InvokeEvent();//�����¼�
// ���¼�CustomEvent���¼�������CustomEvent2��ϵȡ��
my.CustomEvent -= new EventClass.CustomEventHandler(CustomEvent1);
my.InvokeEvent();//�����¼����������κν��
my.CustomEvent += new EventClass.CustomEventHandler(CustomEvent2);
my.InvokeEvent();//�����¼�
Console.ReadLine();
}
}
}
