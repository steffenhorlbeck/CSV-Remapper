﻿namespace CSV_Remapper
{
    partial class MainForm
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
            this.lstSourceCSV = new System.Windows.Forms.ListBox();
            this.lblSourceCSV = new System.Windows.Forms.Label();
            this.lstTargetCSV = new System.Windows.Forms.ListBox();
            this.lstMaps = new System.Windows.Forms.ListBox();
            this.mappingContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTargetCSV = new System.Windows.Forms.Label();
            this.lblMapping = new System.Windows.Forms.Label();
            this.edtSourceCSV = new System.Windows.Forms.TextBox();
            this.btnSelectSourceCSV = new System.Windows.Forms.Button();
            this.btnSelectTargetCSV = new System.Windows.Forms.Button();
            this.edtTargetCSV = new System.Windows.Forms.TextBox();
            this.btnMap = new System.Windows.Forms.Button();
            this.fileSelectDlg = new System.Windows.Forms.OpenFileDialog();
            this.toolTipSource = new System.Windows.Forms.ToolTip(this.components);
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dlgFileSave = new System.Windows.Forms.SaveFileDialog();
            this.mappingContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstSourceCSV
            // 
            this.lstSourceCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstSourceCSV.FormattingEnabled = true;
            this.lstSourceCSV.Location = new System.Drawing.Point(13, 75);
            this.lstSourceCSV.Name = "lstSourceCSV";
            this.lstSourceCSV.Size = new System.Drawing.Size(251, 459);
            this.lstSourceCSV.TabIndex = 0;
            this.lstSourceCSV.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstSourceCSV_MouseMove);
            // 
            // lblSourceCSV
            // 
            this.lblSourceCSV.AutoSize = true;
            this.lblSourceCSV.Location = new System.Drawing.Point(13, 56);
            this.lblSourceCSV.Name = "lblSourceCSV";
            this.lblSourceCSV.Size = new System.Drawing.Size(111, 13);
            this.lblSourceCSV.TabIndex = 1;
            this.lblSourceCSV.Text = "Source CSV Structure";
            // 
            // lstTargetCSV
            // 
            this.lstTargetCSV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTargetCSV.FormattingEnabled = true;
            this.lstTargetCSV.Location = new System.Drawing.Point(339, 75);
            this.lstTargetCSV.Name = "lstTargetCSV";
            this.lstTargetCSV.Size = new System.Drawing.Size(251, 459);
            this.lstTargetCSV.TabIndex = 2;
            // 
            // lstMaps
            // 
            this.lstMaps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstMaps.ContextMenuStrip = this.mappingContextMenu;
            this.lstMaps.FormattingEnabled = true;
            this.lstMaps.Location = new System.Drawing.Point(616, 75);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(251, 459);
            this.lstMaps.TabIndex = 3;
            // 
            // mappingContextMenu
            // 
            this.mappingContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem});
            this.mappingContextMenu.Name = "mappingContextMenu";
            this.mappingContextMenu.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblTargetCSV
            // 
            this.lblTargetCSV.AutoSize = true;
            this.lblTargetCSV.Location = new System.Drawing.Point(336, 56);
            this.lblTargetCSV.Name = "lblTargetCSV";
            this.lblTargetCSV.Size = new System.Drawing.Size(108, 13);
            this.lblTargetCSV.TabIndex = 4;
            this.lblTargetCSV.Text = "Target CSV Structure";
            // 
            // lblMapping
            // 
            this.lblMapping.AutoSize = true;
            this.lblMapping.Location = new System.Drawing.Point(613, 56);
            this.lblMapping.Name = "lblMapping";
            this.lblMapping.Size = new System.Drawing.Size(48, 13);
            this.lblMapping.TabIndex = 5;
            this.lblMapping.Text = "Mapping";
            // 
            // edtSourceCSV
            // 
            this.edtSourceCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSourceCSV.Location = new System.Drawing.Point(13, 541);
            this.edtSourceCSV.Name = "edtSourceCSV";
            this.edtSourceCSV.Size = new System.Drawing.Size(227, 20);
            this.edtSourceCSV.TabIndex = 6;
            // 
            // btnSelectSourceCSV
            // 
            this.btnSelectSourceCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectSourceCSV.Location = new System.Drawing.Point(239, 540);
            this.btnSelectSourceCSV.Name = "btnSelectSourceCSV";
            this.btnSelectSourceCSV.Size = new System.Drawing.Size(25, 23);
            this.btnSelectSourceCSV.TabIndex = 7;
            this.btnSelectSourceCSV.Text = "...";
            this.btnSelectSourceCSV.UseVisualStyleBackColor = true;
            this.btnSelectSourceCSV.Click += new System.EventHandler(this.btnSelectSourceCSV_Click);
            // 
            // btnSelectTargetCSV
            // 
            this.btnSelectTargetCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectTargetCSV.Location = new System.Drawing.Point(565, 539);
            this.btnSelectTargetCSV.Name = "btnSelectTargetCSV";
            this.btnSelectTargetCSV.Size = new System.Drawing.Size(25, 23);
            this.btnSelectTargetCSV.TabIndex = 9;
            this.btnSelectTargetCSV.Text = "...";
            this.btnSelectTargetCSV.UseVisualStyleBackColor = true;
            this.btnSelectTargetCSV.Click += new System.EventHandler(this.btnSelectTargetCSV_Click);
            // 
            // edtTargetCSV
            // 
            this.edtTargetCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTargetCSV.Location = new System.Drawing.Point(339, 540);
            this.edtTargetCSV.Name = "edtTargetCSV";
            this.edtTargetCSV.Size = new System.Drawing.Size(227, 20);
            this.edtTargetCSV.TabIndex = 8;
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(271, 278);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(62, 52);
            this.btnMap.TabIndex = 10;
            this.btnMap.Text = "<- Map ->";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // toolTipSource
            // 
            this.toolTipSource.ToolTipTitle = "Field Value";
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(616, 539);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(123, 23);
            this.btnSaveConfig.TabIndex = 11;
            this.btnSaveConfig.Text = "Save Configuration";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(760, 539);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "Start Remapping";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 589);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnSelectTargetCSV);
            this.Controls.Add(this.edtTargetCSV);
            this.Controls.Add(this.btnSelectSourceCSV);
            this.Controls.Add(this.edtSourceCSV);
            this.Controls.Add(this.lblMapping);
            this.Controls.Add(this.lblTargetCSV);
            this.Controls.Add(this.lstMaps);
            this.Controls.Add(this.lstTargetCSV);
            this.Controls.Add(this.lblSourceCSV);
            this.Controls.Add(this.lstSourceCSV);
            this.Name = "MainForm";
            this.Text = "CSV Remapper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.mappingContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstSourceCSV;
        private System.Windows.Forms.Label lblSourceCSV;
        private System.Windows.Forms.ListBox lstTargetCSV;
        private System.Windows.Forms.ListBox lstMaps;
        private System.Windows.Forms.Label lblTargetCSV;
        private System.Windows.Forms.Label lblMapping;
        private System.Windows.Forms.TextBox edtSourceCSV;
        private System.Windows.Forms.Button btnSelectSourceCSV;
        private System.Windows.Forms.Button btnSelectTargetCSV;
        private System.Windows.Forms.TextBox edtTargetCSV;
        private System.Windows.Forms.Button btnMap;
        private System.Windows.Forms.OpenFileDialog fileSelectDlg;
        private System.Windows.Forms.ToolTip toolTipSource;
        private System.Windows.Forms.ContextMenuStrip mappingContextMenu;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.SaveFileDialog dlgFileSave;
    }
}

