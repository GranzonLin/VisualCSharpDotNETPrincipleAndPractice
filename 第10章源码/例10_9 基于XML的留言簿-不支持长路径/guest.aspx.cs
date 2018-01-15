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
using System.IO;//add
using System.Xml;//add
namespace liu_yan_book
{
	/// <summary>
	/// guestpost ��ժҪ˵����
	/// </summary>
	public class guestpost : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label errmess;
		protected System.Web.UI.WebControls.TextBox Name;
		protected System.Web.UI.WebControls.TextBox Email;
		protected System.Web.UI.WebControls.TextBox Comments;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//�������ݵ�XML�ļ���·�� 
			string dataFile = "guest.xml" ; 
			//����һ��Try-Catch�������Ϣ��ӹ��� 
			try
			{ 
				//����ҳ������Ч��ʱ��Ŵ����� 
				if(Page.IsValid)
				{ 
					errmess.Text="" ; 
					//�Զ���ģʽ��һ��FileStream���������ݿ� 
					FileStream fin; 
					fin= new FileStream(Server.MapPath(dataFile),FileMode.Open, 
						FileAccess.Read,FileShare.ReadWrite); 
					//����һ�����ݿ���� 
					DataSet guestData = new DataSet(); 
					//�������ݿ��ȡXML Schema 
					guestData.ReadXml(fin); 
					fin.Close(); 
					//�����ݼ���Schema�½�һ�������� 
					DataRow newRow = guestData.Tables[0].NewRow(); 
					//����Ӧֵ��д������ 
					newRow["Name"]=Name.Text; 
					newRow["Email"]=Email.Text; 
					newRow["Comments"]=Comments.Text; 
					newRow["DateTime"]=DateTime.Now.ToString(); 
					//��д��ϣ�����������ӵ����ݼ� 
					guestData.Tables[0].Rows.Add(newRow); 
					//Ϊ���ݿ��ļ��½���һ��дģʽ��FileStream���������ļ� 
					FileStream fout ; 
					fout = new FileStream(Server.MapPath(dataFile),FileMode.Create , 
						FileAccess.Write,FileShare.ReadWrite); 
					guestData.WriteXml(fout); 
					fout.Close(); 
					//���ص�ǰ����� 
					//formPanel.Visible=false; 
					//��ʾ���и�л��Ϣ����� 
					//thankPanel.Visible=true; 
					

				} 
			} 
			catch (Exception edd) 
			{ 
				//��׽�쳣 
				errmess.Text="д��XML�ļ�����ԭ��"+edd.ToString() ; 
			} 	
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			//�ж��ļ��Ƿ���� 
			if(!File.Exists(Server.MapPath("guest.xml"))) 
			{ 
				Response.Write("guest.xml�����ļ���������"); 
				Response.End() ; 
			} 
			XmlDocument xmlDoc = new XmlDocument ( ) ;
			xmlDoc.Load(Server.MapPath("guest.xml"));
			//��<NewDataSet>�ڵ��в���һ��<news>�ڵ㣺			
			XmlNode root=xmlDoc.SelectSingleNode("NewDataSet");//����<NewDataSet>
			XmlElement xe1=xmlDoc.CreateElement("news");//����һ��<news>�ڵ�
			XmlElement xesub1=xmlDoc.CreateElement("name");
			xesub1.InnerText=Name.Text;//�����ı��ڵ�
			xe1.AppendChild(xesub1);//��ӵ�<book>�ڵ���

			XmlElement xesub2=xmlDoc.CreateElement("Email");
			xesub2.InnerText=Email.Text;
			xe1.AppendChild(xesub2);

			XmlElement xesub3=xmlDoc.CreateElement("Comments");
			xesub3.InnerText=Comments.Text;
			xe1.AppendChild(xesub3);

			XmlElement xesub4=xmlDoc.CreateElement("DateTime");
			xesub4.InnerText=DateTime.Now.ToString();
			xe1.AppendChild(xesub4);
			root.AppendChild(xe1);//��ӵ�<NewDataSet>�ڵ���
			xmlDoc.Save(Server.MapPath("guest.xml"));
			errmess.Text="���Գɹ�д��"; 
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
		   Response.Redirect("view.aspx"); 
		}

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
		   Response.Redirect("index.aspx"); 
		}
	}
}
