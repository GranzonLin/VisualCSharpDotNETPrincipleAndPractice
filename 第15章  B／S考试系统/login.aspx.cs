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
	/// denglu ��ժҪ˵����
	/// </summary>
	public class denglu : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList DDLdlsf;
		protected System.Web.UI.WebControls.TextBox TXTdlmm;
		protected System.Web.UI.WebControls.Button Btndenglu;
		protected System.Web.UI.WebControls.Button Btnxiugai;
		protected System.Web.UI.WebControls.Panel Panel_dl;
		protected System.Web.UI.WebControls.Button Btnqueren;
		protected System.Web.UI.WebControls.Button Btnfanhui;
		protected System.Web.UI.WebControls.Panel Panel_xgmm;
		protected System.Web.UI.WebControls.DropDownList DDLxgsf;
		protected System.Web.UI.WebControls.TextBox TXTxgdlid;
		protected System.Web.UI.WebControls.TextBox TXTxgjmm;
		protected System.Web.UI.WebControls.TextBox TXTxgxmm;
		protected System.Web.UI.WebControls.TextBox TXTxgxmmqr;
		protected System.Web.UI.WebControls.TextBox TXTdldlid;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			
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
			this.Btndenglu.Click += new System.EventHandler(this.Btndenglu_Click);
			this.Btnxiugai.Click += new System.EventHandler(this.Btnxiugai_Click);
			this.Btnqueren.Click += new System.EventHandler(this.Btnqueren_Click);
			this.Btnfanhui.Click += new System.EventHandler(this.Btnfanhui_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void Btndenglu_Click(object sender, System.EventArgs e)
		{

			if (DDLdlsf.SelectedValue=="ѧ��")
			{
				MyData md=new MyData(Application["connstr"].ToString());
				String StrSQL="select * from ѧ��,�༶ where ѧ��.�༶���=�༶.id and ѧ��='"+TXTdldlid.Text+"'";
				OleDbDataReader DR=md.eSelect(StrSQL);
				if(DR.Read())
				{
					if(Convert.ToString(DR["����"])==TXTdlmm.Text)
					{
						if(DR["����������"].GetType().Name=="DBNull"||Convert.ToDateTime(DR["����������"]).ToShortDateString()!=DateTime.Now.ToShortDateString())						
							Response.Write("<script>alert('���Ŀ������ڲ��ǽ���!')</script>");					
						else
						{	
							if(DR["���Ե�½ʱ��"].GetType().Name=="DBNull"||(System.DateTime)DR["����������"]>=(System.DateTime)DR["���Ե�½ʱ��"])
							{
								StrSQL="update ѧ�� set ���Ե�½ʱ��=#"+DateTime.Now.ToString()+"# where ѧ��='"+TXTdldlid.Text+"'";
								new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);		
								Session["logintime"]=DateTime.Now.ToString();
								Session["Student_ID"]=DR["ѧ��"];
								Session["Student_Name"]=DR["����"];
								Response.Redirect("kaoshi/exam.aspx");
							}
							else
							{
								System.TimeSpan remain_time=DateTime.Now-(DateTime)DR["���Ե�½ʱ��"];
								if(remain_time.TotalSeconds>0&&remain_time.TotalSeconds<7200)					
								{		
									Session["logintime"]=DR["���Ե�½ʱ��"].ToString();
									Session["shijuanhao"]=DR["�����Ծ��"];
									Session["Student_ID"]=DR["ѧ��"];
									Session["Student_Name"]=DR["����"];
									
									Response.Redirect("kaoshi/exam.aspx");
								}	
								else
									Response.Write("<script>alert('���Ŀ���ʱ���ѵ�,�������Ѿ��ύ���Ծ�!')</script>");			
							}
						
						}
						
					}
					else
					{
						Response.Write("<script>alert('���벻��ȷ!')</script>");
					}
					
				}
				else
				{
					Response.Write("<script>alert('û�д˵�½ID!')</script>");
				}
				md.CloseConn();
			}
			else
			{
				String StrSQL="select * from ��ʦ where ��ʦ��='"+TXTdldlid.Text+"'";
			    MyData md=new MyData(Application["connstr"].ToString());
				OleDbDataReader DR=md.eSelect(StrSQL);
				if(DR.Read())
				{
					if(Convert.ToString(DR["����"])==TXTdlmm.Text)
					{
						Session["Teacher_ID"]=DR["��ʦ��"];
						
						Response.Redirect("AdminMain.htm");

					}
					else
					{
						Response.Write("<script>alert('���벻��ȷ!')</script>");
					}
				}
				else
				{
					Response.Write("<script>alert('û�д˵�½ID!')</script>");
				}
				md.CloseConn();
			}
		}

		private void Btnxiugai_Click(object sender, System.EventArgs e)
		{
			Panel_dl.Visible=false;
			Panel_xgmm.Visible=true;

		}

		private void Btnfanhui_Click(object sender, System.EventArgs e)
		{
			Panel_dl.Visible=true;
			Panel_xgmm.Visible=false;
		}

		private void Btnqueren_Click(object sender, System.EventArgs e)
		{
			if(TXTxgxmm.Text!=TXTxgxmmqr.Text)
			{
				Response.Write("<script>alert('�����������벻һ��!')</script>");
			}
			else
			{
				string dengluID;
				if(DDLxgsf.SelectedValue=="ѧ��")
					dengluID="ѧ��";
				else
					dengluID="��ʦ��";
				String StrSQL="update "+DDLxgsf.SelectedValue+" set ����='"+TXTxgxmm.Text+"' where "+dengluID+"='"+TXTxgdlid.Text+"' and ����='"+TXTxgjmm.Text+"'";
				if(new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL)==0)
				{
					Response.Write("<script>alert('��½ID����������!')</script>");
				}
				else
				{
					Response.Write("<script>alert('�������޸ĳɹ�!')</script>");
					Panel_dl.Visible=true;
					Panel_xgmm.Visible=false;
				}

			}
				
		}
	}
}
