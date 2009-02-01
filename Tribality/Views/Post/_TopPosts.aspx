<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_TopPosts.aspx.cs" Inherits="Tribality.Views.Post._TopPosts" %>
<div id="postList">
    
    <%var posts = (IList<BlogPost>)ViewData.Model;

    foreach (var post in posts)
    {%>
        <a href="/Post/Show/<%=post.PrettyUrl %>" class="ajaxLink"><%= post.Subject.Replace(" ","&nbsp;") %></a><br />           
    <%}%>

</div>
