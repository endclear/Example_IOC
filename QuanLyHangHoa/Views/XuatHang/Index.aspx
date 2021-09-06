<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<QuanLyHangHoa.Models.PhieuXuatModel>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">

<link type="text/css" rel="Stylesheet" href="https://cdn.datatables.net/1.10.25/css/jquery.dataTables.min.css" />
   
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
        tr, th {
            border-bottom:1px solid #ccc;
            border-collapse: collapse;
            font-weight:normal;
        }
        .lbl
        {
                font-size: 14px;
                font-family: Arial, Helvetica, sans-serif;
                color: #414141;
                font-weight:bold;
        }
        .modal label
        {
            font-family:'Times New Roman';
            font-size:16px;
            color:#3C428C;
        }
        .input-create
        {
            font-family:Arial;
            font-size:1rem;
            border:none;
            outline:none;
            border-bottom: 1px dashed #808080;
            width:100%;
            background-color:transparent;
        }
        .fade {
            transition: opacity .25s linear;
            transition-property: opacity;
            transition-duration: 0.25s;
            transition-timing-function: linear;
            transition-delay: 0.1s;
        }
        .table td, .table th
        {
            padding: .5rem;
        }
        #myModal2
        {
            font-family:Arial;
            color:#212529;
        }
    </style>

    <div style="text-align: center; margin: 20px">
        <h4 class="font-weight-bold text-dark">QUẢN LÝ XUẤT HÀNG 2</h4>
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
                  Bạn có muốn xóa phiếu xuất và chi tiết phiếu xuất này không?
               </div>
               <!-- Modal footer -->
               <div class="modal-footer">
                  <button id="btn_delete_infor" type="button" class="btn btn-info" data-dismiss="modal">Xóa</button>
               </div>
            </div>
         </div>
      </div>

    <%--chi tiết--%>
    <div id="viewBill">
        <div class="modal fade" id="myModal2">
         <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="border border-dark p-1 m-5">
                    <div class="modal-header border-bottom-0 pb-0" style="display:block">
                      <h4 class="modal-title text-center " style="font-family:'Times New Roman';font-weight:bold;color:red;font-size:25px">HÓA ĐƠN XUẤT HÀNG</h4>
                      <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                   </div>
                   <!-- Modal body -->

                    <div class="text-center">
                        <small id="date"></small>
                    </div>
                   <div class="modal-body row pt-0 mt-3">
                       <div class="col-12">
                           <div>
                               <label class="font-weight-bold col-3">Tên hóa đơn: </label>
                               <input class=" input-create col-8" id="tenphieu" name="Tenphieu" readonly="readonly"/>
                           </div>
                           <div class="mt-1">
                               <label class="font-weight-bold col-3">Mã số: </label>
                               <input class="input-create col-8" id="idphieu" name="idphieu" readonly="readonly"/>
                           </div>
                           <div class="mt-1">
                               <label class="font-weight-bold col-3">Khách hàng: </label>
                               <input class=" input-create col-8" id="khachhang" name="khachhang" readonly="readonly"/>
                           </div>
                       </div>

                       <div class="col-12">
                           <table id="details" class="table table-bordered details">
                               <thead>
                                   <tr class="bg-light">
                                       <th>Mặt hàng</th>
                                       <th>Số lượng</th>
                                       <th>Giá bán</th>
                                       <th>Thành tiền (VND)</th>
                                   </tr>
                               </thead>
                               <tbody id="rowDetail">
                                 
                               </tbody>
                           </table>

                           <div>
                               <span class="col-2 font-italic">Bằng chữ:</span><input id="AmountInWord"  type="text" readonly="readonly" class="input-create col-10" value="" />
                           </div>
                           <div class="row mt-4 pl-3 pr-3">
                               <div class="col-4">Người lập</div>
                               <div class="text-right col-8">Người mua hàng</div>
                               <div style="height:50px"></div>
                           </div>
                       </div>
                   </div>
                </div>
               <!-- Modal Header -->
               
               <!-- Modal footer -->
               <div class="modal-footer border-top-0 p-1 mr-2">
                  <button id="Button1" type="button" class="btn btn-info">In</button>
               </div>
            </div>
         </div>
      </div>
    </div>
    
    
    
    <%--<% using(Html.BeginForm("Search","NhapHang")) {%>
        <div class="row border p-4" style="width:75%;margin:0 auto;border-radius:4px">
            <div class="col-md-6">
                <div class="row">
                    <div class="lbl">
                        <span>Tên phiếu nhập:</span>
                    </div>
                    <div class="input-search col-3">
                        <input type="text" name="tenphieunhap" placeholder="Nhập tên phiếu"/>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="row">
                    <div class="lbl">
                        <span>Công ty:</label>
                    </div>
                    <div class="input-search col-7">
                        <%: Html.DropDownList("Congtyid",(SelectList)TempData["Congty"]) %>
                        <% TempData.Keep("Congty"); %>
                    </div>
                    <div class="col-md-12 mt-2 text-right">
                        <input type="submit" value="Search" class="btn btn-success" />
                    </div>
                </div>
            </div>
            
        </div>
    <%}%>--%>

    <div style="margin-top: 10px;" id="list-table">
        <button style="float:right;margin: 10px; font-size: 13px" class="btn btn-info" onclick="parent.location='/XuatHang/Create'">Tạo mới</button>
        <table id="myTable" class="table table-hover table-striped">
            <thead>
                <tr class="table-info">
                    <th style="text-align:center">STT</th>
                    <th style="text-align:center">Mã phiếu</th>
                    <th style="text-align:center">Tên phiếu xuất</th>
                    
                    <th style="text-align:center">Mô tả</th>
                    <th style="text-align:center">Khách hàng</th>
                    <th style="text-align:center">Chi tiết</th>
                    <th style="text-align:center">Sửa</th>
                    <th style="text-align:center">Xóa</th>
                </tr>
            </thead>
            <tbody>
                <% int i = 0;
                   foreach(var it in Model)
                   {
                       i++;
                %>
                <tr style="text-align: center">
                    <td><%: i %></td>
                    <td><%: it.id %></td>
                    <td><%: it.Tenphieuxuat %></td>
                    
                    <td><%: it.Mota %></td>
                    <td><%: it.Tenkhachhang %></td>
                    <td>
                        <a onclick="AjxCall(<%:it.id %>)" class="btn" data-toggle="modal" data-target="#myModal2"><i class="fas fa-info" title="Chi tiết"></i></a>
                    </td>
                    <td>
                        <a href="/XuatHang/Edit/<%:it.id %>" class="btn" <%--class="btn" data-toggle="modal" data-target="#myModal"--%>><i class="fas fa-pen" title="Sửa"></i></a>
                    </td>
                    <td>
                         <a onclick= "return delete_infor(<%:it.id %>) " class="btn" data-toggle="modal" data-target="#myModal1"><i class="far fa-trash-alt"></i></a>
                    </td>
                </tr>
                <%} %>
            </tbody>
        </table>
    </div>

    <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="<%: Url.Content("~/Content/bootstrap-4.6.0-dist/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script type="text/javascript" src="https://cdn.datatables.net/1.10.25/js/jquery.dataTables.min.js"></script>

    <script type="text/javascript">
        var date = new Date();
        function AjxCall(id) {
            $("#date").html('Hà Nội, ngày ' + date.getDate() + ' tháng ' + date.getMonth() + ' năm ' + date.getFullYear());
            loadDetails(id);

            $.ajax({
                type: "POST",
                url: "/XuatHang/ViewPhieuXuat",
                data: { id: id },
                dataType: 'json',
                success: function (pnModel) {
                    $("#tenphieu").val(pnModel.tenphieu);
                    $("#idphieu").val(pnModel.id);
                    $("#khachhang").val(pnModel.Tenkhachhang);
                }
            });
        }
        function loadDetails(id) {
            $.ajax({
                type: "POST",
                url: "/XuatHang/LoadChiTietPhieuXuat",
                data: { id: id },
                dataType: 'json',
                success: function (Json) {
                    //abc(Json)
                    //console.log(Json);
                    $('.details').html('<thead><tr class="bg-light"><th>Mặt hàng</th> <th>Số lượng</th><th>Giá xuất</th><th>Thành tiền (VND)</th></tr></thead>')
                    $('.details').append(arrayToTable(Json));
                }
            });
        }
        //function abc(data) {
        //    console.log(typeof data);
        //    var table = document.getElementById("details");

        //}
        //them dau cham vao gia nhap, tong tien
        function formatNumber(nStr, decSeperate, groupSeperate) {
            nStr += '';
            x = nStr.split(decSeperate);
            x1 = x[0];
            x2 = x.length > 1 ? '.' + x[1] : '';
            var rgx = /(\d+)(\d{3})/;
            while (rgx.test(x1)) {
                x1 = x1.replace(rgx, '$1' + groupSeperate + '$2');
            }
            return x1 + x2;
        }

        //dinh dang ngay thang
        function parseJsonDate(jsonDate) {

            var fullDate = new Date(parseInt(jsonDate.substr(6)));
            var twoDigitMonth = (fullDate.getMonth() + 1) + ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;

            var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
            var currentDate = twoDigitDate + "/" + twoDigitMonth + "/" + fullDate.getFullYear();

            return currentDate;
        };

        function arrayToTable(tableData) {
            var tongtien = 0;
            var table = $('.details');
            $(tableData).each(function (i, rowData) {
                var row = $('<tr></tr>');
                row.append($('<td>' + tableData[i].Tenmathang + '</td>'));
                row.append($('<td>' + tableData[i].Soluong + '</td>'));
                row.append($('<td>' + formatNumber(tableData[i].Giaban, ',', '.') + '</td>'));
                row.append($('<td>' + formatNumber(tableData[i].Giaban * tableData[i].Soluong, ',', '.') + '</td>'));
                tongtien = tongtien + tableData[i].Giaban * tableData[i].Soluong;
                table.append(row);
            });
            table.append('<tr><td colspan="4"> <span class="col-1 ">Tổng tiền:</span><input  type="text" readonly="readonly" class="input-create col-10" value="' + formatNumber(tongtien, ',', '.') + '" /></td></tr>');
            $("#AmountInWord").val(tongtien.ReadNumber());
            return table;
        }




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
                    url: '/XuatHang/Delete',
                    data: { id: id },
                    type: 'GET',
                    dataType: 'json',
                    success: location.href = '/XuatHang',
                });
            });
        }

        //đọc số thành chữ
        var ChuSo = new Array(" không ", " một ", " hai ", " ba ", " bốn ", " năm ", " sáu ", " bảy ", " tám ", " chín ");
        var Tien = new Array("", " nghìn", " triệu", " tỉ", " nghìn tỉ", " triệu tỉ");

        //1. Hàm đọc số có 3 chữ số
        function DocSo3ChuSo(baso) {
            var tram;
            var chuc;
            var donvi;
            var KetQua = "";
            tram = parseInt(baso / 100);
            chuc = parseInt((baso % 100) / 10);
            donvi = baso % 10;
            if (tram == 0 && chuc == 0 && donvi == 0) return "";
            if (tram != 0) {
                KetQua += ChuSo[tram] + " trăm ";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh ";
            }
            if ((chuc != 0) && (chuc != 1)) {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh ";
            }
            if (chuc == 1) KetQua += " mười ";
            switch (donvi) {
                case 1:
                    if ((chuc != 0) && (chuc != 1)) {
                        KetQua += " một ";
                    }
                    else {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0) {
                        KetQua += ChuSo[donvi];
                    }
                    else {
                        KetQua += " lăm ";
                    }
                    break;
                default:
                    if (donvi != 0) {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        } // End fucntion Docsoco3chuso


        Number.prototype.ReadNumber = function () {
            var SoTien = this.valueOf();
            var lan = 0;
            var i = 0;
            var so = 0;
            var KetQua = "";
            var tmp = "";
            var ViTri = new Array();
            if (SoTien < 0) return "Số tiền âm !";
            if (SoTien == 0) return "Không đồng";
            if (SoTien > 0) {
                so = SoTien;
            }
            else {
                so = -SoTien;
            }
            if (SoTien > 8999999999999999) {
                //SoTien = 0;
                return "Sô quá lớn!";
            }
            ViTri[5] = Math.floor(so / 1000000000000000);
            if (isNaN(ViTri[5]))
                ViTri[5] = "0";
            so = so - parseFloat(ViTri[5].toString()) * 1000000000000000;
            ViTri[4] = Math.floor(so / 1000000000000);
            if (isNaN(ViTri[4]))
                ViTri[4] = "0";
            so = so - parseFloat(ViTri[4].toString()) * 1000000000000;
            ViTri[3] = Math.floor(so / 1000000000);
            if (isNaN(ViTri[3]))
                ViTri[3] = "0";
            so = so - parseFloat(ViTri[3].toString()) * 1000000000;
            ViTri[2] = parseInt(so / 1000000);
            if (isNaN(ViTri[2]))
                ViTri[2] = "0";
            ViTri[1] = parseInt((so % 1000000) / 1000);
            if (isNaN(ViTri[1]))
                ViTri[1] = "0";
            ViTri[0] = parseInt(so % 1000);
            if (isNaN(ViTri[0]))
                ViTri[0] = "0";
            if (ViTri[5] > 0) {
                lan = 5;
            }
            else if (ViTri[4] > 0) {
                lan = 4;
            }
            else if (ViTri[3] > 0) {
                lan = 3;
            }
            else if (ViTri[2] > 0) {
                lan = 2;
            }
            else if (ViTri[1] > 0) {
                lan = 1;
            }
            else {
                lan = 0;
            }
            for (i = lan; i >= 0; i--) {
                tmp = DocSo3ChuSo(ViTri[i]);
                KetQua += tmp;
                if (ViTri[i] > 0) KetQua += Tien[i];
                if ((i > 0) && (tmp.length > 0)) KetQua += ',';//&& (!string.IsNullOrEmpty(tmp))
            }
            if (KetQua.substring(KetQua.length - 1) == ',') {
                KetQua = KetQua.substring(0, KetQua.length - 1);
            }
            KetQua = KetQua.substring(1, 2).toUpperCase() + KetQua.substring(2) + " đồng";
            return KetQua;//.substring(0, 1);//.toUpperCase();// + KetQua.substring(1);
        }
    </script>

</asp:Content>
