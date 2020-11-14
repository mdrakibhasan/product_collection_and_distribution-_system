namespace View.UI
{
    partial class frmProductRequest
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
            this.dgPurchaseInformation = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblHeader = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).BeginInit();
            this.SuspendLayout();
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
            this.Column1});
            this.dgPurchaseInformation.Location = new System.Drawing.Point(-2, 73);
            this.dgPurchaseInformation.Name = "dgPurchaseInformation";
            this.dgPurchaseInformation.Size = new System.Drawing.Size(844, 348);
            this.dgPurchaseInformation.TabIndex = 0;
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
            this.PurchaseDate.ReadOnly = true;
            // 
            // POCode
            // 
            this.POCode.HeaderText = "PO. Code";
            this.POCode.Name = "POCode";
            this.POCode.ReadOnly = true;
            // 
            // FarmerName
            // 
            this.FarmerName.HeaderText = "Farmer Name";
            this.FarmerName.Name = "FarmerName";
            this.FarmerName.ReadOnly = true;
            // 
            // FarmerMobileNo
            // 
            this.FarmerMobileNo.HeaderText = "Farmer Mobile.No";
            this.FarmerMobileNo.Name = "FarmerMobileNo";
            this.FarmerMobileNo.ReadOnly = true;
            // 
            // TotalItemQuantity
            // 
            this.TotalItemQuantity.HeaderText = "Total Item Quantity";
            this.TotalItemQuantity.Name = "TotalItemQuantity";
            this.TotalItemQuantity.ReadOnly = true;
            // 
            // TotalAmount
            // 
            this.TotalAmount.HeaderText = "TotalAmount";
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(842, 26);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "Purchase List";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(187, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(489, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Cornsilk;
            this.label3.Location = new System.Drawing.Point(21, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search By Code/Farmer/Mobile.";
            // 
            // frmProductRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(842, 471);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dgPurchaseInformation);
            this.Name = "frmProductRequest";
            this.Text = "frmProductRequest";
            this.Load += new System.EventHandler(this.frmProductRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgPurchaseInformation;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
    }
}