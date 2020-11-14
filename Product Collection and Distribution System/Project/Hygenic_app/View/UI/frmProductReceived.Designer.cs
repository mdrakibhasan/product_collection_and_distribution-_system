namespace View.UI
{
    partial class frmProductReceived
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtpTodate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dttpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dgPurchaseInformation = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPoCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItemPurchaseDetail = new System.Windows.Forms.DataGridView();
            this.colID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSalePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColItemPurchaseMstID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLabureCharge = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCarriageCharg = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTotalData = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPurchaseDetail)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(649, 530);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 26);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(508, 530);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 26);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(371, 530);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 26);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.dtpTodate);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dttpFromDate);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgPurchaseInformation);
            this.panel2.Location = new System.Drawing.Point(9, 8);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(772, 408);
            this.panel2.TabIndex = 71;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(222, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Cornsilk;
            this.label1.Location = new System.Drawing.Point(56, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search By Code/Farmer/Mobile.";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(619, 54);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtpTodate
            // 
            this.dtpTodate.AllowDrop = true;
            this.dtpTodate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTodate.Location = new System.Drawing.Point(412, 55);
            this.dtpTodate.Name = "dtpTodate";
            this.dtpTodate.Size = new System.Drawing.Size(186, 20);
            this.dtpTodate.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(339, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "To Date";
            // 
            // dttpFromDate
            // 
            this.dttpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttpFromDate.Location = new System.Drawing.Point(116, 55);
            this.dttpFromDate.Name = "dttpFromDate";
            this.dttpFromDate.Size = new System.Drawing.Size(186, 20);
            this.dttpFromDate.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = " Select Date";
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
            this.colStatus});
            this.dgPurchaseInformation.Location = new System.Drawing.Point(7, 95);
            this.dgPurchaseInformation.Name = "dgPurchaseInformation";
            this.dgPurchaseInformation.Size = new System.Drawing.Size(761, 296);
            this.dgPurchaseInformation.TabIndex = 10;
            this.dgPurchaseInformation.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseInformation_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.Visible = false;
            // 
            // PurchaseDate
            // 
            this.PurchaseDate.HeaderText = "Purchase Date";
            this.PurchaseDate.Name = "PurchaseDate";
            // 
            // POCode
            // 
            this.POCode.HeaderText = "PO. Code";
            this.POCode.Name = "POCode";
            // 
            // FarmerName
            // 
            this.FarmerName.FillWeight = 130F;
            this.FarmerName.HeaderText = "Farmer Name";
            this.FarmerName.Name = "FarmerName";
            this.FarmerName.Width = 130;
            // 
            // FarmerMobileNo
            // 
            this.FarmerMobileNo.HeaderText = "Farmer Mobile.No";
            this.FarmerMobileNo.Name = "FarmerMobileNo";
            // 
            // TotalItemQuantity
            // 
            this.TotalItemQuantity.HeaderText = "Total Quantity";
            this.TotalItemQuantity.Name = "TotalItemQuantity";
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Satt";
            this.colStatus.HeaderText = "status";
            this.colStatus.Name = "colStatus";
            this.colStatus.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtPoCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dgvItemPurchaseDetail);
            this.panel1.Controls.Add(this.dtpReceivedDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 402);
            this.panel1.TabIndex = 72;
            // 
            // txtPoCode
            // 
            this.txtPoCode.Enabled = false;
            this.txtPoCode.Location = new System.Drawing.Point(424, 53);
            this.txtPoCode.Name = "txtPoCode";
            this.txtPoCode.Size = new System.Drawing.Size(135, 20);
            this.txtPoCode.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(364, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "P.O Code";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Highlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(0, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(767, 34);
            this.label4.TabIndex = 12;
            this.label4.Text = "Item Details";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.ColSalePrice,
            this.colQuantity,
            this.colTotal,
            this.ColItemPurchaseMstID});
            this.dgvItemPurchaseDetail.GridColor = System.Drawing.SystemColors.Highlight;
            this.dgvItemPurchaseDetail.Location = new System.Drawing.Point(3, 80);
            this.dgvItemPurchaseDetail.MultiSelect = false;
            this.dgvItemPurchaseDetail.Name = "dgvItemPurchaseDetail";
            this.dgvItemPurchaseDetail.RowHeadersVisible = false;
            this.dgvItemPurchaseDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvItemPurchaseDetail.Size = new System.Drawing.Size(758, 313);
            this.dgvItemPurchaseDetail.TabIndex = 11;
            this.dgvItemPurchaseDetail.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvItemPurchaseDetail_CellBeginEdit);
            this.dgvItemPurchaseDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItemPurchaseDetail_CellValueChanged);
            this.dgvItemPurchaseDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItemPurchaseDetail_EditingControlShowing);
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
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            this.colItemCode.DefaultCellStyle = dataGridViewCellStyle1;
            this.colItemCode.HeaderText = "Code";
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.ReadOnly = true;
            // 
            // colItemName
            // 
            this.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = "0";
            this.colUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.colUnitPrice.HeaderText = "Purchase Price";
            this.colUnitPrice.Name = "colUnitPrice";
            this.colUnitPrice.ReadOnly = true;
            // 
            // ColSalePrice
            // 
            this.ColSalePrice.HeaderText = "SalePrice";
            this.ColSalePrice.Name = "ColSalePrice";
            // 
            // colQuantity
            // 
            this.colQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colQuantity.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = "0";
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.colQuantity.HeaderText = "Quantity";
            this.colQuantity.Name = "colQuantity";
            // 
            // colTotal
            // 
            this.colTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle5.Format = "N4";
            dataGridViewCellStyle5.NullValue = "0";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTotal.FillWeight = 80F;
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
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate.Location = new System.Drawing.Point(154, 54);
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size(186, 20);
            this.dtpReceivedDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(64, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Received Date";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.txtLabureCharge);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCarriageCharg);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(223, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 71);
            this.groupBox1.TabIndex = 84;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Extra Charge";
            // 
            // txtLabureCharge
            // 
            this.txtLabureCharge.BackColor = System.Drawing.SystemColors.Window;
            this.txtLabureCharge.Location = new System.Drawing.Point(113, 42);
            this.txtLabureCharge.Name = "txtLabureCharge";
            this.txtLabureCharge.Size = new System.Drawing.Size(141, 22);
            this.txtLabureCharge.TabIndex = 70;
            this.txtLabureCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 69;
            this.label6.Text = "Labor Charge :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCarriageCharg
            // 
            this.txtCarriageCharg.BackColor = System.Drawing.SystemColors.Window;
            this.txtCarriageCharg.Location = new System.Drawing.Point(113, 17);
            this.txtCarriageCharg.Name = "txtCarriageCharg";
            this.txtCarriageCharg.Size = new System.Drawing.Size(141, 22);
            this.txtCarriageCharg.TabIndex = 67;
            this.txtCarriageCharg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 16);
            this.label13.TabIndex = 68;
            this.label13.Text = "Carriage Charge :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblTotalData);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(492, 434);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(277, 71);
            this.groupBox2.TabIndex = 83;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price Information";
            // 
            // lblTotalData
            // 
            this.lblTotalData.BackColor = System.Drawing.Color.White;
            this.lblTotalData.ForeColor = System.Drawing.Color.Lime;
            this.lblTotalData.Location = new System.Drawing.Point(111, 15);
            this.lblTotalData.Name = "lblTotalData";
            this.lblTotalData.Size = new System.Drawing.Size(151, 23);
            this.lblTotalData.TabIndex = 1;
            this.lblTotalData.Text = "0";
            this.lblTotalData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(68, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Total :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmProductReceived
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(791, 568);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmProductReceived";
            this.Text = "Product Received";
            this.Load += new System.EventHandler(this.frmProductReceived_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItemPurchaseDetail)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpTodate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dttpFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgPurchaseInformation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.DataGridView dgvItemPurchaseDetail;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPoCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLabureCharge;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCarriageCharg;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.Label lblTotalData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn BatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSalePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColItemPurchaseMstID;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;


    }
}