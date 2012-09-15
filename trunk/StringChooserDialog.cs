using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KeepSync {
    public partial class StringChooserDialog : Form {
        public StringChooserDialog() {
            InitializeComponent();
        }
        public string result { get { return cbo_value.Text; } set { cbo_value.Text = value; } }
        public IEnumerable<object> history { get { return cbo_value.Items.OfType<object>(); } set { cbo_value.Items.AddRange(value.ToArray()); } }
        public new DialogResult ShowDialog() {
            return base.ShowDialog();
        }

        private void StringChooserDialog_Shown(object sender, EventArgs e) {
            MinimumSize = new Size(MinimumSize.Width, Height - ClientSize.Height + pnl_layout.Height);
           // MaximumSize = new Size(MaximumSize.Width, MinimumSize.Height);
        }
    }
}
