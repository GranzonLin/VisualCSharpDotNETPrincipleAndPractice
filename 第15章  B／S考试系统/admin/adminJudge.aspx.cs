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
namespace Test.admin
{
	/// <summary>
	/// adminpanjuan ��ժҪ˵����
	/// </summary>
	public class adminpanjuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DDLtixing;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.DropDownList DdlSelectcondition;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlConnect;
		protected System.Web.UI.WebControls.Button BtnAdd;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Label lbl_S_Title;
		protected System.Web.UI.WebControls.ListBox DdlSelected;
		protected System.Web.UI.WebControls.DataGrid DG_tian;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.DataGrid DG_jian;
		protected System.Web.UI.WebControls.DataGrid DG_bian;
		protected System.Web.UI.WebControls.Button btn_Complete;
		protected System.Web.UI.WebControls.Panel Panel4;
	    protected static string ddlselectedtext,ddlselectedvalue,curr_SortField,curr_SortDirection;
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!IsPostBack)
			{
			
				if(Session["Teacher_ID"]==null)
				{
					new MyMethods().AlertAndRedirect("����δ��¼��", "/test/login.aspx");
					return;
				}
				lbl_Title.Text="�о����";
				ddlselectedvalue="";
				ddlselectedtext="";
				curr_SortField="���.ѧ��";
				curr_SortDirection="ASC";
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);
				

			}
		}
		
		private void set_datagrid_visible(bool tian_visible,bool pan_jian_visible,bool bian_visible)
		{
			
			DG_tian.Visible=tian_visible;
			DG_jian.Visible=pan_jian_visible;
			DG_bian.Visible=bian_visible;
		}
		private void DG_bind(string tixing,string SearchCondition,string SortExpression)
		{
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(tixing));
			string strsql="SELECT * from (((((��� inner join ѧ�� on ���.ѧ��=ѧ��.ѧ��) inner join �༶ on ѧ��.�༶���=�༶.id) inner join ϵ�� on �༶.ϵ�����=ϵ��.ϵ�����) inner join ��ֵ on ���.�Ծ��=��ֵ.�Ծ��) inner join "+tixing+" on ���.������="+tixing+".id) where ���.����='"+tixing+"'";
		    new MyMethods().DG_bind(curr_dg,strsql,SearchCondition,SortExpression,Application["connstr"].ToString());
		}
		private string find_DG(string tixing)
		{
			string curr_dg_name="";
			switch(tixing)
			{		
				case "�����":
					curr_dg_name="DG_tian";
					break;
				case "�ж���":
				case "�����":
					curr_dg_name="DG_jian";
					break;
				case "�����":
					curr_dg_name="DG_bian";
					break;
				
			}
			return curr_dg_name;
		}

		public bool IsNumberic(string oText)
		{
			try
			{
				int var1=Convert.ToInt32 (oText);
				return true;
			}
			catch
			{
				return false;
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
			this.DDLtixing.SelectedIndexChanged += new System.EventHandler(this.DDLtixing_SelectedIndexChanged);
			this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.btn_Complete.Click += new System.EventHandler(this.btn_Complete_Click);
			this.DG_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_tian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_bian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			if (e.CommandName=="Edit")
			{						
				curr_dg.EditItemIndex=e.Item.ItemIndex;		   
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);					
			}
			if (e.CommandName=="Update")
			{
				TextBox tb1;
				int col_defen=0;
				switch (curr_dg.ID)
				{
					case "DG_tian":
						col_defen=12;
						break;
					case "DG_jian":
						col_defen=8;
						break;
					case "DG_bian":
						col_defen=8;
						break;
				}
				tb1=(TextBox)e.Item.Cells[col_defen].Controls[0];
				if(!IsNumberic(tb1.Text))
				{
					Response.Write("<script>alert('������Ĳ�������,������Ϊ�����洢��')</script>");
					return;
				}
				
				if(Convert.ToInt16(tb1.Text)>Convert.ToInt16(e.Item.Cells[col_defen-1].Text))
				{
					Response.Write("<script>alert('������������Ѿ������˸���ķ�ֵ,���������룡')</script>");
					return;
				}		
				string sql = "update ��� set �÷�=" + tb1.Text + " where dati_id=" + curr_dg.DataKeys[e.Item.ItemIndex] + "";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				curr_dg.EditItemIndex=-1;
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);
			
				
			}
			if(e.CommandName=="Cancel")
			{
				curr_dg.EditItemIndex=-1;   
				DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);			
			}

		}

		private void DDLtixing_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(DDLtixing.SelectedItem.Text.ToString())
			{			
				case "�����":
					set_datagrid_visible(true,false,false);
					break;
				case "�����":
					set_datagrid_visible(false,true,false);
					break;
				case "�����":
					set_datagrid_visible(false,false,true);
					break;
			}
			Session["tixing"]=DDLtixing.SelectedValue;
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);		
		}
		private void btn_Complete_Click(object sender, System.EventArgs e)
		{
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("delete from �ɼ�");
			string strsql="insert into �ɼ� select ѧ��,�Ծ��,sum(�÷�) as �÷� from ��� group by ѧ��,�Ծ��";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strsql);
		
		}

		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			if (TxtSearchContent.Text == "") 
			{
				Response.Write("<script>alert('������ؼ��֣�')</script>");
				return;
			}
			if (ddlselectedtext != "") 
			{
				string str=ddlselectedtext;				
				if((str.IndexOf("����",str.Length-2)==-1)&&(str.IndexOf("����",str.Length-2)==-1))
				{
					Response.Write("<script>alert('��������������ѡ��������')</script>");
					return;
				}
			}
			ddlselectedtext = ddlselectedtext + DdlSearchKind.SelectedItem.Text + DdlSelectcondition.SelectedItem.Text + TxtSearchContent.Text + DdlConnect.SelectedItem.Text;
			string strcontent;
			if (DdlSelectcondition.SelectedItem.Value == "like")
				strcontent = "'%" + TxtSearchContent.Text + "%'";
			else
				strcontent = "'" + TxtSearchContent.Text + "'";      
			ddlselectedvalue = ddlselectedvalue + DdlSearchKind.SelectedItem.Value + " " + DdlSelectcondition.SelectedItem.Value + " " + strcontent + " " + DdlConnect.SelectedItem.Value + " ";
			ListItem listitem1=new ListItem();
			listitem1.Text = ddlselectedtext;
			listitem1.Value =ddlselectedvalue;
			DdlSelected.Items.Clear();
			DdlSelected.Items.Add(listitem1);
			DdlConnect.SelectedIndex = 0;
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			ddlselectedtext = "";
			ddlselectedvalue = "";
			DdlSelected.Items.Clear();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			string str=ddlselectedtext;
			if ( str== "")
			{
				Response.Write("<script>alert('������������')</script>");
				return;
			}
			if ((str.Substring(str.Length-2)=="����") ||(str.Substring(str.Length-2)=="����"))
			{
				Response.Write("<script>alert('��������������������')</script>");
				return;
			}
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(DDLtixing.SelectedValue));			
			curr_dg.CurrentPageIndex = 0;
			Session["curr_page"] = "0";
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);		
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			ddlselectedtext = "";
			ddlselectedvalue = "";
			DdlSelected.Items.Clear();
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);				
		}

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
			DG_bind(DDLtixing.SelectedValue,ddlselectedvalue,curr_SortField+" "+curr_SortDirection);			
		}
	}
}
