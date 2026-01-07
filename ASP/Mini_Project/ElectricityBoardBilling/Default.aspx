<%@ Page Title="Home"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="ElectricityBoardBilling._Default" %>

<asp:Content ID="MainContent1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <div class="d-flex justify-content-center align-items-center"
         style="min-height:calc(100vh - 160px);">

        <div class="text-center" style="max-width:800px;">

            <h1 style="color:#0d6efd; font-weight:700;">
                Electricity Board Billing System
            </h1>

            <p style="font-size:16px; color:#555; margin-top:15px;">
                A web-based application to calculate, generate, and manage
                electricity bills efficiently using predefined tariff rules.
            </p>

            <div class="mt-4">
                <a href="AddElectricityBill.aspx"
                   class="btn btn-primary btn-lg me-3">
                    ➕ Add New Bill
                </a>

                <a href="ViewLastNBills.aspx"
                   class="btn btn-outline-primary btn-lg">
                    📄 View Bills
                </a>
            </div>

        </div>
    </div>

</asp:Content>
