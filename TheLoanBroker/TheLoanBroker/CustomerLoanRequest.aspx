<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerLoanRequest.aspx.cs" Inherits="TheLoanBroker.CustomerLoanRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />€
        <br />
        Vælg beløb:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxAmount" runat="server" Width="169px"></asp:TextBox>
        <br />
&nbsp;<br />
        Vælg låneperiode:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxDuration" runat="server"></asp:TextBox>
        <br />
        <br />
        CPR-nummer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxSSN" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ButtonLoanRequest" runat="server" OnClick="ButtonLoanRequest_Click" Text="Lån nu" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
