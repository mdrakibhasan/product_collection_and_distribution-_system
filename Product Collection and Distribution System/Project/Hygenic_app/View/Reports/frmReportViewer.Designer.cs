namespace View.Reports
{
    partial class frmReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdbprofitLoss = new System.Windows.Forms.RadioButton();
            this.rdbStock = new System.Windows.Forms.RadioButton();
            this.rdbSalesInfo = new System.Windows.Forms.RadioButton();
            this.rdbReceivedInfo = new System.Windows.Forms.RadioButton();
            this.rdbPurchaseStaus = new System.Windows.Forms.RadioButton();
            this.rdbPurchaseInfo = new System.Windows.Forms.RadioButton();
            this.pnlSearch = new System.Windows.Forms.GroupBox();
            this.dtpEmdDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rptOthersreportviewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.grbStocksearch = new System.Windows.Forms.GroupBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.btnStockShow = new System.Windows.Forms.Button();
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.lblItemSearch = new System.Windows.Forms.Label();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.rdbUNAvailable = new System.Windows.Forms.RadioButton();
            this.rdbAvailable = new System.Windows.Forms.RadioButton();
            this.LBSearchItem = new System.Windows.Forms.ListBox();
            this.DataSet1 = new View.Reports.DataSet1();
            this.View_GetItemPurchaseMstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.View_GetItemPurchaseMstTableAdapter = new View.Reports.DataSet1TableAdapters.View_GetItemPurchaseMstTableAdapter();
            this.panel1.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.grbStocksearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_GetItemPurchaseMstBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(201, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rdbprofitLoss);
            this.panel1.Controls.Add(this.rdbStock);
            this.panel1.Controls.Add(this.rdbSalesInfo);
            this.panel1.Controls.Add(this.rdbReceivedInfo);
            this.panel1.Controls.Add(this.rdbPurchaseStaus);
            this.panel1.Controls.Add(this.rdbPurchaseInfo);
            this.panel1.Location = new System.Drawing.Point(23, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 182);
            this.panel1.TabIndex = 2;
            // 
            // rdbprofitLoss
            // 
            this.rdbprofitLoss.AutoSize = true;
            this.rdbprofitLoss.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbprofitLoss.Location = new System.Drawing.Point(23, 137);
            this.rdbprofitLoss.Name = "rdbprofitLoss";
            this.rdbprofitLoss.Size = new System.Drawing.Size(114, 20);
            this.rdbprofitLoss.TabIndex = 0;
            this.rdbprofitLoss.TabStop = true;
            this.rdbprofitLoss.Text = "Profit and Loss";
            this.rdbprofitLoss.UseVisualStyleBackColor = true;
            // 
            // rdbStock
            // 
            this.rdbStock.AutoSize = true;
            this.rdbStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbStock.Location = new System.Drawing.Point(22, 111);
            this.rdbStock.Name = "rdbStock";
            this.rdbStock.Size = new System.Drawing.Size(125, 20);
            this.rdbStock.TabIndex = 0;
            this.rdbStock.TabStop = true;
            this.rdbStock.Text = "Stock Informaton";
            this.rdbStock.UseVisualStyleBackColor = true;
            this.rdbStock.CheckedChanged += new System.EventHandler(this.rdbStock_CheckedChanged);
            // 
            // rdbSalesInfo
            // 
            this.rdbSalesInfo.AutoSize = true;
            this.rdbSalesInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSalesInfo.Location = new System.Drawing.Point(22, 88);
            this.rdbSalesInfo.Name = "rdbSalesInfo";
            this.rdbSalesInfo.Size = new System.Drawing.Size(126, 20);
            this.rdbSalesInfo.TabIndex = 0;
            this.rdbSalesInfo.TabStop = true;
            this.rdbSalesInfo.Text = "Sales Informaton";
            this.rdbSalesInfo.UseVisualStyleBackColor = true;
            // 
            // rdbReceivedInfo
            // 
            this.rdbReceivedInfo.AutoSize = true;
            this.rdbReceivedInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbReceivedInfo.Location = new System.Drawing.Point(22, 65);
            this.rdbReceivedInfo.Name = "rdbReceivedInfo";
            this.rdbReceivedInfo.Size = new System.Drawing.Size(202, 20);
            this.rdbReceivedInfo.TabIndex = 0;
            this.rdbReceivedInfo.TabStop = true;
            this.rdbReceivedInfo.Text = "Product Received Information";
            this.rdbReceivedInfo.UseVisualStyleBackColor = true;
            // 
            // rdbPurchaseStaus
            // 
            this.rdbPurchaseStaus.AutoSize = true;
            this.rdbPurchaseStaus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPurchaseStaus.Location = new System.Drawing.Point(22, 42);
            this.rdbPurchaseStaus.Name = "rdbPurchaseStaus";
            this.rdbPurchaseStaus.Size = new System.Drawing.Size(123, 20);
            this.rdbPurchaseStaus.TabIndex = 0;
            this.rdbPurchaseStaus.TabStop = true;
            this.rdbPurchaseStaus.Text = "Purchase Status";
            this.rdbPurchaseStaus.UseVisualStyleBackColor = true;
            // 
            // rdbPurchaseInfo
            // 
            this.rdbPurchaseInfo.AutoSize = true;
            this.rdbPurchaseInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPurchaseInfo.Location = new System.Drawing.Point(22, 19);
            this.rdbPurchaseInfo.Name = "rdbPurchaseInfo";
            this.rdbPurchaseInfo.Size = new System.Drawing.Size(151, 20);
            this.rdbPurchaseInfo.TabIndex = 0;
            this.rdbPurchaseInfo.TabStop = true;
            this.rdbPurchaseInfo.Text = "Purchase Information";
            this.rdbPurchaseInfo.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            this.pnlSearch.Controls.Add(this.dtpEmdDate);
            this.pnlSearch.Controls.Add(this.dtpStartDate);
            this.pnlSearch.Controls.Add(this.label2);
            this.pnlSearch.Controls.Add(this.label1);
            this.pnlSearch.Controls.Add(this.button1);
            this.pnlSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSearch.Location = new System.Drawing.Point(16, 244);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(327, 182);
            this.pnlSearch.TabIndex = 3;
            this.pnlSearch.TabStop = false;
            this.pnlSearch.Text = "Search";
            // 
            // dtpEmdDate
            // 
            this.dtpEmdDate.Font = new System.Drawing.Font("Microsoft Tai Le", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEmdDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEmdDate.Location = new System.Drawing.Point(114, 93);
            this.dtpEmdDate.Name = "dtpEmdDate";
            this.dtpEmdDate.Size = new System.Drawing.Size(182, 25);
            this.dtpEmdDate.TabIndex = 3;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(114, 45);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(182, 23);
            this.dtpStartDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "To Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "From Date";
            // 
            // rptOthersreportviewer
            // 
            this.rptOthersreportviewer.Location = new System.Drawing.Point(355, 12);
            this.rptOthersreportviewer.Name = "rptOthersreportviewer";
            this.rptOthersreportviewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
            this.rptOthersreportviewer.Size = new System.Drawing.Size(848, 514);
            this.rptOthersreportviewer.TabIndex = 4;
            // 
            // grbStocksearch
            // 
            this.grbStocksearch.Controls.Add(this.lblItemID);
            this.grbStocksearch.Controls.Add(this.btnStockShow);
            this.grbStocksearch.Controls.Add(this.txtSearchItem);
            this.grbStocksearch.Controls.Add(this.lblItemSearch);
            this.grbStocksearch.Controls.Add(this.rdbAll);
            this.grbStocksearch.Controls.Add(this.rdbUNAvailable);
            this.grbStocksearch.Controls.Add(this.rdbAvailable);
            this.grbStocksearch.Location = new System.Drawing.Point(19, 248);
            this.grbStocksearch.Name = "grbStocksearch";
            this.grbStocksearch.Size = new System.Drawing.Size(325, 203);
            this.grbStocksearch.TabIndex = 4;
            this.grbStocksearch.TabStop = false;
            this.grbStocksearch.Text = "Search Option";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(24, 74);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(0, 13);
            this.lblItemID.TabIndex = 143;
            this.lblItemID.Visible = false;
            // 
            // btnStockShow
            // 
            this.btnStockShow.Location = new System.Drawing.Point(224, 140);
            this.btnStockShow.Name = "btnStockShow";
            this.btnStockShow.Size = new System.Drawing.Size(75, 23);
            this.btnStockShow.TabIndex = 3;
            this.btnStockShow.Text = "Show";
            this.btnStockShow.UseVisualStyleBackColor = true;
            this.btnStockShow.Click += new System.EventHandler(this.btnStockShow_Click);
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Location = new System.Drawing.Point(106, 93);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.Size = new System.Drawing.Size(193, 20);
            this.txtSearchItem.TabIndex = 2;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.txtSearchItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchItem_KeyPress);
            // 
            // lblItemSearch
            // 
            this.lblItemSearch.AutoSize = true;
            this.lblItemSearch.Location = new System.Drawing.Point(16, 92);
            this.lblItemSearch.Name = "lblItemSearch";
            this.lblItemSearch.Size = new System.Drawing.Size(63, 13);
            this.lblItemSearch.TabIndex = 1;
            this.lblItemSearch.Text = "Search item";
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(19, 45);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(36, 17);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.TabStop = true;
            this.rdbAll.Text = "All";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // rdbUNAvailable
            // 
            this.rdbUNAvailable.AutoSize = true;
            this.rdbUNAvailable.Location = new System.Drawing.Point(182, 45);
            this.rdbUNAvailable.Name = "rdbUNAvailable";
            this.rdbUNAvailable.Size = new System.Drawing.Size(87, 17);
            this.rdbUNAvailable.TabIndex = 0;
            this.rdbUNAvailable.TabStop = true;
            this.rdbUNAvailable.Text = "UN-Available";
            this.rdbUNAvailable.UseVisualStyleBackColor = true;
            // 
            // rdbAvailable
            // 
            this.rdbAvailable.AutoSize = true;
            this.rdbAvailable.Location = new System.Drawing.Point(78, 45);
            this.rdbAvailable.Name = "rdbAvailable";
            this.rdbAvailable.Size = new System.Drawing.Size(71, 17);
            this.rdbAvailable.TabIndex = 0;
            this.rdbAvailable.TabStop = true;
            this.rdbAvailable.Text = "Available ";
            this.rdbAvailable.UseVisualStyleBackColor = true;
            // 
            // LBSearchItem
            // 
            this.LBSearchItem.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.LBSearchItem.FormattingEnabled = true;
            this.LBSearchItem.Location = new System.Drawing.Point(156, 221);
            this.LBSearchItem.Name = "LBSearchItem";
            this.LBSearchItem.Size = new System.Drawing.Size(64, 17);
            this.LBSearchItem.TabIndex = 142;
            this.LBSearchItem.Visible = false;
            this.LBSearchItem.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LBSearchItem_MouseClick);
            this.LBSearchItem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LBSearchItem_KeyPress);
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // View_GetItemPurchaseMstBindingSource
            // 
            this.View_GetItemPurchaseMstBindingSource.DataMember = "View_GetItemPurchaseMst";
            this.View_GetItemPurchaseMstBindingSource.DataSource = this.DataSet1;
            // 
            // View_GetItemPurchaseMstTableAdapter
            // 
            this.View_GetItemPurchaseMstTableAdapter.ClearBeforeFill = true;
            // 
            // frmReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1212, 655);
            this.Controls.Add(this.LBSearchItem);
            this.Controls.Add(this.rptOthersreportviewer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grbStocksearch);
            this.Controls.Add(this.pnlSearch);
            this.MinimizeBox = false;
            this.Name = "frmReportViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Report";
            this.Load += new System.EventHandler(this.frmReportViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.grbStocksearch.ResumeLayout(false);
            this.grbStocksearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.View_GetItemPurchaseMstBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource View_GetItemPurchaseMstBindingSource;
        private DataSet1 DataSet1;
        private DataSet1TableAdapters.View_GetItemPurchaseMstTableAdapter View_GetItemPurchaseMstTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdbStock;
        private System.Windows.Forms.RadioButton rdbSalesInfo;
        private System.Windows.Forms.RadioButton rdbReceivedInfo;
        private System.Windows.Forms.RadioButton rdbPurchaseStaus;
        private System.Windows.Forms.RadioButton rdbPurchaseInfo;
        private System.Windows.Forms.GroupBox pnlSearch;
        private System.Windows.Forms.DateTimePicker dtpEmdDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer rptOthersreportviewer;
        private System.Windows.Forms.GroupBox grbStocksearch;
        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.Label lblItemSearch;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.RadioButton rdbUNAvailable;
        private System.Windows.Forms.RadioButton rdbAvailable;
        private System.Windows.Forms.Button btnStockShow;
        private System.Windows.Forms.ListBox LBSearchItem;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.RadioButton rdbprofitLoss;
    }
}