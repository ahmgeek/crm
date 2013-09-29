<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SessionQuestions.aspx.cs" Inherits="SystemSettings_DataEntry_SessionQuestions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
      <div id="question" class="form-horizontal controls-row">

               <div class="control-group">
                                <label for="text1" class="control-label">Question : </label>

                                <div class="controls with-tooltip">

                                    <asp:TextBox ID="txtQuestion"  runat="server" class="span7" required></asp:TextBox>
                                    &nbsp;  &nbsp;
                                    <asp:Button runat="server" ID="btnSave" Text="Save" 
                                       OnClick="btnSave_OnClick" CssClass="btn btn-primary"/>
                                      <asp:Button runat="server" ID="btnUpdate" Text="Update" 
                                    Visible="False"   OnClick="btnUpdate_OnClick" CssClass="btn btn-success"/>
                                </div>
                            </div>
          </div>
             <div class="form-horizontal controls-row" dir="rtl">
                 
                <asp:GridView ID="grdQuestions" 
                CssClass="table  table-bordered table-condensed table-hover table-striped"
                runat="server"
                GridLines="None"
                CellSpacing="-1"
                AutoGenerateColumns="False"
                ShowFooter="True" ShowHeaderWhenEmpty="True" 
                EmptyDataText="Empty !" 
                OnRowDataBound="grdQuestions_OnRowDataBound"
                OnPageIndexChanging="grdQuestions_OnPageIndexChanging"
                AllowPaging="True" OnRowCommand="grdQuestions_RowCommand" PageSize="25">
                <Columns>
                <asp:TemplateField HeaderText="#">
                <ItemTemplate>
                    <asp:Label ID="lblRank" runat="server" Text='<%# Container.DataItem %>'></asp:Label>
                </ItemTemplate>
                </asp:TemplateField>

                    <asp:BoundField DataField="SessionQuestion"  HeaderText="Question" />
                    <asp:TemplateField HeaderText="Action">
                <ItemTemplate>

                           <asp:LinkButton ID="btnEdit" runat="server" 
                               CssClass="btn btn-small btn-metis-5" Text="Edit"
                               CommandArgument='<%# Eval("SessionDataID") %>'  CommandName="EditQuestion" />
                            
                             <asp:LinkButton ID="LinkButton2"
                                 runat="server" CssClass="btn btn-small btn-metis-1" Text="Delete"
                            CommandArgument='<%# Eval("SessionDataID") %>' CommandName="DeleteQuestion" />
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

