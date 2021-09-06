<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuanLyHangHoa.Models.PhieuNhapModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    
    <style>
        table, th, td {
            border: 1px solid black;
            border-collapse: collapse;
        }
    </style>

    <div style="text-align: center; margin: 20px">
        <h3>QUẢN LÝ NHẬP HÀNG</h3>
    </div>

    <%--confirm delete--%>
    <div class="modal fade" id="myModal">
         <div class="modal-dialog">
            <div class="modal-content">
               <!-- Modal Header -->
               <div class="modal-header">
                  <h4 class="modal-title">Xác nhận xóa</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
               </div>
               <!-- Modal body -->
               <div class="modal-body">
                  Bạn có muốn xóa phiếu nhập và chi tiết phiếu nhập này không?
               </div>
               <!-- Modal footer -->
               <div class="modal-footer">
                  <button id="btn_delete_infor" type="button" class="btn btn-info" data-dismiss="modal">Xóa</button>
               </div>
            </div>
         </div>
      </div>


    <div style="margin-top: 20px;">
        <button style="margin: 20px; font-size: 13px" class="btn btn-info" onclick="parent.location='/PhieuNhap/Create'">Tạo mới</button>
        <table class="table table-bordered ">
            <tr>
                <th style="text-align:center">STT</th>
                <th style="text-align:center">Tên phiếu nhập</th>
                <th style="text-align:center">Mô tả</th>
                <th style="text-align:center">Công ty</th>
                <th style="text-align:center">Chi tiết</th>
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
                <td><%: it.Tenphieunhap %></td>
                <td><%: it.Mota %></td>
                <td><%: it.Tencongty %></td>
                <td>
                    <a href="/PhieuNhap/ChiTiet/<%:it.id %>"><i class="fas fa-info" title="Chi tiết"></i></a>
                </td>
                <td>
                    <a href="/PhieuNhap/Edit/<%:it.id %>" <%--class="btn" data-toggle="modal" data-target="#myModal"--%>><i class="fas fa-pen" title="Sửa"></i></a>
                </td>
                <td>
                     <a onclick= "return delete_infor(<%:it.id %>) " class="btn" data-toggle="modal" data-target="#myModal"><i class="far fa-trash-alt"></i></a>
                </td>
            </tr>
            <%} %>
        </table>
    </div>
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="<%: Url.Content("~/Content/bootstrap-4.6.0-dist/js/bootstrap.min.js") %>" type="text/javascript"></script>

    <script type="text/javascript">
        function delete_infor(id) {
            $("#btn_delete_infor").click(function () {
                $.ajax({
                    url: '/PhieuNhap/Delete',
                    data: { id: id },
                    type: 'GET',
                    dataType: 'json',
                    success:location.href='/PhieuNhap',
                });
            });
        }
    </script>
    <%--<script type="text/javascript">
        $(".delete_phieunhap").click(function () {
            $("#popup_confirm").show();
        });
        $("#close").click(AnForm);
        function AnForm() {
            $("#popup_confirm").hide();
        }
    </script>--%>

</asp:Content>
