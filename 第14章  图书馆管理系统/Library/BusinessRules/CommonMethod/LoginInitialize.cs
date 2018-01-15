using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Library.UserInterface;
using Library.DataLevel;
namespace Library.UserInterface
{
	/// <summary>
	/// LoginInitialize ��ժҪ˵����
	/// </summary>
	public class LoginInitialize
	{
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlConnection conn;
		public LoginInitialize()
		{
			conn=setConnection();
		}
		private SqlConnection setConnection()
		{
			string ConnString=dbc.databaseConnection;
			SqlConnection conn=new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}
		public void login(TextBox txtID,TextBox txtPSW,Form formLogin)
		{	
			string usercheck=UserCheck(txtID.Text,txtPSW.Text);
			switch(usercheck)
			{
				case"system"://�����ǰ�û������ǡ�ϵͳ����Ա��
					ShowMainform(txtID.Text,txtPSW.Text,"system",formLogin);
					break;
				case"bookmanager"://�����ǰ�û�������"ͼ�����Ա"
					ShowMainform(txtID.Text,txtPSW.Text,"bookmanager",formLogin);
					break;
				case"reader"://�����ǰ�û�������"��ͨ����"
					ShowMainform(txtID.Text,txtPSW.Text,"reader",formLogin);
					break;
				case"counter"://�����ǰ�û�������"�軹�����Ա"
					ShowMainform(txtID.Text,txtPSW.Text,"counter",formLogin);
					break;
				case"Nobody"://�����ǰ�û��ṩ����Ϣ�޷�ͨ��ϵͳ����֤
					if(MessageBox.Show("�����û������������Ƿ����µ�½","��������",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
					{
						txtID.Text="";
						txtPSW.Text="";
						txtID.Focus();
					}
					else//����û�����"ȡ��"��ť
					{
						formLogin.Close();
					}
					break;
			}
		}
		string UserCheck(string username,string userpassword)
		{
			string usersort;	
			usersort="nobody";
			try
			{
				if(Identify(username,userpassword))//����Identify������֤�û��ĺϷ���
				{
					usersort=SetSort(username,userpassword);//����SetSort���������û�Ȩ��
					if(usersort!="reader")//���û�Ȩ�޲���"����"
					{	
						return usersort;
					}
				
					else   //���û�Ȩ����"����"
					{
						return "reader";
					}
				}			
				else//���û���֤ʧ��
				{
					return "Nobody";
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(e.ToString());
			}			
			conn.Close();	
			return "nobody";	
		}
		private bool Identify(string username,string userpassword)
		{
			SqlCommand cm=new SqlCommand("SP_selectIdentify",conn);
			cm.CommandType=CommandType.StoredProcedure;
			cm.Parameters.Add(new SqlParameter("@uname",SqlDbType.Char,10));
			cm.Parameters.Add(new SqlParameter("@upwd",SqlDbType.Char,10));
			cm.Parameters["@uname"].Value=username;
			cm.Parameters["@upwd"].Value=userpassword;
			SqlDataReader dr=cm.ExecuteReader();
			if(dr.Read())
			{
				dr.Close();
				return true;
			}
			else
			{
				dr.Close();
				return false;
			}
		}
		private string SetSort(string username,string userpassword)
		{
			string usersort="";
			string txtSql="select UserID,UserPassword,UserSort from dbo.[User] where UserID='"+username+"' AND UserPassword='"+userpassword+"'";
			SqlCommand checkuser=new SqlCommand(txtSql,conn);
			SqlDataReader sqlreader=checkuser.ExecuteReader();
			while(sqlreader.Read())// �����ݶ�ȡ���ҵ������
			{	
				if((sqlreader[0].ToString().Trim()==username)&&(sqlreader[1].ToString().Trim()==userpassword))//����û�����������֤�ɹ�
				{	
					usersort=sqlreader[2].ToString().Trim();
					sqlreader.Close();
					return usersort;						
				}
			}	
			sqlreader.Close();
			return "reader";
		}

		private void ShowMainform(string username,string userpassword,string usersort,Form formLogin)
		{
			formLogin.Visible=false;
			Form mainform=new MainForm(username,usersort);
			try
			{
				mainform.ShowDialog();
				formLogin.Close();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);			
			}
		}

	}
}
