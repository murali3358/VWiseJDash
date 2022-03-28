<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
    <xsl:template match="WC:Captain.Common.Views.Controls.FriendlyMessage" mode="modContent">
        <div id="FriendlyMessage_{@ControlID}" name="FriendlyMessage_{@ControlID}" vwgcontrolid="{@ControlID}">
            <xsl:attribute name="style">width:100px; height:100px</xsl:attribute>
        </div>
    </xsl:template>
</xsl:stylesheet>