<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="WaitingList.aspx.cs" Inherits="WaitingList_WaitingList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box">
        <header>
            <div class="icons"><i class="icon-list-alt"></i></div>
            <h5><span class="label label-success">Waiting List</span> </h5>
            <div class="toolbar">

                <a href="#List" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>

            </div>
        </header>
        <div id="List" class="body collapse in">

            <div class="tac">
              <asp:GridView ID="grdUnServed"
                CssClass="table table-bordered table-hover table-striped responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True"
                 EmptyDataText="Empty !"
                 OnRowDataBound="grdUnServed_RowDataBound"
                 OnPageIndexChanging="grdUnServed_PageIndexChanging"
                 OnPreRender="grdUnServed_PreRender"
                 
                  AllowPaging="True" PageSize="10">
                <Columns>

                    <asp:TemplateField  HeaderText="#">
                        <ItemTemplate>
                            <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" runat="server"  Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server"  Text='<%#Eval("IsReserved") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                        <ItemTemplate>
                            <asp:Label ID="lblTime" Visible="false" runat="server" Text='<%#Eval("DateTime") %>'></asp:Label>
                            <asp:Label ID="lblDate"  runat="server"></asp:Label>
                            <asp:Label ID="lblNewTime" runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

            </div>
            <hr />
            <asp:GridView ID="grdWaitList"
                CssClass="table table-bordered table-hover table-striped responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True"
                 EmptyDataText="Empty !"
                 OnRowDataBound="grdUsers_RowDataBound"
                 OnPageIndexChanging="grdUsers_PageIndexChanging"
                 OnPreRender="grdWaitList_PreRender"
                AllowPaging="True" PageSize="10">
                <Columns>

                    <asp:TemplateField  HeaderText="#">
                        <ItemTemplate>
                            <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="lblFullName" runat="server"  Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Status">
                        <ItemTemplate>
                            <asp:Label ID="lblStatus" runat="server"  Text='<%#Eval("IsReserved") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                        <ItemTemplate>
                            <asp:Label ID="lblTime" Visible="false" runat="server" Text='<%#Eval("DateTime") %>'></asp:Label>
                            <asp:Label ID="lblDate"  runat="server"></asp:Label>
                            <asp:Label ID="lblNewTime" runat="server"></asp:Label>

                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

        </div>
    </div>
</asp:Content>

