
namespace CheckBook
{
    partial class MainScreen
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ledgerDataGridView = new System.Windows.Forms.DataGridView();
            openQuickenFileDialog = new System.Windows.Forms.OpenFileDialog();
            saveBKFileDialog = new System.Windows.Forms.SaveFileDialog();
            openBKFileDialog = new System.Windows.Forms.OpenFileDialog();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            addTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reconcileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            voidTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)ledgerDataGridView).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ledgerDataGridView
            // 
            ledgerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ledgerDataGridView.Location = new System.Drawing.Point(36, 47);
            ledgerDataGridView.Name = "ledgerDataGridView";
            ledgerDataGridView.RowHeadersWidth = 62;
            ledgerDataGridView.RowTemplate.Height = 33;
            ledgerDataGridView.Size = new System.Drawing.Size(1174, 598);
            ledgerDataGridView.TabIndex = 0;
            // 
            // openQuickenFileDialog
            // 
            openQuickenFileDialog.FileName = "QUICKEXP.TXT";
            // 
            // openBKFileDialog
            // 
            openBKFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { fileToolStripMenuItem, addTransactionToolStripMenuItem, reconcileToolStripMenuItem, reportToolStripMenuItem, voidTransactionToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1223, 33);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, importToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(169, 34);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += ImportToolStripMenuItem_Click;
            // 
            // addTransactionToolStripMenuItem
            // 
            addTransactionToolStripMenuItem.Name = "addTransactionToolStripMenuItem";
            addTransactionToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A;
            addTransactionToolStripMenuItem.Size = new System.Drawing.Size(155, 29);
            addTransactionToolStripMenuItem.Text = "&Add Transaction";
            addTransactionToolStripMenuItem.Click += AddTransactionToolStripMenuItem_Click;
            // 
            // reconcileToolStripMenuItem
            // 
            reconcileToolStripMenuItem.Name = "reconcileToolStripMenuItem";
            reconcileToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            reconcileToolStripMenuItem.Text = "&Reconcile";
            reconcileToolStripMenuItem.Click += ReconcileToolStripMenuItem_Click;
            // 
            // reportToolStripMenuItem
            // 
            reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            reportToolStripMenuItem.Size = new System.Drawing.Size(81, 29);
            reportToolStripMenuItem.Text = "Report";
            reportToolStripMenuItem.Click += ReportToolStripMenuItem_Click;
            // 
            // voidTransactionToolStripMenuItem
            // 
            voidTransactionToolStripMenuItem.Name = "voidTransactionToolStripMenuItem";
            voidTransactionToolStripMenuItem.Size = new System.Drawing.Size(157, 29);
            voidTransactionToolStripMenuItem.Text = "Void Transaction";
            voidTransactionToolStripMenuItem.Click += VoidTransactionToolStripMenuItem_Click;
            // 
            // MainScreen
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1223, 657);
            Controls.Add(ledgerDataGridView);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainScreen";
            Text = "Check Book Program";
            FormClosing += MainScreen_FormClosing;
            Shown += MainScreen_Shown;
            ((System.ComponentModel.ISupportInitialize)ledgerDataGridView).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView ledgerDataGridView;
        private System.Windows.Forms.OpenFileDialog openQuickenFileDialog;
        private System.Windows.Forms.SaveFileDialog saveBKFileDialog;
        private System.Windows.Forms.OpenFileDialog openBKFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTransactionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconcileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem voidTransactionToolStripMenuItem;
    }
}

