<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">
    <xsl:template match="WC:Captain.Common.Views.Controls.Line" mode="modContent">
        <xsl:attribute name="Class">Common-FontData  Line-Control</xsl:attribute>
        <xsl:if test="@LineOrientation = 'Horizontal'">
            <xsl:attribute name="style">width: <xsl:value-of select="@W"/><xsl:value-of select="@WidthUnit"/>;height: <xsl:value-of select="@LineThickness"/>;<xsl:call-template name="tplApplyPaddings"/></xsl:attribute>
        </xsl:if>
        <xsl:if test="@LineOrientation = 'Vertical'">
            <xsl:attribute name="style">width: <xsl:value-of select="@LineThickness"/>; height: <xsl:value-of select="@H"/>; <xsl:call-template name="tplApplyPaddings"/></xsl:attribute>
        </xsl:if>
        <div>
            <xsl:if test="@LineOrientation = 'Horizontal'">
                <xsl:attribute name="style">width: <xsl:value-of select="@W"/><xsl:value-of select="@WidthUnit"/>; height: <xsl:value-of select="@LineThickness"/>; border-bottom-style: <xsl:value-of select="@LineStyle"/>; border-bottom-width: <xsl:value-of select="@LineThickness"/>;border-bottom-color:#<xsl:value-of select="@LineColor"/>; background-color: transparent;</xsl:attribute>
            </xsl:if>
            <xsl:if test="@LineOrientation = 'Vertical'">
                <xsl:attribute name="style">width: <xsl:value-of select="@LineThickness"/>; height: <xsl:value-of select="@H"/>; border-left-style: <xsl:value-of select="@LineStyle"/>; border-left-width: <xsl:value-of select="@LineThickness"/>; border-left-color: #<xsl:value-of select="@LineColor"/>; background-color: transparent;</xsl:attribute>
            </xsl:if>
        </div>
    </xsl:template>
</xsl:stylesheet>