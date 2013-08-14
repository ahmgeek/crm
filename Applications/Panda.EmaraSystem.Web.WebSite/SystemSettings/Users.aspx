<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.cs" Inherits="SystemSetting_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="tac">
        <a class="quick-btn" data-target="#EditModal" data-toggle="modal" href="/SystemSettings/User.aspx">
            <i class="icon-user icon-2x"></i>
            <span>New User</span>
            <span class="label label-important">New</span>

        </a>


    </div>



    <!-- Users -->
        <div class="box">
        <header>
            <div class="icons"><i class="icon-user"></i></div>
            <h5>Users</h5>
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
                ShowFooter="True" ShowHeaderWhenEmpty="True" EmptyDataText="Empty !" OnRowDataBound="grdUsers_RowDataBound" OnPageIndexChanging="grdUsers_PageIndexChanging">
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

                    <asp:BoundField DataField="UserName" HeaderText="User Name" />

                    <asp:BoundField DataField="LastLoginDate" HeaderText="LastLoginDate" />

                   

                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
        <asp:Literal ID="LitUserName" Visible="false"  runat="server" Text='<%#Eval("UserName") %>'></asp:Literal>

                            <asp:LinkButton ID="btnEdit"
                                data-toggle="modal"
                                data-target="#EditModal"
                                href='<%#"/SystemSettings/User.aspx?name="+Eval("UserName")%>'
                                 runat="server" CssClass="btn  icon-edit" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            <div class="form-actions">
                <asp:Button ID="btnDeleteUser"
                     type="submit" class="btn btn-danger" OnClientClick="return confirm(' Delete ? ')"
                     runat="server" Text="Delte" OnClick="btnDeleteUser_Click" />

            </div>
        </div>
    </div>

    <!-- Users End -->


    <!-- ROles -->


    <!-- ROles End -->

    <!-- Modal Edit -->
    <div id="EditModal" class="modal hide fade" style="width:650px;" tabindex="-1" role="application" aria-labelledby="Edit"
        aria-hidden="true">
        <div class="modal-header">
            <h3 id="helpModalLabel"><i class="icon-external-link"></i></h3>
        </div>
        <div class="modal-body">
        </div>
        <div class="modal-footer">

            <button class="btn" data-dismiss="modal" aria-hidden="true">Close</button>
        </div>
    </div>

    <!-- Modal Edit -->
 
</asp:Content>

