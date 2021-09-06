<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuanLyHangHoa.Models.HangHoaModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link type="text/css" rel="Stylesheet" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" />
 <style>
     .btn
        {
            border-radius: 10px;
            box-shadow: 0 2px 3px rgb(0 0 0 / 30%);
        }
    a.btn
        {
            border-radius: 10px;
            box-shadow: 0 2px 3px rgb(0 0 0 / 30%);
            color:#00abff;
        }
        table, th, td {
            border-bottom:1px solid #ccc;
            border-collapse: collapse;
        }
    </style>

   <div style="text-align: center; margin: 20px">
        <h4 class="font-weight-bold text-dark">QUẢN LÝ MẶT HÀNG</h4>
    </div>
    <div style="margin-top: 20px;">
        <button style="float:right;margin: 10px; font-size: 13px" class="btn btn-info" onclick="parent.location='/HangHoa/Create'">Tạo mới</button>
        <table id="myTable" class="table table-hover table-striped">
            <thead class="table-info">
                <tr>
                    <th style="text-align:center">STT</th>
                    <th style="text-align:center">Mã hàng</th>
                    <th style="text-align:center">Tên hàng</th>
                    <th style="text-align:center">Quốc gia</th>
                    <th style="text-align:center">Mô tả</th>
                    <th style="text-align:center">Sửa</th>
                    <th style="text-align:center">Xóa</th>
                </tr>
            </thead>
            <tbody>
                <% int i = 0;
                   foreach (var it in Model)
                   {
                       i++;
                %>
                <tr style="text-align: center">
                    <td><%: i %></td>
                    <td><%: it.Mahang %></td>
                    <td><%: it.Tenhang %></td>
                    <td><%: it.Tenquocgia %></td>
                    <td><%: it.Mota %></td>
                    <td>
                        <a class="btn" href="/HangHoa/Edit/<%:it.id %>"><i class="fas fa-pen"></i></a>
                    </td>
                    <td>
                         <a class="btn glyphicon glyphicon-trash" onclick= "return delete_infor(<%:it.id %>)"  data-toggle="modal" data-target="#myModal1"><i class="far fa-trash-alt"></i></a>
                    </td>
                </tr>
                <%} %>
            </tbody>
            
        </table>
    </div>

    <%--confirm delete--%>
    <div class="modal fade" id="myModal1">
         <div class="modal-dialog">
            <div class="modal-content">
               <!-- Modal Header -->
               <div class="modal-header">
                  <h4 class="modal-title">Xác nhận xóa</h4>
                  <button type="button" class="close" data-dismiss="modal">&times;</button>
               </div>
               <!-- Modal body -->
               <div class="modal-body">
                  Bạn có chắc muốn xóa thông công ty này không?
               </div>
               <!-- Modal footer -->
               <div class="modal-footer">
                  <button id="btn_delete_infor" type="button" class="btn btn-info" data-dismiss="modal">Xóa</button>
               </div>
            </div>
         </div>
      </div>


    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="<%: Url.Content("~/Content/bootstrap-4.6.0-dist/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#myTable').DataTable({
                "pageLength": 5,
                "language": {
                    "lengthMenu": 'Display <select>' +
                    '<option value="5">5</option>' +
                    '<option value="10">10</option>' +
                    '<option value="20">20</option>' +
                    '<option value="30">30</option>' +
                    '<option value="-1">All</option>' +
                    '</select> records'
                }
            });
        });
        function delete_infor(id) {
            $("#btn_delete_infor").click(function () {
                $.ajax({
                    url: '/HangHoa/Delete',
                    data: { id: id },
                    type: 'GET',
                    dataType: 'json',
                    success: location.href = '/HangHoa/Index',
                });
            });
        }
    </script>
</asp:Content>
