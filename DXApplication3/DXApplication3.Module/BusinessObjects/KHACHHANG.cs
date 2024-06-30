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
    [System.ComponentModel.DisplayName("Khách hàng")]
    //[ImageName("BO_Contact")]
   // [DefaultProperty("Tenkh")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class KHACHHANG : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public KHACHHANG(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _cccd;
        [XafDisplayName("Số căn cước công dân"), Size(int.MaxValue)]
        public string Cccd
        {
            get { return _cccd; }
            set { SetPropertyValue<string>(nameof(Cccd), ref _cccd, value); }
        }

        private string _tenkh;
        [XafDisplayName("Tên khách hàng"), Size(int.MaxValue)]
        public string Tenkh
        {
            get { return _tenkh; }
            set { SetPropertyValue<string>(nameof(Tenkh), ref _tenkh, value); }
        }

        private string _sdt;
        [XafDisplayName("Số điện thoại"), Size(int.MaxValue)]
        public string Sdt
        {
            get { return _sdt; }
            set { SetPropertyValue<string>(nameof(Sdt), ref _sdt, value); }
        }

        private string _diachi;
        [XafDisplayName("Địa chỉ"), Size(int.MaxValue)]
        public string Diachi
        {
            get { return _diachi; }
            set { SetPropertyValue<string>(nameof(Diachi), ref _diachi, value); }
        }


        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Đặt hàng")]
        public XPCollection<DATHANG> DATHANGs
        {
            get { return GetCollection<DATHANG>(nameof(DATHANGs)); }
        }
    }
}