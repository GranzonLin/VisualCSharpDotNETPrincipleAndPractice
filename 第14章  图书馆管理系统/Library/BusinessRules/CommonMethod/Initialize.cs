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
	/// Initialize ��ժҪ˵����
	/// </summary>
	public class Initialize
	{
		DataBaseConnection dbc=new DataBaseConnection();
		private System.Data.SqlClient.SqlCommand comm;
		private System.Data.SqlClient.SqlDataReader dr;
		public Initialize()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public void setListView(string dataTable,ListView lv)
		{
			SqlConnection conn=setConnection();
			comm=new SqlCommand();
			comm.Connection=conn;
			string SQLtext="select * from  "+dataTable+"";
			comm.CommandText=SQLtext;
			dr=comm.ExecuteReader();
		
			setTitle(dataTable,lv);
		
		
		}
		public void setListView(string dataTable,string column1,string column2,string sqlQuery,ListView lv)
		{
			SqlConnection conn=setConnection();
			comm=new SqlCommand();
			comm.Connection=conn;
			string SQLtext="select * from "+dataTable + " where "+column1+"='"+sqlQuery+"' or "+column2+"='"+sqlQuery+"'";
			comm.CommandText=SQLtext;
			dr=comm.ExecuteReader();
			setTitle(dataTable,lv);
		}
		private SqlConnection setConnection()
		{
			string ConnString=dbc.databaseConnection;
			SqlConnection conn=new SqlConnection(ConnString);
			conn.Open();
			return conn;
		}

		private void setTitle(string dataTable,ListView lv)
		{
			lv.GridLines = true ;
			lv.FullRowSelect = true ;
			lv.View = View.Details ;
			lv.Scrollable = true ;
			lv.MultiSelect = false ;
			lv.HeaderStyle = ColumnHeaderStyle.Nonclickable ;
			lv.Clear();
			switch(dataTable)
			{
				case"Book":
					lv.Columns.Add("ͼ�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("ͼ������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("ͼ������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("��������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("ͼ�鵥��",100 , HorizontalAlignment.Center );
					lv.Columns.Add("ͼ�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�ܲ���",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�����",100 , HorizontalAlignment.Center );
					break;

				case"Reader":
					lv.Columns.Add("����֤��",100 , HorizontalAlignment.Center );
					lv.Columns.Add("��������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("��������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("���ߵ绰����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("��������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�����ѽ���Ŀ",100 , HorizontalAlignment.Center );
					break;

				case"dbo.[User]":
					lv.Columns.Add("�û���¼��",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�û�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�û�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�û�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�û�����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�û��绰����",100 , HorizontalAlignment.Center );
					break;

					case"PublishCompany":
					lv.Columns.Add("����������",100 , HorizontalAlignment.Center );
					lv.Columns.Add("�������ַ",100 , HorizontalAlignment.Center );
					lv.Columns.Add("������绰����",100 , HorizontalAlignment.Center );
					lv.Columns.Add("����������",100 , HorizontalAlignment.Center );
					break;

			}
		setData(lv);
		
		}

		private void setData(ListView lv)
		{
			int i=0;
			i=dr.FieldCount;
			string [] itemsCount=new string[i];
	
//			for (int j=0;j<i;j++)
//			{
//				lv.GridLines = true ;
//				lv.FullRowSelect = true ;
//				lv.View = View.Details ;
//				lv.Scrollable = true ;
//				lv.MultiSelect = false ;
//				lv.HeaderStyle = ColumnHeaderStyle.Nonclickable ;
//				lv.Columns.Add ( dr.GetName(j) , 100 , HorizontalAlignment.Left ) ;	
//			}
			while (dr.Read())
			{
				ListViewItem li = new ListViewItem ( ) ;
				li.SubItems.Clear ( ) ;
				li.SubItems[0].Text = dr[0].ToString ( ) ;
				for(int k=1;k<i;k++)
				{				
					li.SubItems.Add( dr[k].ToString().Trim() ) ;
				}
				lv.Items.Add ( li ) ; 
			}
			dr.Close();
		}
	
	}
}
