<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="Test.kaoshi.denglu" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>denglu</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<style type="text/css">BODY TD { FONT-SIZE: 12px }
	.zz { FILTER: glow(color=#213a5a,Strength=1); COLOR: #ffffff }
	.front { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.bfront { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.bxfront { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #ffffff; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.frontx { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #00258f; FONT-FAMILY: "����"; TEXT-DECORATION: none }
	.STYLE9 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #133694 }
	.bk2 { BORDER-RIGHT: #8ebeea 1px solid; BORDER-TOP: #8ebeea 1px solid; BORDER-LEFT: #8ebeea 1px solid; BORDER-BOTTOM: #8ebeea 1px solid }
		</style>
	</HEAD>
	<body bgColor="#cde8fb">
		<form id="Form1" method="post" runat="server">
			<P align="center"><FONT color="#3366ff" size="8">���߿���ϵͳ3.0�� </FONT>
			</P>
			<asp:panel id="Panel_dl" runat="server">
				<DIV align="center">
					<TABLE id="Table1" style="WIDTH: 399px; HEIGHT: 124px" borderColor="#ecf6f8" cellSpacing="0"
						cellPadding="0" width="399" border="1">
						<TR>
							<TD style="WIDTH: 49px"><FONT face="����">���</FONT></TD>
							<TD>
								<asp:DropDownList id="DDLdlsf" runat="server" Width="52px">
									<asp:ListItem Value="��ʦ">��ʦ</asp:ListItem>
									<asp:ListItem Value="ѧ��" Selected="True">ѧ��</asp:ListItem>
								</asp:DropDownList><FONT face="����">��ʦ��¼IDΪ�Լ��Ľ�ʦ��,ѧ����¼IDΪ�Լ���ѧ��</FONT></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 49px; HEIGHT: 29px"><FONT face="����">��¼ID</FONT></TD>
							<TD style="HEIGHT: 29px">
								<asp:TextBox id="TXTdldlid" runat="server" Width="146px"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 49px; HEIGHT: 21px"><FONT face="����">����</FONT></TD>
							<TD style="HEIGHT: 21px">
								<asp:TextBox id="TXTdlmm" runat="server" Width="148px" TextMode="Password"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 49px"><FONT face="����"></FONT></TD>
							<TD>
								<asp:Button id="Btndenglu" runat="server" Text="��¼"></asp:Button>
								<asp:Button id="Btnxiugai" runat="server" Width="60px" Text="�޸�����"></asp:Button></TD>
						</TR>
					</TABLE>
				</DIV>
			</asp:panel><asp:panel id="Panel_xgmm" runat="server" Height="64px" Visible="False">
				<DIV align="center">
					<TABLE id="Table2" style="WIDTH: 407px; HEIGHT: 170px" borderColor="#ecf6f8" cellSpacing="0"
						cellPadding="0" width="407" border="1">
						<TR>
							<TD style="WIDTH: 61px; HEIGHT: 17px"><FONT face="����">���</FONT></TD>
							<TD style="HEIGHT: 17px">
								<asp:DropDownList id="DDLxgsf" runat="server" Width="52px">
									<asp:ListItem Value="��ʦ">��ʦ</asp:ListItem>
									<asp:ListItem Value="ѧ��" Selected="True">ѧ��</asp:ListItem>
								</asp:DropDownList></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 61px"><FONT face="����">��¼ID</FONT></TD>
							<TD>
								<asp:TextBox id="TXTxgdlid" runat="server" Width="146px"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 61px"><FONT face="����">������</FONT></TD>
							<TD>
								<asp:TextBox id="TXTxgjmm" runat="server" Width="148px" TextMode="Password"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 61px"><FONT face="����">������</FONT></TD>
							<TD>
								<asp:TextBox id="TXTxgxmm" runat="server" Width="148px" TextMode="Password"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 61px"><FONT face="����">������ȷ��</FONT></TD>
							<TD>
								<asp:TextBox id="TXTxgxmmqr" runat="server" Width="148px" TextMode="Password"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD style="WIDTH: 61px"><FONT face="����"></FONT></TD>
							<TD>
								<asp:Button id="Btnqueren" runat="server" Text="ȷ��"></asp:Button>
								<asp:Button id="Btnfanhui" runat="server" Width="60px" Text="���ص�¼"></asp:Button></TD>
						</TR>
					</TABLE>
				</DIV>
			</asp:panel></form>
	</body>
</HTML>
