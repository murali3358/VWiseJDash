<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:Captain.Common.Views.Controls.ScriptManagerControl" mode="modContent">
    <div id="ScriptManagerControl_{@ControlID}" name="ScriptManagerControl_{@ControlID}" style="display: none" vwgcommand="{@Command}" vwgcontrolname="{@ControlName}" vwgwincontrolguid="{@WinControlGuid}" ></div>
  </xsl:template>
  
</xsl:stylesheet>