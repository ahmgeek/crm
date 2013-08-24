<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Clients.aspx.cs" Inherits="Clients_Clients" %>





<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
       <div class="tac">
        <a class="quick-btn"  href="/Clients/NewClient.aspx">
            <i class="icon-user icon-2x"></i>
            <span>New Client</span>
            <span class="label label-important">New Client</span>
        </a>
    </div>




    <!-- Views-->
    
    <!-- Users -->
        <div class="box">
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
                >
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAllUser" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllUser_CheckedChanged"  />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox ID="chkUser" runat="server" AutoPostBack="True" OnCheckedChanged="chkUser_CheckedChanged"  />
                        </ItemTemplate>
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="#">
                        <ItemTemplate>
                            <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>


                      <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" Font-Bold="true" Font-Size="Medium" runat="server"  Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Account Number">
                        <ItemTemplate>
                            <asp:Label ID="lblAccountNumber" runat="server"  Text='<%#Eval("AccountNumber") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="City">
                        <ItemTemplate>
                            <asp:Label ID="lblcity" runat="server"  Text='<%#Eval("city") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Phone">
                        <ItemTemplate>
                            <asp:Label ID="lblTelephone" runat="server"  Text='<%#Eval("Telephone") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Client Moblie">
                        <ItemTemplate>
                            <asp:Label ID="lblMob" runat="server"  Text='<%#Eval("Mob") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
        <asp:Literal ID="LitUserName" Visible="false"  runat="server"></asp:Literal>

                            <asp:LinkButton ID="btnEdit"
                                href='<%#"/Clients/ClientsDetail.aspx?Acc="+Eval("ClientId")%>'
                                 runat="server" CssClass="btn btn-small btn-metis-5" Text="Edit" />
                            
                             <asp:LinkButton ID="LinkButton2"
                                href='<%#"/Clients/"%>'
                                 runat="server" CssClass="btn btn-small btn-metis-1" Text="DeActivate" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
        </div>
                        <div class="form-actions">
                <asp:Button ID="btnDeleteUser"
                     type="submit" class="btn btn-danger" OnClientClick="return confirm(' Delete ? ')"
                    OnClick="btnDeleteUser_Click"
                     runat="server" Text="Delte" />

            </div>
   </div>
</asp:Content>

