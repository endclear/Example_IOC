<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<QuanLyHangHoa.Models.KhachHangModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<style>
    .field-validation-valid
    {
        color:red;
    }
    .btn
        {
            border-radius: 10px;
            box-shadow: 0 2px 3px rgb(0 0 0 / 30%);
        }
    .input-create
        {
            border:none;
            outline:none;
            border-bottom: 1px dashed #808080;
            width:100%;
            background-color:transparent;
        }
    span
    {
        font-weight:normal;
    }
</style>
<link href="<%:Url.Content("~/Content/themes/base/jquery.ui.datepicker.css") %>rel="stylesheet" type="text/css" />
<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery-1.7.1.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery-ui-1.8.20.min.js" )%>" type="text/javascript"></script>
    
 <h5 class="text-center text-dark font-weight-bold">SỬA THÔNG TIN VỀ KHÁCH HÀNG</h5>
<% using (Html.BeginForm("Edit", "KhachHang", FormMethod.Post, new { id= "Form" }))
   { %>

    <div class="row mt-3">
            <div class="col-12">
                <small class="text-danger "> (*) : không được bỏ trống</small>
            </div>
            <div class="col-md-12">
                <div class="row text-dark">
                    <div class="col-2">
                        <label>1. Họ tên<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-10">
                        <%: Html.TextBoxFor(model => model.Hoten, new { @class="input-create",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="row col-7">
                        <div class="col-md-4">
                            <label>2. Giới tính<small class="text-danger "> (*)</small> : </label>
                        </div>
                        <div class="col-md-8">
                            <%: Html.DropDownList("Gioitinh",(IEnumerable<SelectListItem>)ViewBag.Gioitinh)%>
                        </div>
                    </div>
                    <div class="row col-5">
                        <div class="col-md-5">
                            <label>3. Công ty<small class="text-danger "> (*)</small> : </label>
                        </div>
                        <div class="col-md-7">
                            <%: Html.DropDownList("Congtyid",(IEnumerable<SelectListItem>)ViewBag.Congty) %>
                        </div>
                    </div>
                </div>

                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>4. Ngày sinh<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Ngaysinh, new { @class= "datepicker input-create",Value = DateTime.Now.ToShortDateString()} )%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>5. Điện thoại<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Dienthoai, new { @class="input-create",type="text",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>6. Email: </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Email, new { @class="input-create",type="email",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>7. Địa chỉ<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Diachi, new { @class="input-create",required="required"})%>
                    </div>
                </div>

                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>8. Số CMT/CCCD<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Socmt, new { @class="input-create",required="required"})%>
                    </div>
                </div>

                 <div class="row text-dark">
                    <div class="col-md-2">
                        <label>9. Ngày cấp<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Ngaycap, new { @class= "datepicker input-create",Value = DateTime.Now.ToShortDateString()} )%>
                    </div>
                </div>

                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>10. Nơi cấp<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Noicap, new { @class= "input-create"} )%>
                    </div>
                </div>

                <div class="col-md-12 mt-2 text-center">
                    <input type="reset" class="btn btn-info" value="Làm lại" />
                    <input type="submit" class="btn btn-info" value="Lưu thay đổi" />
                    <button class="btn btn-info" onclick="parent.location='/KhachHang'">Quay lại</button>
                </div>
            </div>
        </div>


       
<% } %>

    <script type="text/javascript">
        $(function () {
            // This will make every element with the class "date-picker" into a DatePicker element
            $('.datepicker').datepicker({
                dateFormat: "mm/dd/yy"
            });
        })
</script>
</asp:Content>
