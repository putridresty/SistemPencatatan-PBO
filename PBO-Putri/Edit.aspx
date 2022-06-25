<%@ Page Title="Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="PBO_Putri.Edit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="mt-5">
        <section class="input_section  mt-3">
            <h2>Edit Data</h2>
            <div id="inputList" class="text-dark">

                <div class="input mt-2">
                    <asp:Label for="namaInput" ID="namaLabel" runat="server" Text="Nama" />
                    <asp:TextBox ID="namaInput" class="form-control full-width" runat="server" />
                </div>

                <div class="input mt-2">
                    <asp:Label for="hargaInput" ID="hargaLabel" runat="server" Text="Harga" />
                    <asp:TextBox ID="hargaInput" class="form-control full-width" runat="server" />
                </div>

                <div class="input input-dropdown mt-2">
                    <asp:Label for="stokInput" ID="stokLabel" runat="server" Text="Stok Barang" />
                    <asp:TextBox ID="stokInput" class="form-control full-width" runat="server" />
                </div>

                <div class="text-center button mt-2">
                    <a class="btn btn-danger m-2" text="Cancel" runat="server" href="~/">Cancel</a>
                    <asp:Button class="btn btn-primary m-2" Text="Edit" OnClick="updateData" runat="server" />
                </div>

            </div>
        </section>
    </main>
</asp:Content>