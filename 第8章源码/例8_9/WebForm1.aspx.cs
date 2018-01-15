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
using System.Data.OleDb;//add
namespace ��8_10
{
	/// <summary>
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

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
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.CancelCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_CancelCommand);
			this.DataGrid1.EditCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_EditCommand);
			this.DataGrid1.UpdateCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_UpdateCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void LoadGrid( )
		{
			string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
			strConnection+=Server.MapPath("person.mdb");
			OleDbConnection objConnection=new OleDbConnection(strConnection);
			OleDbDataAdapter objDataAdapter=new 
				OleDbDataAdapter("Select * From grade",objConnection);
			DataSet objDataSet=new DataSet();
			objDataAdapter.Fill(objDataSet);
			DataGrid1.DataSource=objDataSet;
			DataGrid1.DataBind();
		}
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack) 
			{
				LoadGrid( );
			}

		}
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			LoadGrid( );
		}

		private void DataGrid1_EditCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = e.Item.ItemIndex;
			LoadGrid( );		
		}

		private void DataGrid1_CancelCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid1.EditItemIndex = -1;
			LoadGrid( );
		}

private void DataGrid1_UpdateCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
{			
	//���°�ť��Ҫ�����ݿ��д
	string xue_hao = ((TextBox)e.Item.Cells[1].Controls[0]).Text;
	string sex = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
	string name = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
	string yuwen = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
	string math = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
	string english = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
	string strConnection="Provider=Microsoft.Jet.OleDb.4.0;Data Source=";
	strConnection+=Server.MapPath("person.mdb");
	OleDbConnection objConnection=new OleDbConnection(strConnection);
	objConnection.Open();			
	String strSQL="UPDATE grade SET ѧ��="+xue_hao
		+ ","+"�Ա� = '" + sex+ "'" 
		+ ","+"���� = '" + name+ "'" 
		+ ","+"���� = '" + yuwen+ "'" 
		+ ","+"��ѧ = '" + math+ "'" 
		+ ","+"Ӣ�� = '" + english+ "'" 
		+" WHERE ѧ�� = " + DataGrid1.DataKeys[(int)e.Item.ItemIndex];			
	OleDbCommand cm=new OleDbCommand(strSQL,objConnection);			
	cm.ExecuteNonQuery();
	objConnection.Close();
	DataGrid1.EditItemIndex =-1; 
	LoadGrid();		
}
	}
}
