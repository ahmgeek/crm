<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="NewClient.aspx.cs" Inherits="Clients_NewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!--BEGIN INPUT TEXT FIELDS-->
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
                                <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#divData">
                                    <i class="icon-chevron-up"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.toolbar -->
                </header>
                <div id="divData" class="accordion-body collapse in body">

                    <div class="form-horizontal">
                        <div class="control-group">
                            <label for="text1" class="control-label">Case Number</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtCaseNumber" ReadOnly="true" runat="server" class="span6 input-tooltip"
                                    data-original-title="Unique CLient ID" data-placement="right"></asp:TextBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="pass1" class="control-label">First Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtFName" class="span6 input-tooltip"
                                    data-original-title="Please enter the First Name"
                                     data-placement="right" runat="server"  required></asp:TextBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Middle Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtMiddleName" class="span6 input-tooltip"
                                    data-original-title="Please enter Middle Name" data-placement="right"
                                    runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Surr Name</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtSurrName" class="span6 input-tooltip"
                                    data-original-title="Please enter Surr Name" data-placement="right"
                                    runat="server" required></asp:TextBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">City</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtCity" class="span6 input-tooltip"
                                    data-original-title="Please Enter the City" data-placement="right"
                                    runat="server" required></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Country</label>

                            <div class="controls with-tooltip">
                                <asp:DropDownList CssClass="span6 chzn-select" runat="server" ID="drpCountry">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList>
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
                                    runat="server" pattern="\d+" ></asp:TextBox>
                            </div>
                        </div>
                        <div class="control-group">
                            <label for="limiter" class="control-label">Mobile</label>

                            <div class="controls with-tooltip">

                                <asp:TextBox ID="txtMob" class="span6 input-tooltip"
                                    data-original-title="Please enter Mobile Number" data-placement="right"
                                    runat="server" required pattern="\d+"></asp:TextBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label for="text4" class="control-label">Date Of Birth</label>

                            <div class="controls">

                                <div class="input-append date" id="dpYears" data-date="" data-date-format="dd/mm/yyyy" data-date-viewmode="years">
                                    <asp:TextBox 
                                        data-placement="right" ID="txtDateOf" runat="server" type="text" 
                                        class="span11" data-date-format="dd/mm/yyyy" required></asp:TextBox>
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                </div>

                            </div>
                        </div>


                        <div class="control-group">
                            <label for="autosize" class="control-label">Gender</label>


                            <div class="controls with-tooltip">

                                <asp:DropDownList ID="drpGender" CssClass="span6 chzn-select"  runat="server">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:DropDownList>
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


                        <div class="control-group">
                            <label for="pass1" class="control-label">Has a Relation ? </label>

                            <div class="controls with-tooltip">
                                <asp:RadioButtonList ID="rdlst" runat="server" 
                                    RepeatDirection="Horizontal" CellPadding="9" AutoPostBack="true" OnSelectedIndexChanged="rdlst_SelectedIndexChanged">
                                    <asp:ListItem Value="1"> Yes </asp:ListItem>
                                    <asp:ListItem Value="0"> No </asp:ListItem>
                                </asp:RadioButtonList>
                                                        <asp:RequiredFieldValidator runat="server" ID="req"
                                    ControlToValidate="rdlst" ForeColor="red" ErrorMessage="You must specify the relation" ></asp:RequiredFieldValidator>

                            </div>
                                    
                        </div>



                        <asp:Panel ID="pnlRelation" Visible="False" runat="server">
                            <div class="control-group">
                                <label class="control-label">Related To </label>

                                <div class="controls with-tooltip">
                                    <asp:DropDownList ID="drpClients" runat="server"
                                        CssClass="span6 chzn-select">
                                        <asp:ListItem></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>

                            <div class="control-group">
                                <label class="control-label">Relation Name</label>

                                <div class="controls with-tooltip">
                                    <asp:TextBox ID="txtRelName" runat="server" required CssClass="span6">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </asp:Panel>






                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <div class="row-fluid">
        <div class="span12">

            <div class="box dark">

                <header>
                    <div class="icons"><i class="icon-question-sign"></i></div>
                    <h5>Question</h5>
                    <div class="toolbar">
                        <ul class="nav">
                            <li>
                                <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#divPresc">
                                    <i class="icon-chevron-down"></i>
                                </a>
                            </li>
                        </ul>
                    </div>

                </header>

                <div id="divPresc" class="accordion-body collapse  body">

                    <div class="form-horizontal">

                        <asp:Repeater ID="questionRepeater" ViewStateMode="Enabled" runat="server">
                            <ItemTemplate>
                                <div class="control-group">
                                    <label class="control-label">Question  : </label>
                                    <div class="controls" dir="rtl">
                                        <asp:Label ID="lblQuestion" Style="float: left;" runat="server" CssClass="lbl_ltr" Text='<%#Eval("SessionQuestion") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Answer : </label>
                                    <div class="controls">
                                        <asp:TextBox runat="server" ID="txtAns"
                                            Height="70" TextMode="MultiLine"
                                            CssClass="span8"></asp:TextBox>

                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <hr />
                        <label class="control-label">Final Report : </label>

                        <div class="controls">

                            <asp:TextBox runat="server" ID="txtReport"  required Height="200" TextMode="MultiLine" CssClass="span8">
                            </asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">

            <div class="box dark">

                <header>
                    <div class="icons"><i class="icon-medkit"></i></div>
                    <h5>Prescription</h5>
                    <div class="toolbar">
                        <ul class="nav">
                            <li>
                                <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#divSession">
                                    <i class="icon-chevron-down"></i>
                                </a>
                            </li>
                        </ul>
                    </div>

                </header>

                <div id="divSession" class="accordion-body collapse body">
                    <div id="Presc" class="form-horizontal">

                        <div class="control-group">
                            <label class="control-label">CD's : </label>
                            <div class="controls">
                                <asp:ListBox ID="lstCD"
                                    multiple CssClass="span6  chzn-select chzn-rtl"
                                    DataValueField="CdDataID"
                                    DataTextField="CdDataName"
                                    SelectionMode="Multiple"
                                    runat="server"></asp:ListBox>
                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Courses : </label>

                            <div class="controls">
                                <asp:ListBox ID="lstCourses"
                                    SelectionMode="Multiple"
                                    DataValueField="CourseDataID"
                                    DataTextField="CourseDataName"
                                    multiple CssClass="span6 chzn-select  chzn-rtl"
                                    runat="server"></asp:ListBox>

                            </div>
                        </div>


                        <div class="control-group">
                        <label class="control-label"> Sessions : </label>
                    <div class="controls" style="width:720px;">
                        <table class="table responsive">
                            <tbody>
                                <asp:Repeater ID="repeatSessions" ViewStateMode="Enabled" OnPreRender="repeatSessions_OnPreRender" runat="server">
                                    <ItemTemplate>
                                       
                                        <tr >
                                            <td>
                                                <label>Counter</label><br />
                                                <asp:TextBox runat="server" ID="txtCounter" style="width:50px;" >
                                                        </asp:TextBox>
                                            </td>
                                            <td>
                                                <label>Session Name</label><br />
                                                     <asp:TextBox runat="server" ID="txtSessionName"
                                                  Text='<%# Eval("SessionDataName")%>'  ReadOnly="true" CssClass="span9"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label>Comment</label><br />
                                                <asp:TextBox runat="server" ID="txtComment"
                                                  Width="300"   CssClass="span12">
                                                        </asp:TextBox>
                                            </td>
                                            <td>
                                                <label>&nbsp;</label><br />
                                         <asp:CheckBox id="chkCourse" runat="server" />
                                            </td>
                                        </tr>
                                        
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        </div>


                    </div>
                        
                        <div class="box">
                                            <header>
                                                <div class="icons"><i class="icon-th-large"></i></div>
                                                <h5>Final Report</h5>
                                                <ul class="nav pull-right">
                                                </ul>
                                            </header>
                                            <hr />
                                            <div>
                                                <asp:TextBox ID="txtFinalReport" required runat="server" CssClass="span9"
                                                    Height="200"></asp:TextBox>
                                            </div>

                                        </div>

                </div>


            </div>
        </div>
    </div>
    </div>

    <hr /><br/>

        <div class="form-actions no-margin-bottom">
                        <asp:Button ID="btnSendToConfirm" Width="600" Text="Save and send to Confirmation"
                            runat="server" class="btn btn-success btn-large btn-block" OnClick="btnSendToConfirm_OnClick" />
                    </div>







</asp:Content>

