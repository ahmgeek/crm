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

                    <asp:TextBox ID="txtFName" runat="server" class="span3 input-tooltip"
                        data-original-title="First Name"
                        data-placement="right"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFName" runat="server" />
                </div>
            </div>
                        <div class="control-group">
                <label for="text1" class="control-label">Surr name</label>

                <div class="controls with-tooltip">

                    <asp:TextBox ID="txtSurrName" runat="server" class="span3 input-tooltip"
                        data-original-title="Surr name"
                        data-placement="right"></asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSurrName" runat="server" />
                </div>
            </div>

            <div class="control-group">
                <label class="control-label"> Date Of Birth  </label>
                <div class="controls ">

                          <div class="input-append date" 
                              id="dpYears" 
                              data-date=""
                               data-date-format="dd/mm/yyyy"
                               data-date-viewmode="years">
                              <asp:TextBox data-original-title="Please enter Mobile Number"
                                   data-placement="right" ID="txtDateOf" runat="server" type="text"
                                   class="span11" data-date-format="dd/mm/yyyy"></asp:TextBox>
                              <span class="add-on"><i class="icon-calendar"></i></span>
                          </div>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" 
                                  ForeColor="Red"
                                  ControlToValidate="txtDateOf" runat="server" />
                          <asp:CompareValidator
                        id="dateValidator" runat="server" 
                        Type="Date"
                        Operator="DataTypeCheck"
                        ControlToValidate="txtDateOf" ForeColor="Red"
                        ErrorMessage="Please enter a valid date.">
                    </asp:CompareValidator>

                </div>
            </div>
            <div class="control-group">
                <label class="control-label">Moblie</label>

                <div class="controls">
                    <asp:TextBox ID="txtMob" runat="server" class="span3 input-tooltip"
                        data-original-title="MobileNumber"
                        data-placement="right">
                    </asp:TextBox>
                    <asp:RequiredFieldValidator ErrorMessage="*"
                        ForeColor="Red" ControlToValidate="txtMob" runat="server" />
                    <asp:RegularExpressionValidator 
                        ErrorMessage="Please Proveide A Valid Number" 
                        ForeColor="Red"
                        ControlToValidate="txtMob" runat="server" 
                        ValidationExpression="\d+" />

                </div>
            </div>

        </div>

        <div class="form-actions">
         <asp:Button ID="btnInsert" Visible="false" type="submit"  class="btn btn-primary" runat="server" Text="Insert" OnClick="btnInsert_Click" />

            <asp:Button ID="btnSave" Visible="false" type="submit"  class="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
            <a href="/SystemSettings/Users.aspx" class="btn btn-info" >Cancel</a>
             </div>

    </div>
        </div>
</asp:Content>

