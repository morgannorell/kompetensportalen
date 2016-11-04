<?xml version='1.0'?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    version="1.0">
  <xsl:template match="/">
 
        <table cellspacing="3" cellpadding="8">
          <tr bgcolor="#AAAAAA">
            <td class="heading">
              <strong>Fråga</strong>
            </td>
            <td class="heading">
              <strong>Rätt svar</strong>
            </td>
            <td class="heading">
              <strong>Ditt svar</strong>
            </td>
            <td class="heading">
              <strong>Svar 1</strong>
            </td>
            <td class="heading">
              <strong>Svar 2</strong>
            </td>
            <td class="heading">
              <strong>Svar 3</strong>
            </td>
            <td class="heading">
              <strong>Svar 4</strong>
            </td>
          </tr>
          <xsl:for-each select="Prov/Kategori">
            <tr bgcolor="#DDDDDD">
              <td width="90%" valign="top">
                <xsl:value-of select="Fråga"/>
              </td>
              <td width="90%" valign="top">
                <xsl:value-of select="RättSvar"/>
              </td>
              <td width="90%" valign="top">
                <strong>
                  <xsl:value-of select="MarkeratSvar"/>
                </strong>
              </td>
              <xsl:for-each select="Prov/Kategori/Fråga">
                <td width="90%" valign="top">
                  <strong>
                    <xsl:value-of select="SvarEtt"/>
                  </strong>
                </td>
                <td width="90%" valign="top">
                  <strong>
                    <xsl:value-of select="SvarTvå"/>
                  </strong>
                </td>
                <td width="90%" valign="top">
                  <strong>
                    <xsl:value-of select="SvarTre"/>
                  </strong>
                </td>
                <td width="90%" valign="top">
                  <strong>
                    <xsl:value-of select="SvarFyra"/>
                  </strong>
                </td>
              </xsl:for-each>  
            </tr>
          </xsl:for-each>
        </table>
 
  </xsl:template>
</xsl:stylesheet>
