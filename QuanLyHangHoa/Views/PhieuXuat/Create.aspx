<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.PhieuXuat>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

 <div>
        <h2>THÊM PHIẾU XUẤT</h2>
    </div>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        

        <div class="editor-label">
            <label>Tên phiếu xuất</label>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Tenphieuxuat) %>
            <%: Html.ValidationMessageFor(model => model.Tenphieuxuat) %>
        </div>

        <div class="editor-label">
             <label>Mô tả</label>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Mota) %>
            <%: Html.ValidationMessageFor(model => model.Mota) %>
        </div>

        <div class="editor-label">
            <label>Khách Hàng<label>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("Khachhangid",(SelectList)ViewBag.Khachhang) %>
        </div>

        <br />
        <p>
            <input type="submit" class="btn btn-success" value="Thêm Chi Tiết" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
