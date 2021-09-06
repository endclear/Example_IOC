<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceholder1" runat="server">
    <style>
        .item
        {
            position:relative;
            z-index:1;
        }
        .box
        {
            box-shadow: 3px 3px 0px 0px #999999;
            border-radius:4px;
            /*margin:10px;*/
            color:white;
        }
        .item a
        {
            color:white;
        }
    </style>
    <div class="text-center p-2 item" >
        <div class="row mt-3">

            <div class="col-md-4 p-2">
                <a href="/QuocGia">
                    <div class="box bg-primary p-2">
                        <i class="fas fa-globe fa-7x"></i>
                        <h5>Quốc Gia</h5>
                    </div>
                </a>
            </div>

            <div class="col-md-4 p-2">
                <a href="/CongTy">
                    <div class="box bg-success p-2">  
                            <i class="fas fa-city fa-7x"></i>
                            <h5>Công Ty</h5>
                     </div>
                </a>
            </div>

            <div class="col-md-4 p-2">
                <a href="/HangHoa">
                    <div class="box bg-warning p-2">
                            <i class="fas fa-laptop fa-7x"></i>
                            <h5>Mặt Hàng</h5>
                    </div>
                 </a>
            </div>
        </div>

        <div class="row mt-3">

            <div class="col-md-4 p-2">
                <a href="/KhachHang">
                    <div class="box bg-info p-2">
                            <i class="fas fa-user fa-7x"></i>
                            <h5>Khách Hàng</h5>
                    </div>
                </a>
            </div>

            <div class="col-md-4 p-2">
                <a href="/NhapHang">
                    <div class="box bg-danger p-2">
                            <i class="fas fa-dolly fa-7x"></i>
                            <h5>Nhập Hàng</h5>
                    </div>
                </a>
            </div>

            <div class="col-md-4 p-2">
                <a href="/XuatHang">
                    <div class="box bg-dark p-2">
                            <i class="fas fa-truck fa-7x"></i>
                            <h5>Xuất Hàng</h5>
                    </div>
                </a>
            </div>
        </div>
    </div>

</asp:Content>
