<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="ViewLastNBills.aspx.cs"
    Inherits="ElectricityBoardBilling.ViewLastNBills" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

<div class="billing-card">

    <h3 class="card-title">View Last N Bills</h3>

    <div class="form-group">
        <label class="form-label">Enter number of bills</label>

        <asp:TextBox ID="txtCount"
            runat="server"
            CssClass="input-box" />

       <div class="validation-msg">

   
    <asp:RequiredFieldValidator
        runat="server"
        ControlToValidate="txtCount"
        ErrorMessage="Enter number of bills"
        CssClass="error"
        Display="Dynamic" />

  
    <asp:CustomValidator
        ID="cvCount"
        runat="server"
        ControlToValidate="txtCount"
        ErrorMessage="Enter a value greater than zero"
        CssClass="error"
        Display="Dynamic" />

</div>
    </div>

    <div style="text-align:center; margin-top:15px;">
        <asp:Button ID="btnView"
            runat="server"
            Text="View Bills"
            CssClass="btn-submit"
            OnClick="btnView_Click" />
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

</div>

</asp:Content>
