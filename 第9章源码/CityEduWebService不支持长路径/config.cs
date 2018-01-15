using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Xml;
using System.Configuration;
using System.Data.OleDb;
using System.Web.UI.WebControls;

namespace CityEduWebService
{
	/// <summary>
	/// config ��ժҪ˵����
	/// </summary>
	public class config
	{
		public System.Data.OleDb.OleDbConnection myConnection; 
		public System.Data.OleDb.OleDbCommand myCommand;
		public System.Data.OleDb.OleDbDataAdapter myAdapter;
		public System.Data.OleDb.OleDbDataReader myReader;
		public System.Data.OleDb.OleDbCommandBuilder myCommandBuilder;

		/*public SqlConnection myConnection; 
		public SqlCommand myCommand;
		public SqlDataAdapter myAdapter;
		public SqlDataAdapter myAdapter1;
		public SqlDataReader myReader;
		public SqlCommandBuilder myCommandBuilder;*/
		public DataSet ds;
		public DataTable dt;
		public DataRow dr;

		public config()
		{
			Open(); // �����ݿ�
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		//����������
		public string Open()
		{  
			string myConnectionStr="Provider=SQLOLEDB.1;Persist Security Info=False;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID="
				+ConfigurationSettings.AppSettings["WorkstationSet"]
				+";Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog="
				+ConfigurationSettings.AppSettings["Database"]
				+";Data Source="+ConfigurationSettings.AppSettings["DatabaseServer"]
				+";User ID="+ConfigurationSettings.AppSettings["DatabaseUser"]
				+";Password="+ConfigurationSettings.AppSettings["DatabasePassword"];
			myConnection=new System.Data.OleDb.OleDbConnection(myConnectionStr);
			
			try
			{
				myConnection.Open();
			}
			catch(Exception e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}			
			
			return "OK";
		}

		//�򿪻ָ����ݿ�ר�õ���������,��master���ݿ�
		public string DBRestore(string str_Sql)
		{   
			string myConnectionStr="Provider=SQLOLEDB.1;Persist Security Info=False;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=DH;Use Encryption for Data=False;Tag with column collation when possible=False;Initial Catalog=master;Data Source="
				+ConfigurationSettings.AppSettings["Database"]
				+";User ID="+ConfigurationSettings.AppSettings["DatabaseUser"]
				+";Password="+ConfigurationSettings.AppSettings["DatabasePassword"];
			myConnection=new System.Data.OleDb.OleDbConnection(myConnectionStr);
			
			try
			{
				myConnection.Open();
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myConnection.Dispose();	
			}
			//myCommand = new SqlCommand(str_Sql,myConnection);
			//�Ͽ�SchoolManage��һ������
			string str_Sql_DisConnect="declare hcforeach cursor global for select 'kill '+rtrim(spid) from master.dbo.sysprocesses where dbid=db_id('"
				+ConfigurationSettings.AppSettings["Database"].ToString()
				+"') exec sp_msforeach_worker '?'";
			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql_DisConnect,myConnection);
			myCommand.ExecuteNonQuery();
			myCommand.Dispose();

			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql,myConnection);
			myCommand.ExecuteNonQuery();
			myCommand.Dispose();

			return "OK";
		}
		/// <summary>
		/// �ر����ݿ�����DateSet����
		/// </summary>
		public void Close()
		{
			if (ds!=null) // ���DataSet����
			{
				ds.Clear();
			}
			if (myConnection!=null)
			{
				myConnection.Close(); // �ر����ݿ�
			}
		}
		/// <summary>
		/// ����DataSet����,�ü�¼���򹹼�(�����Ҫ)DataSet����,DataSet�����������ڴ�Ļ���
		/// </summary>
		/// <param name="str_Sql">�򿪱�Sql���</param>
		public string Fill(string str_Sql)
		{  	
			string errorstring=Open();
			if(errorstring!="OK")return errorstring;

			//myAdapter = new SqlDataAdapter(str_Sql,myConnection)
			myAdapter = new System.Data.OleDb.OleDbDataAdapter(str_Sql,myConnection);
			myAdapter.TableMappings.Add("Table", "TaleIn");
			
			ds = new DataSet();
			try
			{
				myAdapter.Fill(ds);	
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myConnection.Dispose();	
			}

			return "OK";
		}

