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
using System.Xml;


namespace CityEduWebService
{
	/// <summary>
	/// Sql_link ��ժҪ˵����
	/// </summary>
	public class Sql_link : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox2;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox3;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox TextBox4;
		protected System.Web.UI.WebControls.TextBox textBox_Database;
		protected System.Web.UI.WebControls.TextBox textBox_DBServer;
		protected System.Web.UI.WebControls.TextBox textBox_DbUser;
		protected System.Web.UI.WebControls.TextBox textBox_DbPassWord;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label lbl_Error;
	
		protected config conn=new config();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			if(Session["PageUser"] == null)Response.Redirect("login.aspx");

			if (!Page.IsPostBack)
			{
				try
				{//��ʾWeb.config�ļ�����
					string path="Web.config";
					XmlDocument xd=new XmlDocument();
					xd.Load(Server.MapPath(".")+"\\"+path);
					foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
					{
						if(xn1.Attributes["key"].Value=="Database")
						{
							textBox_Database.Text=xn1.Attributes["value"].Value;
							//break;
						}
						if(xn1.Attributes["key"].Value=="DatabaseServer")
						{
							textBox_DBServer.Text=xn1.Attributes["value"].Value;
							//break;
						}
						if(xn1.Attributes["key"].Value=="DatabaseUser")
						{
							textBox_DbUser.Text=xn1.Attributes["value"].Value;
							//break;
						}
						if(xn1.Attributes["key"].Value=="DatabasePassword")
						{
							textBox_DbPassWord.Text=xn1.Attributes["value"].Value;
							break;
						}
					}
				}
				catch
				{
					//return false;
					throw new Exception("error");
				}
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{			
			try
			{
				string path=Server.MapPath(".")+"\\"+"Web.config";
				XmlDocument xd=new XmlDocument();
				xd.Load(path);
				//�ж�Web.config�нڵ��Ƿ���ڣ�����������޸ĵ�ǰ�ڵ�
				foreach(XmlNode xn1 in xd.SelectNodes("/configuration/appSettings/add"))
				{
					if(xn1.Attributes["key"].Value=="DatabaseServer")
					{
						xn1.Attributes["value"].Value=textBox_DBServer.Text;
						//break;
					}
					if(xn1.Attributes["key"].Value=="Database")
					{
						xn1.Attributes["value"].Value=textBox_Database.Text;
						//break;
					}
					if(xn1.Attributes["key"].Value=="DatabaseUser")
					{
						xn1.Attributes["value"].Value=textBox_DbUser.Text;
						//break;
					}
					
					if(xn1.Attributes["key"].Value=="DatabasePassword")
					{
						xn1.Attributes["value"].Value=textBox_DbPassWord.Text;
						break;
					}
				}
				//����web.config
				xd.Save(path);
				//return true;
			}
			catch
			{
				//return false;
				throw new Exception("error");
			}
			lbl_Error.Text="<script language=\"javascript\">alert('"+"�ɹ��޸ģ�"+"');</"+"script>"; 
			Button1.Enabled=false;
		}
	}
}
