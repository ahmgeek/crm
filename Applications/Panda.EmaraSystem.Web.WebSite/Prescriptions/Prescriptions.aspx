<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Prescriptions.aspx.cs" Inherits="Prescriptions_Prescriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


    <asp:Timer ID="timer" OnTick="timer_Tick" Interval="28000" runat="server">
    </asp:Timer>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="box">
        <header>
            <div class="icons"><i class="icon-medkit"></i></div>
            <h5><span class="label label-inverse">Prescriptions</span> </h5>
            <div class="toolbar">

                <a href="#List" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>

            </div>
        </header>
        <div id="List" class="body collapse in">

            <div class="tac">
            </div>

            </div>

                <asp:GridView ID="grdClients" runat="server"
                    CssClass="table  table-bordered table-condensed table-hover table-striped"
                    GridLines="None"
                    CellSpacing="-1"
                    AutoGenerateColumns="False"
                    ShowFooter="True" ShowHeaderWhenEmpty="True"
                    EmptyDataText="Empty !"
                    OnRowDataBound="grdClients_RowDataBound"
                    OnPageIndexChanging="grdClients_PageIndexChanging"
                    OnPreRender="grdClients_PreRender"
                    >

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
                            <asp:Label ID="lblStatus" runat="server"  Text='<%#Eval("IsServed") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Time">
                        <ItemTemplate>
                            <asp:Label ID="lblTime" Visible="true" runat="server" Text='<%#Eval("DateTime") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                 <asp:TemplateField HeaderText="Prescription">
                        <ItemTemplate>
                            <asp:LinkButton Text="View"
                                PostBackUrl='<%# "/Prescriptions/NewPrescription.aspx?id="+Eval("ClientId") %>'
                                 CssClass="btn btn-danger" ID="btnSession" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>

                </asp:GridView>
            </div>
       </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

