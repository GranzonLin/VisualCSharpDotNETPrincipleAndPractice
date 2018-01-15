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
	/// adminquestionslist ��ժҪ˵����
	/// </summary>
	public class adminquestionslist : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.DropDownList DdlSearchKind;
		protected System.Web.UI.WebControls.DropDownList DdlSelectcondition;
		protected System.Web.UI.WebControls.TextBox TxtSearchContent;
		protected System.Web.UI.WebControls.DropDownList DdlConnect;
		protected System.Web.UI.WebControls.Button BtnAdd;
		protected System.Web.UI.WebControls.Button BtnReset;
		protected System.Web.UI.WebControls.Button BtnSearch;
		protected System.Web.UI.WebControls.Button BtnAll;
		protected System.Web.UI.WebControls.Button btn_Add;
		protected System.Web.UI.WebControls.Label lbl_S_Title;
		protected System.Web.UI.WebControls.ListBox DdlSelected;
		protected System.Web.UI.WebControls.DataGrid DG_xuan;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.DataGrid DG_tian;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.DropDownList DDLtixing;
		protected System.Web.UI.WebControls.DataGrid DG_bian;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.DataGrid DG_pan_jian;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!IsPostBack)
			{   
				MyMethods mm=new MyMethods();
				if(Session["Teacher_ID"]==null)
				{ //��֤��ʦ�Ƿ��¼
					mm.AlertAndRedirect("����δ��¼��", "/test/login.aspx");
					return;
				}
				if (Session["tixing"]==null)//����Ĭ����ʾ������
					Session["tixing"]="��ѡ��";
				if (Session["curr_page"]==null)
					Session["curr_page"]="0";//��¼��ǰDataGrid�ĵ�ǰҳ��ʹ�Ĵ����¼��ҳ���б༭�󷵻ظ�ҳʱ��Ȼ�ܹ��ص���ǰҳ
                if (Session["sort_field"]==null)
				    Session["sort_field"]="���";//����DataGridĬ�������ֶ�
				if (Session["sort_direction"]==null)
					Session["sort_direction"]="ASC";//����DataGridĬ��������
				if (Session["ddlselectedvalue"]==null)
					Session["ddlselectedvalue"]="";//����û�ʹ���˼������ܣ���Session���ڼ�¼�û��ļ����������Ա�����¼��ҳ���б༭�󷵻ظ�ҳʱ��Ȼ�ܹ���ʾ�ղż������
				if (Session["ddlselectedtext"]==null)
					Session["ddlselectedtext"]="";//�������Sessionһ����¼���������ģ�������������ʽ��ʾ��ҳ��ڶ��е�ListBox�ؼ��е�����
				lbl_Title.Text="����б�";
                DDLtixing.SelectedValue=Convert.ToString(Session["tixing"]);
				set_datagrid_visible(Convert.ToString(Session["tixing"]));;//�÷������ø�DataGrid�ɼ����ԣ�ֻ�в���������������ڵ�DataGrid�ſɼ�
				DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(Convert.ToString(Session["tixing"])));//��ȡ��ǰ��������Ӧ��DataGrid��find_DG�������ص�ǰ�������������������Ӧ��DataGrid��ID 
				curr_dg.CurrentPageIndex=Convert.ToInt16(Session["curr_page"]);//����DataGrid�ĵ�ǰҳ������ΪSession["curr_page"]�д洢��ҳ��
				DG_bind();//�����Զ��庯����ִ�ж�DataGrid�İ���ʾ����
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
			this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
			this.DG_xuan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_xuan.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_xuan.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_xuan.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_tian.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_tian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_tian.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_pan_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_pan_jian.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.PageIndexChanged);
			this.DG_pan_jian.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.SortCommand);
			this.DG_pan_jian.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.ItemDataBound);
			this.DG_bian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DG_bian.SelectedIndexChanged += new System.EventHandler(this.DG_bian_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DDLtixing_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			    fill_DdlSearchKind(DDLtixing.SelectedValue);//���ݵ�ǰ���͵Ĳ�ͬ,Ϊ�����ֶ������б����ò�ͬ�Ŀ�ѡ��
			    set_datagrid_visible(DDLtixing.SelectedValue);
			    Session["tixing"]=DDLtixing.SelectedValue;
			    DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(DDLtixing.SelectedValue));
		        curr_dg.CurrentPageIndex=0;
				DG_bind();
		}
		private void fill_DdlSearchKind(string tixing)
		{
			DdlSearchKind.Items.Clear();
			switch(tixing)
			{
				case "��ѡ��":
				case "��ѡ��":
					DdlSearchKind.Items.Add("�½�����");
					DdlSearchKind.Items.Add("���");
					DdlSearchKind.Items.Add("ѡ��A");
					DdlSearchKind.Items.Add("ѡ��B");
					DdlSearchKind.Items.Add("ѡ��C");
					DdlSearchKind.Items.Add("ѡ��D");
					DdlSearchKind.Items.Add("��ȷ��");
				    break;
				case "�����":
					DdlSearchKind.Items.Add("�½�����");
					DdlSearchKind.Items.Add("���");
					DdlSearchKind.Items.Add("�����");
					DdlSearchKind.Items.Add("���1��");
					DdlSearchKind.Items.Add("���2��");
					DdlSearchKind.Items.Add("���3��");
					DdlSearchKind.Items.Add("���4��");
					
					break;
				case "�ж���":
				case "�����":
					DdlSearchKind.Items.Add("�½�����");
					DdlSearchKind.Items.Add("���");
					DdlSearchKind.Items.Add("��ȷ��");
					break;
				case "�����":
					DdlSearchKind.Items.Add("���");
					DdlSearchKind.Items.Add("��ȷ��");
					break;


			}
		}
		private void set_datagrid_visible(string tixing)
		{
			DG_xuan.Visible=false;
			DG_tian.Visible=false;
			DG_pan_jian.Visible=false;
			DG_bian.Visible=false;
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(tixing));
		    curr_dg.Visible=true;
		}
		private string find_DG(string tixing)
		{
			string curr_dg_name="";
			switch(tixing)
			{
				case "��ѡ��":
				case "��ѡ��":
					curr_dg_name="DG_xuan";
					break;
				case "�����":
					curr_dg_name="DG_tian";
					break;
				case "�ж���":
				case "�����":
					curr_dg_name="DG_pan_jian";
					break;
				case "�����":
					curr_dg_name="DG_bian";
					break;
				
			}
			return curr_dg_name;
		}
		private void DG_bind()
		{
			string curr_tixing=Convert.ToString(Session["tixing"]);
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(curr_tixing));
			string  strsql;
			if (curr_tixing=="�����")
			{
					strsql="select * from "+DDLtixing.SelectedValue;
			}
			else
			{
				    strsql="select * from "+DDLtixing.SelectedValue+",�½� where "+DDLtixing.SelectedValue+".�½ں�=�½�.�½ں�";
			}
			 new MyMethods().DG_bind(curr_dg,strsql,Convert.ToString(Session["ddlselectedvalue"]),Convert.ToString(Session["sort_field"])+" "+Convert.ToString(Session["sort_direction"]),Application["connstr"].ToString());
		}

		private void PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;
			curr_dg.CurrentPageIndex=e.NewPageIndex;
			DG_bind();
		}

		private void SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			if(e.SortExpression!=Convert.ToString(Session["sort_field"]))
			{
				Session["sort_field"]=e.SortExpression;
				Session["sort_direction"]="ASC";
			}
			else
			{
				if(Convert.ToString(Session["sort_direction"])=="ASC")
					Session["sort_direction"]="DESC";
				else
					Session["sort_direction"]="ASC";
			}
			DG_bind();
	 
		}

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
		    DataGrid curr_dg=(DataGrid)source;
			if (e.CommandName=="Select")
			{
				Session["curr_page"]=curr_dg.CurrentPageIndex;
				Response.Redirect("adminquestions.aspx?id="+curr_dg.DataKeys[e.Item.ItemIndex]);
			}
			if(e.CommandName=="Delete")
			{
				string sql="delete from "+DDLtixing.SelectedValue+" where id='"+curr_dg.DataKeys[e.Item.ItemIndex]+"'";
				new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
				DG_bind();
			}
		}

		private void btn_Add_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("adminquestions.aspx");
		}

		private void ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
		    LinkButton lbtn;
			int delete_cell_num=0;
			DataGrid curr_dg=(DataGrid)sender;
			switch(curr_dg.ID)
            {
			    case "DG_xuan":
				case "DG_tian":
					delete_cell_num=8;
				    break;
				case "DG_pan_jian":
					delete_cell_num=4;
					break;
				case "DG_bian":
					delete_cell_num=3;
					break;
			}	
            if (e.Item.Cells[delete_cell_num].Text != "&nbsp;")
		    {
				lbtn = (LinkButton)e.Item.Cells[delete_cell_num].Controls[0];
				if (lbtn!=null) //����lbtn��ɾ����ť�����´���Ըð�ť��ӿͻ��˵�OnClick�¼�������ȷ�϶Ի���
					lbtn.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫɾ����')");
            
		    }
		}

		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			if (TxtSearchContent.Text == "") 
			{
				Response.Write("<script>alert('������ؼ��֣�')</script>");
				return;
			}
			if (Convert.ToString(Session["ddlselectedtext"]) != "") 
			{
				string str=Convert.ToString(Session["ddlselectedtext"]);
				
				if((str.IndexOf("����",str.Length-2)==-1)&&(str.IndexOf("����",str.Length-2)==-1))
				{
					  Response.Write("<script>alert('��������������ѡ��������')</script>");
					  return;
				}
			}
			Session["ddlselectedtext"] = Session["ddlselectedtext"] + DdlSearchKind.SelectedItem.Text + DdlSelectcondition.SelectedItem.Text + TxtSearchContent.Text + DdlConnect.SelectedItem.Text;
			string strcontent;
			if (DdlSelectcondition.SelectedItem.Value == "like")
				strcontent = "'%" + TxtSearchContent.Text + "%'";
			else
				strcontent = "'" + TxtSearchContent.Text + "'";
        
			Session["ddlselectedvalue"] = Session["ddlselectedvalue"] + DdlSearchKind.SelectedItem.Value + " " + DdlSelectcondition.SelectedItem.Value + " " + strcontent + " " + DdlConnect.SelectedItem.Value + " ";
			ListItem listitem1=new ListItem();
			listitem1.Text = Convert.ToString(Session["ddlselectedtext"]);
			listitem1.Value = Convert.ToString(Session["ddlselectedvalue"]);
			DdlSelected.Items.Clear();
			DdlSelected.Items.Add(listitem1);
			DdlConnect.SelectedIndex = 0;
		}

		private void BtnReset_Click(object sender, System.EventArgs e)
		{
			Session["ddlselectedtext"] = "";
			Session["ddlselectedvalue"] = "";
		    DdlSelected.Items.Clear();
		}

		private void BtnSearch_Click(object sender, System.EventArgs e)
		{
			string str=Convert.ToString(Session["ddlselectedtext"]);
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
			DataGrid curr_dg=(DataGrid)this.FindControl(find_DG(Convert.ToString(Session["tixing"])));
				
			curr_dg.CurrentPageIndex = 0;
			Session["curr_page"] = "0";
			DG_bind();
		}

		private void BtnAll_Click(object sender, System.EventArgs e)
		{
			Session["ddlselectedtext"] = "";
			Session["ddlselectedvalue"] = "";

			DdlSelected.Items.Clear();
			DG_bind();
		}

		private void DG_bian_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}	
		
	}
}
