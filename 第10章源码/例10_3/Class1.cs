using System;
using System.Xml;  
namespace WriteXML
{
	class Class1
	{
		[STAThread]
		static void Main( string[] args )
		{
			try
			{
				// ����XmlTextWriter���ʵ������
				XmlTextWriter textWriter = new XmlTextWriter("sky.xml", null);
				textWriter.Formatting = Formatting.Indented;
				// ��ʼд���̣�����WriteStartDocument����
				textWriter.WriteStartDocument();  
				// д��˵��
				textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
				textWriter.WriteComment("sky.xml in root dir");   
				//����һ���ڵ�
				textWriter.WriteStartElement("Administrator");
				textWriter.WriteElementString("Name", "formble");
				textWriter.WriteElementString("site", "w3sky.com");
				textWriter.WriteEndElement();
				// д�ĵ�����������WriteEndDocument����
				textWriter.WriteEndDocument();
				// �ر�textWriter
				textWriter.Close();
			}
			catch(System.Exception e)
			{
				Console.WriteLine(e.ToString());
			}               
            Console.ReadKey();
		}
	}
}

