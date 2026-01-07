<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AddElectricityBill.aspx.cs"
    Inherits="ElectricityBoardBilling.AddElectricityBill" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="billing-card">

    <h3 class="card-title">Add Electricity Bill</h3>

    <!-- Consumer Number -->
    <div class="form-group">
        <label class="form-label">Consumer Number</label>

        <asp:TextBox ID="txtConsumerNumber"
            runat="server"
            CssClass="input-box"
            onblur="validateOnBlur('BillGroup')" />

        <div class="validation-msg">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="txtConsumerNumber"
                ErrorMessage="Number required"
                CssClass="error"
                Display="Dynamic"
                ValidationGroup="BillGroup"
                SetFocusOnError="true" />
        </div>
    </div>

    <!-- Consumer Name -->
    <div class="form-group">
        <label class="form-label">Consumer Name</label>

        <asp:TextBox ID="txtConsumerName"
            runat="server"
            CssClass="input-box"
            onblur="validateOnBlur('BillGroup')" />

        <div class="validation-msg">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="txtConsumerName"
                ErrorMessage="Name required"
                CssClass="error"
                Display="Dynamic"
                ValidationGroup="BillGroup"
                SetFocusOnError="true" />
        </div>
    </div>

    <!-- Units Consumed -->
    <div class="form-group">
        <label class="form-label">Units Consumed</label>

        <asp:TextBox ID="txtUnits"
            runat="server"
            CssClass="input-box"
            onblur="validateOnBlur('BillGroup')" />

        <div class="validation-msg">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="txtUnits"
                ErrorMessage="Units required"
                CssClass="error"
                Display="Dynamic"
                ValidationGroup="BillGroup"
                SetFocusOnError="true" />

            <asp:RangeValidator
                runat="server"
                ControlToValidate="txtUnits"
                MinimumValue="0"
                MaximumValue="10000"
                Type="Integer"
                ErrorMessage="Invalid Units"
                CssClass="error"
                Display="Dynamic"
                ValidationGroup="BillGroup"
                SetFocusOnError="true" />
        </div>
    </div>

    <div class="form-group">
        <label class="form-label">Bill Month</label>

        <asp:DropDownList ID="ddlMonth"
            runat="server"
            CssClass="input-box">
            <asp:ListItem Text="-- Select Month --" Value="" />
            <asp:ListItem>January</asp:ListItem>
            <asp:ListItem>February</asp:ListItem>
            <asp:ListItem>March</asp:ListItem>
            <asp:ListItem>April</asp:ListItem>
            <asp:ListItem>May</asp:ListItem>
            <asp:ListItem>June</asp:ListItem>
            <asp:ListItem>July</asp:ListItem>
            <asp:ListItem>August</asp:ListItem>
            <asp:ListItem>September</asp:ListItem>
            <asp:ListItem>October</asp:ListItem>
            <asp:ListItem>November</asp:ListItem>
            <asp:ListItem>December</asp:ListItem>
        </asp:DropDownList>

        <div class="validation-msg">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="ddlMonth"
                InitialValue=""
                ErrorMessage="Select bill month"
                CssClass="error"
                Display="Dynamic"
                ValidationGroup="BillGroup"
                SetFocusOnError="true" />
        </div>
    </div>

    
    <div style="text-align:center; margin-top:15px;">
        <asp:Button ID="btnAddBill"
            runat="server"
            Text="Add Bill"
            CssClass="btn-submit"
            ValidationGroup="BillGroup"
            CausesValidation="true"
            OnClick="btnAddBill_Click" />
    </div>

    <asp:Label ID="lblResult"
        runat="server"
        CssClass="result-label"></asp:Label>

</div>

</asp:Content>
