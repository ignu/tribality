<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_Add.aspx.cs" Inherits="Tribality.Views.Comment._Add" %>
<%@ Import Namespace="Tribality.Models.Binders"%>

<div id="newCommentDiv">
    
    <h3>Comment:</h3>
    
    <textarea type="text" id="<%= CommentBinder.FormElements.Body%>"></textarea>
    
    <br />
    
    <input type="button" id="submitComment" value="Post" />

</div>