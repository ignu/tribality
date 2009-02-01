<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Display.aspx.cs" Inherits="Tribality.Views.Profile.Display" %>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <% Tribality.Models.User user = ViewData.Model; %>
    
    <h1><%=user.UserName %></h1>
</asp:Content>
