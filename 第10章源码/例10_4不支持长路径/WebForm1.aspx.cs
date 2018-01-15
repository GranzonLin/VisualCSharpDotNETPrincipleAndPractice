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
using System.Xml ;
namespace ��10_4
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			Label1.Text=""; //��ձ�ǩ 
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load(Server.MapPath("data.xml")); 
			XmlNode root=xmlDoc.SelectSingleNode("Employees");//����<Employees> 
			XmlElement xe1=xmlDoc.CreateElement("Book");//����һ��<Book>�ڵ� 
			XmlElement xesub1=xmlDoc.CreateElement("title"); 
			xesub1.InnerText="C#���Ű���";//�����ı��ڵ� 
			xe1.AppendChild(xesub1);//��ӵ�<Book>�ڵ��� 
			XmlElement xesub2=xmlDoc.CreateElement("author"); 
			xesub2.InnerText="����"; 
			xe1.AppendChild(xesub2); 
			XmlElement xesub3=xmlDoc.CreateElement("price"); 
			xesub3.InnerText="158.3"; 
			xe1.AppendChild(xesub3); 
			root.AppendChild(xe1);//��ӵ�<Employees>�ڵ��� 
			xmlDoc.Save ( Server.MapPath("data.xml") ); 
			Label1.Text="��ӳɹ�";
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load( Server.MapPath("data.xml") ); 
			//��ȡEmployees�ڵ������<Book >�ӽڵ�
			XmlNodeList nodeList=xmlDoc.SelectSingleNode("Employees").ChildNodes; 
			foreach(XmlNode xn in nodeList)//���������ӽڵ� 
			{ 
				XmlElement xe=(XmlElement)xn;//���ӽڵ�����ת��ΪXmlElement���� 
				XmlNodeList nls=xe.ChildNodes;//������ȡxe�ӽڵ�������ӽڵ� 
				foreach(XmlNode xn1 in nls)//���� 
				{ 
					XmlElement xe2=(XmlElement)xn1;//ת������ 
					if(xe2.Name=="author" && xe2.InnerText=="����")//����ҵ� 
					{ 
						xe2.InnerText="����";//���޸� 
						Label1.Text="�޸ĳɹ�";
					} 
				} 
			}
			xmlDoc.Save( Server.MapPath("data.xml") );//����		
		}
		private void Button3_Click(object sender, System.EventArgs e)
		{
			XmlDocument xmlDoc=new XmlDocument(); 
			xmlDoc.Load( Server.MapPath("data.xml") ); 
			XmlNode root=xmlDoc.SelectSingleNode("Employees"); 
			XmlNodeList xnl=xmlDoc.SelectSingleNode("Employees").ChildNodes; 
			for(int i=0;i<xnl.Count;i++) 
			{ 
				XmlElement xe=(XmlElement)xnl.Item(i);
				XmlElement xe1=(XmlElement)xe.ChildNodes[0]; 
				if(xe1.Name=="title" && xe1.InnerText =="C#���Ű���")//����ҵ� 
				{ 
					root.RemoveChild(xe); 
					if(i<xnl.Count)i=i-1;
					Label1.Text="ɾ���ɹ�";
				} 
			} 
			xmlDoc.Save( Server.MapPath("data.xml") ); 
		}
	}
}
