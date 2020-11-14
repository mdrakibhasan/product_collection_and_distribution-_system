namespace View.UI
{
    partial class Company
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.gbAddress = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.txtPosatalCode = new System.Windows.Forms.TextBox();
            this.txtState = new System.Windows.Forms.TextBox();
            this.lblPostalCode = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblCountry = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.lblState = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblAddress1 = new System.Windows.Forms.Label();
            this.gbBasicInfo = new System.Windows.Forms.GroupBox();
            this.cmbParentName = new System.Windows.Forms.ComboBox();
            this.lblParentName = new System.Windows.Forms.Label();
            this.lblCompanyRequired = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblMobile = new System.Windows.Forms.Label();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtVATNo = new System.Windows.Forms.TextBox();
            this.txtWebsite = new System.Windows.Forms.TextBox();
            this.lblVATNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblWebsite = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.pnlButton = new System.Windows.Forms.Panel();
            this.dgvCompany = new System.Windows.Forms.DataGridView();
            this.CompanyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VATRegistration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Logo = new System.Windows.Forms.DataGridViewImageColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.City = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postalcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.dlgFileOpen = new System.Windows.Forms.OpenFileDialog();
            this.pnlContainer.SuspendLayout();
            this.gbAddress.SuspendLayout();
            this.gbBasicInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlContainer
            // 
            this.pnlContainer.Controls.Add(this.gbAddress);
            this.pnlContainer.Controls.Add(this.gbBasicInfo);
            this.pnlContainer.Controls.Add(this.pnlButton);
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnlContainer.Size = new System.Drawing.Size(609, 607);
            this.pnlContainer.TabIndex = 1;
            // 
            // gbAddress
            // 
            this.gbAddress.Controls.Add(this.btnClose);
            this.gbAddress.Controls.Add(this.btnSave);
            this.gbAddress.Controls.Add(this.cmbCountry);
            this.gbAddress.Controls.Add(this.txtPosatalCode);
            this.gbAddress.Controls.Add(this.txtState);
            this.gbAddress.Controls.Add(this.lblPostalCode);
            this.gbAddress.Controls.Add(this.txtCity);
            this.gbAddress.Controls.Add(this.lblCountry);
            this.gbAddress.Controls.Add(this.txtAddress2);
            this.gbAddress.Controls.Add(this.lblState);
            this.gbAddress.Controls.Add(this.txtAddress1);
            this.gbAddress.Controls.Add(this.lblCity);
            this.gbAddress.Controls.Add(this.lblAddress2);
            this.gbAddress.Controls.Add(this.lblAddress1);
            this.gbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAddress.ForeColor = System.Drawing.Color.White;
            this.gbAddress.Location = new System.Drawing.Point(5, 247);
            this.gbAddress.Name = "gbAddress";
            this.gbAddress.Size = new System.Drawing.Size(599, 175);
            this.gbAddress.TabIndex = 1;
            this.gbAddress.TabStop = false;
            this.gbAddress.Text = "Address";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(212, 108);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(115, 26);
            this.btnClose.TabIndex = 50;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(91, 108);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 26);
            this.btnSave.TabIndex = 49;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(374, 77);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(207, 21);
            this.cmbCountry.TabIndex = 5;
            // 
            // txtPosatalCode
            // 
            this.txtPosatalCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPosatalCode.Location = new System.Drawing.Point(91, 77);
            this.txtPosatalCode.MaxLength = 10;
            this.txtPosatalCode.Name = "txtPosatalCode";
            this.txtPosatalCode.Size = new System.Drawing.Size(207, 22);
            this.txtPosatalCode.TabIndex = 4;
            // 
            // txtState
            // 
            this.txtState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtState.Location = new System.Drawing.Point(374, 49);
            this.txtState.MaxLength = 15;
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(207, 22);
            this.txtState.TabIndex = 3;
            // 
            // lblPostalCode
            // 
            this.lblPostalCode.AutoSize = true;
            this.lblPostalCode.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostalCode.Location = new System.Drawing.Point(14, 81);
            this.lblPostalCode.Name = "lblPostalCode";
            this.lblPostalCode.Size = new System.Drawing.Size(71, 14);
            this.lblPostalCode.TabIndex = 48;
            this.lblPostalCode.Text = "Postal Code";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(93, 49);
            this.txtCity.MaxLength = 15;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(207, 22);
            this.txtCity.TabIndex = 2;
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(318, 81);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(50, 14);
            this.lblCountry.TabIndex = 47;
            this.lblCountry.Text = "Country";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress2.Location = new System.Drawing.Point(374, 21);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(207, 22);
            this.txtAddress2.TabIndex = 1;
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblState.Location = new System.Drawing.Point(331, 53);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(37, 14);
            this.lblState.TabIndex = 46;
            this.lblState.Text = "State";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress1.Location = new System.Drawing.Point(91, 21);
            this.txtAddress1.MaxLength = 50;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(207, 22);
            this.txtAddress1.TabIndex = 0;
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(58, 53);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(27, 14);
            this.lblCity.TabIndex = 45;
            this.lblCity.Text = "City";
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.Location = new System.Drawing.Point(311, 25);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(57, 14);
            this.lblAddress2.TabIndex = 44;
            this.lblAddress2.Text = "Address2";
            // 
            // lblAddress1
            // 
            this.lblAddress1.AutoSize = true;
            this.lblAddress1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress1.Location = new System.Drawing.Point(28, 25);
            this.lblAddress1.Name = "lblAddress1";
            this.lblAddress1.Size = new System.Drawing.Size(57, 14);
            this.lblAddress1.TabIndex = 42;
            this.lblAddress1.Text = "Address1";
            // 
            // gbBasicInfo
            // 
            this.gbBasicInfo.Controls.Add(this.cmbParentName);
            this.gbBasicInfo.Controls.Add(this.lblParentName);
            this.gbBasicInfo.Controls.Add(this.lblCompanyRequired);
            this.gbBasicInfo.Controls.Add(this.txtName);
            this.gbBasicInfo.Controls.Add(this.btnBrowse);
            this.gbBasicInfo.Controls.Add(this.lblMobile);
            this.gbBasicInfo.Controls.Add(this.pbLogo);
            this.gbBasicInfo.Controls.Add(this.lblFax);
            this.gbBasicInfo.Controls.Add(this.txtVATNo);
            this.gbBasicInfo.Controls.Add(this.txtWebsite);
            this.gbBasicInfo.Controls.Add(this.lblVATNo);
            this.gbBasicInfo.Controls.Add(this.lblName);
            this.gbBasicInfo.Controls.Add(this.lblWebsite);
            this.gbBasicInfo.Controls.Add(this.txtMobile);
            this.gbBasicInfo.Controls.Add(this.lblPhone);
            this.gbBasicInfo.Controls.Add(this.lblEmail);
            this.gbBasicInfo.Controls.Add(this.txtEmail);
            this.gbBasicInfo.Controls.Add(this.txtPhone);
            this.gbBasicInfo.Controls.Add(this.txtFax);
            this.gbBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbBasicInfo.ForeColor = System.Drawing.Color.White;
            this.gbBasicInfo.Location = new System.Drawing.Point(5, 0);
            this.gbBasicInfo.Name = "gbBasicInfo";
            this.gbBasicInfo.Size = new System.Drawing.Size(599, 247);
            this.gbBasicInfo.TabIndex = 0;
            this.gbBasicInfo.TabStop = false;
            this.gbBasicInfo.Text = "Basic Information";
            // 
            // cmbParentName
            // 
            this.cmbParentName.DisplayMember = "Name";
            this.cmbParentName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentName.FormattingEnabled = true;
            this.cmbParentName.Location = new System.Drawing.Point(132, 18);
            this.cmbParentName.Name = "cmbParentName";
            this.cmbParentName.Size = new System.Drawing.Size(207, 21);
            this.cmbParentName.TabIndex = 55;
            this.cmbParentName.ValueMember = "ID";
            this.cmbParentName.Visible = false;
            // 
            // lblParentName
            // 
            this.lblParentName.AutoSize = true;
            this.lblParentName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParentName.Location = new System.Drawing.Point(10, 22);
            this.lblParentName.Name = "lblParentName";
            this.lblParentName.Size = new System.Drawing.Size(97, 14);
            this.lblParentName.TabIndex = 54;
            this.lblParentName.Text = "Parent Company";
            this.lblParentName.Visible = false;
            // 
            // lblCompanyRequired
            // 
            this.lblCompanyRequired.AutoSize = true;
            this.lblCompanyRequired.Cursor = System.Windows.Forms.Cursors.Help;
            this.lblCompanyRequired.ForeColor = System.Drawing.Color.Red;
            this.lblCompanyRequired.Location = new System.Drawing.Point(354, 51);
            this.lblCompanyRequired.Name = "lblCompanyRequired";
            this.lblCompanyRequired.Size = new System.Drawing.Size(11, 13);
            this.lblCompanyRequired.TabIndex = 53;
            this.lblCompanyRequired.Text = "*";
            this.lblCompanyRequired.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(132, 47);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 22);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.Location = new System.Drawing.Point(447, 191);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(115, 26);
            this.btnBrowse.TabIndex = 7;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblMobile
            // 
            this.lblMobile.AutoSize = true;
            this.lblMobile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMobile.Location = new System.Drawing.Point(69, 79);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(41, 14);
            this.lblMobile.TabIndex = 39;
            this.lblMobile.Text = "Mobile";
            // 
            // pbLogo
            // 
            this.pbLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLogo.Location = new System.Drawing.Point(418, 21);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(163, 158);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 47;
            this.pbLogo.TabStop = false;
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFax.Location = new System.Drawing.Point(85, 135);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(25, 14);
            this.lblFax.TabIndex = 42;
            this.lblFax.Text = "Fax";
            // 
            // txtVATNo
            // 
            this.txtVATNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVATNo.Location = new System.Drawing.Point(132, 215);
            this.txtVATNo.MaxLength = 50;
            this.txtVATNo.Name = "txtVATNo";
            this.txtVATNo.Size = new System.Drawing.Size(207, 22);
            this.txtVATNo.TabIndex = 6;
            // 
            // txtWebsite
            // 
            this.txtWebsite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebsite.Location = new System.Drawing.Point(132, 187);
            this.txtWebsite.MaxLength = 50;
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Size = new System.Drawing.Size(207, 22);
            this.txtWebsite.TabIndex = 5;
            // 
            // lblVATNo
            // 
            this.lblVATNo.AutoSize = true;
            this.lblVATNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVATNo.Location = new System.Drawing.Point(46, 219);
            this.lblVATNo.Name = "lblVATNo";
            this.lblVATNo.Size = new System.Drawing.Size(64, 14);
            this.lblVATNo.TabIndex = 46;
            this.lblVATNo.Text = "VAT Reg. ";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(3, 51);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(107, 14);
            this.lblName.TabIndex = 39;
            this.lblName.Text = "Company / Branch";
            // 
            // lblWebsite
            // 
            this.lblWebsite.AutoSize = true;
            this.lblWebsite.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWebsite.Location = new System.Drawing.Point(58, 191);
            this.lblWebsite.Name = "lblWebsite";
            this.lblWebsite.Size = new System.Drawing.Size(52, 14);
            this.lblWebsite.TabIndex = 46;
            this.lblWebsite.Text = "Website";
            // 
            // txtMobile
            // 
            this.txtMobile.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMobile.Location = new System.Drawing.Point(132, 75);
            this.txtMobile.MaxLength = 50;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(207, 22);
            this.txtMobile.TabIndex = 1;
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.Location = new System.Drawing.Point(68, 107);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(42, 14);
            this.lblPhone.TabIndex = 44;
            this.lblPhone.Text = "Phone";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(76, 163);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(34, 14);
            this.lblEmail.TabIndex = 43;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(132, 159);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 22);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(132, 103);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(207, 22);
            this.txtPhone.TabIndex = 2;
            // 
            // txtFax
            // 
            this.txtFax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFax.Location = new System.Drawing.Point(132, 131);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(207, 22);
            this.txtFax.TabIndex = 3;
            // 
            // pnlButton
            // 
            this.pnlButton.Controls.Add(this.dgvCompany);
            this.pnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButton.Location = new System.Drawing.Point(5, 422);
            this.pnlButton.Name = "pnlButton";
            this.pnlButton.Size = new System.Drawing.Size(599, 185);
            this.pnlButton.TabIndex = 2;
            // 
            // dgvCompany
            // 
            this.dgvCompany.AllowUserToAddRows = false;
            this.dgvCompany.AllowUserToDeleteRows = false;
            this.dgvCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompany.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyName,
            this.Mobile,
            this.Phone,
            this.VATRegistration,
            this.ID,
            this.ParentCompany,
            this.Fax,
            this.Country,
            this.Logo,
            this.Email,
            this.Website,
            this.Address1,
            this.Address2,
            this.City,
            this.State,
            this.Postalcode});
            this.dgvCompany.Location = new System.Drawing.Point(6, 6);
            this.dgvCompany.Name = "dgvCompany";
            this.dgvCompany.ReadOnly = true;
            this.dgvCompany.RowHeadersVisible = false;
            this.dgvCompany.Size = new System.Drawing.Size(588, 167);
            this.dgvCompany.TabIndex = 0;
            this.dgvCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCompany_CellClick);
            // 
            // CompanyName
            // 
            this.CompanyName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyName.DataPropertyName = "Name";
            this.CompanyName.HeaderText = "Company / Branch Name";
            this.CompanyName.Name = "CompanyName";
            this.CompanyName.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "Mobile";
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // VATRegistration
            // 
            this.VATRegistration.DataPropertyName = "VATRegistration";
            this.VATRegistration.HeaderText = "VAT Reg.";
            this.VATRegistration.Name = "VATRegistration";
            this.VATRegistration.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // ParentCompany
            // 
            this.ParentCompany.DataPropertyName = "ParentID";
            this.ParentCompany.HeaderText = "ParentCompany";
            this.ParentCompany.Name = "ParentCompany";
            this.ParentCompany.ReadOnly = true;
            this.ParentCompany.Visible = false;
            // 
            // Fax
            // 
            this.Fax.DataPropertyName = "Fax";
            this.Fax.HeaderText = "Fax";
            this.Fax.Name = "Fax";
            this.Fax.ReadOnly = true;
            this.Fax.Visible = false;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Visible = false;
            // 
            // Logo
            // 
            this.Logo.DataPropertyName = "Logo";
            this.Logo.HeaderText = "Logo";
            this.Logo.Name = "Logo";
            this.Logo.ReadOnly = true;
            this.Logo.Visible = false;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Visible = false;
            // 
            // Website
            // 
            this.Website.DataPropertyName = "Website";
            this.Website.HeaderText = "Website";
            this.Website.Name = "Website";
            this.Website.ReadOnly = true;
            this.Website.Visible = false;
            // 
            // Address1
            // 
            this.Address1.DataPropertyName = "Address1";
            this.Address1.HeaderText = "Add";
            this.Address1.Name = "Address1";
            this.Address1.ReadOnly = true;
            this.Address1.Visible = false;
            // 
            // Address2
            // 
            this.Address2.DataPropertyName = "Address2";
            this.Address2.HeaderText = "Add2";
            this.Address2.Name = "Address2";
            this.Address2.ReadOnly = true;
            this.Address2.Visible = false;
            // 
            // City
            // 
            this.City.DataPropertyName = "City";
            this.City.HeaderText = "City";
            this.City.Name = "City";
            this.City.ReadOnly = true;
            this.City.Visible = false;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Visible = false;
            // 
            // Postalcode
            // 
            this.Postalcode.DataPropertyName = "PostalCode";
            this.Postalcode.HeaderText = "Postalcode";
            this.Postalcode.Name = "Postalcode";
            this.Postalcode.ReadOnly = true;
            this.Postalcode.Visible = false;
            // 
            // dlgFileOpen
            // 
            this.dlgFileOpen.FileName = "openFileDialog1";
            // 
            // Company
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(35)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(609, 607);
            this.Controls.Add(this.pnlContainer);
            this.Name = "Company";
            this.Text = "Company";
            this.Load += new System.EventHandler(this.Company_Load);
            this.pnlContainer.ResumeLayout(false);
            this.gbAddress.ResumeLayout(false);
            this.gbAddress.PerformLayout();
            this.gbBasicInfo.ResumeLayout(false);
            this.gbBasicInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.GroupBox gbAddress;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.TextBox txtPosatalCode;
        private System.Windows.Forms.TextBox txtState;
        private System.Windows.Forms.Label lblPostalCode;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Label lblAddress1;
        private System.Windows.Forms.GroupBox gbBasicInfo;
        private System.Windows.Forms.ComboBox cmbParentName;
        private System.Windows.Forms.Label lblParentName;
        private System.Windows.Forms.Label lblCompanyRequired;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtVATNo;
        private System.Windows.Forms.TextBox txtWebsite;
        private System.Windows.Forms.Label lblVATNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblWebsite;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Panel pnlButton;
        private System.Windows.Forms.DataGridView dgvCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn VATRegistration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fax;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewImageColumn Logo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Website;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address2;
        private System.Windows.Forms.DataGridViewTextBoxColumn City;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postalcode;
        private System.Windows.Forms.ToolTip companyToolTip;
        private System.Windows.Forms.OpenFileDialog dlgFileOpen;
    }
}