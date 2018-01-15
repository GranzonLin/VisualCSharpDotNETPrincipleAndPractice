using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//��������ռ�����
using System.Drawing.Printing;
using System.IO;
namespace ���±�
{
	/// <summary>
	/// mynotepad ��ժҪ˵����
	/// </summary>
	public class mynotepad : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemNew;
		private System.Windows.Forms.MenuItem menuItemOpen;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.MenuItem menuItemSaveAs;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItemPageSet;
		private System.Windows.Forms.MenuItem menuItemPrint;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItemExit;
		private System.Windows.Forms.MenuItem menuItemEdit;
		private System.Windows.Forms.MenuItem menuItemUndo;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItemCut;
		private System.Windows.Forms.MenuItem menuItemCopy;
		private System.Windows.Forms.MenuItem menuItemPaste;
		private System.Windows.Forms.MenuItem menuItemDel;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItemSelAll;
		private System.Windows.Forms.MenuItem menuItemFormat;
		private System.Windows.Forms.MenuItem menuItemFont;
		private System.Windows.Forms.MenuItem menuItemColor;
		/// <summary>
		/// ����������������
		/// </summary>
		//********************************
		const int MaxLenght=2000000;        
		private string currentFileName;
		private System.Drawing.Printing.PrintDocument printDocument=
			new PrintDocument();
		private bool needToSave;
        private System.Windows.Forms.TextBox textBoxEdit;
        private IContainer components;

		public mynotepad()
		{
			//
			// Windows ���������֧���������
			//
			InitializeComponent();

			//
			// TODO: �� InitializeComponent ���ú�����κι��캯������
			//
		}

		/// <summary>
		/// ������������ʹ�õ���Դ��
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
        [STAThread]
		static void Main() 
		{
			Application.Run(new mynotepad());
		}

