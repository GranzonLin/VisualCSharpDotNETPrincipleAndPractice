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
	/// MessageToSchool ��ժҪ˵����
	/// </summary>
	public class MessageToSchool : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		protected config conn=new config();
	
		public bool IsOK(object ID)
		{
			if(!Convert.IsDBNull(ID))
			{
				if(ID.ToString() == "True")
					return true;
			}
			return false;
		}

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(Session["PageUser"] == null)Response.Redirect("login.aspx");

			conn.BindDataGrid("SELECT * FROM MessageToSchool",DataGrid1);
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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string str_Sql="UPDATE MessageToSchool SET MessageValid=0";
			conn.ExeSql(str_Sql);

			str_Sql="INSERT INTO MessageToSchool (MessageText,MessageValid) Values("+conn.KickOut(TextBox1.Text)+",1)";
			conn.ExeSql(str_Sql);
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{			
			DataGrid1.CurrentPageIndex=e.NewPageIndex;
			DataGrid1.DataBind();
		}
	}
}
