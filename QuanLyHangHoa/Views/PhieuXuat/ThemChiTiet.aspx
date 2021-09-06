<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.CT_PhieuXuat>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ThemChiTiet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
    <link href="<%:Url.Content("~/Content/themes/base/jquery.ui.datepicker.css") %>rel="stylesheet" type="text/css" />
    <%--<link href="../../Content/themes/base/jquery.ui.datepicker.css" rel="stylesheet" />--%>
    <script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
    <script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.20.min.js" )%>" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            // This will make every element with the class "date-picker" into a DatePicker element
            $('.datepicker').datepicker({
                dateFormat: "dd/mm/yy"
            });
        })
    </script>
<h2>THÊM CHI TIẾT PHIẾU XUẤT</h2>
<div class="row">
    <div class="col-md-4">
            <% using (Html.BeginForm()) { %>
            <%:Html.AntiForgeryToken() %>
            <%: Html.ValidationSummary(true) %>
            <fieldset>
                <%
                    var index = (Core.Entity.PhieuXuat)Session["Phieuxuat"];
                %>

                <%: Html.HiddenFor(model => model.id)%>
                <%: Html.HiddenFor(model => model.PhieuxuatId)%>
                <label class="editor-label font-weight-bold">Tên phiếu xuất: <%:index.Tenphieuxuat %></label>

                <div class="editor-label">
                    <label>Mặt hàng</label>
                </div>
                <div class="editor-field">
                    <%: Html.DropDownList("Hanghoaid",(IEnumerable<SelectListItem>)TempData["hanghoa"])%>
                    <% TempData.Keep("hanghoa"); %>
                </div>

                <div class="editor-label">
                   <label>Ngày bán</label>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Ngayxuat, new { Class= "datepicker",Value = DateTime.Now.ToShortDateString()} )%>
                    <%: Html.ValidationMessageFor(model => model.Ngayxuat) %>
                </div>

                <div class="editor-label">
                   <label>Số lượng</label>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Soluong, new { type="number"})%>
                    <%: Html.ValidationMessageFor(model => model.Soluong) %>
                </div>
        

                <div class="editor-label">
                    <label>Giá bán</label>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(model => model.Giaban, new { type="number"})%>
                    <%: Html.ValidationMessageFor(model => model.Giaban) %>
                </div>
                <br />
                <p>
                    <input type="submit" class="btn btn-success" value="Thêm Chi Tiết" />
                </p>
            </fieldset>
        <% } %>
    </div>

    <div class="col-md-8 mt-3">
        <% var lst = (IEnumerable<QuanLyHangHoa.Models.CT_PhieuXuatModel>)TempData["ct_phieuxuatmodel"];
           TempData.Keep("ct_phieuxuatmodel");
            %>
        <%if(lst!=null&&Session["Phieuxuat"]!=null) 
          {%>
        <% using (Html.BeginForm(FormMethod.Post)) { %>
        <% TempData["url"] = "/PhieuXuat/ThemChiTiet/"; %>
        <h5>Chi tiết phiếu xuất</h5>
         <table class="table table-bordered">
            <tr>
                <th style="text-align:center">STT</th>
                <th style="text-align:center">Tên mặt hàng</th>
                <th style="text-align:center">Ngày xuất</th>
                <th style="text-align:center">Số lượng</th>
                <th style="text-align:center">Giá bán</th>
                <th style="text-align:center">Ghi chú</th>
                <%--<th style="text-align:center">Sửa</th>--%>
                <th style="text-align:center">Xóa</th>
            </tr>
             <% int i = 0;
               foreach(var it in lst)
               {
                   i++;
            %>
            <tr style="text-align: center">
                <td><%: i %></td>
                <td><%: it.Tenmathang %></td>
                <td><%: it.Ngayxuat.ToString("dd/MM/yyyy") %></td>
                <td><%: it.Soluong %></td>
                <td><%: it.Giaban %></td>
                <td><%: it.Ghichu %></td>
                <%--<td>
                    <a href="/PhieuXuat/Edit/<%:it.id %>"><i class="fas fa-pen"></i></a>
                </td>--%>
                <td>
                     <a href="/PhieuXuat/DeleteChiTiet/<%:it.id %>"><i class="far fa-trash-alt"></i></a>
                </td>
            </tr>
            <%} %>
        </table>
        <% } %>
        <%} %>
        <div>
</div>
    </div>

</div>

<div>
    <%: Html.ActionLink("Back to List", "Index") %>
</div>
</asp:Content>
