using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Xml ;//add
namespace ��10_1
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			XmlDocument xmldoc ;
			XmlNode xmlnode ;
			XmlElement xmlelem, xmlelem2 ;
			XmlText xmltext ;
			xmldoc = new XmlDocument ( ) ;
			//����XML����������
			xmlnode = xmldoc.CreateNode ( XmlNodeType.XmlDeclaration , "" , "" ) ;
			xmldoc.AppendChild ( xmlnode ) ;
			//����һ����Ԫ��book
			xmlelem = xmldoc.CreateElement ( "" , "book" , "" ) ;
			xmltext = xmldoc.CreateTextNode ( "�����ͼ��" ) ;
			xmlelem.AppendChild ( xmltext ) ;
			xmldoc.AppendChild ( xmlelem ) ;
			//��Ԫ��book�¼�������һ��Ԫ��title
			xmlelem2 = xmldoc.CreateElement ("title" ) ;
			xmltext = xmldoc.CreateTextNode ( "XML���ž���" ) ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).AppendChild ( xmlelem2 ) ;
			//��Ԫ��book�¼�������һ��Ԫ��author
			xmlelem2 = xmldoc.CreateElement ("author" ) ;
			xmltext = xmldoc.CreateTextNode ( "�Ż�" ) ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).AppendChild ( xmlelem2 ) ;
			//author�¼�������һ��Ԫ��birthday
			xmlelem2 = xmldoc.CreateElement ("birthday" ) ;		
			xmltext = xmldoc.CreateTextNode ( "1971-3-24 ") ;
			xmlelem2.AppendChild ( xmltext ) ;
			xmldoc.ChildNodes.Item(1).ChildNodes.Item(2). AppendChild ( xmlelem2 ) ;
			//���洴���õ�XML�ļ�
			xmldoc.Save ( Server.MapPath("data.xml" )) ;
			Response.Write("д��ɹ�"); 
		}
		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
