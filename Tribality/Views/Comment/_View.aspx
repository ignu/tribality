<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_View.aspx.cs" Inherits="Tribality.Views.Comment._Comment" %>
<% Comment comment = (Comment) ViewData.Model; %>


<%= comment.Body %>
<div class="commentInfo"><%= comment.Poster %> at <%= comment.Date.ToString() %></div>