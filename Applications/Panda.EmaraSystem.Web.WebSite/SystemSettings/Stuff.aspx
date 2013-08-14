<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Stuff.aspx.cs" Inherits="SystemSettings_Stuff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="box">
        <header>
            <div class="icons"><i class="icon-user"></i></div>
            <h5>Stuff</h5>
            <div class="toolbar">
                <a href="#div-1" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>
            </div>
        </header>
        
              <div id="div-1" class="accordion-body collapse in body">
        <div id="form" class="form-horizontal">
            <div class="control-group">
                <label for="text1" class="control-label">First Name</label>

                <div class="controls with-tooltip">

                    <asp:TextBox ID="txtFName" runat="server" class="span5 input-tooltip"
                        data-original-title="First Name"
                        data-placement="right"></asp:TextBox>
                </div>
            </div>
                        <div class="control-group">
                <label for="text1" class="control-label">Surr name</label>

                <div class="controls with-tooltip">

                    <asp:TextBox ID="txtSurrName" runat="server" class="span5 input-tooltip"
                        data-original-title="Email"
                        data-placement="right"></asp:TextBox>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label"> Gender  </label>
                <div class="controls ">
                    <asp:RadioButtonList ID="rdGender" CssClass="uniform" RepeatDirection="Horizontal" CellPadding="10" runat="server">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">Moblie</label>

                <div class="controls">
                    <asp:TextBox ID="txtMob" runat="server" class="span5 input-tooltip"
                    TextMode="Password"    data-original-title="Please Re enter your password" data-placement="right">

                    </asp:TextBox>
                </div>
            </div>

        </div>

        <div class="form-actions">
        <asp:Button ID="btnSave" type="submit"  class="btn btn-primary" runat="server" Text="Save" />
        </div>

    </div>
        </div>
</asp:Content>

