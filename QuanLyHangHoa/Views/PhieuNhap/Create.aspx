<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.PhieuNhap>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <div>
        <h2>THÊM PHIẾU NHẬP</h2>
    </div>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        

        <div class="editor-label">
            <label>Tên phiếu nhập</label>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Tenphieunhap) %>
            <%: Html.ValidationMessageFor(model => model.Tenphieunhap) %>
        </div>

        <div class="editor-label">
             <label>Mô tả</label>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Mota) %>
            <%: Html.ValidationMessageFor(model => model.Mota) %>
        </div>

        <div class="editor-label">
            <label>Công ty<label>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("Congtyid",(SelectList)ViewBag.Congty) %>
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