		#region Windows ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.textBoxEdit = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemNew = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemSaveAs = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItemPageSet = new System.Windows.Forms.MenuItem();
            this.menuItemPrint = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemUndo = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItemCut = new System.Windows.Forms.MenuItem();
            this.menuItemCopy = new System.Windows.Forms.MenuItem();
            this.menuItemPaste = new System.Windows.Forms.MenuItem();
            this.menuItemDel = new System.Windows.Forms.MenuItem();
            this.menuItem19 = new System.Windows.Forms.MenuItem();
            this.menuItemSelAll = new System.Windows.Forms.MenuItem();
            this.menuItemFormat = new System.Windows.Forms.MenuItem();
            this.menuItemFont = new System.Windows.Forms.MenuItem();
            this.menuItemColor = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // textBoxEdit
            // 
            this.textBoxEdit.Location = new System.Drawing.Point(0, 0);
            this.textBoxEdit.Multiline = true;
            this.textBoxEdit.Name = "textBoxEdit";
            this.textBoxEdit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxEdit.Size = new System.Drawing.Size(328, 256);
            this.textBoxEdit.TabIndex = 0;
            this.textBoxEdit.Text = "textBoxEdit";
            this.textBoxEdit.TextChanged += new System.EventHandler(this.textBoxEdit_TextChanged);
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemEdit,
            this.menuItemFormat});
            this.mainMenu1.Collapse += new System.EventHandler(this.menuItemEdit_Popup);
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemNew,
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSaveAs,
            this.menuItem8,
            this.menuItemPageSet,
            this.menuItemPrint,
            this.menuItem11,
            this.menuItemExit});
            this.menuItemFile.Text = "�ļ�(&F)";
            // 
            // menuItemNew
            // 
            this.menuItemNew.Index = 0;
            this.menuItemNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.menuItemNew.Text = "�½�(&N)";
            this.menuItemNew.Click += new System.EventHandler(this.menuItemNew_Click);
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 1;
            this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpen.Text = "��(O)...";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 2;
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "����(&S)";
            this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
            // 
            // menuItemSaveAs
            // 
            this.menuItemSaveAs.Index = 3;
            this.menuItemSaveAs.Text = "���Ϊ(A)...";
            this.menuItemSaveAs.Click += new System.EventHandler(this.menuItemSaveAs_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.Text = "-";
            // 
            // menuItemPageSet
            // 
            this.menuItemPageSet.Index = 5;
            this.menuItemPageSet.Text = "ҳ������(U)...";
            this.menuItemPageSet.Click += new System.EventHandler(this.menuItemPageSet_Click);
            // 
            // menuItemPrint
            // 
            this.menuItemPrint.Index = 6;
            this.menuItemPrint.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItemPrint.Text = "��ӡ(&P)";
            this.menuItemPrint.Click += new System.EventHandler(this.menuItemPrint_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 7;
            this.menuItem11.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 8;
            this.menuItemExit.Text = "�˳�(&X)";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 1;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUndo,
            this.menuItem14,
            this.menuItemCut,
            this.menuItemCopy,
            this.menuItemPaste,
            this.menuItemDel,
            this.menuItem19,
            this.menuItemSelAll});
            this.menuItemEdit.Text = "�༭(&E)";
            // 
            // menuItemUndo
            // 
            this.menuItemUndo.Index = 0;
            this.menuItemUndo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItemUndo.Text = "����(&U)";
            this.menuItemUndo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 1;
            this.menuItem14.Text = "-";
            // 
            // menuItemCut
            // 
            this.menuItemCut.Index = 2;
            this.menuItemCut.Shortcut = System.Windows.Forms.Shortcut.CtrlX;
            this.menuItemCut.Text = "����(&T)";
            this.menuItemCut.Click += new System.EventHandler(this.menuItemCut_Click);
            // 
            // menuItemCopy
            // 
            this.menuItemCopy.Index = 3;
            this.menuItemCopy.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.menuItemCopy.Text = "����(&C)";
            this.menuItemCopy.Click += new System.EventHandler(this.menuItemCopy_Click);
            // 
            // menuItemPaste
            // 
            this.menuItemPaste.Index = 4;
            this.menuItemPaste.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.menuItemPaste.Text = "ճ��(&P)";
            this.menuItemPaste.Click += new System.EventHandler(this.menuItemPaste_Click);
            // 
            // menuItemDel
            // 
            this.menuItemDel.Index = 5;
            this.menuItemDel.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.menuItemDel.Text = "ɾ��(&L)";
            this.menuItemDel.Click += new System.EventHandler(this.menuItemDel_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.Index = 6;
            this.menuItem19.Text = "-";
            // 
            // menuItemSelAll
            // 
            this.menuItemSelAll.Index = 7;
            this.menuItemSelAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.menuItemSelAll.Text = "ȫѡ(&A)";
            this.menuItemSelAll.Click += new System.EventHandler(this.menuItemSelAll_Click);
            // 
            // menuItemFormat
            // 
            this.menuItemFormat.Index = 2;
            this.menuItemFormat.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFont,
            this.menuItemColor});
            this.menuItemFormat.Text = "��ʽ(&O)";
            // 
            // menuItemFont
            // 
            this.menuItemFont.Index = 0;
            this.menuItemFont.Text = "����(&F)...";
            this.menuItemFont.Click += new System.EventHandler(this.menuItemFont_Click);
            // 
            // menuItemColor
            // 
            this.menuItemColor.Index = 1;
            this.menuItemColor.Text = "������ɫ(&C)...";
            this.menuItemColor.Click += new System.EventHandler(this.menuItemColor_Click);
            // 
            // mynotepad
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(328, 257);
            this.Controls.Add(this.textBoxEdit);
            this.Menu = this.mainMenu1;
            this.Name = "mynotepad";
            this.Text = "mynotepad";
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void OpenFile()//����ָ�����ļ�
		{
			try
			{
				FileInfo f=new FileInfo(currentFileName);
				StreamReader reader=f.OpenText();
				textBoxEdit.Text=reader.ReadToEnd();
				reader.Close();
				this.Text="�ı��༭--"+f.Name;
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		private string GetOpenFile()//���ļ��Ի��򲢻�ȡ���ļ���
		{
			OpenFileDialog openFile=new OpenFileDialog();
			openFile.Title="���ı��ļ�";
			openFile.CheckFileExists=true;
			openFile.CheckPathExists=true;
			openFile.AddExtension=true;
			openFile.Multiselect=false;
			openFile.Filter="�ı��ļ� (*.txt)|*.txt|�����ļ� (*.*)|*.*";
			if(openFile.ShowDialog()==DialogResult.OK)
			{
				return openFile.FileName;
			}
			else
			{
				return null;
			}
		}
		private void menuItemExit_Click(object sender, System.EventArgs e)
		{
            this.Close();//this.Dispose();//close�������ͷ���Դ�󻹿��Լ���ʹ�ã���û�����ڴ���ɾ��������dispose��������ڴ���ɾ������Դ������Ͳ�����ʹ������
		}

		private void menuItemUndo_Click(object sender, System.EventArgs e)
		{
			if(textBoxEdit.CanUndo==true)
			{
				textBoxEdit.Undo();
				textBoxEdit.ClearUndo();
			}
		}

		private void menuItemCut_Click(object sender, System.EventArgs e)
		{
			if(textBoxEdit.SelectedText!="")
			{
				textBoxEdit.Cut();
			}
		}

		private void menuItemCopy_Click(object sender, System.EventArgs e)
		{
			if(textBoxEdit.SelectionLength>0)
			{
				textBoxEdit.Copy();
			}
		}

		private void menuItemPaste_Click(object sender, System.EventArgs e)
		{
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text)==true)
			{
				if(textBoxEdit.SelectionLength>0)
				{
					DialogResult result;
					result=MessageBox.Show("���븲�ǵ�ѡ����ı���?","����ȷ��",MessageBoxButtons.YesNo);
                    if (result == DialogResult.No)
                    {
                        textBoxEdit.SelectionStart = textBoxEdit.SelectionStart + textBoxEdit.SelectionLength;
                    }	
				}
				textBoxEdit.Paste();   
			}
		}

		private void menuItemDel_Click(object sender, System.EventArgs e)
		{
			textBoxEdit.SelectedText.Remove(0,textBoxEdit.SelectionLength);
			textBoxEdit.SelectedText="";
		}

		private void menuItemSelAll_Click(object sender, System.EventArgs e)
		{
			textBoxEdit.SelectAll();
		}

		private void menuItemEdit_Popup(object sender, System.EventArgs e)
		{
			if(Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
			{
				menuItemPaste.Enabled=true;
			}
			else 
			{
				menuItemPaste.Enabled=false;
			}
			if(textBoxEdit.SelectionLength>0)
			{
				menuItemCopy.Enabled=true;
				menuItemCut.Enabled=true;
				menuItemDel.Enabled=true;
			}
			else
			{
				menuItemCopy.Enabled=false;
				menuItemCut.Enabled=false;
				menuItemDel.Enabled=false;
			}
			if(textBoxEdit.CanUndo==true)
			{
				menuItemUndo.Enabled=true;
			}
			else
			{
				menuItemUndo.Enabled=false;
			}
		}
		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			if(currentFileName==null)
			{
				menuItemSaveAs_Click(sender,e);
			}
			else
			{
				SaveFile(textBoxEdit.Text);
			}
			needToSave=false;
		}

		private void menuItemSaveAs_Click(object sender, System.EventArgs e)
		{
			string file=GetSaveFile();
			if(file==null)
			{
				return;
			}
			else
			{
				currentFileName=file;
				SaveFile(textBoxEdit.Text);
				FileInfo f=new FileInfo(currentFileName);
				this.Text="�ı��༭--"+f.Name;
				needToSave=false;
			}
		} 
		private void SaveFile(string str)
		{
			try
			{
				StreamWriter writer=new StreamWriter(currentFileName);
				writer.Write(str);
				writer.Close();
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}
		private string GetSaveFile()
		{
			SaveFileDialog saveFile=new SaveFileDialog();
			saveFile.Title="�����ı��ļ�";
			saveFile.OverwritePrompt=true;
			saveFile.CreatePrompt=true;
			saveFile.AddExtension=true;
			saveFile.Filter="�ı��ļ� (*.txt)|*.txt|�����ļ� (*.*)|*.*";
			if(saveFile.ShowDialog()==DialogResult.OK)
			{
				return saveFile.FileName;
			}
			else
			{
				return null;
			}
		}

		private void menuItemFont_Click(object sender, System.EventArgs e)
		{
			FontDialog fontDialog=new FontDialog();
			fontDialog.ShowColor=true;
			fontDialog.AllowScriptChange=true;
			fontDialog.AllowVectorFonts=true;
			fontDialog.ShowEffects=true;
			if(fontDialog.ShowDialog()==DialogResult.OK)
			{
				textBoxEdit.Font=fontDialog.Font;
				textBoxEdit.ForeColor=fontDialog.Color;
			}
		}

		private void menuItemColor_Click(object sender, System.EventArgs e)
		{
			ColorDialog colorDialog=new ColorDialog();
			colorDialog.AllowFullOpen=true;
			colorDialog.AnyColor=true;
			colorDialog.FullOpen=true;
			if(colorDialog.ShowDialog()==DialogResult.OK)
			{
				textBoxEdit.BackColor=colorDialog.Color;
			}
		}

		private void menuItemPrint_Click(object sender, System.EventArgs e)
		{
			PrintDialog printDialog=new PrintDialog();
			printDialog.Document=printDocument;
			if(printDialog.ShowDialog()==DialogResult.OK)
			{
				try
				{
					printDocument.Print();
				}
				catch(Exception e2)
				{
					MessageBox.Show(e2.Message);
				}
			}
		}
		private void printDocument_PrintPage(object sender,PrintPageEventArgs e)
		{
			float linesPerPage=0;
			float yPos=0;
			int count=0;
			float leftMargin=e.MarginBounds.Left;
			float topMargin=e.MarginBounds.Top;
			string line=null;
			StreamReader streamToPrint=new StreamReader(currentFileName);
			SolidBrush brush=new SolidBrush(textBoxEdit.ForeColor);
			linesPerPage=e.MarginBounds.Height/textBoxEdit.Font.GetHeight(e.Graphics);
			while(count<linesPerPage&&((line=streamToPrint.ReadLine())!=null))
			{
				yPos=topMargin+(count*textBoxEdit.Font.GetHeight(e.Graphics));
				e.Graphics.DrawString(line,textBoxEdit.Font,brush,leftMargin,yPos,new StringFormat());
				count++;
			}
			if(line!=null)
			{
				e.HasMorePages=true;
			}
			else
			{
				e.HasMorePages=false;
			}
		}

		private void menuItemPageSet_Click(object sender, System.EventArgs e)
		{
			PageSetupDialog pageSet=new PageSetupDialog();
			pageSet.Document=printDocument;
			pageSet.ShowDialog();
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if(needToSave==true)
			{
				DialogResult result=MessageBox.Show("�ı������Ѿ��ı�,��Ҫ������?","�����ļ�",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if(result==DialogResult.Cancel)
				{
					e.Cancel=true;
					return;
				}
				if(result==DialogResult.Yes)
				{
					menuItemSave_Click(sender,e);
					e.Cancel=false;
					return;
				}
			}
		}

		private void menuItemNew_Click(object sender, System.EventArgs e)
		{
			if(needToSave==true)
			{
				DialogResult result=MessageBox.Show("�ı������Ѿ��ı�,��Ҫ������?","�����ļ�",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				switch(result)
				{
					case DialogResult.Yes:
					{
						menuItemSave_Click(sender,e);
						textBoxEdit.Clear();
						this.Text="�ı��༭--�½��ı�";
						needToSave=false;
						break;
					}
					case DialogResult.No:
					{
						textBoxEdit.Clear();
						this.Text="�ı��༭--�½��ı�";
						needToSave=false;
						break;
					}
					case DialogResult.Cancel:
					{
						break;
					}
				}
			}
			else
			{
				textBoxEdit.Clear();
				this.Text="�ı��༭�½��ı�";
			}
		}
		private void menuItemOpen_Click(object sender, System.EventArgs e)
		{
			if(needToSave==true)
			{
				DialogResult result=MessageBox.Show("�ı������Ѿ��ı�,��Ҫ������?","�����ļ�",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				if(result==DialogResult.Cancel)
				{
					return;
				}
				if(result==DialogResult.Yes)
				{
					menuItemSave_Click(sender,e);
					needToSave=false;
				}
			}
			string file=GetOpenFile();
			if(file==null)
			{
				return;
			}
			else
			{
				currentFileName=file;
				OpenFile();
			}
		}
		private void textBoxEdit_TextChanged(object sender, System.EventArgs e)
		{
			needToSave=true;
		}

//private void menuItemEdit_Select(object sender, EventArgs e)//ԭ��ĿΪ��ʾǰ����ò���е�����
        //{
        //    if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
        //    {
        //        menuItemPaste.Enabled = true;
        //    }
        //    else
        //    {
        //        menuItemPaste.Enabled = false;
        //    }
        //    if (textBoxEdit.SelectionLength > 0)
        //    {
        //        menuItemCopy.Enabled = true;
        //        menuItemCut.Enabled = true;
        //        menuItemDel.Enabled = true;
        //    }
        //    else
        //    {
        //        menuItemCopy.Enabled = false;
        //        menuItemCut.Enabled = false;
        //        menuItemDel.Enabled = false;
        //    }
        //    if (textBoxEdit.CanUndo == true)
        //    {
        //        menuItemUndo.Enabled = true;
        //    }
        //    else
        //    {
        //        menuItemUndo.Enabled = false;
        //    }
        //}
	}
}
