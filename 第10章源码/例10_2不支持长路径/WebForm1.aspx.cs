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
using System.Xml;//add 
namespace ��10_2
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//����һ��XmlTextReaderʵ��������ȡXML�ļ�
			XmlTextReader objXMLReader = new XmlTextReader(Server.MapPath("My1.xml"));
			string strNodeResult = "";
			XmlNodeType objNodeType;
			while(objXMLReader.Read())    
			{
				objNodeType = objXMLReader.NodeType;				
				switch(objNodeType)//�жϵ�ǰ��ȡ�ýڵ�����
				{
					case XmlNodeType.XmlDeclaration:
						//��ȡXML�ļ�ͷ
						strNodeResult += "XML Declaration: <b>" 
							+ objXMLReader.Name 
							+ " " + objXMLReader.Value + "</b><br />";
						break;
					case XmlNodeType.Element:
						//��ȡԪ��
						strNodeResult += "Element: <b>" 
							+ objXMLReader.Name + "</b><br />";
						break;
					case XmlNodeType.Text:
						//��ȡ�ڵ��ı�����ֵ
						strNodeResult += "&nbsp; - Value: <b>" 
							+ objXMLReader.Value + "</b><br />";
						break;
				}
				//�жϸýڵ��Ƿ�������
				if(objXMLReader.AttributeCount > 0) 
				{
					//��ѭ���ж������нڵ�
					while(objXMLReader.MoveToNextAttribute())           
					{
						//ȡ���Ժ�ֵ
						strNodeResult +=  "&nbsp; - Attribute: " + objXMLReader.Name 
							+ "&nbsp; Value: " + objXMLReader.Value	+ "<br />";
					}
				}
				Label1.Text = strNodeResult;
			}
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
