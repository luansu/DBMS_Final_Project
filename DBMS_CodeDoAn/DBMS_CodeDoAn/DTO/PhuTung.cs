﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS_CodeDoAn.DTO
{
    public class PhuTung
    {
        private string maPhuTung;
        private string loaiPhuTung;
        private string tenPhuTung;
        private string thuongHieu;
        private string xuatXu;
        private float giaBan;
        private string chatLuong;
        private string hinhAnh;
        public string MaPhuTung { get => maPhuTung; set => maPhuTung = value; }
        public string LoaiPhuTung { get => loaiPhuTung; set => loaiPhuTung = value; }
        public string TenPhuTung { get => tenPhuTung; set => tenPhuTung = value; }
        public string ThuongHieu { get => thuongHieu; set => thuongHieu = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public float GiaBan { get => giaBan; set => giaBan = value; }
        public string ChatLuong { get => chatLuong; set => chatLuong = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }

        public PhuTung(string maPhuTung, string loaiPhuTung, string tenPhuTung, string thuongHieu, string xuatXu, float giaBan, string chatLuong, string hinhAnh)
        {
            MaPhuTung = maPhuTung;
            LoaiPhuTung = loaiPhuTung;
            TenPhuTung = tenPhuTung;
            ThuongHieu = thuongHieu;
            XuatXu = xuatXu;
            GiaBan = giaBan;
            ChatLuong = chatLuong;
            HinhAnh = hinhAnh;
        }

        public PhuTung(DataRow row)
        {
            MaPhuTung = row["maPhuTung"].ToString();
            LoaiPhuTung = row["loaiPhuTung"].ToString();
            TenPhuTung = row["tenPhuTung"].ToString();
            ThuongHieu = row["thuongHieu"].ToString();
            XuatXu = row["xuatXu"].ToString();
            GiaBan = (float)Convert.ToDouble(row["giaBan"].ToString());
            ChatLuong = row["chatLuong"].ToString();
            HinhAnh = row["hinhAnh"].ToString();
        }

        private byte[] ConvertImageToByteArray(Image image)
        {
            if (image == null)
            {
                return null;
            }
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(image, typeof(byte[]));
            return xByte;
        }

        private Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }
            try
            {
                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    return Image.FromStream(stream);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