		/// <summary>
		///ִ��Sql���
		/// </summary>
		/// <param name="str_Sql">Ҫִ�е�Sql���</param>
		public string ExeSql(string str_Sql)
		{   
			string errorstring=Open();
			if(errorstring!="OK")return errorstring;
			
			//myCommand = new SqlCommand(str_Sql,myConnection);
			myCommand = new System.Data.OleDb.OleDbCommand(str_Sql,myConnection);
			
			try
			{
				myCommand.ExecuteNonQuery();
			}
			catch(SqlException e)
			{
				string errorMessage = e.Message;				
				return errorMessage;
			}
			finally
			{
				myCommand.Dispose();
			}

			return "OK";
		}
		/// <summary>
		/// ��÷��ϸ�Sql���ı��¼��
		/// </summary>
		/// <param name="str_Sql">Select-SQL���</param>
		/// <returns>���ر��¼����</returns>
		public int GetRowCount(string str_Sql)
		{
			if(Fill(str_Sql)!="OK")return 0;
			
			try
			{
				int count=ds.Tables[0].Rows.Count;
				
				ds.Clear();
				myConnection.Close();
				return count;
			}
			catch
			{
				ds.Clear();
				myConnection.Close();
				return 0;
			}
		}
		
		/// <summary>
		/// ͨ����Sql���ؼ�keyֵ��ñ���һ�е�����
		/// </summary>
		/// <param name="str_Sql">���ؼ�Keyֵ������Select-SQL���</param>
		public bool GetRowRecord(string str_Sql)
		{
			if(Fill(str_Sql)!="OK")return false;
			
			//Fill(str_Sql);
			dr=ds.Tables[0].Rows[0];
			myConnection.Close();
			
			return true;
		}

		/// <summary>
		/// ȡĳ������ĳ���ֶ����ֵ
		/// </summary>
		public string GetMaxId(string id,string tablename)
		{
			string str_Key;
			string str_Sql="select top 1 "+id+" AS MaxId from "+tablename+" order by "+id+" desc";
			//string str_Sql="select max("+id+") AS MaxID from "+tablename;
			if (GetRowCount(str_Sql)==0)
			{
				str_Key="1";
			}
			else
			{
				GetRowRecord(str_Sql);
				str_Key=(int.Parse(dr["MaxID"].ToString())+1).ToString(); // ������ݿ��keyֵ
			}
			return str_Key;
		}

