<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Conglomo.Archive.Default" EnableViewState="false" EnableSessionState="False" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<html>
<head runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <title>Conglomo Archives</title>
    <link type="image/vnd.microsoft.icon" rel="shortcut icon" href="~/favicon.ico" />
    <link rel="alternate" href="~/RSS.ashx" type="application/rss+xml" title="Conglomo Archives" id="rss" />
    <script type="text/javascript">
        window.appInsights = { queue: [], applicationInsightsId: null, accountId: null, appUserId: null, configUrl: null, start: function (n) { function u(n, t) { n[t] = function () { var i = arguments; n.queue.push(function () { n[t].apply(n, i) }) } } function f(n) { var t = document.createElement("script"); return t.type = "text/javascript", t.src = n, t.async = !0, t } function r() { i.appendChild(f("//az416426.vo.msecnd.net/scripts/ai.0.js")) } var i, t; this.applicationInsightsId = n; u(this, "logEvent"); u(this, "logPageView"); i = document.getElementsByTagName("script")[0].parentNode; this.configUrl === null ? r() : (t = f(this.configUrl), t.onload = r, t.onerror = r, i.appendChild(t)); this.start = function () { } } };
        appInsights.start("7d8658a4-e9cd-4ea1-9b37-5fea83e692e7");
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
