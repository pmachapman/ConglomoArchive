<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Conglomo.Archive.Default" EnableViewState="false" EnableSessionState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Conglomo Archives</title>
    <link type="image/vnd.microsoft.icon" rel="shortcut icon" href="~/favicon.ico" />
    <link rel="alternate" href="~/RSS.ashx" type="application/rss+xml" title="Conglomo Archives" id="rss" />
    <!-- Google tag (gtag.js) -->
    <script async src="https://www.googletagmanager.com/gtag/js?id=G-76LVL0YYFX" type="text/javascript"></script>
    <script type="text/javascript">
    window.dataLayer = window.dataLayer || [];
    function gtag() { dataLayer.push(arguments); }
    gtag('js', new Date());
    gtag('config', 'G-76LVL0YYFX');
</script>
</head>
<body>
    <h1>Conglomo Archives</h1>
    <p>Welcome to the Conglomo Public Archives.</p>
    <asp:Repeater runat="server" ID="FileList">
        <ItemTemplate>
            <a href='<%# Eval("Url") %>'><img src='<%# Eval("Icon") %>' alt='<%# Eval("Name") %>' align="absmiddle" height="16" width="16" /></a> <a href='<%# Eval("Url") %>'><%# Eval("Name") %></a><br />
        </ItemTemplate>
    </asp:Repeater>
    <p align="right">&copy; <%= DateTime.Now.Year %> Conglomo Limited</p>
</body>
</html>
