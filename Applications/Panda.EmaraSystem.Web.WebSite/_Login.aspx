<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_Login.aspx.cs" Inherits="_Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Login</title>
    <link rel="stylesheet" href="/assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/assets/css/login.css" />
    <link rel="stylesheet" href="/assets/magic/magic.css" />
            <link href="/assets/Noti/jquery.pnotify.default.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="muted text-center">
                <h1>Emara System</h1>

            </div>
            <div class="tab-content">
                <div id="login" class="tab-pane active">
                    <div class="form-signin">
                        <p class="muted ">
                            Enter your username and password
                        </p>


                        <asp:TextBox ID="txtUserName" class="span4" placeholder="Username" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName" runat="server" />

                        <asp:TextBox ID="txtPass" TextMode="Password" class="span4" placeholder="Password" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPass" runat="server" />
                        <br />
                        <br />

                        <label class="label">Keep Me Signed In
                        <asp:CheckBox ID="chkSaveMe" runat="server" />
                        </label>
                        <br /><br />
                        <asp:Button ID="btnLogin" Text="Sign in" runat="server" class="btn btn-large  btn-primary span4 " OnClick="btnLogin_Click" />

                    </div>
                </div>
                <div id="forgot" class="tab-pane">
                    <div class="form-signin">
                        <p class="muted text-center">
                            Enter your valid e-mail
                        </p>
                        <asp:TextBox ID="txtMail" placeholder="mail@domain.com" class="input-block-level" runat="server"></asp:TextBox>

                        <br />
                        <br />
                        <button class="btn btn-large btn-danger btn-block" type="submit">Recover Password</button>
                    </div>
                </div>
            </div>
            <div class="text-center">
                <ul class="inline">
                    <li><a class="muted" href="#login" data-toggle="tab">Login</a></li>
                    <li><a class="muted" href="#forgot" data-toggle="tab">Forgot Password</a></li>
                </ul>
            </div>


        </div>
        <!-- /container -->

        <script src="//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js"></script>
        <script>window.jQuery || document.write('<script src="assets/js/vendor/jquery-1.10.1.min.js"><\/script>')</script>
        <script type="text/javascript" src="assets/js/vendor/bootstrap.min.js"></script>
                        <script src="/assets/Noti/jquery.pnotify.min.js"></script>

        <script>
            $('.inline li > a').click(function () {
                var activeForm = $(this).attr('href') + ' > div';
                //console.log(activeForm);
                $(activeForm).addClass('magictime swap');
                //set timer to 1 seconds, after that, unload the magic animation
                setTimeout(function () {
                    $(activeForm).removeClass('magictime swap');
                }, 1000);
            });

        </script>
    </form>
</body>
</html>
