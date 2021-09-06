<%@Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Entity.CongTy>" %>

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
    
 <h5 class="text-center text-dark font-weight-bold">NHẬP THÔNG TIN VỀ CÔNG TY</h5>
<% using (Html.BeginForm("Create", "CongTy", FormMethod.Post, new { id= "Form" }))
   { %>

    <div class="row mt-3">
            <div class="col-12">
                <small class="text-danger "> (*) : không được bỏ trống</small>
            </div>
            <div class="col-md-12">
                <div class="row text-dark">
                    <div class="col-2">
                        <label>1. Tên công ty<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-10">
                        <%: Html.TextBoxFor(model => model.TenCongTy, new { @class="input-create",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>2. Điện thoại<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.DienThoai, new { @class="input-create",required="required" })%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>3. Website: </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Website, new { @class="input-create"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>4. Email<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.Email, new { @class="input-create",type="email",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>5. Mã số thuế<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.MaSoThue, new { @class="input-create",required="required"})%>
                    </div>
                </div>
                <div class="row text-dark">
                    <div class="col-md-2">
                        <label>6. Địa chỉ<small class="text-danger "> (*)</small> : </label>
                    </div>
                    <div class="col-md-10">
                        <%: Html.TextBoxFor(model => model.DiaChi, new { @class="input-create",required="required"})%>
                    </div>
                </div>

                <div class="col-md-12 mt-2 text-center">
                    <input type="reset" class="btn btn-info" value="Làm lại" />
                    <input type="submit" class="btn btn-info" value="Tạo mới" />
                    <button class="btn btn-info" onclick="parent.location='/CongTy/Index'">Quay lại</button>
                </div>
            </div>
        </div>

<% } %>

</asp:Content>

