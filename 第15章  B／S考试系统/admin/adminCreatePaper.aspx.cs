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
	/// adminzujuan ��ժҪ˵����
	/// </summary>
	public class adminzujuan : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lbl_Title;
		protected System.Web.UI.WebControls.Panel panel_add;
		protected System.Web.UI.WebControls.TextBox TXTdantl;
		protected System.Web.UI.WebControls.TextBox TXTdanfz;
		protected System.Web.UI.WebControls.TextBox TXTduotl;
		protected System.Web.UI.WebControls.TextBox TXTduofz;
		protected System.Web.UI.WebControls.TextBox TXTtiankl;
		protected System.Web.UI.WebControls.TextBox TXTtianfz;
		protected System.Web.UI.WebControls.TextBox TXTpantl;
		protected System.Web.UI.WebControls.TextBox TXTpanfz;
		protected System.Web.UI.WebControls.TextBox TXTjiantl;
		protected System.Web.UI.WebControls.TextBox TXTjianfz;
		protected System.Web.UI.WebControls.TextBox TXTbiantl;
		protected System.Web.UI.WebControls.TextBox TXTbianfz;
		protected System.Web.UI.WebControls.TextBox TXTzjs;
		protected System.Web.UI.WebControls.DropDownList DDLdancqfs;
		protected System.Web.UI.WebControls.DropDownList DDLjianzj;
		protected System.Web.UI.WebControls.TextBox TXTjianzjtl;
		protected System.Web.UI.WebControls.Button BtnAddJian;
		protected System.Web.UI.WebControls.DataGrid Dg_jian;
		protected System.Web.UI.WebControls.DataGrid Dg_dan;
		protected System.Web.UI.WebControls.Button BtnAddDan;
		protected System.Web.UI.WebControls.TextBox TXTdanzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLdanzj;
		protected System.Web.UI.WebControls.DropDownList DDLduocqfs;
		protected System.Web.UI.WebControls.Button BtnAddDuo;
		protected System.Web.UI.WebControls.TextBox TXTduozjtl;
		protected System.Web.UI.WebControls.DropDownList DDLduozj;
		protected System.Web.UI.WebControls.DropDownList DDLtiancqfs;
		protected System.Web.UI.WebControls.DataGrid Dg_tian;
		protected System.Web.UI.WebControls.Button BtnAddTian;
		protected System.Web.UI.WebControls.TextBox TXTtianzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLtianzj;
		protected System.Web.UI.WebControls.DropDownList DDLpancqfs;
		protected System.Web.UI.WebControls.DataGrid Dg_pan;
		protected System.Web.UI.WebControls.Button BtnAddPan;
		protected System.Web.UI.WebControls.TextBox TXTpanzjtl;
		protected System.Web.UI.WebControls.DropDownList DDLpanzj;
		protected System.Web.UI.WebControls.Panel Panel_txtl;
		protected System.Web.UI.WebControls.Panel Panel_cqfs;
		protected System.Web.UI.WebControls.Button BtnCreate;
		protected System.Web.UI.WebControls.Panel Panel_dan;
		protected System.Web.UI.WebControls.Panel Panel_duo;
		protected System.Web.UI.WebControls.Panel Panel_tian;
		protected System.Web.UI.WebControls.Panel Panel_pan;
		protected System.Web.UI.WebControls.Button BtnPre;
		protected System.Web.UI.WebControls.DataGrid Dg_duo;
		protected System.Web.UI.WebControls.DropDownList DDLjiancqfs;
		protected System.Web.UI.WebControls.Label lbl_dan;
		protected System.Web.UI.WebControls.Label lbl_duo;
		protected System.Web.UI.WebControls.Label lbl_tian;
		protected System.Web.UI.WebControls.Label lbl_pan;
		protected System.Web.UI.WebControls.Label lbl_jian;
		protected System.Web.UI.WebControls.Label lbl_dan_yx;
		protected System.Web.UI.WebControls.Label lbl_duo_yx;
		protected System.Web.UI.WebControls.Label lbl_tian_yx;
		protected System.Web.UI.WebControls.Label lbl_pan_yx;
		protected System.Web.UI.WebControls.Label lbl_jian_yx;
		protected System.Web.UI.WebControls.Panel Panel_jian;
		protected System.Web.UI.WebControls.TextBox TXTsjsyrq;
		protected System.Web.UI.WebControls.Button BtnNext;
		
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
				 lbl_Title.Text="������";
				DropDownList[] ddl={DDLdanzj,DDLduozj,DDLtianzj,DDLpanzj,DDLjianzj};
				new MyMethods().fill_dropdownlist(ddl,Application["connstr"].ToString(),"select * from �½�","�½�����","�½ں�");
				ViewState["dtDan"]=CreateDataTable();
				ViewState["dtDuo"]=CreateDataTable();
				ViewState["dtPan"]=CreateDataTable();
				ViewState["dtTian"]=CreateDataTable();
				ViewState["dtJian"]=CreateDataTable();
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
			this.BtnNext.Click += new System.EventHandler(this.BtnNext_Click);
			this.DDLdancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddDan.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_dan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLduocqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddDuo.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_duo.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLtiancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddTian.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_tian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLpancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddPan.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_pan.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.DDLjiancqfs.SelectedIndexChanged += new System.EventHandler(this.DDL_SelectedIndexChanged);
			this.BtnAddJian.Click += new System.EventHandler(this.BtnAdd_Click);
			this.Dg_jian.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.ItemCommand);
			this.BtnCreate.Click += new System.EventHandler(this.BtnCreate_Click);
			this.BtnPre.Click += new System.EventHandler(this.BtnPre_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		private void BtnNext_Click(object sender, System.EventArgs e)
		{
			if (TXTzjs.Text=="")
			{
				Response.Write("<script>alert('������������,���������������!')</script>");
				return;

			}
			if((String_to_Num(TXTdantl.Text)*String_to_Num(TXTdanfz.Text)+String_to_Num(TXTduotl.Text)*String_to_Num(TXTduofz.Text)+String_to_Num(TXTtiankl.Text)*String_to_Num(TXTtianfz.Text)+String_to_Num(TXTpantl.Text)*String_to_Num(TXTpanfz.Text)+String_to_Num(TXTjiantl.Text)*String_to_Num(TXTjianfz.Text)+String_to_Num(TXTbiantl.Text)*String_to_Num(TXTbianfz.Text))!=100)
			{
				Response.Write("<script>alert('������������,�ֱܷ������100��,����������!')</script>");
				return;
			}
			else
			{
				Panel_txtl.Visible=false;
				Panel_cqfs.Visible =true;
				lbl_dan.Text=String_to_Num(TXTdantl.Text).ToString();
				lbl_dan_yx.Text="0";
				lbl_duo.Text=String_to_Num(TXTduotl.Text).ToString() ;
				lbl_duo_yx.Text="0";
				lbl_pan.Text=String_to_Num(TXTpantl.Text).ToString();
				lbl_pan_yx.Text="0";
				lbl_tian.Text=String_to_Num(TXTtiankl.Text).ToString();
				lbl_tian_yx.Text="0";
				lbl_jian.Text=String_to_Num(TXTjiantl.Text).ToString();
				lbl_jian_yx.Text="0";

			}

		}
		private int String_to_Num(string strtxt)
		{
			if (strtxt=="")
			{
				return 0;
			}
			else
			{
				return Convert.ToInt16(strtxt);
			}
		}
		private void DDL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			DropDownList curr_ddl=(DropDownList)sender; //��ȡ��ǰ�������¼��������б�
			string curr_panel_id="Panel_"+curr_ddl.ID.Substring(3,curr_ddl.ID.Length-7);//���ڸ����������б��IDΪ��DDL������cqfs�����������͵İ��½ڱ��س�ȡʱ�����ý����IDΪ��Panel_�����������ʲ��ô˷������Panel��
			if(curr_ddl.SelectedValue=="��ȫ���")
			{
				
				((Panel)FindControl(curr_panel_id)).Enabled =false;
			}
			else
			{
				((Panel)FindControl(curr_panel_id)).Enabled  =true;
			}
		
		}

		private void DataGrid_Bind(DataGrid dg,DataTable dt)
		{
			dg.Visible =true;
			dg.DataSource=dt.DefaultView;
			dg.DataBind();

		}
		private DataTable CreateDataTable()
		{
			DataTable dt=new DataTable();
		    
			DataColumn dc=new DataColumn();
		    dc.ColumnName="�½�����";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="����";
			dc.DataType=System.Type.GetType("System.String");
			dt.Columns.Add(dc);
			dc=new DataColumn();
			dc.ColumnName="�½ڱ��";

			dc.DataType=System.Type.GetType("System.String");
			
			dt.Columns.Add(dc);
			DataColumn[] dcs={dc};
		    dt.PrimaryKey=dcs;
			return dt;
		}
		private void BtnAdd_Click(object sender, System.EventArgs e)
		{
			Button curr_button=(Button)sender;
			string commonstr=curr_button.ID.Substring(6);
			Label curr_lbl_yx=(Label)FindControl("lbl_"+commonstr.ToLower()+"_yx");//��ȡ��ʶ��ǰ������ѡ������Label
			Label curr_lbl=(Label)FindControl("lbl_"+commonstr.ToLower());//��ȡ��ʶ��ǰ������������Label
			TextBox curr_txt_zjtl=(TextBox)FindControl("TXT"+commonstr.ToLower()+"zjtl");//��ȡ�������õ�ǰ���͵�ĳ�½�������TextBox
			DropDownList curr_ddl_zj=(DropDownList)FindControl("DDL"+commonstr+"zj");//��ȡ��ǰ���͵��½������б��
			DataGrid curr_dg=(DataGrid)FindControl("Dg_"+commonstr.ToLower());//��ȡ��ǰ���Ͱ��½ڱ������ý����е�DataGrid
			if ((String_to_Num(curr_lbl_yx.Text)+String_to_Num(curr_txt_zjtl.Text))<=String_to_Num(curr_lbl.Text)) 
			{
				try
				{
					
					DataTable dt=(DataTable)ViewState["dt"+commonstr];
					DataRow dr=dt.NewRow();
					dr["�½�����"]=curr_ddl_zj.SelectedItem.Text;
					dr["����"]=curr_txt_zjtl.Text;
					dr["�½ڱ��"]=curr_ddl_zj.SelectedValue;
					dt.Rows.Add(dr);
					DataGrid_Bind(curr_dg,dt);
					curr_lbl_yx.Text=(String_to_Num(curr_lbl_yx.Text)+String_to_Num(curr_txt_zjtl.Text)).ToString();
				}
				catch(ConstraintException ex)
				{
					Response.Write("<script>alert('"+ex.Message+"')</script>");
				}
			}
			else
			{
				string tixing="";
				switch(commonstr)
				{
					case "Dan":tixing="��ѡ";break;
					case "Duo":tixing="��ѡ";break;
					case "Tian":tixing="���";break;
					case "Pan":tixing="�ж�";break;
					case "Jian":tixing="���";break;
				}
                Response.Write("<script>alert('������������,"+tixing+"�������������"+lbl_dan.Text+"��,����������!')</script>");
			}
		}
		

		private void ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataGrid curr_dg=(DataGrid)source;	
			DataTable dt=(DataTable)ViewState["dt"+curr_dg.ID.Substring(3,1).ToUpper()+curr_dg.ID.Substring(4)];//���DataGrid��ID�е����Ĵ������������ַ�������ĸΪСд,���Ӧ��DataTable��ID�д������������ַ�������ĸΪ��д,���Դ˾�ʵ������ĸ��д��ת��
			Label curr_lbl_yx=(Label)FindControl("lbl_"+curr_dg.ID.Substring(3)+"_yx");
			Label curr_lbl=(Label)FindControl("lbl_"+curr_dg.ID.Substring(3));
			
			if (e.CommandName=="Delete")
			{//���ɾ����ť��ִ�еĴ���
				
				DataRow dr=dt.Rows.Find(e.Item.Cells[4].Text);
				curr_lbl_yx.Text=Convert.ToString(Convert.ToInt16(curr_lbl_yx.Text)-Convert.ToInt16(e.Item.Cells[1].Text));
				dt.Rows.Remove(dr);
				DataGrid_Bind(curr_dg,dt);
				  
			}
			if (e.CommandName=="Edit")
			{//����༭��ť��ִ�еĴ���
				ViewState["curr_edit_row_key"]=e.Item.Cells[4].Text;
				ViewState["curr_edit_row_tl"]=e.Item.Cells[1].Text;
				curr_dg.EditItemIndex=e.Item.ItemIndex;
				DataGrid_Bind(curr_dg,dt);
			    
			}
			if (e.CommandName=="Update")
			{//������°�ť(���°�ť�ڵ�༭��ť����ʾ)��ִ�еĴ���
				DataRow dr=dt.Rows.Find(ViewState["curr_edit_row_key"].ToString());
				TextBox tb2=(TextBox)e.Item.Cells[1].Controls[0];
				int curr_total_num=Convert.ToInt16(curr_lbl_yx.Text)-Convert.ToInt16(dr["����"])+Convert.ToInt16(tb2.Text);//�����޸ĺ󽫵õ��������õ�������
				if(curr_total_num>Convert.ToInt16(curr_lbl.Text))
				{
					Response.Write("<script>alert('������������,�˴�����ʹ����ѡ���������˸����ͳ�ȡ������,����������!')</script>");
					return;

				}
				else
				{
					curr_lbl_yx.Text=curr_total_num.ToString();
			   
					dr["����"]=tb2.Text;
				
					curr_dg.EditItemIndex=-1;
			    
					DataGrid_Bind(curr_dg,dt);
				}
			}
			if (e.CommandName=="Cancel")
			{//���ȡ����ť(ȡ����ť�ڵ�༭��ť����ʾ)��ִ�еĴ���	
				curr_dg.EditItemIndex=-1;
				DataGrid_Bind(curr_dg,dt);
			}
		}
		private void GetObjects( ref string tixing,ref DataGrid curr_dg,ref DropDownList curr_ddl,ref TextBox txt_tiliang,int j)
		{
			switch(j)
			{
				case 0:
					tixing="��ѡ��";
					curr_dg=Dg_dan;
					curr_ddl=DDLdancqfs;
					txt_tiliang=TXTdantl;
					break;
				case 1:
					tixing="��ѡ��";
					curr_dg=Dg_duo;
					curr_ddl=DDLduocqfs;
					txt_tiliang=TXTduotl;
					break;
				case 2:
					tixing="�����";
					curr_dg=Dg_tian;
					curr_ddl=DDLtiancqfs;
					txt_tiliang=TXTtiankl;
					break;
				case 3:
					tixing="�ж���";
					curr_dg=Dg_pan;
					curr_ddl=DDLpancqfs;
					txt_tiliang=TXTpantl;
					break;
				case 4:
					tixing="�����";
					curr_dg=Dg_jian;
					curr_ddl=DDLjiancqfs;
					txt_tiliang=TXTjiantl;
					break;
				case 5:
					tixing="�����";
					txt_tiliang=TXTbiantl;
					break;
			}
		}

		private void BtnCreate_Click(object sender, System.EventArgs e)
		{
			if((lbl_dan.Text!="0"&&(DDLdancqfs.SelectedValue)=="�����½ڱ���"&&lbl_dan.Text!=lbl_dan_yx.Text)||(lbl_duo.Text!="0"&&(DDLduocqfs.SelectedValue)=="�����½ڱ���"&&lbl_duo.Text!=lbl_duo_yx.Text)||(lbl_tian.Text!="0"&&(DDLtiancqfs.SelectedValue)=="�����½ڱ���"&&lbl_tian.Text!=lbl_tian_yx.Text)||(lbl_pan.Text!="0"&&(DDLpancqfs.SelectedValue)=="�����½ڱ���"&&lbl_pan.Text!=lbl_pan_yx.Text)||(lbl_jian.Text!="0"&&(DDLjiancqfs.SelectedValue)=="�����½ڱ���"&&lbl_jian.Text!=lbl_jian_yx.Text))
			{
				Response.Write("<script>alert('������������,�����ѡ���˿����½ڱ��صĳ�ȡ��ʽ,����Ϊ����Ӹ��½ڵ�����,��������������ڸ�����Ԥ�����õ�������������ѡ����ȫ�����ʽ,ϵͳ���Զ�������������,����������!')</script>");
				return;

			}
            else
			{
				for(int j=0;j<=5;j++)
				{//ÿ��ѭ���ж�һ�����������õĸ��������Ƿ񳬳������Ϳ������
					string tixing=null;//�洢��ǰ����,��������switch���õ�
					TextBox txt_tiliang=null;//�洢������õ�һ�����������뵱ǰ���͵�������TextBox
					DataGrid curr_dg=null;//�洢��ǰ���͵İ��½ڱ��س�ȡ��ʽ�����ý����е�DataGrid
					DropDownList curr_ddl=null;//�洢��ǰ���͵ĳ�ȡ��ʽ�����б�
					GetObjects(ref tixing,ref curr_dg,ref curr_ddl,ref txt_tiliang,j);
					if(curr_ddl!=null)
					{//�����ǰΪ�Ǳ����
						if(curr_ddl.SelectedValue=="��ȫ���")
						{ //��ȫ�����������ж����õĵ�ǰ�����������Ƿ񳬶�
							if(get_zongtishu(tixing,"")< String_to_Num(txt_tiliang.Text))
							{
								Response.Write("<script>alert('������������,"+tixing+"����е�����ֻ��"+get_zongtishu(tixing,"")+"��,�����Գ�ȡ,����������!')</script>");
								return;
							}
						}
						else
						{//���½ڱ��س�ȡ�������Ҫ�ж������õ�ÿһ���½ڵ������Ƿ񳬶�
							for(int i=0;i<curr_dg.Items.Count;i++)
							{
								if (get_zongtishu(tixing,curr_dg.Items[i].Cells[4].Text)<Convert.ToInt16(curr_dg.Items[i].Cells[1].Text))
								{
									Response.Write("<script>alert('������������,"+tixing+"����е�"+curr_dg.Items[i].Cells[0].Text+"һ���е�����ֻ��"+get_zongtishu(tixing,curr_dg.Items[i].Cells[4].Text)+"��,�����Գ���,����������!')</script>");
									return;
								}
							}
						}
					}
					else
					{//�����ǰΪ�����
						if(get_zongtishu(tixing,"")< String_to_Num(txt_tiliang.Text))
						{
							Response.Write("<script>alert('������������,"+tixing+"����е�����ֻ��"+get_zongtishu(tixing,"")+"��,�����Գ�ȡ,����������!')</script>");
							return;
						}
					}

				}
				

				string[] shijuanhaos=new string[Convert.ToInt16(TXTzjs.Text)];
				for(int i=0;i<Convert.ToInt16(TXTzjs.Text);i++)
				{
					shijuanhaos[i]=new MyMethods().DateId();
					String StrSQL="insert into ��ֵ values('"+shijuanhaos[i]+"','"+String_to_Num(TXTdantl.Text)+"','"+String_to_Num(TXTduotl.Text)+"','"+String_to_Num(TXTtiankl.Text)+"','"+String_to_Num(TXTpantl.Text)+"','"+String_to_Num(TXTjiantl.Text)+"','"+String_to_Num(TXTbiantl.Text)+"'";
					StrSQL+=",'"+String_to_Num(TXTdanfz.Text)+"','"+String_to_Num(TXTduofz.Text)+"','"+String_to_Num(TXTtianfz.Text)+"','"+String_to_Num(TXTpanfz.Text)+"','"+String_to_Num(TXTjianfz.Text)+"','"+String_to_Num(TXTbianfz.Text)+"','"+TXTsjsyrq.Text+"')";
					MyData md=new MyData(Application["connstr"].ToString());
					md.eInsertUpdateDelete(StrSQL);
					for(int k=0;k<=4;k++)
					{
						string tixing=null;//�洢��ǰ����,��������switch���õ�
						TextBox txt_tiliang=null;//�洢������õ�һ�����������뵱ǰ���͵�������TextBox
						DataGrid curr_dg=null;//�洢��ǰ���͵İ��½ڱ��س�ȡ��ʽ�����ý����е�DataGrid
						DropDownList curr_ddl=null;//�洢��ǰ���͵ĳ�ȡ��ʽ�����б�
						GetObjects(ref tixing,ref curr_dg,ref curr_ddl,ref txt_tiliang,k);
						if (curr_ddl.SelectedValue=="��ȫ���")
						{
							chouqu(tixing,Convert.ToInt16(txt_tiliang.Text),"",shijuanhaos[i],0);
					
						}
						else
						{
							int shunxuhao_begin=0;
							for(int j=0;j<curr_dg.Items.Count;j++)
							{
						

								chouqu(tixing,Convert.ToInt16(curr_dg.Items[j].Cells[1].Text),curr_dg.Items[j].Cells[4].Text,shijuanhaos[i],shunxuhao_begin);
								shunxuhao_begin+=Convert.ToInt16(curr_dg.Items[j].Cells[1].Text);
							}
						}
					}
					chouqu("�����",String_to_Num(TXTbiantl.Text),"",shijuanhaos[i],0);

				}
			}
			
		}
		private int get_zongtishu(string tixing,string zhangjiehao)
		{
			String StrSQL;
			if (tixing!="�����")
			{
				if (zhangjiehao=="")
				{
					StrSQL="select count(*) as ���� from "+tixing ;//ͳ��ָ�����Ϳ���ȫ������	
				}
				else
				{
					StrSQL="select count(*) as ���� from "+tixing+" where �½ں�='"+zhangjiehao+"'" ;	//ͳ���������Ϳ���ָ���½ڵ�ȫ������
				}
			}
			else
			{
				if (zhangjiehao=="")
				{
					StrSQL="select count(�����) as ���� from "+tixing ;	//ͳ��������������ܿ���
				}
				else
				{
					StrSQL="select count(�����) as ���� from "+tixing+" where �½ں�='"+zhangjiehao+"'" ;	//ͳ����տ�������ָ���µĵ��ܿ���
				}
			}
			MyData md=new MyData(Application["connstr"].ToString());	
			OleDbDataReader DR=md.eSelect(StrSQL);
			DR.Read(); 
			int ti_total=Convert.ToInt16(DR["����"]);//������
			DR.Close();
			md.CloseConn();
			return ti_total;
		}
		private void chouqu(string tixing,int tishu,string zhangjiehao,string shijuanhao,int shunxuhao_begin)
		{
		
			MyData md;
			String StrSQL;
			int ti_total=get_zongtishu(tixing,zhangjiehao);
			ArrayList tihaos=new ArrayList();//�ݴ�˴��ѳ�������������
			string curr_tihao;
			int i=1,curr_shunxu=1;
				while(i<=tishu)//iΪ��ǰ��ȡ�������������������⣬��Ϊ������������ȡ�����⣨�գ�����û�ﵽҪ��ȡ��������ʱ������ȡ
				{
			
					Random r = new Random(unchecked((int)DateTime.Now.Ticks));
					int curr_ti_num=(int)((ti_total)*r.NextDouble()+1);//������������������������е�λ�� 
					if (zhangjiehao=="")//��������ȫ����ĳ�ȡ��ʽ
					{
						StrSQL="select * from "+tixing+" order by id";
					}
					else
					{//����ǰ��½ڱ��صĳ�ȡ��ʽ
						StrSQL="select * from "+tixing+" where �½ں�='"+zhangjiehao+"' order by id";
					}
					md=new MyData(Application["connstr"].ToString());
					OleDbDataReader DR=md.eSelect(StrSQL);
					for(int j=1;j<=curr_ti_num;j++)
					{//�ҳ����������������
						DR.Read();
					}
					curr_tihao=Convert.ToString(DR["id"]);//��¼�����
					int tiankongshu=0;
					if(tixing=="�����")
					{//������γ�ȡ��������⣬���жϵ�ǰ���п������ϴ˴�����������������Ƿ񳬳�����ȡ�����������س�
						tiankongshu=Convert.ToInt16(DR["�����"]);
						if ((i<=tishu)&&((i+tiankongshu)>tishu+1))
						{
							DR.Close();
							continue;
						}
					}
					if (tihaos.Contains(curr_tihao))
					{//�жϴ˴����������������ʱ���Ѿ����˵���chouqu����ʱ�����������ѱ���������³�ȡ
						DR.Close();
					}
					else
					{//��������ڱ��ε���chouqu����ʱ��δ���������ȷ����ȡ���⣬���������ݿ�
						tihaos.Add(curr_tihao);
						
						DR.Close();
					
						StrSQL="insert into ���(�Ծ��,˳���,����,������) values('"+shijuanhao+"','"+(curr_shunxu+shunxuhao_begin)+"','"+tixing+"','"+curr_tihao+"')";
						new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);
						curr_shunxu++;
						if(tixing=="�����")
						{
							i+=tiankongshu;
						}
						else
						{
							i++;
						}
					}
					md.CloseConn();

				}
				
			}

		

		private void BtnPre_Click(object sender, System.EventArgs e)
		{
			Panel_cqfs.Visible=false;
			Panel_txtl.Visible=true;
		}
		}	
	}

