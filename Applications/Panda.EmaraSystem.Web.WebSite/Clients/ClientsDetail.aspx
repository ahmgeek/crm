<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientsDetail.aspx.cs" Inherits="Clients_ClientsDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div class="row-fluid">
        <div class="span12">


            <div class="box dark">

                <header>
                    <div class="icons"><i class="icon-male"></i></div>
                    <h5>Client Information</h5>
                    <!-- .toolbar -->
                    <div class="toolbar">
                        <ul class="nav">
                            <li>
                                <a href="/Clients/Clients.aspx">
                                    <i class="icon-arrow-left"></i>Back
                                </a>

                            </li>
                            <li>
                                <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#div-1">
                                    <i class="icon-chevron-up"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.toolbar -->
                </header>

                <div class="box">
                    <div class="body">
                        <ul id="myTab" class="nav nav-tabs">
                            <li class="active"><a href="#Client" data-toggle="tab"> Client Data </a></li>
                            <li><a href="#Relation" data-toggle="tab"> Relation </a></li>
                           
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane fade in active" id="Client">
                       <div id="div-1" class="accordion-body collapse in body">
                    <div class="form-horizontal controls-row">


                        <div class="control-group">
                            <label for="text1" class="control-label">Account Number</label>

                            <div class="controls  with-tooltip" ">

                                <asp:TextBox ID="txtAccNum" ReadOnly="true" runat="server" class="span3 input-tooltip"
                                    data-original-title="Unique CLient ID" data-placement="right"></asp:TextBox>
                      
                            </div>
                        </div>
                        

                        <div class="control-group">
                            <label for="pass1" class="control-label">First Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtFName" class="span6 input-tooltip"
                                    data-original-title="Please enter the First Name" data-placement="right" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFName" runat="server" />
                            </div>
                        </div>

                         <div class="control-group">
                            <label class="control-label">Middle Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtMiddleName" class="span6 input-tooltip"
                                    data-original-title="Please enter Middle Name" data-placement="right"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMiddleName" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Surr Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtSurrName" class="span6 input-tooltip"
                                    data-original-title="Please enter Surr Name" data-placement="right"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSurrName" runat="server" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">City</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtCity"  class="span6 input-tooltip"
                                    data-original-title="Please Enter the City" data-placement="right"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtCity" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Country</label>

                            <div class="controls with-tooltip">
                                <asp:DropDownList CssClass="span6 chzn-select"  runat="server" ID="drpCountry">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ErrorMessage="*" ForeColor="Red" ControlToValidate="drpCountry" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Address</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtAdress" TextMode="MultiLine" class="span6 input-tooltip"
                                    data-original-title="Please enter the Address" data-placement="right"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="control-group">
                            <label for="text2" class="control-label">Telephone</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtTelephone" class="span6 input-tooltip"
                                    data-original-title="Please entre Phone Number" data-placement="right"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtTelephone" runat="server" />
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="limiter" class="control-label">Mobile</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtMob" class="span6 input-tooltip"
                                    data-original-title="Please enter Mobile Number" data-placement="right"
                                    runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMob" runat="server" />
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="text4" class="control-label">Date Of Birth</label>

                            <div class="controls">

                                    <div class="input-append date" id="dpYears" data-date=""  data-date-format="dd/mm/yyyy" data-date-viewmode="years">
                                        <asp:TextBox data-original-title="Please enter Mobile Number" data-placement="right" ID="txtDateOf" runat="server" type="text" class="span11" data-date-format="dd/mm/yyyy"></asp:TextBox>
                                        <span class="add-on"><i class="icon-calendar"></i></span>
                                        </div>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDateOf" runat="server" />

                                </div>
                        </div>


                        <div class="control-group">
                            <label for="autosize" class="control-label">Gender</label>


                            <div class="controls with-tooltip">

                                <asp:DropDownList ID="drpGender"  CssClass="span6 chzn-select" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ErrorMessage="*" ForeColor="Red" ControlToValidate="drpGender" runat="server" />
                            </div>
                        </div>







                        <div class="control-group">
                            <label for="tags" class="control-label">Prefered Time For Call</label>
                            <div class="controls">
                                <asp:DropDownList ID="drpTime"  CssClass="span6 chzn-select" runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>10AM - 3PM</asp:ListItem>
                                    <asp:ListItem>3PM - 8PM</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ErrorMessage="*" ForeColor="Red" ControlToValidate="drpTime" runat="server" />
                         </div>
                         
                        </div>
                        <div class="control-group">
                            <label for="tags" class="control-label">Notes</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtNotes" TextMode="MultiLine" class="span6 input-tooltip"
                                    data-original-title="Notes " data-placement="right"
                                    runat="server"></asp:TextBox>
                            </div>


                        </div>

                           

                      
                             
                    </div>
                </div>

                        </div>
                        <div class="tab-pane fade" id="Relation">
                            <!-- TODO Relation -->
                        </div>
                    </div>
                          <div class="control-group">

                            <div class="form-actions no-margin-bottom">
                                <asp:Button ID="btnSave" Text="Update"
                                    runat="server" class="btn btn-primary"  />
                            </div>
                        </div>
                </div>
            </div>

            </div>
        </div>
    </div>
    

</asp:Content>

