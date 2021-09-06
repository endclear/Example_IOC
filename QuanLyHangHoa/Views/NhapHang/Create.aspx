<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.PhieuNhap>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
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
            $('.Ngaynhap').val({
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
     <h5 class="text-center text-dark font-weight-bold">NHẬP THÔNG TIN VỀ PHIẾU NHẬP</h5>
    <% using (Html.BeginForm("Create","NhapHang",FormMethod.Post,new { @id = "Mainform"}))
       { %>
        <%: Html.Hidden("PubDatasource")%>

        <div class="row mt-3">
            <div class="col-md-8">
                <div class="row font-weight-bold text-dark">
                    <div class="col-3">
                        <label>Tên phiếu nhập: </label>
                    </div>
                    <div class="col-9">
                        <input class="input-create" type="text" name="Tenphieunhap" id="Tenphieunhap" required />
                    </div>
                </div>
                <div class="row font-weight-bold text-dark">
                    <div class="col-md-3">
                        <label>Mô tả: </label>
                    </div>
                    <div class="col-md-9">
                        <input  class="input-create" type="text" name="Mota" id="Mota" />
                    </div>
                </div>
            </div>

            <div class="col-md-4">
                <div class="row font-weight-bold text-dark">
                    <div class="col-4">
                        <label>Công ty: </label>
                    </div>
                    <div class="col-8">
                        <%: Html.DropDownList("Congtyid", (IEnumerable<SelectListItem>)TempData["Congty"])%>
                        <% TempData.Keep("Congty"); %>
                    </div>
                </div>
            </div>
            
        </div>
        <div class="mt-3">
            <table id="myTable" class="table table-hover border products">
                <thead>
                    <tr class="table-info">
                        <th style="text-align:center">STT</th>
                        <th style="text-align:center">Mặt hàng</th>
                        <th style="text-align:center">Số lượng</th>
                        <th style="text-align:center">Giá nhập</th>
                        <th style="text-align:center">Thành tiền</th>
                        <th style="text-align:center">Ngày nhập</th>
                        <th style="text-align:center">Xóa</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                           for (int i = 1; i < 6; i++)
                           {
                                var date = DateTime.Now;
                    %>
                        <tr style="text-align: center">
                            <td><%:i%></td>
                            <td>
                                <%: Html.DropDownList("Hanghoaid", (IEnumerable<SelectListItem>)TempData["Hanghoa"], new { @class = "input-create ddlList" })%>
                                <% TempData.Keep("Hanghoa"); %>
                            </td>
                            <td>
                                <input name="Soluong" type="number" class="input-create soluong"/>
                            </td>
                            <td>
                                <input name="Gianhap" type="number" class="input-create gianhap"/>
                            </td>
                            <td>
                                <input name="Thanhtien" type="number" class="input-create thanhtien" readonly="readonly"/>
                            </td>
                            <td>
                                <input name="ngaynhap" type="text" class="input-create ngaynhap" readonly="readonly"/>
                            </td>
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
            <input type="submit" class="btn btn-info" value="Tạo mới" />
            <button class="btn btn-info" onclick="parent.location='/NhapHang'">Quay lại</button>
        </div>
        
    <%} %>
    <script type="text/javascript">
        $("table.products tbody tr").each(function (i, row) {
            var _pSoluong = $(row).find("input[type=number].soluong");
            var _pGianhap = $(row).find("input[type=number].gianhap");
            var _pThanhtien = $(row).find("input[type=number].thanhtien");
            var _pNgaynhap = $(row).find("input[type=text].ngaynhap");
            
            _pSoluong.change(function () {
                var today = new Date();
                var date = (today.getMonth()+1) + '/' + today.getDate() + '/' + today.getFullYear();
                var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
                var dateTime = date + ' ' + time;
                _pThanhtien.val(_pSoluong.val() * _pGianhap.val());
                _pNgaynhap.val(dateTime);
            });

            _pGianhap.change(function () {
                var today = new Date();
                var date = (today.getMonth() + 1) + '/' + today.getDate() + '/' + today.getFullYear();
                var time = today.getHours() + ":" + today.getMinutes() + ":" + today.getSeconds();
                var dateTime = date + ' ' + time;
                _pThanhtien.val(_pSoluong.val() * _pGianhap.val());
                _pNgaynhap.val(dateTime);
            })
        });
        $('#Mainform').submit(function () {
            
            var _products2 = [];
            $("table.products tbody tr").each(function (i, row) {
                var _product2 = {};
                var _pHanghoaid = $(row).find(".ddlList");
                var _pSoluong = $(row).find("input[type=number].soluong");
                var _pGianhap = $(row).find("input[type=number].gianhap");
                var _pNgaynhap = $(row).find("input[type=text].ngaynhap");
                if (_pSoluong.val() && _pGianhap.val()) {
                    _product2.Hanghoaid = _pHanghoaid.val();
                    _product2.Soluong = _pSoluong.val();
                    _product2.Gianhap = _pGianhap.val();
                    _product2.Ngaynhap = _pNgaynhap.val();
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
