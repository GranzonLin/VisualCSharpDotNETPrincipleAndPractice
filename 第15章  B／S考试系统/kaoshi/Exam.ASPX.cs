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


namespace Test
{
	/// <summary>
	/// CH7_12 ��ժҪ˵����
	/// </summary>
	public class test : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater Repeater1;
		protected System.Web.UI.WebControls.TextBox TextBox1;	
        protected static System.Text.StringBuilder dan_head=new System.Text.StringBuilder(),duo_head=new System.Text.StringBuilder(),pan_head=new System.Text.StringBuilder(),jian_head=new System.Text.StringBuilder(),bian_head=new System.Text.StringBuilder(),tian_head=new System.Text.StringBuilder();
		protected static int num_of_kong;
		protected System.Web.UI.WebControls.Label xuehao;
		protected System.Web.UI.WebControls.Label name;
		protected System.Web.UI.WebControls.Button save1;
		protected System.Web.UI.WebControls.Button Submit1;
		protected System.Web.UI.WebControls.Repeater rpCust1;
		protected System.Web.UI.WebControls.Repeater rpCust2;
		protected System.Web.UI.WebControls.Repeater rpCust3;
		protected System.Web.UI.WebControls.Repeater rpCust4;
		protected System.Web.UI.WebControls.Label xuehao2;
		protected System.Web.UI.WebControls.Label name2;
		protected System.Web.UI.WebControls.Button save2;
		protected System.Web.UI.WebControls.Repeater rpCust5;
		protected System.Web.UI.WebControls.Repeater rpCust6;
		protected System.Web.UI.WebControls.Button Submit;
		protected static DataSet[] ds=new DataSet[6];
		protected System.Web.UI.HtmlControls.HtmlInputText hid;
		protected System.Web.UI.WebControls.Button BtnDown;

	
		private void Page_Load(object sender, System.EventArgs e)
		{ 
			Response.Buffer=true;
			Response.ExpiresAbsolute=DateTime.Now.AddSeconds(-1);
			Response.Expires=0;
			Response.CacheControl="no-cache";

			MyData md;
			if(Session["Student_ID"]==null)
			{
				new MyMethods().AlertAndRedirect("'�����½���ܽ��п��ԣ�", "/test/login.aspx");
				return;
			}
			DateTime FirstLoginTime=DateTime.Parse(Session["logintime"].ToString());
			System.TimeSpan remain_time=DateTime.Now.Date.AddDays(1)-FirstLoginTime;//�����һ�ε�½ʱ�����ڶ����賿��ʱ��
			if(remain_time.TotalSeconds<7200)
			{//�������120���ӣ�����ʱ���޶����賿ǰ�����ӽ���
				remain_time=DateTime.Now.Date.AddDays(1)-DateTime.Now;
				Session["Time"]=(int)remain_time.TotalSeconds-60;
			}
			else
			{//�����������ʱ�����Ե�½֮�󣱣������ӵ�ʱ��
				remain_time=DateTime.Now-FirstLoginTime;
				Session["Time"]=7200-(int)remain_time.TotalSeconds;
			}	
			if(!IsPostBack)
			{
				
				
				xuehao.Text=Convert.ToString(Session["Student_ID"]);//��ѧ����ʾҳ���Ϸ�
				name.Text=Convert.ToString(Session["Student_name"]);//��������ʾ��ҳ���Ϸ�
				xuehao2.Text=xuehao.Text;//��ѧ����ʾҳ���·�
				name2.Text=name.Text;//��������ʾ��ҳ���·�
				int shijuan_total,curr_tixing_num=0;//ǰ�߼�¼��ѡ�Ծ���,���߼�¼���Ծ�ǰ���͵ĵ����
				string StrSQL;
				OleDbDataReader DR;
				if(Session["shijuanhao"]!=null)
				{//���ѧ���ǵ�һ�ε�½
					StrSQL="select * from ��ֵ where �Ծ��='"+Session["shijuanhao"].ToString()+"'";
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					DR.Read();
					BtnDown.Visible=true;
					
				}
				else
				{//���ѧ����һ�ε�½
					StrSQL="select count(*) as �Ծ��� from ��ֵ where ʹ������=#"+DateTime.Now.ToShortDateString()+"#" ;	//ͳ�ƿ�ѡ�Ծ���
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					bool ishasdata=DR.Read(); 			
					shijuan_total=Convert.ToInt16(DR["�Ծ���"]);
					DR.Close();
					md.CloseConn();
					Random r = new Random(unchecked((int)DateTime.Now.Ticks));//��������Ծ��λ��
					int curr_shijuan_num=(int)((shijuan_total)*r.NextDouble()+1); 
					StrSQL="select * from ��ֵ where ʹ������=#"+DateTime.Now.ToShortDateString()+"# order by �Ծ��";
					md=new MyData(Application["connstr"].ToString());
					DR=md.eSelect(StrSQL);
					for(int i=1;i<=curr_shijuan_num;i++)		
						DR.Read();//��λ�����Ծ�
					Session["shijuanhao"]=Convert.ToString(DR["�Ծ��"]);
					
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete("update ѧ�� set �����Ծ��='"+Session["shijuanhao"].ToString()+"' where ѧ��='"+xuehao.Text+"'");//��¼ѧ���״ε�½ʹ�õ��Ծ�
				}
				
				for(int i=0;i<=5;i++)
				{//���ø�������ͷ��Ϣ����ʾ
					string curr_tixing=null;
					System.Text.StringBuilder curr_head=null;
					GetHeadVariables(ref curr_tixing,ref curr_head,i);//�÷����ɸ���iֵ,���ز�ͬ�����͸�curr_tixing,���ز�ͬ����������ͷ��Ϣ�ı���������
					string str_tl_last,str_fz_last;
					if(i==2)
					{//�����
						str_tl_last="�����";
						str_fz_last="��ÿ�շ�ֵ";
					}
					else
					{//������
						str_tl_last="����";
						str_fz_last="��ÿ���ֵ";
					}
					
					if (Convert.ToString(DR[curr_tixing+str_tl_last])!="0")
					{//�����ǰ���͵�������Ϊ0,��������ͷ��Ϣ
						curr_tixing_num+=1;
						curr_head.Remove(0,curr_head.ToString().Length);
						curr_head.Append(num_to_word(curr_tixing_num)+"��"+curr_tixing+"�⣨��"+Convert.ToString(DR[curr_tixing+str_tl_last])+"�⣬ÿ��"+Convert.ToString(DR[curr_tixing+str_fz_last])+"��)");
					}
					else
					{//������ͷ��ϢΪ��
						curr_head.Append("");
					}

				}
				
				DR.Close();
				md.CloseConn();
				
				
				for(int j=0;j<=5;j++)
				{//�����Ծ�����͵�����ȡ��,���󶨵���Ӧ��Repeater
					Repeater rp=null;
					string tixing="";
					switch(j)
					{
						case 0:tixing="��ѡ��";rp=rpCust1;break;
						case 1:tixing="��ѡ��";rp=rpCust2;break;
						case 2:tixing="�ж���";rp=rpCust3;break;
						case 3:tixing="�����";rp=rpCust4;break;
						case 4:tixing="�����";rp=rpCust5;break;
						case 5:tixing="�����";rp=rpCust6;break;
					}
					String strSQL="select  * from "+tixing+",��� where "+tixing+".id=���.������ and ���.����='"+tixing+"' and ���.�Ծ��='"+Session["shijuanhao"].ToString()+"' order by ˳��� ASC"; 
					new MyMethods().Repeater_bind(rp,ref ds[j],strSQL,Application["connstr"].ToString());
					
				}
			}
			else
			{
					
			}
			
		
		}
		private void GetHeadVariables(ref string tixing,ref System.Text.StringBuilder curr_head,int i)
		{
					switch(i)
					{
						case 0: tixing="��ѡ";curr_head=dan_head;break;
						case 1: tixing="��ѡ";curr_head=duo_head;break;
						case 2: tixing="���";curr_head=tian_head;break;
						case 3: tixing="�ж�";curr_head=pan_head;break;
						case 4: tixing="���";curr_head=jian_head;break;
						case 5: tixing="���";curr_head=bian_head;break;

					}
					
		}
	
