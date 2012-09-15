namespace KeepSync {
    partial class SyncSettings {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnl_layout = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_sourceFolder = new System.Windows.Forms.LinkLabel();
            this.lbl_destFolder = new System.Windows.Forms.LinkLabel();
            this.txt_ignoreList = new System.Windows.Forms.TextBox();
            this.chk_active = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_remoteSite = new System.Windows.Forms.LinkLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btn_autoPublish = new System.Windows.Forms.ToolStripButton();
            this.btn_publishChanges = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.btn_clearPublished = new System.Windows.Forms.ToolStripButton();
            this.btn_remove = new System.Windows.Forms.Button();
            this.dgv_files = new System.Windows.Forms.DataGridView();
            this.col_status = new System.Windows.Forms.DataGridViewImageColumn();
            this.lastModified_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_publish = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pb_publishing = new System.Windows.Forms.ProgressBar();
            this.pnl_layout.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_files)).BeginInit();
            this.SuspendLayout();
            // 
            // pnl_layout
            // 
            this.pnl_layout.AutoSize = true;
            this.pnl_layout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnl_layout.ColumnCount = 3;
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnl_layout.Controls.Add(this.label4, 0, 2);
            this.pnl_layout.Controls.Add(this.label1, 0, 1);
            this.pnl_layout.Controls.Add(this.label2, 0, 0);
            this.pnl_layout.Controls.Add(this.lbl_sourceFolder, 1, 0);
            this.pnl_layout.Controls.Add(this.lbl_destFolder, 1, 1);
            this.pnl_layout.Controls.Add(this.txt_ignoreList, 1, 3);
            this.pnl_layout.Controls.Add(this.chk_active, 0, 4);
            this.pnl_layout.Controls.Add(this.label3, 0, 3);
            this.pnl_layout.Controls.Add(this.lbl_remoteSite, 1, 2);
            this.pnl_layout.Controls.Add(this.toolStrip1, 2, 0);
            this.pnl_layout.Controls.Add(this.btn_remove, 0, 5);
            this.pnl_layout.Controls.Add(this.dgv_files, 0, 6);
            this.pnl_layout.Controls.Add(this.pb_publishing, 2, 5);
            this.pnl_layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_layout.Location = new System.Drawing.Point(0, 0);
            this.pnl_layout.MinimumSize = new System.Drawing.Size(0, 350);
            this.pnl_layout.Name = "pnl_layout";
            this.pnl_layout.RowCount = 6;
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_layout.Size = new System.Drawing.Size(396, 379);
            this.pnl_layout.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Remote";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Destination";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Source";
            // 
            // lbl_sourceFolder
            // 
            this.lbl_sourceFolder.AutoSize = true;
            this.lbl_sourceFolder.Location = new System.Drawing.Point(69, 0);
            this.lbl_sourceFolder.Name = "lbl_sourceFolder";
            this.lbl_sourceFolder.Size = new System.Drawing.Size(111, 13);
            this.lbl_sourceFolder.TabIndex = 3;
            this.lbl_sourceFolder.TabStop = true;
            this.lbl_sourceFolder.Text = "Click Here To Choose";
            this.lbl_sourceFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_sourceFolder_LinkClicked);
            // 
            // lbl_destFolder
            // 
            this.lbl_destFolder.AutoSize = true;
            this.lbl_destFolder.Location = new System.Drawing.Point(69, 13);
            this.lbl_destFolder.Name = "lbl_destFolder";
            this.lbl_destFolder.Size = new System.Drawing.Size(111, 13);
            this.lbl_destFolder.TabIndex = 4;
            this.lbl_destFolder.TabStop = true;
            this.lbl_destFolder.Text = "Click Here To Choose";
            this.lbl_destFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_destFolder_LinkClicked);
            // 
            // txt_ignoreList
            // 
            this.txt_ignoreList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_ignoreList.Location = new System.Drawing.Point(69, 42);
            this.txt_ignoreList.Multiline = true;
            this.txt_ignoreList.Name = "txt_ignoreList";
            this.pnl_layout.SetRowSpan(this.txt_ignoreList, 3);
            this.txt_ignoreList.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txt_ignoreList.Size = new System.Drawing.Size(200, 100);
            this.txt_ignoreList.TabIndex = 8;
            this.txt_ignoreList.WordWrap = false;
            this.txt_ignoreList.TextChanged += new System.EventHandler(this.txt_ignoreList_TextChanged);
            // 
            // chk_active
            // 
            this.chk_active.AutoSize = true;
            this.chk_active.Location = new System.Drawing.Point(3, 68);
            this.chk_active.Name = "chk_active";
            this.chk_active.Size = new System.Drawing.Size(56, 17);
            this.chk_active.TabIndex = 5;
            this.chk_active.Text = "Active";
            this.chk_active.UseVisualStyleBackColor = true;
            this.chk_active.CheckedChanged += new System.EventHandler(this.chk_active_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ignore (,)";
            // 
            // lbl_remoteSite
            // 
            this.lbl_remoteSite.AutoSize = true;
            this.lbl_remoteSite.Location = new System.Drawing.Point(69, 26);
            this.lbl_remoteSite.Name = "lbl_remoteSite";
            this.lbl_remoteSite.Size = new System.Drawing.Size(111, 13);
            this.lbl_remoteSite.TabIndex = 11;
            this.lbl_remoteSite.TabStop = true;
            this.lbl_remoteSite.Text = "Click Here To Choose";
            this.lbl_remoteSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_remote_LinkClicked);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_autoPublish,
            this.btn_publishChanges,
            this.toolStripButton3,
            this.btn_clearPublished});
            this.toolStrip1.Location = new System.Drawing.Point(272, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.pnl_layout.SetRowSpan(this.toolStrip1, 6);
            this.toolStrip1.Size = new System.Drawing.Size(124, 145);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btn_autoPublish
            // 
            this.btn_autoPublish.CheckOnClick = true;
            this.btn_autoPublish.Image = global::KeepSync.Properties.Resources.document_out;
            this.btn_autoPublish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_autoPublish.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btn_autoPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_autoPublish.Name = "btn_autoPublish";
            this.btn_autoPublish.Size = new System.Drawing.Size(121, 20);
            this.btn_autoPublish.Text = "Auto Publish";
            // 
            // btn_publishChanges
            // 
            this.btn_publishChanges.Image = global::KeepSync.Properties.Resources.document_check;
            this.btn_publishChanges.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_publishChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_publishChanges.Name = "btn_publishChanges";
            this.btn_publishChanges.Size = new System.Drawing.Size(121, 28);
            this.btn_publishChanges.Text = "Publish Changes";
            this.btn_publishChanges.Click += new System.EventHandler(this.btn_publishChanges_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::KeepSync.Properties.Resources.clipboard;
            this.toolStripButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(121, 28);
            this.toolStripButton3.Text = "Paste Files";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // btn_clearPublished
            // 
            this.btn_clearPublished.Image = global::KeepSync.Properties.Resources.document_delete;
            this.btn_clearPublished.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_clearPublished.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clearPublished.Name = "btn_clearPublished";
            this.btn_clearPublished.Size = new System.Drawing.Size(121, 28);
            this.btn_clearPublished.Text = "Clear Published";
            this.btn_clearPublished.Click += new System.EventHandler(this.btn_clearPublished_Click);
            // 
            // btn_remove
            // 
            this.btn_remove.AutoSize = true;
            this.btn_remove.Image = global::KeepSync.Properties.Resources.stop24_h;
            this.btn_remove.Location = new System.Drawing.Point(3, 91);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Padding = new System.Windows.Forms.Padding(1);
            this.btn_remove.Size = new System.Drawing.Size(32, 32);
            this.btn_remove.TabIndex = 15;
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // dgv_files
            // 
            this.dgv_files.AllowUserToAddRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_files.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_files.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_status,
            this.lastModified_column,
            this.name_column,
            this.col_publish});
            this.pnl_layout.SetColumnSpan(this.dgv_files, 3);
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_files.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_files.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_files.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_files.Location = new System.Drawing.Point(3, 177);
            this.dgv_files.Name = "dgv_files";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_files.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_files.Size = new System.Drawing.Size(390, 199);
            this.dgv_files.TabIndex = 14;
            this.dgv_files.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_files_CellContentClick);
            this.dgv_files.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_files_KeyPress);
            this.dgv_files.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgv_files_KeyUp);
            // 
            // col_status
            // 
            this.col_status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_status.DataPropertyName = "statusImg";
            this.col_status.HeaderText = "Status";
            this.col_status.Name = "col_status";
            this.col_status.Width = 43;
            // 
            // lastModified_column
            // 
            this.lastModified_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lastModified_column.DataPropertyName = "lastModified";
            this.lastModified_column.HeaderText = "Modified";
            this.lastModified_column.Name = "lastModified_column";
            this.lastModified_column.Width = 72;
            // 
            // name_column
            // 
            this.name_column.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name_column.DataPropertyName = "name";
            this.name_column.HeaderText = "File Name";
            this.name_column.Name = "name_column";
            // 
            // col_publish
            // 
            this.col_publish.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.col_publish.DataPropertyName = "publish";
            this.col_publish.FalseValue = "False";
            this.col_publish.HeaderText = "Publish";
            this.col_publish.Name = "col_publish";
            this.col_publish.TrueValue = "True";
            this.col_publish.Width = 47;
            // 
            // pb_publishing
            // 
            this.pnl_layout.SetColumnSpan(this.pb_publishing, 3);
            this.pb_publishing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_publishing.Location = new System.Drawing.Point(3, 148);
            this.pb_publishing.Name = "pb_publishing";
            this.pb_publishing.Size = new System.Drawing.Size(390, 23);
            this.pb_publishing.TabIndex = 16;
            this.pb_publishing.Visible = false;
            // 
            // SyncSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnl_layout);
            this.MinimumSize = new System.Drawing.Size(400, 80);
            this.Name = "SyncSettings";
            this.Size = new System.Drawing.Size(396, 379);
            this.Resize += new System.EventHandler(this.SyncSettings_Resize);
            this.pnl_layout.ResumeLayout(false);
            this.pnl_layout.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_files)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel pnl_layout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lbl_sourceFolder;
        private System.Windows.Forms.LinkLabel lbl_destFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ignoreList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chk_active;
        private System.Windows.Forms.LinkLabel lbl_remoteSite;
        private System.Windows.Forms.DataGridView dgv_files;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_publishChanges;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton btn_clearPublished;
        private System.Windows.Forms.DataGridViewImageColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModified_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_column;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_publish;
        private System.Windows.Forms.ProgressBar pb_publishing;
        private System.Windows.Forms.ToolStripButton btn_autoPublish;
    }
}
