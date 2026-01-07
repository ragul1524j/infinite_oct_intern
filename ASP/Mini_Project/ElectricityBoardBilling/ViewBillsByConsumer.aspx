<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ViewBillsByConsumer.aspx.cs"
    Inherits="ElectricityBoardBilling.ViewBillsByConsumer" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="billing-card" style="width:500px">

    <h3 class="card-title">View Bills by Consumer</h3>

    <div class="form-group">
        <label class="form-label">Enter Consumer Number</label>

        <asp:TextBox ID="txtConsumerNumber"
            runat="server"
            CssClass="input-box" />

        <div class="validation-msg">
            <asp:RequiredFieldValidator
                runat="server"
                ControlToValidate="txtConsumerNumber"
                ErrorMessage="Consumer Number is required"
                CssClass="error"
                Display="Dynamic" />
        </div>
    </div>

    <div style="text-align:center; margin-top:15px;">
        <asp:Button ID="btnSearch"
            runat="server"
            Text="View Bills"
            CssClass="btn-submit"
            OnClick="btnSearch_Click" />
    </div>

    <br />

    <asp:GridView ID="gvBills"
        runat="server"
        AutoGenerateColumns="False"
        CssClass="table table-bordered"
        Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">

        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />

        <Columns>
            <asp:BoundField HeaderText="Consumer Number" DataField="ConsumerNumber" />
            <asp:BoundField HeaderText="Consumer Name" DataField="ConsumerName" />
            <asp:BoundField HeaderText="Bill Month" DataField="BillMonth" />
            <asp:BoundField HeaderText="Units Consumed" DataField="UnitsConsumed" />
            <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" />
        </Columns>

        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

    </asp:GridView>

    <asp:Label ID="lblMessage"
        runat="server"
        CssClass="error"
        Visible="false"></asp:Label>

</div>

</asp:Content>
