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

namespace CityEduWebService
{
	/// <summary>
	/// index ��ժҪ˵����
	/// </summary>
	public class index : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.ImageButton ImageButton_UpClass;
		protected System.Web.UI.WebControls.ImageButton ImageButton_dept;
		protected System.Web.UI.WebControls.ImageButton ImageButton_Coop;
		protected System.Web.UI.WebControls.ImageButton ImageButton_admin;
		protected System.Web.UI.HtmlControls.HtmlTable Table_select;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["PageUser"] == null)Response.Redirect("login.aspx");
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
			this.ImageButton_Coop.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_Coop_Click);
			this.ImageButton_UpClass.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_UpClass_Click);
			this.ImageButton_admin.Click += new System.Web.UI.ImageClickEventHandler(this.ImageButton_admin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ImageButton_admin_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("login.aspx");
		}

		private void ImageButton_UpClass_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("Sql_link.aspx");		
		}

		private void ImageButton_Coop_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			Response.Redirect("DtaBaseModifyToSchool.aspx");		
		}
	}
}
