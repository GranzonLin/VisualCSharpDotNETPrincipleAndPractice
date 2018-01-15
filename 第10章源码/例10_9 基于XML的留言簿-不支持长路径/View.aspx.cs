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

namespace liu_yan_book
{
	/// <summary>
	/// View ��ժҪ˵����
	/// </summary>
	public class View : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.DataGrid Dg1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Repeater Repeater1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//�����������ݵ�XML�ļ���·�� 
			string datafile = "guest.xml" ; 
			//����һ��Try-Catch�������Ϣ��ȡ���� 
			try 
			{ 

				DataSet da1=new DataSet ();
				da1.ReadXml (Server.MapPath (datafile));
				//����һ�����е����ݼ�����Repeater 
				Repeater1.DataSource = da1.Tables[0].DefaultView; 
				Repeater1.DataBind(); 

			} 
			catch (Exception edd) 
			{ 
				//��׽�쳣 
				Label1.Text="���ܴ�XML�ļ��������ݣ�ԭ��"+edd.ToString() ; 
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
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void Button2_Click(object sender, System.EventArgs e)
		{
			//�����������ݵ�XML�ļ���·�� 
			string datafile = "guest.xml" ; 
			DataSet da1=new DataSet ();
			da1.ReadXml (Server.MapPath (datafile));
			Dg1.DataSource=da1.Tables[0].DefaultView;
			Dg1.DataBind() ;
		}
	}
}
