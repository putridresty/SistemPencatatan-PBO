<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="PBO_Putri.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main class="mt-5">
        <section class="input_section  mt-3">
            <h2>Masukan Data</h2>
            <div id="inputList" class="text-dark">
                <div class="input mt-2">
                    <asp:Label for="namabarang" runat="server" Text="Nama Barang" />
                    <asp:TextBox ID="namabarang" class="form-control full-width" runat="server" />
                </div>
                <div class="input mt-2">
                    <asp:Label for="harga" runat="server" Text="Harga">
                        <asp:TextBox ID="harga" class="form-control full-width" TextMode="number" runat="server" />
                    </asp:Label>
                </div>
                <div class="input input-dropdown mt-2">
                    <asp:Label for="stok" runat="server" Text="Stok Barang">
                        <asp:TextBox ID="stok" class="form-control full-width" TextMode="number" runat="server" />
                    </asp:Label>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    </div>  
                <div class="text-center button mt-2">
                    <a class="btn btn-danger m-2" text="Cancel" runat="server" href="~/">Cancel</a>
                    <asp:Button class="btn btn-success m-2" Text="Done" runat="server" OnClick="insertData" />
                </div>

            </div>
        </section>
    </main>
</asp:Content>
