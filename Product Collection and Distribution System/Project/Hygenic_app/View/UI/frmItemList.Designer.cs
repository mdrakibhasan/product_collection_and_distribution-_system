namespace View.UI
{
    partial class frmItemList
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesign = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUOMID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscountAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitsInStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.dgvItem);
            this.pnlBottom.Controls.Add(this.lblHeader);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 48);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Padding = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlBottom.Size = new System.Drawing.Size(693, 307);
            this.pnlBottom.TabIndex = 18;
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AllowUserToResizeRows = false;
            this.dgvItem.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colCode,
            this.colItemSize,
            this.colName,
            this.colSubCategory,
            this.colCategory,
            this.colDesign,
            this.colUOMID,
            this.colUOM,
            this.colUnitPrice,
            this.colDiscountAmount,
            this.colUnitsInStock});
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgvItem.Location = new System.Drawing.Point(6, 30);
            this.dgvItem.MultiSelect = false;
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersVisible = false;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(681, 272);
            this.dgvItem.TabIndex = 13;
            this.dgvItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItem_CellDoubleClick);
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.ReadOnly = true;
            this.colID.Visible = false;
            // 
            // colCode
            // 
            this.colCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Code";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            // 
            // colItemSize
            // 
            this.colItemSize.DataPropertyName = "StyleNo";
            this.colItemSize.FillWeight = 120F;
            this.colItemSize.HeaderText = "Style No.";
            this.colItemSize.Name = "colItemSize";
            this.colItemSize.ReadOnly = true;
            this.colItemSize.Visible = false;
            this.colItemSize.Width = 140;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Name";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 177;
            // 
            // colSubCategory
            // 
            this.colSubCategory.DataPropertyName = "SubCategory";
            this.colSubCategory.HeaderText = "SubCategory";
            this.colSubCategory.Name = "colSubCategory";
            this.colSubCategory.ReadOnly = true;
            // 
            // colCategory
            // 
            this.colCategory.DataPropertyName = "Category";
            this.colCategory.HeaderText = "Category";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            // 
            // colDesign
            // 
            this.colDesign.DataPropertyName = "design";
            this.colDesign.HeaderText = "design";
            this.colDesign.Name = "colDesign";
            this.colDesign.ReadOnly = true;
            this.colDesign.Visible = false;
            // 
            // colUOMID
            // 
            this.colUOMID.DataPropertyName = "UOMID";
            this.colUOMID.HeaderText = "UOM";
            this.colUOMID.Name = "colUOMID";
            this.colUOMID.ReadOnly = true;
            this.colUOMID.Visible = false;
            // 
            // colUOM
            // 
            this.colUOM.DataPropertyName = "UOMName";
            this.colUOM.HeaderText = "UOM";
            this.colUOM.Name = "colUOM";
            this.colUOM.ReadOnly = true;
            this.colUOM.Width = 80;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            this.colUnitPrice.FillWeight = 60F;
            this.colUnitPrice.HeaderText = "Unit Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // colDiscountAmount
            // 
            this.colDiscountAmount.DataPropertyName = "DiscountAmount";
            this.colDiscountAmount.HeaderText = "DiscountAmount";
            this.colDiscountAmount.Name = "colDiscountAmount";
            this.colDiscountAmount.ReadOnly = true;
            this.colDiscountAmount.Visible = false;
            this.colDiscountAmount.Width = 70;
            // 
            // colUnitsInStock
            // 
            this.colUnitsInStock.DataPropertyName = "UnitsInStock";
            this.colUnitsInStock.FillWeight = 50F;
            this.colUnitsInStock.HeaderText = "Stock ";
            this.colUnitsInStock.Name = "colUnitsInStock";
            this.colUnitsInStock.ReadOnly = true;
            this.colUnitsInStock.Visible = false;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(6, 5);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(681, 25);
            this.lblHeader.TabIndex = 11;
            this.lblHeader.Text = "Item List";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(693, 48);
            this.pnlTop.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search By Code/Name/Style No.";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(205, 13);
            this.txtSearch.MaxLength = 50;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSearch.Size = new System.Drawing.Size(457, 20);
            this.txtSearch.TabIndex = 13;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // frmItemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(693, 355);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmItemList";
            this.Text = "frmItemList";
            this.Load += new System.EventHandler(this.frmItemList_Load);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemSize;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesign;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUOMID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscountAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitsInStock;
    }
}