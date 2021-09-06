<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.QuocGia>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2>Sửa quốc gia</h2>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>

        <%: Html.HiddenFor(model => model.id) %>

        <div class="editor-label">
             <label>Mã quốc gia</label> 
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.MaQuocGia) %>
            <%: Html.ValidationMessageFor(model => model.MaQuocGia) %>
        </div>

        <div class="editor-label">
            <label>Tên quốc gia</label> 
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.TenQuocGia) %>
            <%: Html.ValidationMessageFor(model => model.TenQuocGia) %>
        </div>

       
        <p>
            <input style="margin-top:10px;" type="submit" class="btn btn-success" value="Save" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
