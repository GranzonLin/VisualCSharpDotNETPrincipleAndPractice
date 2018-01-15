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
	/// adminxibubanji ��ժҪ˵����
	/// </summary>
	public class adminxibubanji : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.TextBox TXTxbmc;
		protected System.Web.UI.WebControls.DataGrid Dg_xb;
		protected System.Web.UI.WebControls.Panel Panel_xb;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.DataGrid Dg_bj;
		protected System.Web.UI.WebControls.Panel Panel_bj;
		protected System.Web.UI.WebControls.Button BtnSaveBj;
		protected System.Web.UI.WebControls.TextBox TXTbjmc;
		protected System.Web.UI.WebControls.Button BtnClose;
		protected System.Web.UI.WebControls.Button BtnSave;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if (!IsPostBack)
			{
				MyMethods mm=new MyMethods();
				if(Session["Teacher_ID"]==null)
				{
					mm.AlertAndRedirect("����δ��¼��", "/test/login.aspx");
					return;
				}
				 lbl_Title.Text="ϵ���༶����";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
				BtnSaveBj.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
				mm.DG_bind(Dg_xb,"select * from ϵ��","","",Application["connstr"].ToString());
	         
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
			this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
			this.Dg_xb.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_xb.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_xb.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.BtnSaveBj.Click += new System.EventHandler(this.BtnSaveBj_Click);
			this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
			this.Dg_bj.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_bj.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_bj.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	
		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if(TXTxbmc.Text=="")
			{
				Response.Write("<script>alert('ϵ�����Ʋ���Ϊ��!')</script>");
				return;
			}
			MyMethods mm=new MyMethods();
			string strid = mm.DateId();
			string sql = "insert into ϵ�� values ('" + strid + "','" + TXTxbmc.Text + "')";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
            TXTxbmc.Text="";
			mm.DG_bind(Dg_xb,"select * from ϵ��","","",Application["connstr"].ToString());
			Response.Write("<script>alert('��ӳɹ�!')</script>");
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		    DataGrid curr_dg=(DataGrid)source;
			MyMethods mm=new MyMethods();
			if (curr_dg.ID=="Dg_xb")
			{
				if (e.CommandName=="Select")
				{
					Panel_bj.Visible =true;
					string strsql="select * from �༶ where ϵ�����='"+Convert.ToString(Dg_xb.DataKeys[e.Item.ItemIndex])+"'";
					mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
				}
				else
				{
					if (e.CommandName=="Edit")
					{
						Dg_xb.EditItemIndex=e.Item.ItemIndex;
						Panel_bj.Visible =false;
					}
					if (e.CommandName=="Update")
					{
						TextBox tb1;
						tb1=(TextBox)e.Item.Cells[0].Controls[0];
						if(tb1.Text=="")
						{
							Response.Write("<script>alert('�½����Ʋ���Ϊ��!')</script>");
							return;
						}
					
						string sql = "update ϵ�� set ϵ������='" + tb1.Text + "' where ϵ�����='" + Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
						Dg_xb.EditItemIndex=-1;
						Panel_bj.Visible =false;
					}

					if (e.CommandName == "Delete") 
					{
				
						string sql="select * from �༶ where ϵ�����='"+Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
						MyData md=new MyData(Application["connstr"].ToString());
						OleDbDataReader dr=md.eSelect(sql);
						if(dr.Read())
						{
							dr.Close();
							md.CloseConn();
							Response.Write("<script>alert('���ڸ�ϵ�����а༶��Ϣ,����ɾ�������������༶��Ϣ,������ɾ��ϵ����Ϣ!')</script>");
						}
						else
						{
							dr.Close();
							md.CloseConn();
							sql = "delete from ϵ�� where ϵ�����='" + Dg_xb.DataKeys[e.Item.ItemIndex] + "'";
							new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
							Panel_bj.Visible =false;
						}
					}
					if(e.CommandName=="Cancel")
					{
						Dg_xb.EditItemIndex=-1;
						Panel_bj.Visible=false;
					}
					mm.DG_bind(Dg_xb,"select * from ϵ��","","",Application["connstr"].ToString());
				}
			}
			else
			{
				if (e.CommandName=="Edit")
				{
					Dg_bj.EditItemIndex=e.Item.ItemIndex;			
				}
				if (e.CommandName=="Update")
				{
					TextBox tb1,tb2;
					tb1=(TextBox)e.Item.Cells[0].Controls[0];
					tb2=(TextBox)e.Item.Cells[1].Controls[0];
					string msg="";
					if(tb1.Text=="")
					{
						msg+="�༶���Ʋ���Ϊ��!";
						return;
					}
					if (tb2.Text!="")
					{
						try   
						{   
							Convert.ToDateTime(tb2.Text);   
						}   
						catch(Exception)   
						{   
						
							msg+="��������������ڲ�����ȷ������������ȷд����:2007-2-9!";  
							return;
						}   

					}
					if(msg!="")
					{
						Response.Write("<script>alert('"+msg+"')</script>");
				        return;
					}
					string sql;
					if(tb2.Text=="")
					{
						sql = "update �༶ set �༶����='" + tb1.Text + "' where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'";
					}
					else
					{
						sql = "update �༶ set �༶����='" + tb1.Text + "',����������=#"+tb2.Text+"# where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'";

					}
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
					Dg_bj.EditItemIndex=-1;
				}

				if (e.CommandName == "Delete") 
				{				
					MyData md=new MyData(Application["connstr"].ToString());
					OleDbDataReader dr=md.eSelect("select * from ѧ�� where �༶���='"+Dg_bj.DataKeys[e.Item.ItemIndex] + "'");
					if(dr.Read())
					{
						dr.Close();
						Response.Write("<script>alert('���ڸð༶����ѧ����Ϣ,����ɾ������������ѧ����Ϣ,������ɾ���༶��Ϣ!')</script>");
					}
					else
					{
						dr.Close();
						md.CloseConn();
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("delete from �༶ where id='" + Dg_bj.DataKeys[e.Item.ItemIndex] + "'");
					}
				}
				if(e.CommandName=="Cancel")
				{
					Dg_bj.EditItemIndex=-1;		
				}
				string strsql="select * from �༶ where ϵ�����='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
				mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
			}

		}

		private void BtnSaveBj_Click(object sender, System.EventArgs e)
		{
			if(TXTbjmc.Text=="")
			{
				Response.Write("<script>alert('�༶���Ʋ���Ϊ��!')</script>");
				return;
			}
			MyMethods mm=new MyMethods();
			string strid = mm.DateId();
			string sql = "insert into �༶(id,�༶����,ϵ�����) values ('" + strid + "','" + TXTbjmc.Text + "','"+Dg_xb.DataKeys[Dg_xb.SelectedIndex]+"')";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
			TXTbjmc.Text="";
			string strsql="select * from �༶ where ϵ�����='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
			mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
			Response.Write("<script>alert('��ӳɹ�!')</script>");
		}

		private void BtnClose_Click(object sender, System.EventArgs e)
		{
			Panel_bj.Visible=false;
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			DataGrid curr_dg=(DataGrid)sender;
			int update_col_num;
			if(curr_dg.ID=="Dg_xb")
				update_col_num=1;
			else
				update_col_num=2;
			if (e.Item.Cells[update_col_num].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[update_col_num].Controls[0];
				if (lbtn!=null) 
					if (lbtn.Text=="����")
						lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
            
			}
			if (e.Item.Cells[update_col_num+1].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[update_col_num+1].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫɾ����')");
            
			}
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			curr_dg.CurrentPageIndex=e.NewPageIndex;
			MyMethods mm=new MyMethods();
			if(curr_dg.ID=="Dg_xb")
			{
				mm.DG_bind(Dg_xb,"select * from ϵ��","","",Application["connstr"].ToString());
			}
			else
			{
				string strsql="select * from �༶ where ϵ�����='"+Convert.ToString(Dg_xb.DataKeys[Dg_xb.SelectedIndex])+"'";
				mm.DG_bind(Dg_bj,strsql,"","",Application["connstr"].ToString());
					
			}
		}
		
	}
}
