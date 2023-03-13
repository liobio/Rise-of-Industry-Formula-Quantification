namespace FormulationQuantification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.quantization = new System.Windows.Forms.Button();
            this.numTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.itemComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.formulaTreeView = new System.Windows.Forms.TreeView();
            this.formulaListBox = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quantization);
            this.panel1.Controls.Add(this.numTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.itemComboBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 100);
            this.panel1.TabIndex = 6;
            // 
            // quantization
            // 
            this.quantization.Location = new System.Drawing.Point(384, 38);
            this.quantization.Name = "quantization";
            this.quantization.Size = new System.Drawing.Size(53, 23);
            this.quantization.TabIndex = 10;
            this.quantization.Text = "量化";
            this.quantization.UseVisualStyleBackColor = true;
            this.quantization.Click += new System.EventHandler(this.Quantification);
            // 
            // numTextBox
            // 
            this.numTextBox.Location = new System.Drawing.Point(263, 38);
            this.numTextBox.Name = "numTextBox";
            this.numTextBox.Size = new System.Drawing.Size(80, 23);
            this.numTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(207, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "数量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "物品";
            // 
            // itemComboBox
            // 
            this.itemComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.itemComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.itemComboBox.FormattingEnabled = true;
            this.itemComboBox.Location = new System.Drawing.Point(75, 36);
            this.itemComboBox.Name = "itemComboBox";
            this.itemComboBox.Size = new System.Drawing.Size(120, 25);
            this.itemComboBox.TabIndex = 6;
            this.itemComboBox.TextUpdate += new System.EventHandler(this.SelectItem);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel2.Controls.Add(this.formulaTreeView);
            this.panel2.Controls.Add(this.formulaListBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(584, 661);
            this.panel2.TabIndex = 7;
            // 
            // formulaTreeView
            // 
            this.formulaTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formulaTreeView.Font = new System.Drawing.Font("Microsoft YaHei UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.formulaTreeView.Location = new System.Drawing.Point(0, 0);
            this.formulaTreeView.Name = "formulaTreeView";
            this.formulaTreeView.Size = new System.Drawing.Size(584, 470);
            this.formulaTreeView.TabIndex = 1;
            // 
            // formulaListBox
            // 
            this.formulaListBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.formulaListBox.FormattingEnabled = true;
            this.formulaListBox.ItemHeight = 17;
            this.formulaListBox.Location = new System.Drawing.Point(0, 470);
            this.formulaListBox.Name = "formulaListBox";
            this.formulaListBox.Size = new System.Drawing.Size(584, 191);
            this.formulaListBox.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 761);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Rise of Industry 配方量化";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button quantization;
        private TextBox numTextBox;
        private Label label2;
        private Label label1;
        private ComboBox itemComboBox;
        private Panel panel2;
        private ListBox formulaListBox;
        private TreeView formulaTreeView;
    }
}