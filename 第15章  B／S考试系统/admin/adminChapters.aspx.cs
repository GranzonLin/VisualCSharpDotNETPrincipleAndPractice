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
	/// adminzhangjie ��ժҪ˵����
	/// </summary>
	public class adminzhangjie : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Button BtnSave;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.TextBox TXTzjmc;
		protected System.Web.UI.WebControls.DataGrid Dg_zhangjie;
		protected System.Web.UI.WebControls.TextBox TXTsmxx;
	    protected static string search_kind,search_content;
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
				 lbl_Title.Text="�½ڹ���";
				BtnSave.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
				search_kind = "";
				search_content = "";
				DG_bind();
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
			this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			this.BtnAll.Click += new System.EventHandler(this.BtnAll_Click);
			this.Dg_zhangjie.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.Dg_zhangjie.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.Dg_zhangjie.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void Clear_Input()
		{
			TXTzjmc.Text = "";
			TXTsmxx.Text = "";
			
		}
		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if (e.CommandName == "Edit")
			{
				Dg_zhangjie.EditItemIndex=e.Item.ItemIndex;
				
			}
			if (e.CommandName=="Update")
			{
				TextBox tb1,tb2;
				tb1=(TextBox)e.Item.Cells[0].Controls[0];
				tb2=(TextBox)e.Item.Cells[1].Controls[0];
				if(tb1.Text=="")
				{
					Response.Write("<script>alert('�½����Ʋ���Ϊ��!')</script>");
					return;
				}		
	            string sql = "update �½� set �½�����='" + tb1.Text + "',˵����Ϣ='" + tb2.Text + "' where �½ں�='" + Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				
				Dg_zhangjie.EditItemIndex=-1;  
			}

			if (e.CommandName == "Delete") 
			{
				 OleDbDataReader dr=null;
				int i;
				string table_name="";
				for(i=1;i<=6;i++)
				{
					switch(i)
					{
						case 1:
							table_name="��ѡ��";
							break;
						case 2:
							table_name="��ѡ��";
							break;
						case 3:
							table_name="�����";
							break;
						case 4:
							table_name="�ж���";
							break;
						case 5:
							table_name="�����";
							break;
				
					}
					MyData md=new MyData(Application["connstr"].ToString());
					dr=md.eSelect("select * from "+table_name+" where �½ں�='"+ Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'");		
					if(dr.Read())
					{
						Response.Write("<script>alert('������������и��½��µ���Ŀ,����ɾ������и��½��µ�������Ŀ,������ɾ���½���Ϣ!')</script>");
						dr.Close();
						return;
					}
					else
					{
						dr.Close();
					}
				}
					
				
				if (i==7)
				{
					dr.Close();
					MyData md=new MyData(Application["connstr"].ToString());
					md.eInsertUpdateDelete("delete from �½� where �½ں�='" + Dg_zhangjie.DataKeys[e.Item.ItemIndex] + "'");
				}
			}
			if(e.CommandName=="Cancel")
			{
				Dg_zhangjie.EditItemIndex=-1;  
			}
			DG_bind();
	         
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			LinkButton lbtn;
			if (e.Item.Cells[2].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[2].Controls[0];
				if (lbtn!=null) 
				   if (lbtn.Text=="����")
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");
            
			}
			if (e.Item.Cells[3].Text != "&nbsp;")
			{
				lbtn = (LinkButton)e.Item.Cells[3].Controls[0];
				if (lbtn!=null) 
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫɾ����')");
            
			}
		}

		private void BtnSave_Click(object sender, System.EventArgs e)
		{
			if(TXTzjmc.Text=="")
			{
				Response.Write("<script>alert('�½����Ʋ���Ϊ��!')</script>");
				return;
			}	
			string strid=new MyMethods().DateId();
			string sql = "insert into �½� values ('" + strid + "','" + TXTzjmc.Text + "','" +TXTsmxx.Text + "')";
			MyData md=new MyData(Application["connstr"].ToString());
		    md.eInsertUpdateDelete(sql);	
			Clear_Input();
			DG_bind();
	         
			Response.Write("<script>alert('��ӳɹ�!')</script>");
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Clear_Input();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			search_kind = DdlSearchKind.SelectedValue;
			search_content = TxtSearchContent.Text;
			DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			search_kind = "";
			search_content= "";
			TxtSearchContent.Text = "";
			DG_bind();
		
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			Dg_zhangjie.CurrentPageIndex = e.NewPageIndex;
			DG_bind();
	         
		}
		private void DG_bind()
		{	
			string searchCondition="";
			if ((search_kind != "" && search_content != ""))
				searchCondition=search_kind + " like '%" + search_content + "%'";
				new MyMethods().DG_bind(Dg_zhangjie,"select * from �½�",searchCondition,"",Application["connstr"].ToString());
			
		}
	}
}
