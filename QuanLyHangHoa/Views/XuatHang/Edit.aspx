<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyHangHoa.Models.PhieuXuatModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

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
            $('.Ngayxuat').val({
                dateFormat: "dd/mm/yy"
            });
        })

    </script>
    <style>
        .btn
        {
            border-radius: 10px;
            box-shadow: 0 2px 3px rgb(0 0 0 / 30%);
        }
         a.btn
        {
            color:#00abff;
        }
        .input-create
        {
            border:none;
            outline:none;
            border-bottom: 1px dashed #808080;
            width:100%;
            background-color:transparent;
        }
        .ddlList {
            -webkit-appearance: none;
            -moz-appearance: none;
            text-indent: 1px;
            text-overflow: "";
        }
        .table, td, th
        {
            border:1px solid #d1d1d1;
        }   
    </style>
     <h5 class="text-center text-dark font-weight-bold">SỬA THÔNG TIN VỀ PHIẾU XUẤT</h5>
    <% using (Html.BeginForm("Edit","XuatHang",FormMethod.Post,new { @id = "Mainform"}))
       { %>
        <%: Html.Hidden("PubDatasource")%>
       <% var date = DateTime.Now.ToString("dd/MM/yyyy"); %>
        <div class="row mt-3">
            <div class="col-md-8">
                <%: Html.HiddenFor(model => model.id) %>
                <div class="row font-weight-bold text-dark">
                    <div class="col-3">
                        <label>Tên phiếu xuất: </label>
                    </div>
                    <div class="col-9">
                        <%:Html.TextBoxFor(model => model.Tenphieuxuat, new { @class = "input-create" })%>
                    </div>
                </div>
                <div class="row font-weight-bold text-dark">
                    <div class="col-md-3">
                        <label>Mô tả: </label>
                    </div>
                    <div class="col-md-9">
                        <%:Html.TextBoxFor(model => model.Mota, new { @class = "input-create" })%>
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="row font-weight-bold text-dark">
                    <div class="col-5">
                        <label>Khách hàng: </label>
                    </div>
                    <div class="col-7">
                        <%: Html.DropDownList("Khachhangid", (IEnumerable<SelectListItem>)TempData["Khachhang"])%>
                        <% TempData.Keep("Khachhang"); %>
                    </div>
                </div>
            </div>
            
        </div>
        <div class="mt-3">
            <table id="myTable" class="table table-hover border products">
                <thead>
                    <tr class="table-info">
                        <th>STT</th>
                        <th>Mặt hàng</th>
                        <th>Số lượng</th>
                        <th>Giá bán</th>
                        <th>Thành tiền</th>
                        <th>Xóa</th>
                    </tr>
                </thead>
                <tbody id="rowdata">
                    <%  int i = 0;
                         var lst = (IEnumerable<QuanLyHangHoa.Models.CT_PhieuXuatModel>)TempData["CT_phieuxuat"];
                           foreach (var it in lst)
                           {
                               i++;
                               var selected = new SelectList(ViewBag.listhanghoa, "id", "tenhang", it.Tenmathang);
                    %>
                        <tr>
                            <td><%:i%><input type="hidden" class="id_CtPhieu" value="<%:it.id %>" /></td>
                            <td>
                                <%: Html.DropDownList("Hanghoaid", (IEnumerable<SelectListItem>)selected, new { @class = "input-create ddlList",disabled="disabled"})%>
                                <% TempData.Keep("Hanghoa"); %>
                            </td>
                            <td>
                                <%:Html.TextBoxFor(model => it.Soluong, new { @class = "input-create soluong",type = "number" })%>
                            </td>
                            <td>
                                <%:Html.TextBoxFor(model => it.Giaban, new { @class = "input-create giaban",type = "number" })%>
                            </td>
                            <td>
                                <input name="Thanhtien" type="number" class="input-create thanhtien" readonly="readonly" value="<%: it.Giaban * it.Soluong %>"/>
                            </td>
                            <input name="ngayxuat" type="hidden" class="input-create ngayxuat" readonly="readonly" value="<%:it.Ngayxuat %>" />
                            <td>
                                 <a class="btn" data-toggle="modal" data-target="#myModal"><i class="far fa-trash-alt"></i></a>
                            </td>
                        </tr>
                    <%} %>
                </tbody>
            </table>
        </div>

        <div class="col-md-12 mt-2 text-center">
            <input type="reset" class="btn btn-info" value="Làm lại" />
            <input type="submit" class="btn btn-info" value="Cập nhật" />
            <button class="btn btn-info" onclick="parent.location='/XuatHang'">Quay lại</button>
        </div>
        
    <%} %>
    <script type="text/javascript">
        $("table.products tbody tr").each(function (i, row) {
            var _pSoluong = $(row).find("input[type=number].soluong");
            var _pGiaban = $(row).find("input[type=number].giaban");
            var _pThanhtien = $(row).find("input[type=number].thanhtien");

            _pSoluong.change(function () {
                _pThanhtien.val(_pSoluong.val() * _pGiaban.val());
            });

            _pGiaban.change(function () {
                _pThanhtien.val(_pSoluong.val() * _pGiaban.val());
            })
        });

        $('#Mainform').submit(function () {

            var _products2 = [];
            $("table.products tbody tr").each(function (i, row) {
                var _product2 = {};
                var _pId = $(row).find(".id_CtPhieu");
                var _pHanghoaid = $(row).find(".ddlList");
                var _pSoluong = $(row).find("input[type=number].soluong");
                var _pGiaban = $(row).find("input[type=number].giaban");
                var _pNgayxuat = $(row).find("input[type=hidden].ngayxuat");
                if (_pSoluong.val() && _pGiaban.val()) {
                    _product2.id = _pId.val();
                    _product2.PhieuxuatId = $("#id").val();
                    _product2.HanghoaId = _pHanghoaid.val();
                    _product2.Soluong = _pSoluong.val();
                    _product2.Giaban = _pGiaban.val();
                    _product2.Ngayxuat = _pNgayxuat.val();
                    _products2.push(_product2);
                }

            });
            //alert($("#PubDatasource").val());
            $("#PubDatasource").val(JSON.stringify(_products2));
        });

        //$('#Mainform').submit(function () {
        //    $("#PubDatasource").val(JSON.stringify(_products2));
        //    debugger;
        //});

    </script>

</asp:Content>
