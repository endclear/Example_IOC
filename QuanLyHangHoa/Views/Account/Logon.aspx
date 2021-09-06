<%@ Page Title="" Language="C#"  Inherits="System.Web.Mvc.ViewPage<QuanLyHangHoa.Models.UserModel>" %>

<style>
    .panel-default {
    border-color: #ddd;
}
    .panel {
        margin:0 auto;
        width:350px;
        background-color: #fff;
        border: 1px solid #8787877a;
        border-radius: 4px;
        -webkit-box-shadow: 0 1px 1px rgb(0 0 0 / 5%);
        box-shadow: 0 1px 1px rgb(0 0 0 / 5%);
    }

    .panel-default>.panel-heading {
        color: #333;
        background-color: #f5f5f5;
        border-color: #ddd;
    }

    .panel-heading {
        padding: 10px 15px;
        border-bottom: 1px solid transparent;
        border-top-left-radius: 3px;
        border-top-right-radius: 3px;
        text-align:center;
    }
    .panel-body {
        padding: 15px;
    }
    .panel-footer {
	    padding: 1px 15px;
	    color: #A0A0A0;
    }

    .profile-img {
	    width: 96px;
	    height: 96px;
	    margin: 0 auto 10px;
	    display: block;
	    -moz-border-radius: 50%;
	    -webkit-border-radius: 50%;
	    border-radius: 50%;
    }
    .center-block {
    display: block;
    margin-right: auto;
    margin-left: auto;
    }
    .input-group-addon
    {
        border:1px solid #ddd;
    }
</style>
<head>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" rel="stylesheet" />
    <link href="../../Content/bootstrap-4.6.0-dist/css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>

 <div class="container" style="margin-top:40px">
        <div class="row">
            <div class="col-sm-6 col-md-12 col-md-offset-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <strong> Sign in to continue</strong>
                    </div>
                    <div class="panel-body">
                        <% using (Html.BeginForm()) { %>
                        <%: Html.ValidationSummary(true, "Đăng nhập thất bại.") %>
                            <fieldset>
                                <div class="row">
                                    <div class="center-block">
                                        <img class="profile-img" src="../../Content/pic_login/VN.png"  alt="" />
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 col-md-12  col-md-offset-1 ">
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fas fa-user p-2"></i>
                                                </span>
                                                 <%: Html.TextBoxFor(m => m.Username, new {@class="form-control", placeholder="Tên đăng nhập"  })%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="input-group">
                                                <span class="input-group-addon">
                                                    <i class="fas fa-key p-2"></i>
                                                </span>
                                                   <%: Html.PasswordFor(m => m.Password, new { @class="form-control", placeholder="Mật khẩu" })%>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <input type="submit" class="btn btn-lg btn-primary btn-block" value="Đăng nhập">
                                        </div>
                                    </div>
                                </div>
                            </fieldset>
                        <%} %>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>


