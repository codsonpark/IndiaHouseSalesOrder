namespace IndiaHouseSalesOrder
{
    partial class frmSalesOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesOrder));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSalesOrderNumberSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgSalesOrder = new System.Windows.Forms.DataGridView();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.lblSalesOrderNumber = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblShippingAddress = new System.Windows.Forms.Label();
            this.txtShippingAddress = new System.Windows.Forms.TextBox();
            this.txtBillingAddress = new System.Windows.Forms.TextBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.txtSalesOrderNumber = new System.Windows.Forms.TextBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.chkIncludePictures = new System.Windows.Forms.CheckBox();
            this.txtTotalQuantity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShipDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(197, 96);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 30);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSalesOrderNumberSearch
            // 
            this.txtSalesOrderNumberSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalesOrderNumberSearch.Location = new System.Drawing.Point(197, 56);
            this.txtSalesOrderNumberSearch.Name = "txtSalesOrderNumberSearch";
            this.txtSalesOrderNumberSearch.Size = new System.Drawing.Size(81, 26);
            this.txtSalesOrderNumberSearch.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sales Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sales Order Number:";
            // 
            // dgSalesOrder
            // 
            this.dgSalesOrder.AllowUserToAddRows = false;
            this.dgSalesOrder.AllowUserToDeleteRows = false;
            this.dgSalesOrder.AllowUserToOrderColumns = true;
            this.dgSalesOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSalesOrder.Location = new System.Drawing.Point(12, 212);
            this.dgSalesOrder.Name = "dgSalesOrder";
            this.dgSalesOrder.ReadOnly = true;
            this.dgSalesOrder.RowTemplate.Height = 80;
            this.dgSalesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSalesOrder.Size = new System.Drawing.Size(900, 384);
            this.dgSalesOrder.TabIndex = 6;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.Location = new System.Drawing.Point(358, 133);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(113, 17);
            this.lblCustomerName.TabIndex = 7;
            this.lblCustomerName.Text = "Customer Name:";
            // 
            // lblSalesOrderNumber
            // 
            this.lblSalesOrderNumber.AutoSize = true;
            this.lblSalesOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalesOrderNumber.Location = new System.Drawing.Point(383, 89);
            this.lblSalesOrderNumber.Name = "lblSalesOrderNumber";
            this.lblSalesOrderNumber.Size = new System.Drawing.Size(88, 17);
            this.lblSalesOrderNumber.TabIndex = 8;
            this.lblSalesOrderNumber.Text = "Sales Order:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(429, 38);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 17);
            this.lblDate.TabIndex = 9;
            this.lblDate.Text = "Date:";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(567, 17);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(105, 17);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "Billing Address:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(391, 185);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(80, 17);
            this.lblTotal.TabIndex = 11;
            this.lblTotal.Text = "Total Price:";
            // 
            // lblShippingAddress
            // 
            this.lblShippingAddress.AutoSize = true;
            this.lblShippingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShippingAddress.Location = new System.Drawing.Point(749, 17);
            this.lblShippingAddress.Name = "lblShippingAddress";
            this.lblShippingAddress.Size = new System.Drawing.Size(123, 17);
            this.lblShippingAddress.TabIndex = 12;
            this.lblShippingAddress.Text = "Shipping Address:";
            // 
            // txtShippingAddress
            // 
            this.txtShippingAddress.Location = new System.Drawing.Point(752, 37);
            this.txtShippingAddress.Multiline = true;
            this.txtShippingAddress.Name = "txtShippingAddress";
            this.txtShippingAddress.Size = new System.Drawing.Size(160, 89);
            this.txtShippingAddress.TabIndex = 13;
            // 
            // txtBillingAddress
            // 
            this.txtBillingAddress.Location = new System.Drawing.Point(570, 37);
            this.txtBillingAddress.Multiline = true;
            this.txtBillingAddress.Name = "txtBillingAddress";
            this.txtBillingAddress.Size = new System.Drawing.Size(160, 89);
            this.txtBillingAddress.TabIndex = 14;
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Location = new System.Drawing.Point(808, 168);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 37);
            this.btnExportToExcel.TabIndex = 15;
            this.btnExportToExcel.Text = "Export To Excel";
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(477, 37);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(64, 20);
            this.txtDate.TabIndex = 16;
            // 
            // txtSalesOrderNumber
            // 
            this.txtSalesOrderNumber.Location = new System.Drawing.Point(477, 89);
            this.txtSalesOrderNumber.Name = "txtSalesOrderNumber";
            this.txtSalesOrderNumber.Size = new System.Drawing.Size(64, 20);
            this.txtSalesOrderNumber.TabIndex = 17;
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(477, 184);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(64, 20);
            this.txtTotalPrice.TabIndex = 18;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(477, 132);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(253, 20);
            this.txtCustomerName.TabIndex = 19;
            // 
            // chkIncludePictures
            // 
            this.chkIncludePictures.AutoSize = true;
            this.chkIncludePictures.Location = new System.Drawing.Point(808, 144);
            this.chkIncludePictures.Name = "chkIncludePictures";
            this.chkIncludePictures.Size = new System.Drawing.Size(102, 17);
            this.chkIncludePictures.TabIndex = 20;
            this.chkIncludePictures.Text = "Include Pictures";
            this.chkIncludePictures.UseVisualStyleBackColor = true;
            this.chkIncludePictures.CheckedChanged += new System.EventHandler(this.chkIncludePictures_CheckedChanged);
            // 
            // txtTotalQuantity
            // 
            this.txtTotalQuantity.Location = new System.Drawing.Point(477, 158);
            this.txtTotalQuantity.Name = "txtTotalQuantity";
            this.txtTotalQuantity.Size = new System.Drawing.Size(64, 20);
            this.txtTotalQuantity.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(370, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Total Quantity:";
            // 
            // txtShipDate
            // 
            this.txtShipDate.Location = new System.Drawing.Point(477, 63);
            this.txtShipDate.Name = "txtShipDate";
            this.txtShipDate.Size = new System.Drawing.Size(64, 20);
            this.txtShipDate.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(397, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 23;
            this.label4.Text = "Ship Date:";
            // 
            // frmSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 607);
            this.Controls.Add(this.txtShipDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTotalQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIncludePictures);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.txtSalesOrderNumber);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.btnExportToExcel);
            this.Controls.Add(this.txtBillingAddress);
            this.Controls.Add(this.txtShippingAddress);
            this.Controls.Add(this.lblShippingAddress);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSalesOrderNumber);
            this.Controls.Add(this.lblCustomerName);
            this.Controls.Add(this.dgSalesOrder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalesOrderNumberSearch);
            this.Controls.Add(this.btnSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesOrder";
            this.Text = "Sales Order - India House";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesOrder_FormClosing);
            this.Load += new System.EventHandler(this.frmSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgSalesOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSalesOrderNumberSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgSalesOrder;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label lblSalesOrderNumber;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblShippingAddress;
        private System.Windows.Forms.TextBox txtShippingAddress;
        private System.Windows.Forms.TextBox txtBillingAddress;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.TextBox txtSalesOrderNumber;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.CheckBox chkIncludePictures;
        private System.Windows.Forms.TextBox txtTotalQuantity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShipDate;
        private System.Windows.Forms.Label label4;
    }
}

