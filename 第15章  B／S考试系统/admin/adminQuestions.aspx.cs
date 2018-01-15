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
	/// adminquestions ��ժҪ˵����
	/// </summary>
	public class adminquestions : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DropDownList DDLTx;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.TextBox TXTdanxzd;
		protected System.Web.UI.WebControls.TextBox TXTdanxzc;
		protected System.Web.UI.WebControls.TextBox TXTdanxzb;
		protected System.Web.UI.WebControls.TextBox TXTdantg;
		protected System.Web.UI.WebControls.TextBox TXTdanxza;
		protected System.Web.UI.WebControls.RadioButtonList RBLdanzqda;
		protected System.Web.UI.WebControls.TextBox TXTduoxzd;
		protected System.Web.UI.WebControls.TextBox TXTduoxzc;
		protected System.Web.UI.WebControls.TextBox TXTduoxzb;
		protected System.Web.UI.WebControls.TextBox TXTduoxza;
		protected System.Web.UI.WebControls.TextBox TXTduotg;
		protected System.Web.UI.WebControls.Panel Panel_duo;
		protected System.Web.UI.WebControls.CheckBoxList CBLduozqda;
		protected System.Web.UI.WebControls.DropDownList DDLdansszj;
		protected System.Web.UI.WebControls.DropDownList DDLduosszj;
		protected System.Web.UI.WebControls.TextBox TXTtiantg;
		protected System.Web.UI.WebControls.Panel Panel_tian;
		protected System.Web.UI.WebControls.DropDownList DDLtiantks;
		protected System.Web.UI.WebControls.DropDownList DDLtiansszj;
		protected System.Web.UI.WebControls.Panel Panel_pan;
		protected System.Web.UI.WebControls.Panel Panel_jian;
		protected System.Web.UI.WebControls.Panel Panel_bian;
		protected System.Web.UI.WebControls.Button BTNsave;
		protected System.Web.UI.WebControls.Button BTNreturn;
		protected System.Web.UI.WebControls.Button BTNreset;
		protected System.Web.UI.WebControls.TextBox TXTtiankong1;
		protected System.Web.UI.WebControls.TextBox TXTtiankong2;
		protected System.Web.UI.WebControls.TextBox TXTtiankong3;
		protected System.Web.UI.WebControls.TextBox TXTtiankong4;
		protected System.Web.UI.HtmlControls.HtmlTable table_tian;
		protected System.Web.UI.WebControls.TextBox TXTpantg;
		protected System.Web.UI.WebControls.DropDownList DDLpanzqda;
		protected System.Web.UI.WebControls.DropDownList DDLpansszj;
		protected System.Web.UI.WebControls.TextBox TXTjiantg;
		protected System.Web.UI.WebControls.TextBox TXTjianzqda;
		protected System.Web.UI.WebControls.DropDownList DDLjiansszj;
		protected System.Web.UI.WebControls.TextBox TXTbiantg;
		protected System.Web.UI.WebControls.TextBox TXTbianzqda;
		protected System.Web.UI.WebControls.Panel panel_add;
	
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
				 lbl_Title.Text="������";
				 DropDownList[] ddl={DDLdansszj,DDLduosszj,DDLtiansszj,DDLpansszj,DDLjiansszj};
				 new MyMethods().fill_dropdownlist(ddl,Application["connstr"].ToString(),"select * from �½�","�½�����","�½ں�");//�����е�������ʾ�½ڵ������б���а�
				 BTNsave.Attributes.Add("OnClick", "JavaScript:return confirm('����Ҫ������')");//Ϊ���水ť���ӽű�����
				 set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));//�����û�ѡ������������������ʾ��Ӧ��������������մ𰸵��ı���
				if (Request["id"]!=null)//���ҳ�������Ϊ�գ���֤����ҳ�Ǵ�����б��е������ɾ����ť�����ģ�����ʾ���������ϸ��Ϣ
				{
					DDLTx.SelectedValue=Convert.ToString(Session["tixing"]);
					DDLTx.Enabled=false;
					set_panel_visible(Convert.ToString(Session["tixing"])); //���ݲ�ͬ������ʾ��ͬ��¼����棨���漯����Panel�У�
					string sql="select * from "+Convert.ToString(Session["tixing"])+" where id='"+Request["id"]+"'";
					MyData md=new MyData(Application["connstr"].ToString());
					OleDbDataReader dr=md.eSelect(sql);
					if(dr.Read())
					{
						switch(Convert.ToString(Session["tixing"]))
						{
							case "��ѡ��":
								DDLdansszj.SelectedValue=Convert.ToString(dr["�½ں�"]);
						        TXTdantg.Text=Convert.ToString(dr["���"]);
								TXTdanxza.Text=Convert.ToString(dr["ѡ��A"]);
								TXTdanxzb.Text=Convert.ToString(dr["ѡ��B"]);
							    TXTdanxzc.Text=Convert.ToString(dr["ѡ��C"]);
								TXTdanxzd.Text=Convert.ToString(dr["ѡ��D"]);
								RBLdanzqda.SelectedValue=Convert.ToString(dr["��ȷ��"]);
								break;
							case "��ѡ��":
								DDLduosszj.SelectedValue=Convert.ToString(dr["�½ں�"]);
								TXTduotg.Text=Convert.ToString(dr["���"]);
								TXTduoxza.Text=Convert.ToString(dr["ѡ��A"]);
								TXTduoxzb.Text=Convert.ToString(dr["ѡ��B"]);
								TXTduoxzc.Text=Convert.ToString(dr["ѡ��C"]);
								TXTduoxzd.Text=Convert.ToString(dr["ѡ��D"]);
								string zqda=Convert.ToString(dr["��ȷ��"]);
								
								   for(int i=0;i<4;i++)//�����ݿ��и��������ȷ�𰸷�ӳ�ڸ�CheckBox��
								 	 if(zqda.IndexOf(CBLduozqda.Items[i].Value)!=-1)
										 CBLduozqda.Items[i].Selected=true;
							         else
										 CBLduozqda.Items[i].Selected=false;
								
								break;
							case "�����":
								DDLtiansszj.SelectedValue=Convert.ToString(dr["�½ں�"]);
								TXTtiantg.Text=Convert.ToString(dr["���"]);
								DDLtiantks.SelectedValue=Convert.ToString(dr["�����"]);
								set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));
								TXTtiankong1.Text=Convert.ToString(dr["���1��"]);
								TXTtiankong2.Text=Convert.ToString(dr["���2��"]);
								TXTtiankong3.Text=Convert.ToString(dr["���3��"]);
								TXTtiankong4.Text=Convert.ToString(dr["���4��"]);	
								break;
							case "�ж���":
								DDLpansszj.SelectedValue=Convert.ToString(dr["�½ں�"]);
								TXTpantg.Text=Convert.ToString(dr["���"]);
								DDLpanzqda.SelectedValue=Convert.ToString(dr["��ȷ��"]);
								break;
							case "�����":
								DDLjiansszj.SelectedValue=Convert.ToString(dr["�½ں�"]);
								TXTjiantg.Text=Convert.ToString(dr["���"]);
								TXTjianzqda.Text=Convert.ToString(dr["��ȷ��"]);
								break;
							case "�����":
							
								TXTbiantg.Text=Convert.ToString(dr["���"]);
								TXTbianzqda.Text=Convert.ToString(dr["��ȷ��"]);
								break;
						
						}
					}
					md.CloseConn();
				 
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
			this.DDLTx.SelectedIndexChanged += new System.EventHandler(this.DDLTx_SelectedIndexChanged);
			this.DDLtiantks.SelectedIndexChanged += new System.EventHandler(this.DDLtiantks_SelectedIndexChanged);
			this.BTNsave.Click += new System.EventHandler(this.BTNsave_Click);
			this.BTNreturn.Click += new System.EventHandler(this.BTNreturn_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		private void DDLTx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			set_panel_visible(DDLTx.SelectedValue);
			
		}
		private void set_panel_visible(string tixing)
		{
			Panel_dan.Visible=false;
			Panel_duo.Visible=false;
			Panel_tian.Visible=false;
			Panel_pan.Visible=false;
			Panel_jian.Visible=false;
			Panel_bian.Visible=false;
			Panel curr_panel=(Panel)this.FindControl(find_panel(tixing));
			curr_panel.Visible=true;

		}
		private string find_panel(string tixing)
		{
			string curr_panel_name="";
			switch(tixing)
			{
				case "��ѡ��":
					curr_panel_name="Panel_dan";
					break;
				case "��ѡ��":
					curr_panel_name="Panel_duo";
					break;
				case "�����":
					curr_panel_name="Panel_tian";
					break;
				case "�ж���":
					curr_panel_name="Panel_pan";
					break;
				case "�����":
					curr_panel_name="Panel_jian";
					break;
				case "�����":
					curr_panel_name="Panel_bian";
					break;
				
			}
			return curr_panel_name;
		}
		private void set_tiankong_visible(int tiankong_num)
		{
			for(int i=0;i<tiankong_num;i++)
			{
				table_tian.Rows[i].Visible=true;
			}
			for(int i=tiankong_num;i<4;i++)
		    {
                table_tian.Rows[i].Visible=false;
			 }

		}
		
		private void BTNsave_Click(object sender, System.EventArgs e)
		{
			string sql="",strid=new MyMethods().DateId();
			if (Request["id"]==null)
			{//���ҳ�����idΪ�գ���ִ����Ӳ���,����ִ�и��²���
				switch(DDLTx.SelectedItem.Text.ToString())
				{
					case "��ѡ��":							
						sql="insert into ��ѡ�� (id,�½ں�,���,ѡ��A,ѡ��B,ѡ��C,ѡ��D,��ȷ��)values('"+strid+"','"+DDLdansszj.SelectedValue.ToString()+"','"+TXTdantg.Text+"','"+TXTdanxza.Text+"','"+TXTdanxzb.Text+"','"+TXTdanxzc.Text+"','"+TXTdanxzd.Text+"','"+RBLdanzqda.SelectedValue+"')";		
						break;
					case "��ѡ��":
						string str_da="";
						for(int i=0;i<4;i++)//���û����ĸ�CheckBox�ϱ�����Ķ�ѡ�����ɴ��ַ���.
						{
							if (CBLduozqda.Items[i].Selected)
								str_da+=CBLduozqda.Items[i].Value;
						}
						sql="insert into ��ѡ�� (id,�½ں�,���,ѡ��A,ѡ��B,ѡ��C,ѡ��D,��ȷ��)values('"+strid+"','"+DDLduosszj.SelectedValue.ToString()+"','"+TXTduotg.Text+"','"+TXTduoxza.Text+"','"+TXTduoxzb.Text+"','"+TXTduoxzc.Text+"','"+TXTduoxzd.Text+"','"+str_da+"')";		
						break;
					case "�����":
						sql="insert into ����� (id,�½ں�,���,�����,���1��,���2��,���3��,���4��)values('"+strid+"','"+DDLtiansszj.SelectedValue.ToString()+"','"+TXTtiantg.Text+"','"+DDLtiantks.SelectedValue+"','"+TXTtiankong1.Text+"','"+TXTtiankong2.Text+"','"+TXTtiankong3.Text+"','"+TXTtiankong4.Text+"')";		
						break;
					case "�ж���":
						sql="insert into �ж��� (id,�½ں�,���,��ȷ��)values('"+strid+"','"+DDLpansszj.SelectedValue.ToString()+"','"+TXTpantg.Text+"','"+DDLpanzqda.SelectedValue+"')";
						break;
					case "�����":
						sql="insert into ����� (id,�½ں�,���,��ȷ��)values('"+strid+"','"+DDLjiansszj.SelectedValue.ToString()+"','"+TXTjiantg.Text+"','"+TXTjianzqda.Text+"')";
						break;
					case "�����":
						sql="insert into ����� (id,���,��ȷ��)values('"+strid+"','"+TXTbiantg.Text+"','"+TXTbianzqda.Text+"')";
						break;			
				}
			}
			else
			{
				switch(DDLTx.SelectedItem.Text.ToString())
				{
					case "��ѡ��":							
						sql="update ��ѡ�� set �½ں�='"+DDLdansszj.SelectedValue.ToString()+"',���='"+TXTdantg.Text+"',ѡ��A='"+TXTdanxza.Text+"',ѡ��B='"+TXTdanxzb.Text+"',ѡ��C='"+TXTdanxzc.Text+"',ѡ��D='"+TXTdanxzd.Text+"',��ȷ��='"+RBLdanzqda.SelectedValue+"' where id='"+Request["id"]+"'";		
						break;
					case "��ѡ��":
						string str_da="";
						for(int i=0;i<4;i++)
						{
							if (CBLduozqda.Items[i].Selected)
								str_da+=CBLduozqda.Items[i].Value;
						}
						sql="update ��ѡ�� set �½ں�='"+DDLduosszj.SelectedValue.ToString()+"',���='"+TXTduotg.Text+"',ѡ��A='"+TXTduoxza.Text+"',ѡ��B='"+TXTduoxzb.Text+"',ѡ��C='"+TXTduoxzc.Text+"',ѡ��D='"+TXTduoxzd.Text+"',��ȷ��='"+str_da+"' where id='"+Request["id"]+"'";		
						break;
					case "�����":
						sql="update ����� set �½ں�='"+DDLtiansszj.SelectedValue.ToString()+"',���='"+TXTtiantg.Text+"',�����='"+DDLtiantks.SelectedValue+"',���1��='"+TXTtiankong1.Text+"',���2��='"+TXTtiankong2.Text+"',���3��='"+TXTtiankong3.Text+"',���4��='"+TXTtiankong4.Text+"' where id='"+Request["id"]+"'";
						break;
					case "�ж���":
						sql="update �ж��� set �½ں�='"+DDLpansszj.SelectedValue.ToString()+"',���='"+TXTpantg.Text+"',��ȷ��='"+DDLpanzqda.SelectedValue+"' where id='"+Request["id"]+"'";
						break;
					case "�����":
						sql="update ����� set �½ں�='"+DDLjiansszj.SelectedValue.ToString()+"',���='"+TXTjiantg.Text+"',��ȷ��='"+TXTjianzqda.Text+"' where id='"+Request["id"]+"'";
						break;
					case "�����":
						sql="update ����� set ���='"+TXTbiantg.Text+"',��ȷ��='"+TXTbianzqda.Text+"' where id='"+Request["id"]+"'";
						break;			
				}
			}
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(sql);
			Response.Write("<script>alert('����ɹ�!')</script>");
			
		}

		private void DDLtiantks_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			set_tiankong_visible(Convert.ToInt16(DDLtiantks.SelectedValue));
		}

		private void BTNreturn_Click(object sender, System.EventArgs e)
		{
		    Response.Redirect("adminquestionslist.aspx");
		}
	}
}
