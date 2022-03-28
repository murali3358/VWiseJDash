<?xml version="1.0" encoding="UTF-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:WC="wgcontrols">

  <xsl:template match="WC:ViewPoint.Common.Views.Controls.ModalPopupControl" mode="modContent">
    <xsl:attribute name="Class">Common-FontData  ModalPopupControl-Control</xsl:attribute>
      <div id="VgwModalPopup_{@Id}" style="width:100%;height:100%;overflow:hidden;position:absolute;top:0px;left:0px;visibility:hidden;z-index:390;">
          <iframe id="VgwModalPopup" frameborder="0" src="blank.html" style="margin: 0px auto;width:300px;height:170px;position:absolute;left:41%;top:35%;float:left;filter:progid:DXImageTransform.Microsoft.Shadow(color:gray, strength:5, direction:135);"></iframe>
      </div>
  </xsl:template>
  
</xsl:stylesheet>