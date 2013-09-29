<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sessions.aspx.cs" Inherits="SystemSettings_DataEntry_Sessions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            

    <div class="box">
        <header>
            <div class="icons"><i class="icon-question"></i></div>
            <h5>Session Questions</h5>
            <div class="toolbar">
                <a href="#UserTable" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>
            </div>
        </header>
        <div id="UserTable" class="body collapse in">
      <div id="id" class="form-horizontal controls-row">

               <div class="control-group">
                                <label for="text1" class="control-label">Session Name : </label>

                                <div class="controls with-tooltip">

                                    <asp:TextBox ID="txtData"  runat="server" class="span7" required></asp:TextBox>
                                    &nbsp;  &nbsp;
                                    <asp:Button runat="server" ID="btnSave" Text="Save" 
                                       OnClick="btnSave_OnClick" CssClass="btn btn-primary"/>
                                      <asp:Button runat="server" ID="btnUpdate" Text="Update" 
                                    Visible="False"   OnClick="btnUpdate_OnClick" CssClass="btn btn-success"/>
                                </div>
                            </div>
          </div>
             <div class="form-horizontal controls-row" dir="rtl">
                 
                <asp:GridView ID="grd" 
                CssClass="table  table-bordered table-condensed table-hover table-striped"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True" 
                EmptyDataText="Empty !" 
                OnRowDataBound="grd_OnRowDataBound"
                OnPageIndexChanging="grd_OnPageIndexChanging"
                AllowPaging="True" OnRowCommand="grd_OnRowCommand" PageSize="25">
                <Columns>
                <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>

                    <asp:BoundField DataField="SessionDataName"  HeaderText="Sessions" />
                    <asp:TemplateField HeaderText="Action">
                <ItemTemplate>

                           <asp:LinkButton ID="btnEdit" runat="server" 
                               CssClass="btn btn-small btn-metis-5" Text="Edit"
                               CommandArgument='<%# Eval("SessionDataID") %>'  CommandName="EditCommand" />
                            
                             <asp:LinkButton ID="LinkButton2"
                                 runat="server" CssClass="btn btn-small btn-metis-1" Text="Delete"
                            CommandArgument='<%# Eval("SessionDataID") %>' CommandName="DeleteCommand" />
                </ItemTemplate>

                    </asp:TemplateField>

                </Columns>

            </asp:GridView>

                 </div>

        </div>
    </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

