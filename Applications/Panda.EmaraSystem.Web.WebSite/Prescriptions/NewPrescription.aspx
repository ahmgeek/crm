<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="NewPrescription.aspx.cs" Inherits="Prescriptions_NewPrescriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript" src="/assets/js/lib/jquery.sparkline.min.js"></script>

    <script type="text/javascript" src="/assets/wysihtml5/lib/js/wysihtml5-0.3.0.min.js"></script>
    <script type="text/javascript" src="/assets/wysihtml5/dist/bootstrap-wysihtml5-0.0.2.min.js"></script>
    <script type="text/javascript" src="/assets/CLEditor1_4_3/jquery.cleditor.min.js"></script>

    <script type="text/javascript" src="/assets/pagedown-bootstrap/Markdown.Converter.js"></script>
    <script type="text/javascript" src="/assets/pagedown-bootstrap/Markdown.Sanitizer.js"></script>
    <script type="text/javascript" src="/assets/pagedown-bootstrap/Markdown.Editor.js"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

        <div class="box">
        <header>
            <div class="icons"><i class="icon-edit"></i></div>
            <h5><span class="label label-info">Contact Data</span> </h5>
            <div class="icons"><i class="icon-calendar"></i></div>
            <h5><span class="label label-inverse">
                <asp:Label ID="lblDate" runat="server" /></span> </h5>
            <div class="icons"><i class="icon-time"></i></div>
            <h5><span class="label label-inverse">
                <asp:Label ID="lblTime" runat="server" /></span> </h5>
            <div class="toolbar">
                <a href="/Prescriptions/Prescriptions.aspx">
                    <i class="icon-backward"></i>Cancel
                </a>
                 &nbsp;  &nbsp;  &nbsp; 
            <a href="#List" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>
            </div>
        </header>

        <div id="List" class="body collapse in">
            <div class="form-horizontal">

                <div class="tac">
                    <asp:GridView ID="grdUser"
                        CssClass="table responsive"
                        runat="server"
                        GridLines="None"
                        CellSpacing="-1"
                        AutoGenerateColumns="False"
                        OnPreRender="grdUser_PreRender"
                        OnRowDataBound="grdUser_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblFullName" Font-Bold="true" Font-Size="Medium" runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Account Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblAccountNumber" runat="server" Text='<%#Eval("AccountNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblcity" runat="server" Text='<%#Eval("city") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Moblie">
                                <ItemTemplate>
                                    <asp:Label ID="lblMob" runat="server" Text='<%#Eval("Mob") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="BirthDate">
                                <ItemTemplate>
                                    <asp:Label ID="lblBirth" runat="server" Text='<%# String.Format("{0:d}",Eval("DateOfBirth")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Gender">
                                <ItemTemplate>
                                    <asp:Label ID="lblgender" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>

                    </asp:GridView>


                </div>
            </div>
        </div>
    </div>
        <div class="box">

        <header>
            <div class="icons"><i class="icon-question"></i></div>
            <h5><span class="label label-info">Session Questions</span> </h5>
            <div class="toolbar">
                <a href="#div2" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-hand-down icon-2x"></i>
                </a>
            </div>

        </header>
        <div id="div2" class="body collapse">
            <div class="form-horizontal">

                <div id="optionalTable" class="body collapse in">
                    <table class="table responsive">
                        <tbody>
                            <asp:Repeater ID="questionRepeater" ViewStateMode="Enabled" runat="server">
                                <ItemTemplate>
                                    <tr class="">
                                        <td>
                                            <div class="control-group">
                                                <label class="control-label">Queston  : </label>

                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtQ" Text='<%#Eval("Question") %>' ReadOnly="true" CssClass="span8">
                                                    </asp:TextBox>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr class="info">
                                        <td>
                                            <div class="control-group">
                                                <label class="control-label">Answer : </label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txtAns"
                                                        Height="150" TextMode="MultiLine"  Text='<%#Eval("Answer") %>' ReadOnly="true" CssClass="span8"></asp:TextBox>

                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <hr />
                    <table class="table responsive">
                        <tbody>
                            <tr class="error">
                                <td>
                                    <div class="control-group">
                                        <label class="control-label">Final Report : </label>

                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txtReport" Height="200"  
                                                TextMode="MultiLine" ReadOnly="true" CssClass="span8">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <a href="#div2" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-hand-up icon-2x"></i>
                </a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>







            </div>
        </div>

    </div>
        <div class="box">
        <header>
            <div class="icons"><i class="icon-medkit icon-2x"></i></div>
            <h5><span class="label label-info">Prescription</span> </h5>
            <div class="toolbar">
               
            <a href="#Presc" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-hand-down icon-2x"></i>
                </a>
            </div>
        </header>

        <div id="Presc" class="body collapse">
            <div class="form-horizontal">
                    <div class="control-group">
                        <label class="control-label"> CD's : </label>

                        <div class="controls">
                            <asp:ListBox ID="lstCD" 
                                multiple CssClass="span6 chzn-select  chzn-rtl"
                                SelectionMode="Multiple" 
                                runat="server"></asp:ListBox>
                        </div>
                    </div>

                                 <div class="control-group">
                        <label class="control-label"> Courses : </label>

                        <div class="controls">
                            <asp:ListBox ID="lstCourses" 
                                SelectionMode="Multiple"
                                multiple CssClass="span6 chzn-select  chzn-rtl"
                                runat="server"></asp:ListBox>
                           
                        </div>
                    </div>



                <div class="control-group">
                        <label class="control-label"> Sessions : </label>
                    <div class="controls" style="width:650px;">
                        <table class="table responsive">
                            <tbody">
                                <asp:Repeater ID="repeatSessions" ViewStateMode="Enabled" runat="server">
                                    <ItemTemplate>
                                       
                                        <tr >
                                            <td>
                                                <label>Counter</label>
                                                <asp:TextBox runat="server" ID="txtCounter" CssClass="span4">
                                                        </asp:TextBox>
                                            </td>
                                            <td>
                                                <label>Session Name</label>
                                                <asp:TextBox runat="server" ID="txtSessionName"
                                                  Text='<%# Eval("SessionName") %>'  ReadOnly="true" CssClass="span9"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label>Comment</label>
                                                <asp:TextBox runat="server" ID="txtComment"
                                                  Width="300"   CssClass="span12">
                                                        </asp:TextBox>
                                            </td>
                                            <td>
                                                <label>&nbsp;</label>
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
                          <asp:TextBox ID="txtFinalReport" runat="server" CssClass="span9"
                              Height="200"></asp:TextBox>
                      </div>

                  </div>
                
                   <div class="form-actions no-margin-bottom">
                        <asp:Button ID="btnSave" Width="600" Text="Save"
                            runat="server" class="btn btn-success btn-large btn-block" OnClick="btnSave_Click" />
                    </div>




            </div>

              
        </div>
</div>
    


</asp:Content>

