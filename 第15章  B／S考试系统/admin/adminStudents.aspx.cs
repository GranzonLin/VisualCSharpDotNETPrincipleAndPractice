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
	/// adminstudent ��ժҪ˵����
	/// </summary>
	public class adminstudent : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
	    protected static string search_kind,search_content,sort_field,sort_direction;
		protected System.Web.UI.WebControls.DataGrid Dg_xuesheng;
		protected System.Web.UI.WebControls.TextBox TXTxh;
		protected System.Web.UI.WebControls.DropDownList DDLxb;
		protected System.Web.UI.WebControls.DropDownList DDLbj;
		protected System.Web.UI.WebControls.TextBox TXTmm;
		protected System.Web.UI.WebControls.TextBox TXTmmqr;
		protected System.Web.UI.WebControls.Button BtnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TXTxm;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!IsPostBack)
			{
				if(Session["Teacher_ID"]==null)
				{
					new MyMethods().AlertAndRedirect("����δ��¼��", "/test/login.aspx");
					return;
				}
				 lbl_Title.Text="ѧ������";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
				search_kind = "";
				search_content = "";
				sort_field="ѧ��";
				sort_direction="ASC";
				fill_xb(DDLxb);
				DG_bind();
			}
			else
			{//����Ǵ˴�Page_Load��ִ��������ҳ��ش������
				string curr_object=Request.Form["__EVENTTARGET"];//��ȡ�����ش���Դ����
				if (curr_object.IndexOf("DDLdgxb")!=-1)
				{//��������ش���Դ�ؼ���ϵ�������б�,���ȡ��ǰѡ���ϵ��,������ϵ�µ����а༶��Ϣ�󶨵��༶�����б���
					 DropDownList ddl=(DropDownList)Dg_xuesheng.Items[Dg_xuesheng.EditItemIndex].Cells[2].FindControl("DDLdgxb");
                     fill_banji((DropDownList)Dg_xuesheng.Items[Dg_xuesheng.EditItemIndex].Cells[3].FindControl("DDLdgbj"),ddl.SelectedValue);
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
			this.TXTxm.TextChanged += new System.EventHandler(this.TXTxm_TextChanged);
			this.Dg_xuesheng.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_xuesheng.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_xuesheng.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.Dg_xuesheng.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			string msg="";
			if(TXTxm.Text=="")		
				msg+="��������Ϊ��!";
			if(TXTxh.Text=="")
				msg+="ѧ�Ų���Ϊ��!";
		    if(DDLbj.SelectedValue=="")
				msg+="�༶����Ϊ��!";
			if(TXTmm.Text=="")
				msg+="���벻��Ϊ��!";
			if (TXTmm.Text!=TXTmmqr.Text)
			{
				msg+="�����������벻һ��!";
			}
			if(msg!="")
			{
				Response.Write("<script>alert('"+msg+"')</script>");
				return;
			}
			string strid =new MyMethods().DateId();
			string sql = "insert into ѧ��(ѧ��,����,�༶���,����) values ('" + TXTxh.Text + "','" +TXTxm.Text + "','"+DDLbj.SelectedValue+"','"+TXTmm.Text+"')";
			if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql)==0)
			{
				Response.Write("<script>alert('�����ѧ�������ݿ���ĳһ��¼�ظ�,������!')</script>");
				return;
			}
			Clear_Input();
			DG_bind();
			Response.Write("<script>alert('��ӳɹ�!')</script>");
		}
		private void Clear_Input()
		{
			TXTxm.Text="";
			TXTxh.Text="";
			TXTmm.Text="";
			TXTmmqr.Text="";
		}
		private void fill_xb(DropDownList ddl)
		{
			DropDownList[] ddlArr={ddl};
			new MyMethods().fill_dropdownlist(ddlArr,Application["connstr"].ToString(),"select * from ϵ��","ϵ������","ϵ�����");
				
		}
		private void fill_banji(DropDownList ddl,string xbbh)
		{	
			string strsql="select * from �༶ where ϵ�����='"+xbbh+"'";	
			DropDownList[] ddlArr={ddl};
			new MyMethods().fill_dropdownlist(ddlArr,Application["connstr"].ToString(),strsql,"�༶����","id");
				
		}
		private void DDLxb_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			fill_banji(DDLbj,Convert.ToString(DDLxb.SelectedValue));
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear_Input();
		}
		private void DG_bind()
		{	
			string searchCondition="";
			if ((search_kind != "" && search_content != ""))
				searchCondition=search_kind + " like '%" + search_content + "%'";
			string strsql= "select ѧ��.���� as ����,ѧ��.ѧ�� as ѧ��,ѧ��.���� as ����,�༶.id as �༶���,�༶.�༶���� as �༶����,ϵ��.ϵ����� as ϵ�����,ϵ��.ϵ������ as ϵ������  from ѧ��,�༶,ϵ�� where ѧ��.�༶���=�༶.id and �༶.ϵ�����=ϵ��.ϵ�����";
			new MyMethods().DG_bind(Dg_xuesheng,strsql,searchCondition,sort_field+" "+sort_direction,Application["connstr"].ToString());
			
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName=="Edit")
			{				
				Dg_xuesheng.EditItemIndex=e.Item.ItemIndex;		   
				DG_bind();
				DropDownList ddl1=(DropDownList)Dg_xuesheng.Items[e.Item.ItemIndex].Cells[2].FindControl("DDLdgxb");	
				fill_xb(ddl1);
				ddl1.SelectedValue=e.Item.Cells[6].Text;//������Ϊ������,������Ϊ��ǰѧ����Ϣ��ϵ�����
				ddl1=(DropDownList)Dg_xuesheng.Items[e.Item.ItemIndex].Cells[3].FindControl("DDLdgbj");
				fill_banji(ddl1,e.Item.Cells[6].Text);
				ddl1.SelectedValue=e.Item.Cells[7].Text;//������Ϊ������,������Ϊ��ǰѧ����Ϣ�İ༶���
			}
			else
			{
				if (e.CommandName=="Update")
				{
					TextBox tb1,tb2;
					tb1=(TextBox)e.Item.Cells[0].Controls[0];
					tb2=(TextBox)e.Item.Cells[1].Controls[0];
					DropDownList ddl1;
					ddl1=(DropDownList)e.Item.Cells[3].FindControl("DDLdgbj");
					string sql = "update ѧ�� set ����='" + tb1.Text + "',ѧ��='" + tb2.Text + "',�༶���='"+ddl1.SelectedValue+"' where ѧ��='" + Dg_xuesheng.DataKeys[e.Item.ItemIndex] + "'";
					if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql)==0)
					{
						Response.Write("<script>alert('�����ѧ�������ݿ���ĳһ��¼�ظ�,������!')</script>");
						return;
					}
					Dg_xuesheng.EditItemIndex=-1;
				
				}

				if (e.CommandName == "Delete") 
				{
					string sql= "delete from ѧ�� where ѧ��='" + Dg_xuesheng.DataKeys[e.Item.ItemIndex] + "'";
				    new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				}
				if(e.CommandName=="Cancel")		
					Dg_xuesheng.EditItemIndex=-1;
				DG_bind();
			}
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			if (e.Item.Cells[4].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[4].Controls[0];
				if (lbtn!=null) 
					if (lbtn.Text=="����")
						lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
            
			}
			if (e.Item.Cells[5].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[5].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫɾ����')");
            
			}
			if (e.Item.ItemType==ListItemType.EditItem)   
			{ //����EditTemplate��ʾ�¸��еĿ��  
						 
						WebControl cur=(WebControl)e.Item.Cells[0].Controls[0];   
						cur.Width=60;
						cur=(WebControl)e.Item.Cells[1].Controls[0];   
						cur.Width=90;
						cur=(WebControl)e.Item.Cells[2].FindControl("DDLdgxb");
						cur.Width=70;
						cur=(WebControl)e.Item.Cells[3].FindControl("DDLdgbj");
						cur.Width=70;				
			}   

		
		}
		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			 Dg_xuesheng.CurrentPageIndex = 0;
			 search_kind=DdlSearchKind.SelectedValue;
			 search_content=TxtSearchContent.Text;
             DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			Dg_xuesheng.CurrentPageIndex = 0;
			search_kind="";
			search_content="";
			DG_bind();
		}

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
		
			if(e.SortExpression==sort_field)
			{
				if (sort_direction=="ASC")
					sort_direction="DESC";
				else
					sort_direction="ASC";
			}
			else
			{
				sort_field=e.SortExpression;
				sort_direction="ASC";

			}
			DG_bind();
	          
		}
		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Dg_xuesheng.CurrentPageIndex=e.NewPageIndex;
			DG_bind();
		}

		private void TXTxm_TextChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}
