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
using System.IO;
using System.Text;

namespace CityEduWebService
{
	/// <summary>
	/// DtaBaseModifyToSchool ��ժҪ˵����
	/// </summary>
	public class DtaBaseModifyToSchool : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox_MessageUpdateDB;
		protected System.Web.UI.WebControls.Label Label;
	
		private string[] ArraytSql=new String[1111];
		protected System.Web.UI.WebControls.Label lbl_Error;
		protected config conn=new config();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			//δ��¼�������޸�
			if(Session["PageUser"] == null)Response.Redirect("login.aspx");

			if (!Page.IsPostBack)
			{//��ʾ�޸����ݿ�.sql�ļ�����
				StreamReader sr = new StreamReader(Server.MapPath(".")+"\\�޸����ݿ�.sql",Encoding.GetEncoding("gb2312"));
				try
				{
					TextBox_MessageUpdateDB.Text=sr.ReadToEnd();
				}
				catch
				{
					conn.JsIsNull("�޸����ݿ�.sql�ļ��򿪳���",lbl_Error);
				}
				try
				{
					sr.Close();
				}
				catch
				{//�Ի���
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
			//д���޸����ݿ�.sql�ļ�
			WriteToFile();
		}
		
		//д���޸����ݿ�.sql�ļ�
		private void WriteToFile()
		{
			//HttpContext.Current.Request.MapPath(".");
			StreamWriter sw=new StreamWriter(Server.MapPath(".")+"\\�޸����ݿ�.sql",false,Encoding.GetEncoding("gb2312"));
			
			try
			{
				sw.Write(TextBox_MessageUpdateDB.Text);
			}
			catch
			{
				conn.JsIsNull("�޸����ݿ�.sql�ļ�д�����",lbl_Error);//�Ի���
			}
			try
			{
				sw.Close();
			}
			catch
			{
				conn.JsIsNull("�޸����ݿ�.sql�ļ��رճ���",lbl_Error);//�Ի���
			}
			//�Ի���
			Button1.Enabled=false;
		}
	}
}
