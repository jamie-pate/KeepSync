namespace KeepSync {
    partial class StringChooserDialog {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StringChooserDialog));
            this.cbo_value = new System.Windows.Forms.ComboBox();
            this.pnl_layout = new System.Windows.Forms.TableLayoutPanel();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.pnl_layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbo_value
            // 
            this.cbo_value.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbo_value.FormattingEnabled = true;
            this.cbo_value.Location = new System.Drawing.Point(3, 3);
            this.cbo_value.Name = "cbo_value";
            this.cbo_value.Size = new System.Drawing.Size(256, 21);
            this.cbo_value.TabIndex = 0;
            // 
            // pnl_layout
            // 
            this.pnl_layout.AutoSize = true;
            this.pnl_layout.ColumnCount = 3;
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnl_layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnl_layout.Controls.Add(this.cbo_value, 0, 0);
            this.pnl_layout.Controls.Add(this.btn_ok, 1, 0);
            this.pnl_layout.Controls.Add(this.btn_cancel, 2, 0);
            this.pnl_layout.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_layout.Location = new System.Drawing.Point(0, 0);
            this.pnl_layout.Name = "pnl_layout";
            this.pnl_layout.RowCount = 1;
            this.pnl_layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnl_layout.Size = new System.Drawing.Size(424, 29);
            this.pnl_layout.TabIndex = 1;
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(265, 3);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 1;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            // 
            // btn_cancel
            // 
            this.btn_cancel.AutoSize = true;
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(346, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // StringChooserDialog
            // 
            this.AcceptButton = this.btn_ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(424, 30);
            this.Controls.Add(this.pnl_layout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(430, 0);
            this.Name = "StringChooserDialog";
            this.Text = "Select a Remote Destination";
            this.Shown += new System.EventHandler(this.StringChooserDialog_Shown);
            this.pnl_layout.ResumeLayout(false);
            this.pnl_layout.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbo_value;
        private System.Windows.Forms.TableLayoutPanel pnl_layout;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
    }
}