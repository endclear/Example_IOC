﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuanLyHangHoa.Models.CT_PhieuXuatModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    ChiTiet
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

<h2>CHI TIẾT PHIẾU XUẤT: <%: ViewBag.Tenphieuxuat %> </h2>
        <% using (Html.BeginForm(FormMethod.Post)) { %>
        <% TempData["url"] ="/PhieuXuat/ChiTiet/"+ ViewBag.phieuxuatid; %>
         <table class="table table-bordered">
            <tr>
                <th style="text-align:center">STT</th>
                <th style="text-align:center">Tên mặt hàng</th>
                <th style="text-align:center">Ngày nhập</th>
                <th style="text-align:center">Số lượng</th>
                <th style="text-align:center">Giá nhập</th>
                <th style="text-align:center">Ghi chú</th>
                <th style="text-align:center">Sửa</th>
                <th style="text-align:center">Xóa</th>
            </tr>
             <% int i = 0;
               foreach(var it in Model)
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
                <td>
                    <a href="#<%:it.id %>"><i class="fas fa-pen"></i></a>
                </td>
                <td>
                     <a href="/PhieuXuat/DeleteChiTiet/<%:it.id %>"><i class="far fa-trash-alt"></i></a>
                </td>
            </tr>
            <%} %>
        </table>
        <% } %>

</asp:Content>
