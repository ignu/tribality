<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Tribality.Views.Post.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% 
       var post = ViewData.Model;
       string message = "Edit Post";
       if (post == null)
           post = new BlogPost();
       else
           message = post.Subject;
    %>

    <h1><%=message %></h1>
    <form action="/Post/Save" method="post" id="postForm">
        <input type="hidden" 
            name="PostID" id="<%= Tribality.Models.Binders.PostBinder.FormElements.PostID %>" value="<%= post.ID %>" />
        <input type="text" 
            name="Subject" id="<%= Tribality.Models.Binders.PostBinder.FormElements.Subject %>" value="<%=post.Subject %>"/>
        <br />
        <textarea   
            name="Body" id="Body" rows="10" cols="50"><%= post.Body %></textarea>
        <br />
        <input type="submit" value="Save" class="submitPost"/>
    </form>
</asp:Content>
