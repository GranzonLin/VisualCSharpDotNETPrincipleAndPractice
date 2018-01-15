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
using System.Data.OleDb;
namespace Test.kaoshi
{
	/// <summary>
	/// chaxun ��ժҪ˵����
	/// </summary>
	public class chaxun : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.DataGrid DG_chengji;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected static string curr_search,curr_SortField,curr_SortDirection;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!IsPostBack)
			{
				 lbl_Title.Text="��ѯ�ɼ�";
				curr_search="";
				curr_SortField="�ɼ�.ѧ��";
				curr_SortDirection="ASC";
				DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
			}
		}
		private void DG_bind(string SearchCondition,string SortExpression)
		{
			string  strsql="SELECT * from ((�ɼ� inner join ѧ�� on �ɼ�.ѧ��=ѧ��.ѧ��) inner join �༶ on ѧ��.�༶���=�༶.id) inner join ϵ�� on �༶.ϵ�����=ϵ��.ϵ�����";
			new MyMethods().DG_bind(DG_chengji,strsql,SearchCondition,SortExpression,Application["connstr"].ToString());
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
			this.DdlSearchKind.SelectedIndexChanged += new System.EventHandler(this.DdlSearchKind_SelectedIndexChanged);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.DG_chengji.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(e.SortExpression!=curr_SortField)
			{
				curr_SortField=e.SortExpression;
				curr_SortDirection="ASC";
			}
			else
			{
				if(curr_SortDirection=="ASC")
					curr_SortDirection="DESC";
				else
					curr_SortDirection="ASC";
			}
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
		    curr_search=DdlSearchKind.SelectedValue+" like '%"+TxtSearchContent.Text+"%'"; 
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			curr_search="";
			DG_bind(curr_search,curr_SortField+" "+curr_SortDirection);
		
		}

		private void DdlSearchKind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		
		}
	}
}
