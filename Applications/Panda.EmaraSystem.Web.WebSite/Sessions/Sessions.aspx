<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sessions.aspx.cs" Inherits="Sessions_Sessions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <asp:Timer ID="timer" OnTick="timer_Tick" Interval="280000" runat="server">
    </asp:Timer>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">


        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick"  />

        </Triggers>
        <ContentTemplate>

        <div class="box">
        <header>
            <div class="icons"><i class="icon-windows"></i></div>
            <h5><span class="label label-inverse">Sessions</span> </h5>
            <div class="toolbar">

                <a href="#List" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>

            </div>
        </header>
        <div id="List" class="body collapse in">

            <div class="tac">
            </div>

                <asp:GridView ID="grdWaitList"
                CssClass="table table-bordered responsive"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True"
                 EmptyDataText="Empty !"
                 OnRowDataBound="grdUsers_RowDataBound"
                 OnPageIndexChanging="grdUsers_PageIndexChanging"
                 OnPreRender="grdWaitList_PreRender">
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

                 <asp:TemplateField HeaderText="Session">
                        <ItemTemplate>
                            <asp:LinkButton Text="Open Session"
                                PostBackUrl='<%# "/Sessions/NewSession.aspx?id="+Eval("ClientId") %>'
                                 CssClass="btn btn-danger" ID="btnSession" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

            </asp:GridView>
            </div>
            </div>
    
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

