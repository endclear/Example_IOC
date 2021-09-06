<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.HangHoa>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
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

<script src="<%: Url.Content("~/Scripts/jquery.validate.min.js") %>" type="text/javascript"></script>
<script src="<%: Url.Content("~/Scripts/jquery.validate.unobtrusive.min.js") %>" type="text/javascript"></script>
    
 <h5 class="text-center text-dark font-weight-bold">NHẬP THÔNG TIN VỀ MẶT HÀNG</h5>
<% using (Html.BeginForm("Create", "HangHoa", FormMethod.Post, new { id= "Form" }))
   { %>

    <div class="row mt-3">
            <div class="col-12">
                <small class="text-danger "> (*) : không được bỏ trống</small>
            </div>
            <div class="col-md-12">
                <div class="row text-dark">
                    <div class="row col-8">
                        <div class="col-3">
                            <label>1. Mã mặt hàng<small class="text-danger "> (*)</small> : </label>
                        </div>
                        <div class="col-9">
                            <%: Html.TextBoxFor(model => model.Mahang, new { @class="input-create",required="required"})%>
                        </div>
                    </div>
                    <div class="row col-4">
                        <div class="col-md-6">
                            <label>4. Quốc gia<small class="text-danger "> (*)</small> : </label>
                        </div>
                        <div class="col-md-6">
                            <%: Html.DropDownList("Xuatxuid",(SelectList)ViewBag.Quocgia) %>
                        </div>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>2. Tên mặt hàng<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Tenhang, new { @class="input-create",required="required" })%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>3. Mô tả: </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Mota, new { @class="input-create"})%>
                    </div>
                </div>

                <div class="col-md-12 mt-2 text-center">
                    <input type="reset" class="btn btn-info" value="Làm lại" />
                    <input type="submit" class="btn btn-info" value="Tạo mới" />
                    <button class="btn btn-info" onclick="parent.location='/HangHoa'">Quay lại</button>
                </div>
            </div>
        </div>


       
<% } %>
</asp:Content>
