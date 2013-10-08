<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Calls_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
          <a class="quick-btn" style="width: 120px;"  href="/Cases/ManageCases.aspx">
            <i class="icon-phone icon-large "></i>
            <span>Manage Calls</span>
            <span class="label label-important">Calls</span>
        </a>
    
    
    
    

    <!-- Cases -->

      <div class="row-fluid">
        <div class="span12">


            <div class="box dark">
                <header>
                    <div class="icons"><i class="icon-briefcase"></i></div>
                    <h5>View Cases</h5>
                    <!-- .toolbar -->
                    <div class="toolbar">
                        <ul class="nav">
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
                        
                <asp:GridView ID="grd"
                CssClass="table table-bordered responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True" 
                EmptyDataText="Empty !" 
                OnRowDataBound="grd_RowDataBound" 
                OnPreRender="grd_PreRender"
                OnRowCommand="grd_OnRowCommand"  
                AllowPaging="true" 
                PageSize="10"
                >
                <Columns>
                       <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" Font-Bold="true"  style="width:180px;" runat="server"  Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Case Number">
                        <ItemTemplate>
                            <asp:Label ID="lblCaseNum" runat="server" style="width:100px;" Text='<%#Eval("CaseNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    
                       <asp:TemplateField HeaderText="Creation Date">
                        <ItemTemplate>
                            <asp:Label ID="lblCreation" runat="server" style="width:140px;"   Text='<%#Eval("dateTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                         <asp:TemplateField HeaderText="Mobile">
                        <ItemTemplate>
                            <asp:Label ID="lblMob" runat="server" style="width:90px;"  Text='<%#Eval("Mob") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label ID="lblGender" runat="server" style="width:40px;"  Text='<%#Eval("Gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Case Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server"  Text='<%#Eval("PrescriptionStatus") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit"
                                CommandArgument='<%# Eval("CaseId") %>'  CommandName="EditCommand"
                                 runat="server" CssClass="btn btn-small btn-danger" Text="Sign First Call" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
                        

                        </div>
                </div>

                </div>

            </div>

          </div>
</asp:Content>

