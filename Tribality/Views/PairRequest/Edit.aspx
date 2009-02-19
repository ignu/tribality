<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" MasterPageFile="~/Views/Shared/No.Master" %>
<asp:Content ID="content" ContentPlaceHolderID="MainContent" runat="server">
<form action="/PairRequest/Save">
    Add Request:<br />
    <div>
        Title:<br />
        <input type="text" id="title" size="52" />
    </div>
    <div>
        More Details:<br />
        <textarea id="body" cols="40" rows="9"></textarea>
    </div>
    <div>
        Language:<br />
        <select id="langauge">
            <option value="">-- select --</option>
        <% foreach (var language in (IList<Language>)Model)
           {%>
                <option id="<%=language.ID %>"><%=language.Name %></option>
        <% } %>
        </select>
    </div>
    <input type="submit" value="Submit" />
</form>    
</asp:Content>