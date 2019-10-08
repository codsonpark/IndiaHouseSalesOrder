namespace IndiaHouseSalesOrder
{
    partial class frmLabels
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLabels));
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoadItems = new System.Windows.Forms.Button();
            this.dgItems = new System.Windows.Forms.DataGridView();
            this.inventoryItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.rdbInnerPack = new System.Windows.Forms.RadioButton();
            this.rdbRegular = new System.Windows.Forms.RadioButton();
            this.rdb2x2 = new System.Windows.Forms.RadioButton();
            this.rdb15x2 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.itemCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mPNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryItemBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(520, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 26);
            this.label1.TabIndex = 5;
            this.label1.Text = "Print Labels";
            // 
            // btnLoadItems
            // 
            this.btnLoadItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadItems.Location = new System.Drawing.Point(15, 21);
            this.btnLoadItems.Name = "btnLoadItems";
            this.btnLoadItems.Size = new System.Drawing.Size(220, 45);
            this.btnLoadItems.TabIndex = 7;
            this.btnLoadItems.Text = "Load Items from QuickBooks";
            this.btnLoadItems.UseVisualStyleBackColor = true;
            this.btnLoadItems.Click += new System.EventHandler(this.btnLoadItems_Click);
            // 
            // dgItems
            // 
            this.dgItems.AllowUserToAddRows = false;
            this.dgItems.AllowUserToDeleteRows = false;
            this.dgItems.AllowUserToOrderColumns = true;
            this.dgItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgItems.AutoGenerateColumns = false;
            this.dgItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkSelect,
            this.itemCodeDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.mPNDataGridViewTextBoxColumn,
            this.innerDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.caseDataGridViewTextBoxColumn,
            this.price2DataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.price3DataGridViewTextBoxColumn});
            this.dgItems.DataSource = this.inventoryItemBindingSource;
            this.dgItems.GridColor = System.Drawing.Color.LightGray;
            this.dgItems.Location = new System.Drawing.Point(15, 72);
            this.dgItems.Name = "dgItems";
            this.dgItems.RowTemplate.Height = 25;
            this.dgItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgItems.Size = new System.Drawing.Size(1013, 467);
            this.dgItems.TabIndex = 25;
            this.dgItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgItems_CellContentClick);
            // 
            // inventoryItemBindingSource
            // 
            this.inventoryItemBindingSource.DataSource = typeof(IndiaHouse.Core.Models.InventoryItem);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(866, 545);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(162, 30);
            this.btnPrint.TabIndex = 26;
            this.btnPrint.Text = "Print Labels";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.Location = new System.Drawing.Point(935, 21);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(93, 45);
            this.btnOptions.TabIndex = 27;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // rdbInnerPack
            // 
            this.rdbInnerPack.AutoSize = true;
            this.rdbInnerPack.Checked = true;
            this.rdbInnerPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbInnerPack.Location = new System.Drawing.Point(13, 19);
            this.rdbInnerPack.Name = "rdbInnerPack";
            this.rdbInnerPack.Size = new System.Drawing.Size(93, 21);
            this.rdbInnerPack.TabIndex = 29;
            this.rdbInnerPack.TabStop = true;
            this.rdbInnerPack.Text = "Inner Pack";
            this.rdbInnerPack.UseVisualStyleBackColor = true;
            // 
            // rdbRegular
            // 
            this.rdbRegular.AutoSize = true;
            this.rdbRegular.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbRegular.Location = new System.Drawing.Point(112, 19);
            this.rdbRegular.Name = "rdbRegular";
            this.rdbRegular.Size = new System.Drawing.Size(76, 21);
            this.rdbRegular.TabIndex = 30;
            this.rdbRegular.Text = "Regular";
            this.rdbRegular.UseVisualStyleBackColor = true;
            // 
            // rdb2x2
            // 
            this.rdb2x2.AutoSize = true;
            this.rdb2x2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb2x2.Location = new System.Drawing.Point(99, 19);
            this.rdb2x2.Name = "rdb2x2";
            this.rdb2x2.Size = new System.Drawing.Size(80, 21);
            this.rdb2x2.TabIndex = 33;
            this.rdb2x2.Text = "2.0 x 2.0";
            this.rdb2x2.UseVisualStyleBackColor = true;
            // 
            // rdb15x2
            // 
            this.rdb15x2.AutoSize = true;
            this.rdb15x2.Checked = true;
            this.rdb15x2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb15x2.Location = new System.Drawing.Point(13, 19);
            this.rdb15x2.Name = "rdb15x2";
            this.rdb15x2.Size = new System.Drawing.Size(80, 21);
            this.rdb15x2.TabIndex = 32;
            this.rdb15x2.TabStop = true;
            this.rdb15x2.Text = "1.5 x 2.0";
            this.rdb15x2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdb15x2);
            this.groupBox1.Controls.Add(this.rdb2x2);
            this.groupBox1.Location = new System.Drawing.Point(241, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 50);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Label Size";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.rdbInnerPack);
            this.groupBox2.Controls.Add(this.rdbRegular);
            this.groupBox2.Location = new System.Drawing.Point(729, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 50);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Price 1 Label";
            // 
            // chkSelect
            // 
            this.chkSelect.HeaderText = "Select";
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Width = 50;
            // 
            // itemCodeDataGridViewTextBoxColumn
            // 
            this.itemCodeDataGridViewTextBoxColumn.DataPropertyName = "ItemCode";
            this.itemCodeDataGridViewTextBoxColumn.HeaderText = "Item Code";
            this.itemCodeDataGridViewTextBoxColumn.Name = "itemCodeDataGridViewTextBoxColumn";
            this.itemCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemCodeDataGridViewTextBoxColumn.Width = 60;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Width = 280;
            // 
            // mPNDataGridViewTextBoxColumn
            // 
            this.mPNDataGridViewTextBoxColumn.DataPropertyName = "MPN";
            this.mPNDataGridViewTextBoxColumn.HeaderText = "UPC";
            this.mPNDataGridViewTextBoxColumn.Name = "mPNDataGridViewTextBoxColumn";
            this.mPNDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // innerDataGridViewTextBoxColumn
            // 
            this.innerDataGridViewTextBoxColumn.DataPropertyName = "Inner";
            this.innerDataGridViewTextBoxColumn.HeaderText = "Inner";
            this.innerDataGridViewTextBoxColumn.Name = "innerDataGridViewTextBoxColumn";
            this.innerDataGridViewTextBoxColumn.ReadOnly = true;
            this.innerDataGridViewTextBoxColumn.Width = 60;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.priceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price1";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 60;
            // 
            // caseDataGridViewTextBoxColumn
            // 
            this.caseDataGridViewTextBoxColumn.DataPropertyName = "Case";
            this.caseDataGridViewTextBoxColumn.HeaderText = "Case";
            this.caseDataGridViewTextBoxColumn.Name = "caseDataGridViewTextBoxColumn";
            this.caseDataGridViewTextBoxColumn.ReadOnly = true;
            this.caseDataGridViewTextBoxColumn.Width = 60;
            // 
            // price2DataGridViewTextBoxColumn
            // 
            this.price2DataGridViewTextBoxColumn.DataPropertyName = "Price2";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.price2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.price2DataGridViewTextBoxColumn.HeaderText = "Price2";
            this.price2DataGridViewTextBoxColumn.Name = "price2DataGridViewTextBoxColumn";
            this.price2DataGridViewTextBoxColumn.ReadOnly = true;
            this.price2DataGridViewTextBoxColumn.Width = 60;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "Volume";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 60;
            // 
            // price3DataGridViewTextBoxColumn
            // 
            this.price3DataGridViewTextBoxColumn.DataPropertyName = "Price3";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.price3DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.price3DataGridViewTextBoxColumn.HeaderText = "Price3";
            this.price3DataGridViewTextBoxColumn.Name = "price3DataGridViewTextBoxColumn";
            this.price3DataGridViewTextBoxColumn.ReadOnly = true;
            this.price3DataGridViewTextBoxColumn.Width = 60;
            // 
            // frmLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.dgItems);
            this.Controls.Add(this.btnLoadItems);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLabels";
            this.Text = "Print Labels";
            this.Load += new System.EventHandler(this.frmLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryItemBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLoadItems;
        private System.Windows.Forms.DataGridView dgItems;
        private System.Windows.Forms.BindingSource inventoryItemBindingSource;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.RadioButton rdbInnerPack;
        private System.Windows.Forms.RadioButton rdbRegular;
        private System.Windows.Forms.RadioButton rdb2x2;
        private System.Windows.Forms.RadioButton rdb15x2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mPNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn price3DataGridViewTextBoxColumn;
    }
}