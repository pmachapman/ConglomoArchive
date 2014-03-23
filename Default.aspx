<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Conglomo.Archive.Default" EnableViewState="false" EnableSessionState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Conglomo Archives</title>
    <link type="image/vnd.microsoft.icon" rel="shortcut icon" href="~/favicon.ico" />
    <link rel="alternate" href="~/RSS.ashx" type="application/rss+xml" title="Conglomo Archives" id="rss" />
    <script type="text/javascript">
        var appInsights = { queue: [], start: function (n) { function r(n, t) { n[t] = function () { var i = arguments; n.queue.push(function () { n[t].apply(n, i) }) } } var t, i; this.applicationInsightsId = n; this.accountId = null; this.appUserId = null; r(this, "logEvent"); r(this, "logPageView"); t = document.createElement("script"); t.type = "text/javascript"; t.src = "//az416426.vo.msecnd.net/scripts/ai.js"; t.async = !0; i = document.getElementsByTagName("script")[0]; i.parentNode.insertBefore(t, i) } };
        appInsights.start("75c0d219-f46e-4490-bd89-c4ef138fc566");
        appInsights.logPageView();
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
    <p align="right">&copy; <%= DateTime.Now.Year %> Peter Chapman</p>
    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-27223871-2']);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();
    </script>
</body>
</html>
