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
    [System.ComponentModel.DisplayName("Nhà cung cấp")]
    //[ImageName("BO_Contact")]
    [DefaultProperty("Tenncc")]
    [DefaultListViewOptions(MasterDetailMode.ListViewOnly, true, NewItemRowPosition.Top)]
    //[Persistent("DatabaseTableName")]
    // Specify more UI options using a declarative approach (https://documentation.devexpress.com/#eXpressAppFramework/CustomDocument112701).
    public class NHACUNGCAP : BaseObject
    { // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
        // Use CodeRush to create XPO classes and properties with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/118557
        public NHACUNGCAP(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
        }

        private string _tenncc;
        [XafDisplayName("Tên nhà cung cấp"), Size(int.MaxValue)]
        public string Tenncc
        {
            get { return _tenncc; }
            set { SetPropertyValue<string>(nameof(Tenncc), ref _tenncc, value); }
        }

        private string _mota;
        [XafDisplayName("Mô tả"), Size(int.MaxValue)]
        public string Mota
        {
            get { return _mota; }
            set { SetPropertyValue<string>(nameof(Mota), ref _mota, value); }
        }


        [DevExpress.Xpo.Aggregated, Association]
        [XafDisplayName("nhập hàng")]
        public XPCollection<NHAPHANG> NHAPHANGs
        {
            get { return GetCollection<NHAPHANG>(nameof(NHAPHANGs)); }
        }

    }
}