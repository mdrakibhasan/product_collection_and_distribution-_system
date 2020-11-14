namespace View.UI
{
    partial class frmPurhaseAprovedInfo
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.dgPurchaseInformation = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchaseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FarmerMobileNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalItemQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Satatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.White;
            this.lblHeader.Location = new System.Drawing.Point(0, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(955, 26);
            this.lblHeader.TabIndex = 3;
            this.lblHeader.Text = "Purchase List";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Satatus});
            this.dgPurchaseInformation.Location = new System.Drawing.Point(-5, 40);
            this.dgPurchaseInformation.Name = "dgPurchaseInformation";
            this.dgPurchaseInformation.Size = new System.Drawing.Size(957, 432);
            this.dgPurchaseInformation.TabIndex = 2;
            this.dgPurchaseInformation.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgPurchaseInformation_CellContentDoubleClick);
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
            this.FarmerName.FillWeight = 180F;
            this.FarmerName.HeaderText = "Farmer Name";
            this.FarmerName.Name = "FarmerName";
            this.FarmerName.Width = 180;
            // 
            // FarmerMobileNo
            // 
            this.FarmerMobileNo.FillWeight = 150F;
            this.FarmerMobileNo.HeaderText = "Farmer Mobile.No";
            this.FarmerMobileNo.Name = "FarmerMobileNo";
            this.FarmerMobileNo.Width = 150;
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
            // Satatus
            // 
            this.Satatus.FillWeight = 150F;
            this.Satatus.HeaderText = "Satatus";
            this.Satatus.Name = "Satatus";
            this.Satatus.ReadOnly = true;
            this.Satatus.Width = 150;
            // 
            // frmPurhaseAprovedInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(955, 483);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.dgPurchaseInformation);
            this.Name = "frmPurhaseAprovedInfo";
            this.Text = "frmPurhaseAprovedInfo";
            this.Load += new System.EventHandler(this.frmPurhaseAprovedInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPurchaseInformation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.DataGridView dgPurchaseInformation;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchaseDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn POCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FarmerMobileNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalItemQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Satatus;
    }
}