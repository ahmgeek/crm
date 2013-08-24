<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewSession.aspx.cs" Inherits="Sessions_NewSession" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box">
        <header>
            <div class="icons"><i class="icon-edit"></i></div>
            <h5><span class="label label-info">Contact Data</span> </h5>
        </header>
        <div id="List" class="body collapse in">
            <div class="tac">
                <asp:GridView ID="grdUser"
                CssClass="table table-bordered responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                OnPreRender="grdUser_PreRender">
                <Columns>
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
                    <asp:TemplateField HeaderText="Client Moblie">
                        <ItemTemplate>
                            <asp:Label ID="lblMob" runat="server"  Text='<%#Eval("Mob") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>


            </div>
            <hr />

        </div>
    </div>
</asp:Content>

