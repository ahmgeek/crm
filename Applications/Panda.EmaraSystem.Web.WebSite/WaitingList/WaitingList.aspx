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

                
            </div>
        </div>
    </div>
</asp:Content>

