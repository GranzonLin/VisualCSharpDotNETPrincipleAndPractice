using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;//add
namespace ע��ϵͳ�ȼ�
{
	/// <summary>
	/// Form1 ��ժҪ˵����
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.Container components = null;
		#region DLLImport
		[DllImport("user32.dll")]
		public extern static int RegisterHotKey(
			IntPtr hWnd, // handle to window//���ھ��
			int id, // hot key identifier//�ȼ���ʶ
			uint fsModifiers, // key-modifier options//�ȼ���ʶ
			Keys vk // virtual-key code//����
			);
		[DllImport("user32.dll")]
		public extern static int UnregisterHotKey(
			IntPtr hWnd, // handle to window//���ھ��
			int id // hot key identifier//�ȼ���ʶ
			);
		#endregion
		public Form1()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();
			RegisterHotKey(this.Handle, 100, 2, Keys.T);

		}
		protected override void WndProc(ref Message m)
		{
			if (m.Msg == 0x0312)//0x0312 ��windows��ϢWM_HOTKEY����ʾ�û��������ȼ����������㶨���ȼ��ȣ���ʮ�����Ʊ�ʾ��ʽ
			{
				MessageBox.Show("Hot Key\nKeyNo:"+m.WParam.ToString());
			}
			base.WndProc(ref m);
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);

		}
		#endregion

		/// <summary>
		/// Ӧ�ó��������ڵ㡣
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			UnregisterHotKey(this.Handle, 100);
		}
	}
}
