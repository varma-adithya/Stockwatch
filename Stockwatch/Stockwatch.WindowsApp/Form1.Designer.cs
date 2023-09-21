using Microsoft.Extensions.DependencyInjection;

namespace Stockwatch.WindowsApp
{
    partial class Form1
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
            this.InputContainer = new System.Windows.Forms.SplitContainer();
            this.SymbolpageMsg = new System.Windows.Forms.Label();
            this.SymbolsubmitBtn = new System.Windows.Forms.Button();
            this.SymbolnameTbx = new System.Windows.Forms.TextBox();
            this.entersymbollabel = new System.Windows.Forms.Label();
            this.Hlimittbx = new System.Windows.Forms.TextBox();
            this.Llimittbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.StockPageMsg = new System.Windows.Forms.Label();
            this.NewStockcreateBtn = new System.Windows.Forms.Button();
            this.Llimitstocklabel = new System.Windows.Forms.Label();
            this.SymbolDdown = new System.Windows.Forms.ComboBox();
            this.Symbolselectlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).BeginInit();
            this.InputContainer.Panel1.SuspendLayout();
            this.InputContainer.Panel2.SuspendLayout();
            this.InputContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputContainer
            // 
            this.InputContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.InputContainer.Location = new System.Drawing.Point(12, 427);
            this.InputContainer.Name = "InputContainer";
            // 
            // InputContainer.Panel1
            // 
            this.InputContainer.Panel1.Controls.Add(this.SymbolpageMsg);
            this.InputContainer.Panel1.Controls.Add(this.SymbolsubmitBtn);
            this.InputContainer.Panel1.Controls.Add(this.SymbolnameTbx);
            this.InputContainer.Panel1.Controls.Add(this.entersymbollabel);
            // 
            // InputContainer.Panel2
            // 
            this.InputContainer.Panel2.Controls.Add(this.Hlimittbx);
            this.InputContainer.Panel2.Controls.Add(this.Llimittbx);
            this.InputContainer.Panel2.Controls.Add(this.label2);
            this.InputContainer.Panel2.Controls.Add(this.StockPageMsg);
            this.InputContainer.Panel2.Controls.Add(this.NewStockcreateBtn);
            this.InputContainer.Panel2.Controls.Add(this.Llimitstocklabel);
            this.InputContainer.Panel2.Controls.Add(this.SymbolDdown);
            this.InputContainer.Panel2.Controls.Add(this.Symbolselectlabel);
            this.InputContainer.Panel2.Controls.Add(this.label1);
            this.InputContainer.Size = new System.Drawing.Size(998, 298);
            this.InputContainer.SplitterDistance = 474;
            this.InputContainer.TabIndex = 0;
            // 
            // SymbolpageMsg
            // 
            this.SymbolpageMsg.AutoSize = true;
            this.SymbolpageMsg.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SymbolpageMsg.Location = new System.Drawing.Point(23, 192);
            this.SymbolpageMsg.Name = "SymbolpageMsg";
            this.SymbolpageMsg.Size = new System.Drawing.Size(0, 29);
            this.SymbolpageMsg.TabIndex = 3;
            // 
            // SymbolsubmitBtn
            // 
            this.SymbolsubmitBtn.Location = new System.Drawing.Point(240, 192);
            this.SymbolsubmitBtn.Name = "SymbolsubmitBtn";
            this.SymbolsubmitBtn.Size = new System.Drawing.Size(179, 58);
            this.SymbolsubmitBtn.TabIndex = 2;
            this.SymbolsubmitBtn.Text = "Create";
            this.SymbolsubmitBtn.UseVisualStyleBackColor = true;
            this.SymbolsubmitBtn.Click += new System.EventHandler(this.SymbolsubmitBtn_Click);
            // 
            // SymbolnameTbx
            // 
            this.SymbolnameTbx.Location = new System.Drawing.Point(42, 130);
            this.SymbolnameTbx.Name = "SymbolnameTbx";
            this.SymbolnameTbx.Size = new System.Drawing.Size(377, 27);
            this.SymbolnameTbx.TabIndex = 1;
            // 
            // entersymbollabel
            // 
            this.entersymbollabel.AutoSize = true;
            this.entersymbollabel.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.entersymbollabel.Location = new System.Drawing.Point(23, 52);
            this.entersymbollabel.Name = "entersymbollabel";
            this.entersymbollabel.Size = new System.Drawing.Size(326, 51);
            this.entersymbollabel.TabIndex = 0;
            this.entersymbollabel.Text = "Enter New Symbol Name";
            // 
            // Hlimittbx
            // 
            this.Hlimittbx.Location = new System.Drawing.Point(211, 193);
            this.Hlimittbx.Name = "Hlimittbx";
            this.Hlimittbx.Size = new System.Drawing.Size(216, 27);
            this.Hlimittbx.TabIndex = 8;
            // 
            // Llimittbx
            // 
            this.Llimittbx.Location = new System.Drawing.Point(211, 148);
            this.Llimittbx.Name = "Llimittbx";
            this.Llimittbx.Size = new System.Drawing.Size(216, 27);
            this.Llimittbx.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Symbol Lower limit";
            // 
            // StockPageMsg
            // 
            this.StockPageMsg.AutoSize = true;
            this.StockPageMsg.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StockPageMsg.Location = new System.Drawing.Point(32, 247);
            this.StockPageMsg.Name = "StockPageMsg";
            this.StockPageMsg.Size = new System.Drawing.Size(0, 29);
            this.StockPageMsg.TabIndex = 4;
            // 
            // NewStockcreateBtn
            // 
            this.NewStockcreateBtn.Location = new System.Drawing.Point(306, 242);
            this.NewStockcreateBtn.Name = "NewStockcreateBtn";
            this.NewStockcreateBtn.Size = new System.Drawing.Size(121, 37);
            this.NewStockcreateBtn.TabIndex = 5;
            this.NewStockcreateBtn.Text = "Create";
            this.NewStockcreateBtn.UseVisualStyleBackColor = true;
            this.NewStockcreateBtn.Click += new System.EventHandler(this.NewStockcreateBtn_Click);
            // 
            // Llimitstocklabel
            // 
            this.Llimitstocklabel.AutoSize = true;
            this.Llimitstocklabel.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Llimitstocklabel.Location = new System.Drawing.Point(32, 147);
            this.Llimitstocklabel.Name = "Llimitstocklabel";
            this.Llimitstocklabel.Size = new System.Drawing.Size(165, 32);
            this.Llimitstocklabel.TabIndex = 3;
            this.Llimitstocklabel.Text = "Symbol Lower limit";
            // 
            // SymbolDdown
            // 
            this.SymbolDdown.DisplayMember = "Select";
            this.SymbolDdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SymbolDdown.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SymbolDdown.FormattingEnabled = true;
            this.SymbolDdown.Location = new System.Drawing.Point(211, 89);
            this.SymbolDdown.Name = "SymbolDdown";
            this.SymbolDdown.Size = new System.Drawing.Size(216, 38);
            this.SymbolDdown.TabIndex = 2;
            this.SymbolDdown.ValueMember = "Select";
            this.SymbolDdown.SelectedIndexChanged += new System.EventHandler(this.SymbolDdown_SelectedIndexChanged);
            // 
            // Symbolselectlabel
            // 
            this.Symbolselectlabel.AutoSize = true;
            this.Symbolselectlabel.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Symbolselectlabel.Location = new System.Drawing.Point(32, 92);
            this.Symbolselectlabel.Name = "Symbolselectlabel";
            this.Symbolselectlabel.Size = new System.Drawing.Size(124, 32);
            this.Symbolselectlabel.TabIndex = 1;
            this.Symbolselectlabel.Text = "Select Symbol";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(32, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter New Stock to be tracked";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 737);
            this.Controls.Add(this.InputContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputContainer.Panel1.ResumeLayout(false);
            this.InputContainer.Panel1.PerformLayout();
            this.InputContainer.Panel2.ResumeLayout(false);
            this.InputContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).EndInit();
            this.InputContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer InputContainer;
        private Label SymbolpageMsg;
        private Button SymbolsubmitBtn;
        private TextBox SymbolnameTbx;
        private Label entersymbollabel;
        private Label label1;
        private TextBox Hlimittbx;
        private TextBox Llimittbx;
        private Label label2;
        private Label StockPageMsg;
        private Button NewStockcreateBtn;
        private Label Llimitstocklabel;
        private ComboBox SymbolDdown;
        private Label Symbolselectlabel;
    }
}