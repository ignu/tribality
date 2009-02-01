<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/No.Master" AutoEventWireup="true" CodeBehind="Entities.aspx.cs" Inherits="Tribality.Content.Entities" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    // TODO: codegen this, make it DRY
    postForm = {        
        getObject: function() {
            rv = new Object();
            rv.PostID = $('#PostID').val();
            rv.Subject = $('#Subject').val();
            rv.Body = $('#Body').val();
            return rv;
        }
    }

</asp:Content>