		//��ID���������ֶ�ֵ
		public  string School_Type_IDtoWhat(string str_School_Type_ID,string what)
		{
			string str_Sql="select "+what+" from School_Type where School_Type_ID="+str_School_Type_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string Class_Type_IDtoWhat(string str_Class_Type_ID,string what)
		{
			string str_Sql="select "+what+" from Class_Type where Class_Type_ID="+str_Class_Type_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string School_IDtoWhat(string str_School_ID,string what)
		{
			string str_Sql="select "+what+" from School where School_ID="+str_School_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string QuXian_IDtoWhat(string str_QuXian_ID,string what)
		{
			string str_Sql="select "+what+" from QuXian where QuXian_ID="+str_QuXian_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}

		public  string Office_IDtoWhat(string str_Office_ID,string what)
		{
			string str_Sql="select "+what+" from Office where Office_ID="+str_Office_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  string Class_IDtoWhat(string str_Calss_ID,string what)
		{
			string str_Sql="select "+what+" from Class where Class_ID="+str_Calss_ID;
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  string Student_IDtoWhat(string str_Student_ID,string what)
		{
			string str_Sql="select "+what+" from View_StudentClass where Student_ID='"+str_Student_ID+"'";
			if(GetRowRecord(str_Sql)==false)return "";
			return  dr[what].ToString();
		}
		public  bool Student_ID_Had(string str_Student_ID)
		{
			string str_Sql="select * from Student where Student_ID='"+str_Student_ID+"'";
			//if(GetRowRecord(str_Sql)==false)return false;
			if(GetRowCount(str_Sql)==0)return false;
			return true;
		}

		public  bool UserName_Had(string str_UserName)
		{
			string str_Sql="select * from Users where UserName='"+str_UserName+"'";
			//if(GetRowRecord(str_Sql)==false)return false;
			if(GetRowCount(str_Sql)==0)
				return false;
			return true;
		}

		//�ж���Ч����
		public bool ValidDate(decimal intYear,decimal intMonth,decimal intDate)
		{
			switch ((int)intMonth)
			{
				case 4:
					if(intDate>30)return false;
					break;
				case 6:
					if(intDate>30)return false;
					break;
				case 9:
					if(intDate>30)return false;
					break;
				case 11:
					if(intDate>30)return false;
					break;
				case 2:
					if(intDate>29)return false;
					if(intDate>28&&(!((intYear%400==0)||((intYear%4==0)&&(intYear%100!=0)))))return false;
				return true;
			}
			return true;
		}

		/// <summary>
		/// ���ĳ���ַ���������ַ�����һ�γ���ʱǰ�������ַ�
		/// </summary>
		/// <param name="strOriginal">Ҫ������ַ�</param>
		/// <param name="strSymbol">����</param>
		/// <returns>����ֵ</returns>
		public string GetFirstStr(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.IndexOf(strSymbol);
			if (strPlace!=-1)
				strOriginal=strOriginal.Substring(0,strPlace);
			return strOriginal;
		}

		/// <summary>
		/// ���ĳ���ַ���������ַ������һ�γ���ʱ���������ַ�
		/// </summary>
		/// <param name="strOriginal">Ҫ������ַ�</param>
		/// <param name="strSymbol">����</param>
		/// <returns>����ֵ</returns>
		public string GetLastStr(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.LastIndexOf(strSymbol)+strSymbol.Length;
			strOriginal=strOriginal.Substring(strPlace);
			return strOriginal;
		}

		/// <summary>
		/// ���ĳ���ַ���������ַ������һ�γ���ʱǰ�������ַ�
		/// </summary>
		public string GetLastStrFront(string strOriginal,string strSymbol)
		{
			int strPlace=strOriginal.LastIndexOf(strSymbol);
			strOriginal=strOriginal.Substring(0,strPlace);
			return strOriginal;
						
		}

		/// <summary>
		/// ����yyyy-mm-dd hh:mm.ssʱ���͵�year,month,date
		/// </summary>		
		public string GetYMD(string ymd,string what)
		{
			//"1980-7-15 1:02:03"
			if(what=="year")return GetFirstStr(ymd,"-");
			if(what=="month")return GetLastStr(GetLastStrFront(ymd,"-"),"-");
			if(what=="date")return GetFirstStr(GetLastStr(ymd,"-")," ");

			if(what=="hour")return GetLastStr(GetLastStrFront(GetLastStrFront(ymd,":"),":")," ");
			if(what=="minute")return GetLastStr(GetLastStrFront(ymd,":"),":");
			if(what=="second")return GetLastStr(ymd,":");
			
			return ymd;
		}

		/// <summary>
		/// ��DataGrid�ؼ�����ʾ����
		/// </summary>
		/// <param name="str_Sql">Select-SQL���</param>
		/// <param name="mydatagrid">DataGrid�ؼ�idֵ</param>
		public void BindDataGrid(string str_Sql,DataGrid mydatagrid)
		{
			Fill(str_Sql);
			mydatagrid.DataSource=ds.Tables[0].DefaultView;
			mydatagrid.DataBind();
			//myConnection.Close();
		}

		/// <summary>
		/// ȥ��'"?%=�ո�
		/// </summary>
		/// <param name="strOriginal">Ҫ������ַ�</param>
		/// <returns>����ֵ</returns>
		public string KickOut(string strOriginal)
		{
			strOriginal=strOriginal.Replace("\"","");
			strOriginal=strOriginal.Replace("'","");
			strOriginal=strOriginal.Replace(" ","");
			strOriginal=strOriginal.Replace("?","");
			strOriginal=strOriginal.Replace("%","");
			strOriginal=strOriginal.Replace("=","");
			return strOriginal;
		}

		/// <summary>
		/// �����Ƿ����'"?%=�ո�
		/// </summary>
		/// <param name="strOriginal">Ҫ������ַ�</param>
		/// <returns>����ֵ</returns>
		public bool Sniffer_In(string strOriginal)
		{
			if(strOriginal.IndexOf("\"")!=-1)return true;
			if(strOriginal.IndexOf("'")!=-1)return true;
			if(strOriginal.IndexOf(" ")!=-1)return true;
			if(strOriginal.IndexOf("?")!=-1)return true;
			if(strOriginal.IndexOf("%")!=-1)return true;
			if(strOriginal.IndexOf("=")!=-1)return true;
			return false;
		}

		/// <summary>
		/// ����ʱ������ʾ�Ի���
		/// </summary>
		/// <param name="str_Prompt">��ʾ��Ϣ</param>
		/// <param name="lbl_Error">Label�ؼ�idֵ</param>
		public void JsIsNull(string str_Prompt,Label lbl_Error)
		{
			lbl_Error.Text="<script language=\"javascript\">alert('"+str_Prompt+"');</"+"script>"; 
		}

	}
}
