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
using System.Configuration;

namespace CityEduWebService
{
	/// <summary>
	/// login ��ժҪ˵����
	/// </summary>
	public class login : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox TextBox_PagePassword;
		protected System.Web.UI.WebControls.TextBox TextBox_PageUser;
	
		protected config conn=new config();

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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{	
			//�û���������ȷ,����Session���������Է�������ҳ��
			//str_Sql="Select * FROM Users WHERE UserName= '"+textBox_User.Text+"' AND PassWord='"+textBox_PassWord.Text+"'";
			string str_Sql="Select * FROM Users WHERE UserName= '"+TextBox_PageUser.Text+"' AND PassWord='"+TextBox_PagePassword.Text+"' AND ReadOnly=0";
			if(conn.GetRowCount(str_Sql)==1)
			{
				Session["PageUser"]=TextBox_PageUser.Text;
				Response.Redirect("index.aspx");
			}
			else
				Response.Redirect("noright.aspx");

		}
	}
}
