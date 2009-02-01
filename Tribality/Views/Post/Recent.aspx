<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Recent.aspx.cs" Inherits="Tribality.Views.Post.Recent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<%var posts = (IList<BlogPost>)ViewData.Model; %>

<%
    foreach(var post in posts)
    {
        Html.RenderPartial("_View", post);
    }    
%>
</asp:Content>
