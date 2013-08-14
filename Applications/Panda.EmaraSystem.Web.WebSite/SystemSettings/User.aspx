<%@ Page Title="" Language="C#" MasterPageFile="~/Modal.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="SystemSettings_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <div id="div-1" class="accordion-body collapse in body">
        <div id="form" class="form-horizontal">
            <div class="control-group">
                <label for="text1" class="control-label">User Name</label>

                <div class="controls with-tooltip">

                    <asp:TextBox ID="txtUserName" runat="server" class="span9 input-tooltip"
                        data-original-title="User Name"
                        data-placement="right"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                </div>
            </div>
                        <div class="control-group">
                <label for="text1" class="control-label">Email</label>

                <div class="controls with-tooltip">

                    <asp:TextBox ID="txtEmail" runat="server" class="span9 input-tooltip"
                        data-original-title="Email"
                        data-placement="right"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtEmail" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                </div>
            </div>

            <div class="control-group">
                <label class="control-label">Password</label>

                <div class="controls">
                    <asp:TextBox ID="txtPassword" runat="server" class="span9 input-tooltip"
                   TextMode="Password"     data-original-title="Please use your password" data-placement="right"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtPassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    

                </div>
            </div>
            <div class="control-group">
                <label class="control-label">Re Password</label>

                <div class="controls">
                    <asp:TextBox ID="txtRePassword" runat="server" class="span9 input-tooltip"
                    TextMode="Password"    data-original-title="Please Re enter your password" data-placement="right"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtRePassword" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>                    
                    <asp:CompareValidator 
                        ErrorMessage="Passwords Not Matching ! "
                         ControlToValidate="txtPassword" ControlToCompare="txtRePassword" runat="server" />
                </div>
            </div>
        <div class="control-group">
            <label class="control-label">Role </label><br />
                <div class="controls">
                    <asp:CheckBoxList ID="chkList" 
                         RepeatColumns="1"
                         CssClass="checkbox"
                        runat="server"></asp:CheckBoxList>
                    </div>
            </div>

        </div>

        <div class="form-actions">
        <asp:Button ID="btnSave" type="submit"  class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
    <asp:Button ID="btnUpdate" type="submit"  class="btn btn-info" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </div>

    </div>
</asp:Content>

