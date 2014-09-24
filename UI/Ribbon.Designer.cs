namespace UI
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab_FICC = this.Factory.CreateRibbonTab();
            this.group_Data = this.Factory.CreateRibbonGroup();
            this.group_Product = this.Factory.CreateRibbonGroup();
            this.tab_FICC.SuspendLayout();
            // 
            // tab_FICC
            // 
            this.tab_FICC.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab_FICC.Groups.Add(this.group_Data);
            this.tab_FICC.Groups.Add(this.group_Product);
            this.tab_FICC.Label = "FICC";
            this.tab_FICC.Name = "tab_FICC";
            // 
            // group_Data
            // 
            this.group_Data.Label = "Data";
            this.group_Data.Name = "group_Data";
            // 
            // group_Product
            // 
            this.group_Product.Label = "Product";
            this.group_Product.Name = "group_Product";
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab_FICC);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonTest_Load);
            this.tab_FICC.ResumeLayout(false);
            this.tab_FICC.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab_FICC;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_Data;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group_Product;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon RibbonTest
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
