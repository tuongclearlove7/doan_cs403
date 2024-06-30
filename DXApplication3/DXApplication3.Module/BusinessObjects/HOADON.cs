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
    [System.ComponentModel.DisplayName("Hóa đơn")]
    [DefaultProperty("Tongtien")]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class HOADON : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public HOADON(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (Session.IsNewObject(this))
                Ngay = DateTime.Now;
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        

        private DateTime _ngay;
        [XafDisplayName("Ngày đặt"), Size(int.MaxValue)]
        public DateTime Ngay
        {
            get { return _ngay; }
            set { SetPropertyValue<DateTime>(nameof(Ngay), ref _ngay, value); }
        }

        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("Đặt hàng")]
        public XPCollection<DATHANG> DATHANGs
        {
            get { return GetCollection<DATHANG>(nameof(DATHANGs)); }
        }



        [XafDisplayName("Tổng tiền"), Size(255)]
        public decimal Tongtien
        {
            get
            {
                decimal tong = 0;
                foreach (var item in DATHANGs) {

                    tong += item.Thanhtien;
                }

                return tong;
            }
        }
    }
}