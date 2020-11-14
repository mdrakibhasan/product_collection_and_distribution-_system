namespace View.UI
{
    partial class frmPurchaseAuthontication
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgPurchaseInformation = new System.Windows.Forms.DataGridView();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvItemPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalesPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemPurchaseMstID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Expairedate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Recommended = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPurchaseDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(-24, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(910, 34);
            this.label1.TabIndex = 5;
            this.label1.Text = "Request Authorize";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgPurchaseInformation
            // 
            this.dgPurchaseInformation.AllowUserToAddRows = false;
            this.dgPurchaseInformation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPurchaseInformation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.PurchaseDate,
            this.POCode,
            this.FarmerName,
            this.FarmerMobileNo,
            this.TotalItemQuantity,
            this.TotalAmount,
            this.Status,
            this.Recommended});
            this.dgPurchaseInformation.Location = new System.Drawing.Point(3, 78);
            this.dgPurchaseInformation.Name = "dgPurchaseInformation";
            this.dgPurchaseInformation.Size = new System.Drawing.Size(883, 213);
            this.dgPurchaseInformation.TabIndex = 4;
            this.dgPurchaseInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseInformation_CellClick);
            // 
            // btnsave
            // 
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.Location = new System.Drawing.Point(18, 537);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(89, 23);
            this.btnsave.TabIndex = 6;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(164, 536);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Refresh";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(320, 536);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvItemPurchaseDetail);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(3, 295);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(883, 232);
            this.panel1.TabIndex = 8;
            // 
            // dgvItemPurchaseDetail
            // 
            this.dgvItemPurchaseDetail.AllowUserToAddRows = false;
            this.dgvItemPurchaseDetail.AllowUserToResizeRows = false;
            this.dgvItemPurchaseDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvItemPurchaseDetail.BackgroundColor = System.Drawing.Color.Silver;
            this.dgvItemPurchaseDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItemPurchaseDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colID,
            this.colItemID,
            this.colItemCode,
            this.colItemName,
            this.BatchNo,
            this.colUnitPrice,
            this.ColSalesPrice,
            this.colQuantity,
            this.colTotal,
            this.ColItemPurchaseMstID,
            this.Expairedate});
            this.dgvItemPurchaseDetail.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgvItemPurchaseDetail.Location = new System.Drawing.Point(0, 29);
            this.dgvItemPurchaseDetail.MultiSelect = false;
            this.dgvItemPurchaseDetail.Name = "dgvItemPurchaseDetail";
            this.dgvItemPurchaseDetail.RowHeadersVisible = false;
            this.dgvItemPurchaseDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemPurchaseDetail.Size = new System.Drawing.Size(877, 223);
            this.dgvItemPurchaseDetail.TabIndex = 7;
            // 
            // colID
            // 
            this.colID.DataPropertyName = "ID";
            this.colID.HeaderText = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = false;
            // 
            // colItemID
            // 
            this.colItemID.DataPropertyName = "ItemID";
            this.colItemID.HeaderText = "ItemID";
            this.colItemID.Name = "colItemID";
            this.colItemID.Visible = false;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemCode";
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info;
            this.colItemCode.DefaultCellStyle = dataGridViewCellStyle21;
            this.colItemCode.HeaderText = "Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle22;
            this.colItemName.HeaderText = "Name";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            // 
            // BatchNo
            // 
            this.BatchNo.DataPropertyName = "BatchNo";
            this.BatchNo.HeaderText = "BatchNo";
            this.BatchNo.Name = "BatchNo";
            this.BatchNo.Visible = false;
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colUnitPrice.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N4";
            dataGridViewCellStyle23.NullValue = "0";
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle23;
            this.colUnitPrice.HeaderText = "Purchase Price";
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // ColSalesPrice
            // 
            this.ColSalesPrice.DataPropertyName = "SalesPrice";
            this.ColSalesPrice.HeaderText = "SalesPrice";
            this.ColSalesPrice.Name = "ColSalesPrice";
            this.ColSalesPrice.ReadOnly = true;
            // 
            // colQuantity
            // 
            this.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = "0";
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle24;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle25.Format = "N4";
            dataGridViewCellStyle25.NullValue = "0";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle25;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            // 
            // ColItemPurchaseMstID
            // 
            this.ColItemPurchaseMstID.DataPropertyName = "ItemPurchaseMstID";
            this.ColItemPurchaseMstID.HeaderText = "ItemPurchaseMstID";
            this.ColItemPurchaseMstID.Name = "ColItemPurchaseMstID";
            this.ColItemPurchaseMstID.Visible = false;
            // 
            // Expairedate
            // 
            this.Expairedate.HeaderText = "Expairedate";
            this.Expairedate.Name = "Expairedate";
            this.Expairedate.ReadOnly = true;
            this.Expairedate.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Highlight;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, -11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(874, 57);
            this.label2.TabIndex = 6;
            this.label2.Text = "Item Details";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(64, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Search By Code/Farmer/Mobile.";
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.HeaderText = "Collection Date";
            this.PurchaseDate.Name = "PurchaseDate";
            // 
            // POCode
            // 
            this.POCode.HeaderText = "Code";
            this.POCode.Name = "POCode";
            // 
            // FarmerName
            // 
            this.FarmerName.HeaderText = "Farmer Name";
            this.FarmerName.Name = "FarmerName";
            // 
            // FarmerMobileNo
            // 
            this.FarmerMobileNo.FillWeight = 130F;
            this.FarmerMobileNo.HeaderText = "Farmer Mobile.No";
            this.FarmerMobileNo.Name = "FarmerMobileNo";
            this.FarmerMobileNo.Width = 130;
            // 
            // TotalItemQuantity
            // 
            this.TotalItemQuantity.FillWeight = 130F;
            this.TotalItemQuantity.HeaderText = "Total Item Quantity";
            this.TotalItemQuantity.Name = "TotalItemQuantity";
            this.TotalItemQuantity.Width = 130;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // Recommended
            // 
            this.Recommended.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Recommended.HeaderText = "Recommended";
            this.Recommended.Items.AddRange(new object[] {
            "Approved",
            "Cancel",
            "Request for Shipment",
            "Panding"});
            this.Recommended.Name = "Recommended";
            // 
            // frmPurchaseAuthontication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(888, 573);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgPurchaseInformation);
            this.Name = "frmPurchaseAuthontication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmPurchaseAuthontication";
            this.Load += new System.EventHandler(this.frmPurchaseAuthontication_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPurchaseDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgPurchaseInformation;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView dgvItemPurchaseDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalesPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemPurchaseMstID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Expairedate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewComboBoxColumn Recommended;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}