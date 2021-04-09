<%@ Page Title="" Language="C#" MasterPageFile="~/App.Master" AutoEventWireup="true" CodeBehind="ChiTietSach.aspx.cs" Inherits="QLTV.ChiTietSach1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:DataList ID="DataList1" runat="server">
            <SelectedItemTemplate>
                <asp:Image ID="Image1" runat="server" />
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Text="Label" Text='<%# Eval("tensach") %>'></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Label" Text='<%# Eval("mota") %>'></asp:Label>

                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Số lượng" ></asp:Label>
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>

            </SelectedItemTemplate>

        </asp:DataList>
</asp:Content>
