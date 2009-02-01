<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="Tribality.Views.Post.View" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%var post = ViewData.Model; %>

        <div id="postDiv" postID="<%=post.ID %>">
        
        <h1><%=post.Subject %></h1><p />

        <%=post.Body %>
    
       <div id="CommentDiv" style="cursor:pointer;">
        <% foreach (var comment in post.Comments) {
               Html.RenderPartial("~/Views/Comment/_View.aspx", comment);
           } %>
           
       <span class="link" id="addComment">Add Comment</span>        
       </div> 
    </div>        
</asp:Content>
