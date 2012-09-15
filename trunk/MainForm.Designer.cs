namespace KeepSync {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tc_syncs = new System.Windows.Forms.TabControl();
            this.tp_output = new System.Windows.Forms.TabPage();
            this.dgv_output = new System.Windows.Forms.DataGridView();
            this.btn_newSync = new System.Windows.Forms.ToolStripButton();
            this.Reason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Output = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.tc_syncs.SuspendLayout();
            this.tp_output.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_output)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_newSync});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(677, 31);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(674, 31);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 471);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // tc_syncs
            // 
            this.tc_syncs.Controls.Add(this.tp_output);
            this.tc_syncs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_syncs.Location = new System.Drawing.Point(0, 31);
            this.tc_syncs.Multiline = true;
            this.tc_syncs.Name = "tc_syncs";
            this.tc_syncs.SelectedIndex = 0;
            this.tc_syncs.Size = new System.Drawing.Size(674, 471);
            this.tc_syncs.TabIndex = 5;
            // 
            // tp_output
            // 
            this.tp_output.Controls.Add(this.dgv_output);
            this.tp_output.Location = new System.Drawing.Point(4, 22);
            this.tp_output.Name = "tp_output";
            this.tp_output.Padding = new System.Windows.Forms.Padding(3);
            this.tp_output.Size = new System.Drawing.Size(666, 445);
            this.tp_output.TabIndex = 0;
            this.tp_output.Text = "Output";
            this.tp_output.UseVisualStyleBackColor = true;
            // 
            // dgv_output
            // 
            this.dgv_output.AllowUserToAddRows = false;
            this.dgv_output.AllowUserToDeleteRows = false;
            this.dgv_output.AllowUserToResizeColumns = false;
            this.dgv_output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_output.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Reason,
            this.col_Output});
            this.dgv_output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_output.Location = new System.Drawing.Point(3, 3);
            this.dgv_output.Name = "dgv_output";
            this.dgv_output.RowHeadersVisible = false;
            this.dgv_output.Size = new System.Drawing.Size(660, 439);
            this.dgv_output.TabIndex = 0;
            // 
            // btn_newSync
            // 
            this.btn_newSync.Image = global::KeepSync.Properties.Resources.db_register24_h;
            this.btn_newSync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_newSync.Name = "btn_newSync";
            this.btn_newSync.Size = new System.Drawing.Size(87, 28);
            this.btn_newSync.Text = "New Sync";
            this.btn_newSync.Click += new System.EventHandler(this.btn_newSync_Click);
            // 
            // Reason
            // 
            this.Reason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Reason.DataPropertyName = "reason";
            this.Reason.HeaderText = "Category";
            this.Reason.Name = "Reason";
            this.Reason.ReadOnly = true;
            this.Reason.Width = 74;
            // 
            // col_Output
            // 
            this.col_Output.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Output.DataPropertyName = "message";
            this.col_Output.HeaderText = "Output";
            this.col_Output.Name = "col_Output";
            this.col_Output.ReadOnly = true;
            this.col_Output.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 502);
            this.Controls.Add(this.tc_syncs);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Keep Sync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tc_syncs.ResumeLayout(false);
            this.tp_output.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_output)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btn_newSync;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tc_syncs;
        private System.Windows.Forms.TabPage tp_output;
        private System.Windows.Forms.DataGridView dgv_output;
        private System.Windows.Forms.DataGridViewTextBoxColumn Reason;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Output;

    }
}

