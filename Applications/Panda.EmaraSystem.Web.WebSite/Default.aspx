<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="box">
        <header>
            <div class="icons"><i class="icon-link"></i></div>
            <h5><span class="label label-important">Quick Links</span> </h5>
            <div class="toolbar">

                <a href="#quick" data-toggle="collapse" class="accordion-toggle minimize-box">
                    <i class="icon-chevron-up"></i>
                </a>

            </div>
        </header>
        <div id="quick" class="body collapse in">

            <div class="tac">
                <a class="quick-btn" href="/Clients/NewClient.aspx">
                    <i class="icon-user icon-2x"></i>
                    <span>New Client </span>
                    <span class="label label-important">New</span>
                </a>
                <a class="quick-btn" href="/WaitingList/WaitingList.aspx">
                    <i class="icon-list-ul icon-2x"></i>
                    <span>Waiting List</span>
                    <span class="label label-info">View</span>
                </a>
                <a class="quick-btn" href="/Sessions/Sessions.aspx">
                    <i class="icon-building icon-2x"></i>
                    <span>New Session</span>
                    <span class="label label-important">New</span>
                </a>
                <a class="quick-btn" href="/Prescriptions/NewPrescription.aspx">
                    <i class="icon-medkit icon-2x"></i>
                    <span>Prescription</span>
                    <span class="label label-important">New</span>
                </a>
                <a class="quick-btn" href="Clients/Clients.aspx">
                    <i class="icon-male icon-2x"></i>
                    <span>Clients</span>
                    <span class="label label-info">View</span>
                </a>




            </div>
        </div>
    </div>
    <hr />

    <div class="tac">
        <ul class="stats_box">
            <li>
                <div class="sparkline bar_week"></div>
                <div class="stat_text">
                    <strong>2.345</strong>Total Clients
                <span class="percent down"><i class="icon-caret-up"></i>TODO</span>
                </div>
            </li>
            <li>
                <div class="sparkline line_day"></div>
                <div class="stat_text">
                    <strong>165</strong>Daily Visit
                                            <span class="percent up"><i class="icon-caret-up"></i>TODO</span>
                </div>
            </li>
            <li>
                <div class="sparkline pie_week"></div>
                <div class="stat_text">
                    <strong>$2 345.00</strong>Weekly Sale
                                            <span class="percent">TODO</span>
                </div>
            </li>
            <li>
                <div class="sparkline stacked_month"></div>
                <div class="stat_text">
                    <strong>$678.00</strong>Monthly Sale
                                            <span class="percent down"><i class="icon-caret-down"></i>TODO</span>
                </div>
            </li>
        </ul>
    </div>

</asp:Content>

