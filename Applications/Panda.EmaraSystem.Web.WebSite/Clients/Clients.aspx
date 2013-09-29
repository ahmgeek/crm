<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clients.aspx.cs" Inherits="Clients_Clients" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <a class="quick-btn"  href="/Clients/NewClient.aspx">
            <i class="icon-user icon-2x"></i>
            <span>New Client</span>
            <span class="label label-important">New Client</span>
        </a>


    <!-- Views-->
    
  <div class="row-fluid">
        <div class="span12">
        <div class="box dark">
        <header>
            <div class="icons"><i class="icon-user-md"></i></div>
            <h5> Clients </h5>
            <div class="toolbar">
                <a href="#UserTable" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>
            </div>
        </header>
        <div id="UserTable" class="body collapse in">
                        <asp:GridView ID="grdUsers"
                CssClass="table table-bordered responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True" 
                EmptyDataText="Empty !" 
                OnRowDataBound="grdUsers_RowDataBound" 
                OnPageIndexChanging="grdUsers_PageIndexChanging"
                OnPreRender="grdUsers_PreRender"
                OnRowCommand="grdUsers_OnRowCommand"  
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
                            <asp:Label ID="lblFullName" Font-Bold="true" style="width:180px;" runat="server"  Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Regestration Date">
                        <ItemTemplate>
                            <asp:Label ID="lblRegister" runat="server" style="width:140px;" Text='<%#Eval("CreationDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                       <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" style="width:90px;" Text='<%#Eval("City") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                       <asp:TemplateField HeaderText="Client Moblie">
                        <ItemTemplate>
                            <asp:Label ID="lblMob" runat="server" style="width:90px;" Text='<%#Eval("Mob") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                         <asp:TemplateField HeaderText="Has Relatives ? ">
                        <ItemTemplate>
                            <asp:Label ID="lblRelation" runat="server" style="width:40px;" Text='<%#Eval("HasArelation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit"
                                CommandArgument='<%# Eval("ClientId") %>'  CommandName="EditCommand"
                                 runat="server" CssClass="btn btn-small btn-metis-5" Text="Edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
   </div>
   </div>

   </div>

</asp:Content>

