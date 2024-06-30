using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace DXApplication3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Đặt hàng")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("Tensp")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class DATHANG : BaseObject
    { 
        // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public DATHANG(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }


        private int _soluong;
        [XafDisplayName("Số lượng"), Size(int.MaxValue)]
        public int Soluong
        {
            get {
                return _soluong;
            }
            set {
                if (!IsLoading)
                {
                    int oldValue = _soluong;
                    _soluong = value;
                    OnSoluongChanged(oldValue);
                    if(Soluong > 0)
                    {
                        if (Soluong < Nhaphang.Soluong)
                        {
                            Thanhtien = (decimal)Soluong * Sanpham.Gia;
                        }
                    }
                }
                else
                {
                    _soluong = value;
                }
                
            }
        }

        private void OnSoluongChanged(int oldValue)
        {
            if (Nhaphang != null && oldValue > 0 && oldValue <= Nhaphang.Soluong)
            {
                Nhaphang.Soluong += oldValue; 
            }

            if (Nhaphang != null && Soluong > 0 && Soluong <= Nhaphang.Soluong)
            {
                Nhaphang.Soluong -= Soluong; 
            }
            else
            {
                
            }
        }


        private decimal _dongia;
        [XafDisplayName("Đơn gía"), Size(int.MaxValue)]
        public decimal Dongia
        {
            get { return _dongia; }
            set { SetPropertyValue<decimal>(nameof(Dongia), ref _dongia, value); }
        }

        private KHACHHANG _khachhang;
        [XafDisplayName("Khách hàng"), Size(255)]
        [Association]
        public KHACHHANG Khachhang
        {
            get { return _khachhang; }
            set
            {
                SetPropertyValue<KHACHHANG>(nameof(Khachhang), ref _khachhang, value);

            }
        }

        private SANPHAM _sanpham;
        [XafDisplayName("Sản phẩm"), Size(255)]
        [Association]
        public SANPHAM Sanpham
        {
            get { return _sanpham; }
            set
            {

                bool isModified = SetPropertyValue<SANPHAM>(nameof(Sanpham), ref _sanpham, value);
                if (isModified && !IsLoading && !IsSaving && value != null)
                {
                    Dongia = value.Gia;

                    if (value.NHAPHANGs != null && value.NHAPHANGs.Count > 0)
                    {
                        Nhaphang = value.NHAPHANGs.OrderByDescending(nhap => nhap.Soluong).FirstOrDefault();
                    }
                    else
                    {
                        Nhaphang = null;
                    }
                }

                SetPropertyValue<SANPHAM>(nameof(Sanpham), ref _sanpham, value);
            }
        }

        private NHAPHANG _nhaphang;
        [XafDisplayName("Nhập hàng"), Size(255)]
        [Association]
        [VisibleInDetailView(false), VisibleInListView(false), VisibleInLookupListView(false)]
        public NHAPHANG Nhaphang
        {
            get { return _nhaphang; }
            set
            {
                //Nhaphang.Soluong = Nhaphang.Soluong - Soluong;
                SetPropertyValue<NHAPHANG>(nameof(Nhaphang), ref _nhaphang, value);
            }
        }


        private HOADON _hoadon;
        [XafDisplayName("Hóa đơn"), Size(255)]
        [Association]
        public HOADON Hoadon
        {
            get { return _hoadon; }
            set {
                
                SetPropertyValue<HOADON>(nameof(Hoadon), ref _hoadon, value);
            
            
            }
        }


        private decimal _thanhtien;
        [XafDisplayName("Thành tiền"), Size(255)]
        public decimal Thanhtien
        {
            get
            {
                if (Khachhang == null || Sanpham == null || Sanpham.Gia == null)
                    return 0;

                if (Nhaphang == null || Soluong > Nhaphang.Soluong)
                    return 0;

                return (decimal)Soluong * Sanpham.Gia;
            }
            set { SetPropertyValue<decimal>(nameof(Thanhtien), ref _thanhtien, value); }
        }

        protected override void OnSaving()
        {
            base.OnSaving();
        }



    }
}