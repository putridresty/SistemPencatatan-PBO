using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBO_Putri
{
    public class Pencatatan
    {
        public string id;
        public string namabarang;
        public int harga;
        public int stok;

        public Pencatatan(string id, string namabarang, int harga, int stok)
        {
            this.id = id;
            this.namabarang = namabarang;
            this.harga = harga;
            this.stok = stok;
        }
    }
}