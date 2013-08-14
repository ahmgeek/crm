<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RelClients.aspx.cs" Inherits="Clients_RelClients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="row-fluid">
        <div class="span12">
            <div class="box dark">
                <header>
                    <div class="icons"><i class="icon-male"></i></div>
                    <h5>Relate Clients</h5>
                    <!-- .toolbar -->
                    <div class="toolbar">
                        <ul class="nav">
                            <li>
                                <a href="#" "">
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
                <div id="div-1" class="accordion-body collapse in body">
                        <div class="form-horizontal">

                            <div class="control-group">
                                <label for="text1" class="control-label">Account Number</label>

                                <div class="controls with-tooltip">

                                    <asp:TextBox ID="txtAccNum" ReadOnly="true" runat="server" class="span6 input-tooltip"
                                        data-original-title="Account Number" data-placement="right"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label for="pass1" class="control-label">Client Name</label>

                                <div class="controls with-tooltip">

                                    <asp:TextBox ID="txtClientName" ReadOnly="true" class="span6 input-tooltip"
                                        data-original-title="Client Name" data-placement="right" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="control-group">
                                <label for="pass1" class="control-label">Has a Relation ? </label>

                                <div class="controls with-tooltip">
                                    <asp:RadioButtonList ID="rdlst" runat="server" 
                                        RepeatDirection="Horizontal" CellPadding="9" AutoPostBack="true" OnSelectedIndexChanged="rdlst_SelectedIndexChanged" >
                                        <asp:ListItem> Yes </asp:ListItem>
                                        <asp:ListItem> No </asp:ListItem>
                                    </asp:RadioButtonList>
                                   </div>
                            </div>



                            <asp:Panel ID="pnlRel" Visible="false" runat="server">
                            <div class="control-group">
                                <label class="control-label">Related To </label>

                                <div class="controls with-tooltip">
                                    <asp:DropDownList ID="drpClients" runat="server"
                                        CssClass="span6 chzn-select"
                                       >
                                        <asp:ListItem></asp:ListItem>

                                    </asp:DropDownList>
                                </div>
                            </div>

                                      <div class="control-group">
                                <label class="control-label">Relation Name</label>

                                <div class="controls with-tooltip">                                        
                                    <asp:TextBox ID="txtRelName" runat="server" CssClass="span6">
                                    </asp:TextBox>
                                   
                                </div>
                            </div>
                  
                          </asp:Panel>

                             
                            </div>
                       <div class="form-actions no-margin-bottom">
                                    <asp:Button ID="btnWaitList" Text="Save and send to waiting List"
                                        runat="server" class="btn btn-primary" OnClick="btnWaitList_Click" />
                                      &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                     <asp:Button ID="btnAppointMent" Text="Save and check an appointment"
                                        runat="server" class="btn btn-metis-6" OnClick="btnAppointMent_Click" />
                                </div>
                    </div>


        </div>
    
            
        </div>
</div>
        
               
</asp:Content>

