<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="Tribality.Views.PairRequest.List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<%var requests = ViewData.Model;
  foreach (var request in requests){            
%>
<div class="pairRequest">
  <h2><%=request.Owner.UserName %>:
  <%=request.Description %></h2>
  <%=request.Body %>  
  <%=request.Date.ToShortDateString() %>
  <%=request.Date.ToShortTimeString() %>
<%} %></div>
</asp:Content>
