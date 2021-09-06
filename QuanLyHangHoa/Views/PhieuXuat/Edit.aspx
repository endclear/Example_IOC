<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyHangHoa.Models.PhieuXuatModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

<div>
        <h2>SỬA PHIẾU XUẤT</h2>
    </div>
<% using (Html.BeginForm()) { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        
        <%: Html.HiddenFor(model => model.id) %>
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
            <label>Khách hàng<label>
        </div>
        <div class="editor-field">
            <%: Html.DropDownList("Khachhangid",(SelectList)TempData["Khachhang"]) %>
        </div>

        <br />
        <p>
            <input type="submit" class="btn btn-success" value="Cập nhật" />
        </p>
    </fieldset>
<% } %>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>

</asp:Content>