		private string num_to_word(int num)
		{
			string word;
			switch(num)
			{
				case 1:
					  word="һ";
					  break;
				case 2:
					word="��";
					break;
				case 3:
					word="��";
					break;
				case 4:
					word="��";
					break;
				case 5:
					word="��";
					break;
				case 6:
					word="��";
					break;
				default:
					word="";
					break;
			}
			return word;
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
			this.save1.Click += new System.EventHandler(this.save_Click);
			this.Submit1.Click += new System.EventHandler(this.Submit_Click);
			this.BtnDown.Click += new System.EventHandler(this.BtnDown_Click);
			this.rpCust1.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust1.ItemCommand += new System.Web.UI.WebControls.RepeaterCommandEventHandler(this.rpCust1_ItemCommand);
			this.rpCust2.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust6.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust3.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust4.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.rpCust5.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.ItemDataBound);
			this.save2.Click += new System.EventHandler(this.save_Click);
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		public string Changechr(string str)
		{
			str=str.Replace("<","&lt;");
			str=str.Replace(">","&gt;");
			str=str.Replace(" ","&nbsp;");
			str=str.Replace("\n","<br>");
			return str;

		}
		
        private void  pan_juan()
		{
			
			//***************************************ȡ������ֵ
	        String strSQL="select * from ��ֵ where �Ծ��='"+Session["shijuanhao"].ToString()+"'";
			MyData md=new MyData(Application["connstr"].ToString());
			OleDbDataReader dr=md.eSelect(strSQL);
			dr.Read();
			int dan_fz,duo_fz,pan_fz;
			dan_fz=Convert.ToInt16(dr["��ѡ��ÿ���ֵ"]);
			duo_fz=Convert.ToInt16(dr["��ѡ��ÿ���ֵ"]);
			pan_fz=Convert.ToInt16(dr["�ж���ÿ���ֵ"]);		
			dr.Close();
			md.CloseConn();
			//*************************************END
           
			for(int j=0;j<=2;j++)
			{ //ÿ��ѭ����һ�ֿ͹�������ľ�
				int everyscore=0;//�洢����ѭ������������͵�ÿ��(��)��ֵ
				Repeater rp=null;
				switch(j)
				{
					case 0:rp=rpCust1;everyscore=dan_fz;break;
					case 1:rp=rpCust2;everyscore=duo_fz;break;
					case 2:rp=rpCust3;everyscore=pan_fz;break;
				}
				for(int i=0;i<rp.Items.Count;i++)
				{
					string answer="";//�洢�ÿ����Ե�ǰ����������
					int score;//�洢��ǰ����÷�
					switch(j)
					{
						case 0:answer=find_dan_checked(i);break;
						case 1:answer=find_duo_checked(i);break;
						case 2:answer=find_pan_checked(i);break;
					}
					if(answer!=ds[j].Tables[0].Rows[i]["��ȷ��"].ToString())
						score=0;
					else
					    score=everyscore;
				    strSQL="update ��� set �÷�="+score+" where ѧ��='"+Session["Student_ID"]+"' and �Ծ��='"+Session["shijuanhao"].ToString()+"' and ����='"+ds[j].Tables[0].Rows[i]["����"].ToString()+"' and ������='"+ds[j].Tables[0].Rows[i]["������"].ToString()+"'";
					
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strSQL);//Ϊ���������ĵ�ǰ���͵ĵ�ǰ�������.		    
				}
				
			}
			strSQL="update ѧ�� set ���Ե�½ʱ��=#"+DateTime.Now.Date.AddDays(1)+"# where ѧ��='"+xuehao.Text+"'";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(strSQL);	
			Response.Write("<script>alert('�Ծ��ύ�ɹ�,���Խ���!');window.opener=null;window.close();</script>");
		}

	
		private void Submit_Click(object sender, System.EventArgs e)
		{
			save();
			pan_juan();
		}

		
	
		private void save()
		{
		  
			String StrSQL="Delete from ��� where ѧ��='"+Session["Student_ID"].ToString()+"' and �Ծ��='"+Session["shijuanhao"].ToString()+"'";
			new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);//ɾ�������ϴα���ĸ��Ծ�Ĵ��
			for(int j=0;j<=5;j++)
			{//ÿ��ѭ������һ�����͵Ĵ��״̬       
				string tixing="",answerchecked="";
				for (int i=0;i<ds[j].Tables[0].Rows.Count;i++)
				{//�Դ��е�ǰ�������������DataSet���б���,ÿ�δ洢��ǰ������һ������Ĵ��״̬
					switch(j)
					{
						case 0:tixing="��ѡ��";answerchecked=find_dan_checked(i);break;
						case 1:tixing="��ѡ��";answerchecked=find_duo_checked(i);break;
						case 5:tixing="�����";answerchecked=find_tian_content(i);break;
						case 2:tixing="�ж���";answerchecked=find_pan_checked(i);break;
						case 3:tixing="�����";answerchecked=((TextBox)rpCust4.Items[i].FindControl("txt_jian")).Text;break;
						case 4:tixing="�����";answerchecked=((TextBox)rpCust5.Items[i].FindControl("txt_bian")).Text;break;

					}
				
					StrSQL="insert into ���(ѧ��,�Ծ��,����,������,ѧ����) values('"+Session["Student_ID"]+"','"+ds[j].Tables[0].Rows[i]["�Ծ��"]+"','"+tixing+"','"+ds[j].Tables[0].Rows[i]["������"]+"','"+answerchecked+"')";
					new MyData(Application["connstr"].ToString()).eInsertUpdateDelete(StrSQL);
				}
			}
			
		}
		private string find_duo_checked(int curr_row)
		{
			CheckBox rb1=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxa");
			CheckBox rb2=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxb");
			CheckBox rb3=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxc");
			CheckBox rb4=(CheckBox)rpCust2.Items[curr_row].FindControl("cb_xxd");
			string result="";
			if (rb1.Checked)
				result+=rb1.Text;
			if(rb2.Checked)
				result+=rb2.Text;
			if(rb3.Checked)
				result+=rb3.Text;
			if(rb4.Checked)
				result+=rb4.Text;
			return result;

		}
		private string find_tian_content(int curr_row)
		{
			string result;
			TextBox tb1=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk1");
			TextBox tb2=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk2");
			TextBox tb3=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk3");
			TextBox tb4=(TextBox)rpCust6.Items[curr_row].FindControl("txt_tk4");
			result=tb1.Text;
			int num_of_kong=Convert.ToInt16(ds[5].Tables[0].Rows[curr_row][3].ToString());
			if (num_of_kong>1)
			{
				result+=","+tb2.Text;
				if(num_of_kong>2)
				{
					result+=","+tb3.Text;
					if(num_of_kong>3)
						result+=","+tb4.Text;
				}
			}
			return result;
		}
		private string find_dan_checked(int curr_row)
		{
			RadioButton rb1=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxa");
			RadioButton rb2=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxb");
			RadioButton rb3=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxc");
			RadioButton rb4=(RadioButton)rpCust1.Items[curr_row].FindControl("rb_xxd");
			string result="";
			if (rb1.Checked)
				result=rb1.Text;
			if (rb2.Checked)
				result=rb2.Text;
			if (rb3.Checked)
				result=rb3.Text;
			if (rb4.Checked)
				result=rb4.Text;
			return result;
		}
		private string find_pan_checked(int curr_row)
		{
			RadioButton rb1=(RadioButton)rpCust3.Items[curr_row].FindControl("rb_pan1");
			RadioButton rb2=(RadioButton)rpCust3.Items[curr_row].FindControl("rb_pan2");
			string result="";
			if (rb1.Checked)
				result=rb1.Text;
			if (rb2.Checked)
				result=rb2.Text;
			return result;
		}

		private void save_Click(object sender, System.EventArgs e) 
		{
		  save();
		}

	
		private void ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{
			Repeater rp=(Repeater)sender;
			string curr_lbl_name="",curr_lbl_text="";
			switch(rp.ID)
			{//���ݵ�ǰ�ؼ��Ĳ�ͬ,ѡ��ͬ�����������ͷ��label����Ԥ����ʾ����ͷ��Ϣ
				case "rpCust1":curr_lbl_name="lbl_dan";curr_lbl_text=dan_head.ToString();break;
				case "rpCust2":curr_lbl_name="lbl_duo";curr_lbl_text=duo_head.ToString();break;
				case "rpCust3":curr_lbl_name="lbl_pan";curr_lbl_text=pan_head.ToString();break;
				case "rpCust4":curr_lbl_name="lbl_jian";curr_lbl_text=jian_head.ToString();break;
				case "rpCust5":curr_lbl_name="lbl_bian";curr_lbl_text=bian_head.ToString();break;
				case "rpCust6":curr_lbl_name="lbl_tian";curr_lbl_text=tian_head.ToString();break;
			}
			
			if (rp.ID=="rpCust6")
			{//�����ǰ�ؼ�ΪrpCust6�����������Repeater�ؼ�,��Ҫ���ݵ�ǰ�����������,��ʾ��Ӧ�����������ش���������TextBox
				
				try
				{
					TextBox tb2=(TextBox)e.Item.FindControl("txt_tk2");
					TextBox tb3=(TextBox)e.Item.FindControl("txt_tk3");
					TextBox tb4=(TextBox)e.Item.FindControl("txt_tk4");
					int num_of_kong=Convert.ToInt16(ds[5].Tables[0].Rows[e.Item.ItemIndex][3].ToString());
						if (num_of_kong>1)
						{
							tb2.Visible=true;
							if(num_of_kong>2)
							{
								tb3.Visible =true;
								if(num_of_kong>3)
									tb4.Visible =true;
							}
						}
				}
				catch{}
			}
			try
			{//Ϊ��ǰRepeater�ؼ����øÿؼ����������͵���ͷ
				Label lb=(Label)e.Item.FindControl(curr_lbl_name);
				lb.Text=curr_lbl_text;
			}
			catch
			{
			}

		}

		private void rpCust1_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
		{
		
		}

		private void BtnDown_Click(object sender, System.EventArgs e)
		{
			
			String StrSQL="select ���.������ as ������,���.���� as ����,���.ѧ���� as ѧ���� from ���,��ֵ where ���.�Ծ��=��ֵ.�Ծ�� and ���.ѧ��='"+Session["Student_ID"].ToString()+"' and ��ֵ.ʹ������=#"+DateTime.Now.ToShortDateString()+"#";
			MyData md=new MyData(Application["connstr"].ToString());//�Ӵ����н���������Ϊ���յ�������йص���������ȡ��
			OleDbDataReader DR=md.eSelect(StrSQL);
			while(DR.Read())
			{//����ܹ�ȡ������,�������������
				if(DR["ѧ����"].ToString()!="")
				{//�����ǰ�����ѧ�����ֶβ�Ϊ��
					switch(DR["����"].ToString())
					{
						case "��ѡ��"://�����ǰ����Ϊ��ѡ��

							for(int i=0;i<rpCust1.Items.Count;i++)
							{//��rpCust1�ؼ����ҳ�������,����ѧ���𰸱������Ӧ��RadioButton��
								Label lbl=(Label)rpCust1.Items[i].FindControl("lbl_dan_stbh");//lbl_dan_stbh����е�ǰ����������
								if(DR["������"].ToString()==lbl.Text)
								{
									string rb_name="";
									switch(DR["ѧ����"].ToString())
									{
										case "A":
											rb_name="rb_xxa";
											break;
										case "B":
											rb_name="rb_xxb";
											break;
										case "C":
											rb_name="rb_xxc";
											break;
										case "D":
											rb_name="rb_xxd";
											break;
									}
									RadioButton rb=(RadioButton)rpCust1.Items[i].FindControl(rb_name);
									rb.Checked=true;
								}
							}
							break;
						case "��ѡ��"://�����ǰ����Ϊ��ѡ��

							for(int i=0;i<rpCust2.Items.Count;i++)
							{//��rpCust2�ؼ����ҳ�������,����ѧ���𰸱������Ӧ��CheckBox��
								Label lbl=(Label)rpCust2.Items[i].FindControl("lbl_duo_stbh");//lbl_duo_stbh����е�ǰ����������
								if(DR["������"].ToString()==lbl.Text)
								{
									string cb_name="";
									for(int j=0;j<DR["ѧ����"].ToString().Length;j++)
									{
										switch(DR["ѧ����"].ToString().Substring(j,1))
										{
											case "A":
												cb_name="cb_xxa";
												break;
											case "B":
												cb_name="cb_xxb";
												break;
											case "C":
												cb_name="cb_xxc";
												break;
											case "D":
												cb_name="cb_xxd";
												break;
										}
									
										CheckBox cb=(CheckBox)rpCust2.Items[i].FindControl(cb_name);
										cb.Checked=true;
									}
								}
							}
							break;
						case "�ж���"://�����ǰ����Ϊ�ж���

							for(int i=0;i<rpCust3.Items.Count;i++)
							{//��rpCust3�ؼ����ҳ�������,����ѧ���𰸱������Ӧ��RadioButton��
								Label lbl=(Label)rpCust3.Items[i].FindControl("lbl_pan_stbh");//lbl_pan_stbh����е�ǰ����������
								if(DR["������"].ToString()==lbl.Text)
								{
									string rb_name="";
									if(DR["ѧ����"].ToString()=="��")
									       rb_name="rb_pan1";
									else
										   rb_name="rb_pan2";
									RadioButton rb=(RadioButton)rpCust3.Items[i].FindControl(rb_name);
									rb.Checked=true;
								}
							}
							break;
						case "�����"://�����ǰ����Ϊ�����

							for(int i=0;i<rpCust4.Items.Count;i++)
							{//��rpCust4�ؼ����ҳ�������,����ѧ���������TextBox��
								Label lbl=(Label)rpCust4.Items[i].FindControl("lbl_jian_stbh");//lbl_jian_stbh����е�ǰ�����������
								if(DR["������"].ToString()==lbl.Text)
								{
									TextBox tb=(TextBox)rpCust4.Items[i].FindControl("txt_jian");
									tb.Text=DR["ѧ����"].ToString();
								}
							}
							break;
						case "�����"://�����ǰ����Ϊ�����

							for(int i=0;i<rpCust5.Items.Count;i++)
							{//��rpCust5�ؼ����ҳ�������,����ѧ���������TextBox��
								Label lbl=(Label)rpCust5.Items[i].FindControl("lbl_bian_stbh");//lbl_bian_stbh����е�ǰ�����������
								if(DR["������"].ToString()==lbl.Text)
								{
									TextBox tb=(TextBox)rpCust5.Items[i].FindControl("txt_bian");
									tb.Text=DR["ѧ����"].ToString();
								}
							}
							break;
						case "�����"://�����ǰ����Ϊ�����

							for(int i=0;i<rpCust6.Items.Count;i++)
							{//��rpCust6�ؼ����ҳ�������,����ѧ�����������Ӧ��TextBox��
								Label lbl=(Label)rpCust6.Items[i].FindControl("lbl_tian_stbh");//lbl_tian_stbh����е�ǰ�����������
								if(DR["������"].ToString()==lbl.Text)
								{
									
									string[] daan=DR["ѧ����"].ToString().Split(',');
									for(int j=1;j<=daan.Length;j++)
									{
										TextBox tb=(TextBox)rpCust6.Items[i].FindControl("txt_tk"+j);
										tb.Text=daan[j-1];
										if(j>0)
										{
											tb.Visible=true;
										}
										
									}
								}
							}
							break;
					}
				}
			}
			md.CloseConn();
		}
	}
}
