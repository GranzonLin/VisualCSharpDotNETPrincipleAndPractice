<?xml version="1.0" encoding="GB2312" ?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/TR/WD-xsl">
<xsl:template match="/">
<html><body>
<center><h2>�鼮��Ϣ</h2></center>
<div align="center"><center>
<table border="1" cellpadding="5" bgcolor="#4EB7DE">
<tr>
<th>����</th><th>����</th><th>�۸�(�����)</th>
<th>��ע</th>
</tr>

<xsl:for-each select="data/book" order-by="title">
<tr>
<td><xsl:value-of select="title"/></td>
<td><xsl:value-of select="author"/></td>
<td><xsl:value-of select="price"/></td>
<td width="150"><xsl:value-of select="memo"/></td>
</tr>
</xsl:for-each>
</table>
</center></div>
</body></html>
</xsl:template>
</xsl:stylesheet>
