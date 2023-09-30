using Microsoft.Extensions.DependencyInjection;

namespace Stockwatch.WindowsApp
{
    partial class StockPage
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
            this.components = new System.ComponentModel.Container();
            this.InputContainer = new System.Windows.Forms.SplitContainer();
            this.EditSymbolbx = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.EditLLimitbx = new System.Windows.Forms.NumericUpDown();
            this.EditHLimitbx = new System.Windows.Forms.NumericUpDown();
            this.EditUpdatebtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UpdataMsgbx = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EditDeletebtn = new System.Windows.Forms.Button();
            this.NewLLimitbx = new System.Windows.Forms.NumericUpDown();
            this.NewHLimitbx = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.StockPageMsg = new System.Windows.Forms.Label();
            this.NewStockcreateBtn = new System.Windows.Forms.Button();
            this.Llimitstocklabel = new System.Windows.Forms.Label();
            this.SymbolDdown = new System.Windows.Forms.ComboBox();
            this.Symbolselectlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Symbol1bx = new System.Windows.Forms.TextBox();
            this.LowerLimit1bx = new System.Windows.Forms.TextBox();
            this.UpperLimit1bx = new System.Windows.Forms.TextBox();
            this.Stock1Msg = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Stock1label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Symbol2bx = new System.Windows.Forms.TextBox();
            this.LowerLimit2bx = new System.Windows.Forms.TextBox();
            this.UpperLimit2bx = new System.Windows.Forms.TextBox();
            this.Stock2Msg = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Stock2label = new System.Windows.Forms.Label();
            this.WorkerServiceIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).BeginInit();
            this.InputContainer.Panel1.SuspendLayout();
            this.InputContainer.Panel2.SuspendLayout();
            this.InputContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditLLimitbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditHLimitbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLLimitbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewHLimitbx)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.InputContainer.Panel1.Controls.Add(this.EditSymbolbx);
            this.InputContainer.Panel1.Controls.Add(this.label4);
            this.InputContainer.Panel1.Controls.Add(this.EditLLimitbx);
            this.InputContainer.Panel1.Controls.Add(this.EditHLimitbx);
            this.InputContainer.Panel1.Controls.Add(this.EditUpdatebtn);
            this.InputContainer.Panel1.Controls.Add(this.label7);
            this.InputContainer.Panel1.Controls.Add(this.label3);
            this.InputContainer.Panel1.Controls.Add(this.UpdataMsgbx);
            this.InputContainer.Panel1.Controls.Add(this.label5);
            this.InputContainer.Panel1.Controls.Add(this.EditDeletebtn);
            // 
            // InputContainer.Panel2
            // 
            this.InputContainer.Panel2.Controls.Add(this.NewLLimitbx);
            this.InputContainer.Panel2.Controls.Add(this.NewHLimitbx);
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
            // EditSymbolbx
            // 
            this.EditSymbolbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditSymbolbx.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EditSymbolbx.Location = new System.Drawing.Point(175, 98);
            this.EditSymbolbx.Name = "EditSymbolbx";
            this.EditSymbolbx.ReadOnly = true;
            this.EditSymbolbx.Size = new System.Drawing.Size(241, 29);
            this.EditSymbolbx.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(21, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 32);
            this.label4.TabIndex = 21;
            this.label4.Text = "Symbol Name:";
            // 
            // EditLLimitbx
            // 
            this.EditLLimitbx.Location = new System.Drawing.Point(200, 197);
            this.EditLLimitbx.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.EditLLimitbx.Name = "EditLLimitbx";
            this.EditLLimitbx.Size = new System.Drawing.Size(216, 27);
            this.EditLLimitbx.TabIndex = 20;
            // 
            // EditHLimitbx
            // 
            this.EditHLimitbx.Location = new System.Drawing.Point(200, 152);
            this.EditHLimitbx.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.EditHLimitbx.Name = "EditHLimitbx";
            this.EditHLimitbx.Size = new System.Drawing.Size(216, 27);
            this.EditHLimitbx.TabIndex = 19;
            // 
            // EditUpdatebtn
            // 
            this.EditUpdatebtn.Location = new System.Drawing.Point(219, 239);
            this.EditUpdatebtn.Name = "EditUpdatebtn";
            this.EditUpdatebtn.Size = new System.Drawing.Size(121, 37);
            this.EditUpdatebtn.TabIndex = 18;
            this.EditUpdatebtn.Text = "Update";
            this.EditUpdatebtn.UseVisualStyleBackColor = true;
            this.EditUpdatebtn.Click += new System.EventHandler(this.EditUpdatebtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Dubai", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(21, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 42);
            this.label7.TabIndex = 9;
            this.label7.Text = "Stock Update / Delete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 32);
            this.label3.TabIndex = 15;
            this.label3.Text = "Stock Lower Limit";
            // 
            // UpdataMsgbx
            // 
            this.UpdataMsgbx.AutoSize = true;
            this.UpdataMsgbx.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UpdataMsgbx.Location = new System.Drawing.Point(21, 244);
            this.UpdataMsgbx.Name = "UpdataMsgbx";
            this.UpdataMsgbx.Size = new System.Drawing.Size(0, 29);
            this.UpdataMsgbx.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(21, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Stock Upper Limit";
            // 
            // EditDeletebtn
            // 
            this.EditDeletebtn.Location = new System.Drawing.Point(346, 239);
            this.EditDeletebtn.Name = "EditDeletebtn";
            this.EditDeletebtn.Size = new System.Drawing.Size(121, 37);
            this.EditDeletebtn.TabIndex = 14;
            this.EditDeletebtn.Text = "Delete";
            this.EditDeletebtn.UseVisualStyleBackColor = true;
            this.EditDeletebtn.Click += new System.EventHandler(this.EditDeletebtn_Click);
            // 
            // NewLLimitbx
            // 
            this.NewLLimitbx.Location = new System.Drawing.Point(211, 197);
            this.NewLLimitbx.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.NewLLimitbx.Name = "NewLLimitbx";
            this.NewLLimitbx.Size = new System.Drawing.Size(216, 27);
            this.NewLLimitbx.TabIndex = 8;
            // 
            // NewHLimitbx
            // 
            this.NewHLimitbx.Location = new System.Drawing.Point(211, 152);
            this.NewHLimitbx.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.NewHLimitbx.Name = "NewHLimitbx";
            this.NewHLimitbx.Size = new System.Drawing.Size(216, 27);
            this.NewHLimitbx.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(32, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stock Lower Limit";
            // 
            // StockPageMsg
            // 
            this.StockPageMsg.AutoSize = true;
            this.StockPageMsg.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StockPageMsg.Location = new System.Drawing.Point(32, 247);
            this.StockPageMsg.Name = "StockPageMsg";
            this.StockPageMsg.Size = new System.Drawing.Size(117, 29);
            this.StockPageMsg.TabIndex = 4;
            this.StockPageMsg.Text = "*Upto 4 stocks";
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
            this.Llimitstocklabel.Size = new System.Drawing.Size(157, 32);
            this.Llimitstocklabel.TabIndex = 3;
            this.Llimitstocklabel.Text = "Stock Upper Limit";
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
            this.label1.Size = new System.Drawing.Size(196, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Brand New Stock";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Symbol1bx);
            this.panel1.Controls.Add(this.LowerLimit1bx);
            this.panel1.Controls.Add(this.UpperLimit1bx);
            this.panel1.Controls.Add(this.Stock1Msg);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.Stock1label);
            this.panel1.Location = new System.Drawing.Point(19, 66);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(462, 169);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // Symbol1bx
            // 
            this.Symbol1bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Symbol1bx.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Symbol1bx.Location = new System.Drawing.Point(149, 43);
            this.Symbol1bx.Name = "Symbol1bx";
            this.Symbol1bx.ReadOnly = true;
            this.Symbol1bx.Size = new System.Drawing.Size(241, 29);
            this.Symbol1bx.TabIndex = 15;
            // 
            // LowerLimit1bx
            // 
            this.LowerLimit1bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LowerLimit1bx.Location = new System.Drawing.Point(341, 75);
            this.LowerLimit1bx.Name = "LowerLimit1bx";
            this.LowerLimit1bx.ReadOnly = true;
            this.LowerLimit1bx.Size = new System.Drawing.Size(108, 20);
            this.LowerLimit1bx.TabIndex = 14;
            // 
            // UpperLimit1bx
            // 
            this.UpperLimit1bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UpperLimit1bx.Location = new System.Drawing.Point(134, 75);
            this.UpperLimit1bx.Name = "UpperLimit1bx";
            this.UpperLimit1bx.ReadOnly = true;
            this.UpperLimit1bx.Size = new System.Drawing.Size(82, 20);
            this.UpperLimit1bx.TabIndex = 13;
            // 
            // Stock1Msg
            // 
            this.Stock1Msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Stock1Msg.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stock1Msg.Location = new System.Drawing.Point(33, 120);
            this.Stock1Msg.Name = "Stock1Msg";
            this.Stock1Msg.ReadOnly = true;
            this.Stock1Msg.Size = new System.Drawing.Size(383, 31);
            this.Stock1Msg.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(223, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 32);
            this.label10.TabIndex = 11;
            this.label10.Text = "Lower Limit:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(16, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 32);
            this.label9.TabIndex = 10;
            this.label9.Text = "Upper Limit:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(16, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 32);
            this.label8.TabIndex = 9;
            this.label8.Text = "Symbol Name:";
            // 
            // Stock1label
            // 
            this.Stock1label.AutoSize = true;
            this.Stock1label.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stock1label.Location = new System.Drawing.Point(16, -9);
            this.Stock1label.Name = "Stock1label";
            this.Stock1label.Size = new System.Drawing.Size(76, 34);
            this.Stock1label.TabIndex = 2;
            this.Stock1label.Text = "Stock 1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Symbol2bx);
            this.panel2.Controls.Add(this.LowerLimit2bx);
            this.panel2.Controls.Add(this.UpperLimit2bx);
            this.panel2.Controls.Add(this.Stock2Msg);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.Stock2label);
            this.panel2.Location = new System.Drawing.Point(524, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(462, 169);
            this.panel2.TabIndex = 16;
            this.panel2.Visible = false;
            // 
            // Symbol2bx
            // 
            this.Symbol2bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Symbol2bx.Font = new System.Drawing.Font("Dubai", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Symbol2bx.Location = new System.Drawing.Point(149, 43);
            this.Symbol2bx.Name = "Symbol2bx";
            this.Symbol2bx.ReadOnly = true;
            this.Symbol2bx.Size = new System.Drawing.Size(241, 29);
            this.Symbol2bx.TabIndex = 15;
            // 
            // LowerLimit2bx
            // 
            this.LowerLimit2bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LowerLimit2bx.Location = new System.Drawing.Point(341, 75);
            this.LowerLimit2bx.Name = "LowerLimit2bx";
            this.LowerLimit2bx.ReadOnly = true;
            this.LowerLimit2bx.Size = new System.Drawing.Size(108, 20);
            this.LowerLimit2bx.TabIndex = 14;
            // 
            // UpperLimit2bx
            // 
            this.UpperLimit2bx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UpperLimit2bx.Location = new System.Drawing.Point(134, 75);
            this.UpperLimit2bx.Name = "UpperLimit2bx";
            this.UpperLimit2bx.ReadOnly = true;
            this.UpperLimit2bx.Size = new System.Drawing.Size(82, 20);
            this.UpperLimit2bx.TabIndex = 13;
            // 
            // Stock2Msg
            // 
            this.Stock2Msg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Stock2Msg.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stock2Msg.Location = new System.Drawing.Point(33, 120);
            this.Stock2Msg.Name = "Stock2Msg";
            this.Stock2Msg.ReadOnly = true;
            this.Stock2Msg.Size = new System.Drawing.Size(383, 31);
            this.Stock2Msg.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(223, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 32);
            this.label11.TabIndex = 11;
            this.label11.Text = "Lower Limit:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(16, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(112, 32);
            this.label12.TabIndex = 10;
            this.label12.Text = "Upper Limit:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Dubai", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(16, 39);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 32);
            this.label13.TabIndex = 9;
            this.label13.Text = "Symbol Name:";
            // 
            // Stock2label
            // 
            this.Stock2label.AutoSize = true;
            this.Stock2label.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Stock2label.Location = new System.Drawing.Point(16, -9);
            this.Stock2label.Name = "Stock2label";
            this.Stock2label.Size = new System.Drawing.Size(76, 34);
            this.Stock2label.TabIndex = 2;
            this.Stock2label.Text = "Stock 2";
            // 
            // WorkerServiceIcon
            // 
            this.WorkerServiceIcon.Text = "WorkerService";
            this.WorkerServiceIcon.Visible = true;
            // 
            // StockPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 737);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InputContainer);
            this.Name = "StockPage";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputContainer.Panel1.ResumeLayout(false);
            this.InputContainer.Panel1.PerformLayout();
            this.InputContainer.Panel2.ResumeLayout(false);
            this.InputContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InputContainer)).EndInit();
            this.InputContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditLLimitbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditHLimitbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewLLimitbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewHLimitbx)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer InputContainer;
        private Label label1;
        private Label label2;
        private Label StockPageMsg;
        private Button NewStockcreateBtn;
        private Label Llimitstocklabel;
        private ComboBox SymbolDdown;
        private Label Symbolselectlabel;
        private Button EditUpdatebtn;
        private Label label7;
        private Label label3;
        private Label UpdataMsgbx;
        private Label label5;
        private Button EditDeletebtn;
        private Panel panel1;
        private Label Stock1label;
        private TextBox Symbol1bx;
        private TextBox LowerLimit1bx;
        private TextBox UpperLimit1bx;
        private TextBox Stock1Msg;
        private Label label10;
        private Label label9;
        private Label label8;
        private Panel panel2;
        private TextBox Symbol2bx;
        private TextBox LowerLimit2bx;
        private TextBox UpperLimit2bx;
        private TextBox Stock2Msg;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label Stock2label;
        private NumericUpDown EditLLimitbx;
        private NumericUpDown EditHLimitbx;
        private NumericUpDown NewLLimitbx;
        private NumericUpDown NewHLimitbx;
        private TextBox EditSymbolbx;
        private Label label4;
        private NotifyIcon WorkerServiceIcon;
    }
}