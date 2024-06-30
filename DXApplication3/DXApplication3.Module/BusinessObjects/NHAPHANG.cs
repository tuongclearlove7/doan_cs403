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

namespace DXApplication3.Module.BusinessObjects
{
    [DefaultClassOptions]
    [System.ComponentModel.DisplayName("Nhập hàng")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NHAPHANG : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NHAPHANG(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
                Ngaynhaphang = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private int _soluong;
        [XafDisplayName("Số lượng"), Size(int.MaxValue)]
        public int Soluong
        {
            get { return _soluong; }
            set { SetPropertyValue<int>(nameof(Soluong), ref _soluong, value); }
        }


        private DateTime _ngaynhaphang;
        [XafDisplayName("Ngày nhập hàng"), Size(int.MaxValue)]
        public DateTime Ngaynhaphang
        {
            get { return _ngaynhaphang; }
            set { SetPropertyValue<DateTime>(nameof(Ngaynhaphang), ref _ngaynhaphang, value); }
        }

        private string _mota;
        [XafDisplayName("Mô tả"), Size(int.MaxValue)]
        public string Mota
        {
            get { return _mota; }
            set { SetPropertyValue<string>(nameof(Mota), ref _mota, value); }
        }



        private SANPHAM _sanpham;
        [XafDisplayName("Sản phẩm"), Size(255)]
        [Association]
        public SANPHAM Sanpham
        {
            get { return _sanpham; }
            set
            {

                SetPropertyValue<SANPHAM>(nameof(Sanpham), ref _sanpham, value);

            }
        }


        private NHACUNGCAP _nhacungcap;
        [XafDisplayName("Nhà cung cấp"), Size(255)]
        [Association]
        public NHACUNGCAP Nhacungcap
        {
            get { return _nhacungcap; }
            set
            {

                SetPropertyValue<NHACUNGCAP>(nameof(Nhacungcap), ref _nhacungcap, value);

            }
        }


        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Đặt hàng")]
        public XPCollection<DATHANG> DATHANGs
        {
            get { return GetCollection<DATHANG>(nameof(DATHANGs)); }
        }




    }
}