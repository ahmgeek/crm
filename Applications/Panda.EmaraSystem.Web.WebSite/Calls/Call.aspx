<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Call.aspx.cs" Inherits="Calls_Call" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box">
        <header>
            <div class="icons"><i class="icon-male"></i></div>
            <h5>Client Data</h5>
            <!-- .toolbar -->
            <div class="toolbar">
                <ul class="nav">
                    <li>
                        <a class="btn btn-link" href="/Calls/View.aspx"><i class="icon-arrow-left"></i>Back
                        </a>
                    </li>
                </ul>
            </div>

            <!-- /.toolbar -->
        </header>

        <asp:GridView ID="grd"
            CssClass="table  table-bordered table-condensed table-hover table-striped"
            runat="server"
            GridLines="None"
            CellSpacing="-1"
            AutoGenerateColumns="False"
            ShowHeaderWhenEmpty="True"
            EmptyDataText="Empty !"
            OnPreRender="grd_PreRender"
            AllowPaging="true"
            PageSize="10">
            <Columns>
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <asp:Label ID="lblFullName" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Case Number">
                    <ItemTemplate>
                        <asp:Label ID="lblCaseNum" runat="server" Style="width: 100px;" Text='<%#Eval("CaseNumber") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Case Status">
                    <ItemTemplate>
                        <asp:Label ID="lblCaseStatus" runat="server" Style="width: 100px;" Text='<%#Eval("PrescriptionStatus") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Creation Date">
                    <ItemTemplate>
                        <asp:Label ID="lblCreation" runat="server" Style="width: 140px;" Text='<%#Eval("dateTime") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Mobile">
                    <ItemTemplate>
                        <asp:Label ID="lblMob" runat="server" Style="width: 90px;" Text='<%#Eval("Mob") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label ID="lblGender" runat="server" Style="width: 40px;" Text='<%#Eval("Gender") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Related To">
                    <ItemTemplate>
                        <asp:Label ID="lblRelation" runat="server" Style="width: 180px;" Text='<%#Eval("ClientRelName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>



    <div class="box dark">
        <header>
            <div class="icons"><i class="icon-briefcase"></i></div>
            <h5>View Case</h5>
            <!-- .toolbar -->
            <div class="toolbar">
                <ul class="nav">
                    <li>
                        <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#divData">
                            <i class="icon-chevron-down"></i>
                        </a>
                    </li>
                </ul>
            </div>
            <!-- /.toolbar -->
        </header>
        <div id="divData" class="accordion-body  collapse  body">
            <div class="form-horizontal">
                <div class="box dark">
                    <header>
                        <div class="icons"><i class="icon-question"></i></div>
                        <h5>Questions</h5>
                        <div class="toolbar">
                            <ul class="nav">
                                <li>
                                    <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#Sessions">
                                        <i class="icon-chevron-up"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <!-- .toolbar -->
                        <!-- /.toolbar -->
                    </header>
                    <div id="Sessions" style="overflow: scroll; height: 400px;" class="accordion-body collapse in body">
                        <asp:Repeater ID="questionRepeater" ViewStateMode="Enabled" runat="server" OnPreRender="questionRepeater_PreRender">
                            <ItemTemplate>
                                <div class="control-group">
                                    <label class="control-label">Question  : </label>
                                    <div class="controls" dir="rtl">
                                        <asp:Label ID="lblQuestion" Style="float: left;" runat="server" CssClass="lbl_ltr" Text='<%#Eval("Question") %>'></asp:Label>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Answer  : </label>
                                    <div class="controls" dir="rtl">
                                        <asp:Label ID="lblAnswer" Style="float: left;" runat="server" CssClass="lbl_ltr" Text='<%#Eval("Answer") %>'></asp:Label>
                                    </div>
                                </div>

                            </ItemTemplate>
                        </asp:Repeater>
                        <hr />
                        <label class="control-label">Question Report : </label>

                        <div class="controls">

                            <asp:TextBox runat="server" ID="txtReport" Height="200"
                                TextMode="MultiLine" ReadOnly="true" CssClass="span8">
                            </asp:TextBox>
                        </div>

                    </div>

                </div>




                <div class="box dark">
                    <header>
                        <div class="icons"><i class="icon-medkit"></i></div>
                        <h5>Prescription</h5>
                        <div class="toolbar">
                            <ul class="nav">
                                <li>
                                    <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#Prescription">
                                        <i class="icon-chevron-down"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <!-- .toolbar -->
                        <!-- /.toolbar -->
                    </header>
                    <div id="Prescription" class="accordion-body collapse body">
                        <div class="row-fluid">
                            <div class="span3" style="overflow: scroll; height: 300px;">
                                <asp:GridView ID="grdCd" Width="400px"
                                    CssClass="table  table-bordered table-condensed table-hover table-striped"
                                    runat="server"
                                    GridLines="None"
                                    CellSpacing="-1"
                                    AutoGenerateColumns="False"
                                    ShowHeaderWhenEmpty="True"
                                    EmptyDataText="Empty !"
                                    OnPreRender="grd_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Cd's">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCD" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("CdName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="Maroon" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div class="span3" style="overflow: scroll; height: 300px;">
                                <asp:GridView ID="grdCourses" Width="400"
                                    CssClass="table  table-bordered table-condensed table-hover table-striped"
                                    runat="server"
                                    GridLines="None"
                                    CellSpacing="-1"
                                    AutoGenerateColumns="False"
                                    ShowHeaderWhenEmpty="True"
                                    EmptyDataText="Empty !"
                                    OnPreRender="grd_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Courses">
                                            <ItemTemplate>
                                                <asp:Label ID="Courses" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("CourseName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="Maroon" />
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div class="span6" style="overflow: scroll; height: 300px;">
                                <asp:GridView ID="grdSessions" Width="600px"
                                    CssClass="table  table-bordered table-condensed table-hover table-striped"
                                    runat="server"
                                    GridLines="None"
                                    CellSpacing="-1"
                                    AutoGenerateColumns="False"
                                    ShowHeaderWhenEmpty="True"
                                    EmptyDataText="Empty !"
                                    OnPreRender="grd_PreRender">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Session Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSessionName" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("SessionName") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="Maroon" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="How Many?">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNumber" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("Number") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="#006699" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Comments">
                                            <ItemTemplate>
                                                <asp:Label ID="lblComment" Font-Bold="true" Style="width: 180px;" runat="server" Text='<%#Eval("Comment") %>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle ForeColor="#333333" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>


                            </div>

                        </div>



                    </div>
                </div>
                <div class="box dark">
                    <header>
                        <div class="icons"><i class="icon-medkit"></i></div>
                        <h5>Final Report</h5>
                        <div class="toolbar">
                            <ul class="nav">
                                <li>
                                    <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#FinalReport">
                                        <i class="icon-chevron-down"></i>
                                    </a>
                                </li>
                            </ul>
                        </div>

                        <!-- .toolbar -->
                        <!-- /.toolbar -->
                    </header>


                    <div id="FinalReport" class="accordion-body collapse body">
                        <div class="form-horizontal">

                            <asp:TextBox ID="txtFinalReport" ReadOnly="True" runat="server" CssClass="span9"
                                Height="200"></asp:TextBox>
                            <asp:Panel runat="server" ID="pnlRevised" Visible="false">
                                <hr />

                                <div>
                                    <header>
                                        <div class="icons"><i class="icon-comment"></i></div>
                                        <h5>Revision Comment</h5>
                                        <ul class="nav pull-right">
                                        </ul>
                                    </header>
                                    <br />
                                    <asp:TextBox ID="txtComment" TextMode="MultiLine" ReadOnly="true" runat="server" CssClass="span9"
                                        Height="200"></asp:TextBox>
                                </div>
                            </asp:Panel>

                        </div>
                    </div>

                </div>

            </div>

        </div>

    </div>



    <div class="row-fluid">
        <div class="span12">


            <div class="box ">
                <header>
                    <div class="icons"><i class="icon-phone"></i></div>
                    <h5>Call Signing</h5>
                    <!-- .toolbar -->
                    <div class="toolbar">
                        <ul class="nav">
                            <li>
                                <a class="accordion-toggle minimize-box" data-toggle="collapse" href="#divCall">
                                    <i class="icon-chevron-up"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!-- /.toolbar -->
                </header>
                <div id="divCall" class="accordion-body  collapse in body">
                    <div class="form-horizontal">
                        <div class="control-group">
                            <label class="control-label">Client Availability : </label>
                            <div class="controls">
                                <asp:RadioButtonList ID="rdStatusList"
                                    AutoPostBack="true" OnSelectedIndexChanged="rdStatusList_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" CellPadding="9"
                                    runat="server">
                                    <asp:ListItem Value="1" Text="Available" />
                                    <asp:ListItem Value="2" Text="On Hold" />
                                    <asp:ListItem Value="3" Text="Un Available" />
                                </asp:RadioButtonList>

                            </div>
                        </div>

                        <asp:Panel runat="server"
                            ID="pnlAvailble" Visible="false">
                        <div class="control-group">
                            <label class="control-label">Call Report : </label>
                            <div class="controls">
                                <asp:TextBox ID="txtCallReport" Height="200"
                                    CssClass="span8"
                                    TextMode="MultiLine"
                                    runat="server"></asp:TextBox>

                            </div>
                        </div>
                        <div class="control-group">
                            <label class="control-label">Technical Report : </label>
                            <div class="controls">
                                <asp:TextBox ID="txtTechnichalReport"
                                    Height="200"
                                    CssClass="span8"
                                    TextMode="MultiLine"
                                    runat="server"></asp:TextBox>

                            </div>
                        </div>

                        <div class="control-group">
                            <label class="control-label">Visit Date : </label>
                            <div class="controls">
                                <div class="input-append date" id="dpYears" data-date="" data-date-format="dd/mm/yyyy" data-date-viewmode="years">
                                    <asp:TextBox
                                        data-placement="right" ID="txtVisitDate" runat="server" type="text"
                                        class="span11" data-date-format="dd/mm/yyyy" required></asp:TextBox>
                                    <span class="add-on"><i class="icon-calendar"></i></span>
                                </div>
                            </div>
                        </div>


                        <div class="control-group">
                            <label class="control-label">Visit Time : </label>
                            <div class="controls">
                                <div class="input-append bootstrap-timepicker-component">
                                    <asp:TextBox ID="txtTime" CssClass="input-append bootstrap-timepicker-component span11 timepicker-default" runat="server">
                                    </asp:TextBox>
                                    <span class="add-on"><i class="icon-time"></i></span>

                                </div>


                            </div>


                        </div>
                               <div class="control-group">
                            <label class="control-label">Notes : </label>
                            <div class="controls">
                                <asp:TextBox ID="txtNotes" Height="100"
                                    CssClass="span6"
                                    TextMode="MultiLine"
                                    runat="server"></asp:TextBox>

                            </div>
                        </div>
                            </asp:Panel>

                         <div class="control-group">
                            <div class="controls">

                                <asp:Button ID="btnSave" Width="400"
                                    OnClick="btnSave_Click"
                                    Enabled="false"
                                    CssClass="btn btn-large btn-primary"
                                     runat="server" Text="Save" />
                            </div>


                        </div>




                    </div>
                </div>
            </div>
        </div>
        </div>
    
</asp:Content>

