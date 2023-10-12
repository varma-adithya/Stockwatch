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
            components = new System.ComponentModel.Container();
            inputContainer = new SplitContainer();
            editSymbolBx = new TextBox();
            label4 = new Label();
            editLowLimitBx = new NumericUpDown();
            editHighLimitBx = new NumericUpDown();
            editUpdateBtn = new Button();
            label7 = new Label();
            label3 = new Label();
            updateMsgBx = new Label();
            label5 = new Label();
            editDeleteBtn = new Button();
            newLowLimitBx = new NumericUpDown();
            newHighLimitBx = new NumericUpDown();
            label2 = new Label();
            stockPageMsg = new Label();
            newStockCreateBtn = new Button();
            Llimitstocklabel = new Label();
            SymbolDown = new ComboBox();
            Symbolselectlabel = new Label();
            label1 = new Label();
            panel1 = new Panel();
            Symbol1bx = new TextBox();
            LowerLimit1bx = new TextBox();
            UpperLimit1bx = new TextBox();
            Stock1Msg = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            stock1Label = new Label();
            panel2 = new Panel();
            Symbol2bx = new TextBox();
            LowerLimit2bx = new TextBox();
            UpperLimit2bx = new TextBox();
            Stock2Msg = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            Stock2label = new Label();
            WorkerServiceIcon = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)inputContainer).BeginInit();
            inputContainer.Panel1.SuspendLayout();
            inputContainer.Panel2.SuspendLayout();
            inputContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)editLowLimitBx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)editHighLimitBx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newLowLimitBx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)newHighLimitBx).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // inputContainer
            // 
            inputContainer.BorderStyle = BorderStyle.Fixed3D;
            inputContainer.Location = new Point(12, 427);
            inputContainer.Name = "inputContainer";
            // 
            // inputContainer.Panel1
            // 
            inputContainer.Panel1.Controls.Add(editSymbolBx);
            inputContainer.Panel1.Controls.Add(label4);
            inputContainer.Panel1.Controls.Add(editLowLimitBx);
            inputContainer.Panel1.Controls.Add(editHighLimitBx);
            inputContainer.Panel1.Controls.Add(editUpdateBtn);
            inputContainer.Panel1.Controls.Add(label7);
            inputContainer.Panel1.Controls.Add(label3);
            inputContainer.Panel1.Controls.Add(updateMsgBx);
            inputContainer.Panel1.Controls.Add(label5);
            inputContainer.Panel1.Controls.Add(editDeleteBtn);
            // 
            // inputContainer.Panel2
            // 
            inputContainer.Panel2.Controls.Add(newLowLimitBx);
            inputContainer.Panel2.Controls.Add(newHighLimitBx);
            inputContainer.Panel2.Controls.Add(label2);
            inputContainer.Panel2.Controls.Add(stockPageMsg);
            inputContainer.Panel2.Controls.Add(newStockCreateBtn);
            inputContainer.Panel2.Controls.Add(Llimitstocklabel);
            inputContainer.Panel2.Controls.Add(SymbolDown);
            inputContainer.Panel2.Controls.Add(Symbolselectlabel);
            inputContainer.Panel2.Controls.Add(label1);
            inputContainer.Size = new Size(998, 298);
            inputContainer.SplitterDistance = 474;
            inputContainer.TabIndex = 0;
            // 
            // editSymbolBx
            // 
            editSymbolBx.BorderStyle = BorderStyle.None;
            editSymbolBx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            editSymbolBx.Location = new Point(175, 98);
            editSymbolBx.Name = "editSymbolBx";
            editSymbolBx.ReadOnly = true;
            editSymbolBx.Size = new Size(241, 29);
            editSymbolBx.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(21, 92);
            label4.Name = "label4";
            label4.Size = new Size(127, 32);
            label4.TabIndex = 21;
            label4.Text = "Symbol Name:";
            // 
            // editLowLimitBx
            // 
            editLowLimitBx.Location = new Point(200, 197);
            editLowLimitBx.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            editLowLimitBx.Name = "editLowLimitBx";
            editLowLimitBx.Size = new Size(216, 27);
            editLowLimitBx.TabIndex = 20;
            // 
            // editHighLimitBx
            // 
            editHighLimitBx.Location = new Point(200, 152);
            editHighLimitBx.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            editHighLimitBx.Name = "editHighLimitBx";
            editHighLimitBx.Size = new Size(216, 27);
            editHighLimitBx.TabIndex = 19;
            // 
            // editUpdateBtn
            // 
            editUpdateBtn.Location = new Point(219, 239);
            editUpdateBtn.Name = "editUpdateBtn";
            editUpdateBtn.Size = new Size(121, 37);
            editUpdateBtn.TabIndex = 18;
            editUpdateBtn.Text = "Update";
            editUpdateBtn.UseVisualStyleBackColor = true;
            editUpdateBtn.Click += EditUpdateBtn_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Dubai", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(21, 29);
            label7.Name = "label7";
            label7.Size = new Size(250, 42);
            label7.TabIndex = 9;
            label7.Text = "Stock Update / Delete";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(21, 192);
            label3.Name = "label3";
            label3.Size = new Size(157, 32);
            label3.TabIndex = 15;
            label3.Text = "Stock Lower Limit";
            // 
            // updateMsgBx
            // 
            updateMsgBx.AutoSize = true;
            updateMsgBx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            updateMsgBx.Location = new Point(21, 244);
            updateMsgBx.Name = "updateMsgBx";
            updateMsgBx.Size = new Size(0, 29);
            updateMsgBx.TabIndex = 13;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(21, 147);
            label5.Name = "label5";
            label5.Size = new Size(157, 32);
            label5.TabIndex = 12;
            label5.Text = "Stock Upper Limit";
            // 
            // editDeleteBtn
            // 
            editDeleteBtn.Location = new Point(346, 239);
            editDeleteBtn.Name = "editDeleteBtn";
            editDeleteBtn.Size = new Size(121, 37);
            editDeleteBtn.TabIndex = 14;
            editDeleteBtn.Text = "Delete";
            editDeleteBtn.UseVisualStyleBackColor = true;
            editDeleteBtn.Click += EditDeleteBtn_Click;
            // 
            // newLowLimitBx
            // 
            newLowLimitBx.Location = new Point(211, 197);
            newLowLimitBx.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            newLowLimitBx.Name = "newLowLimitBx";
            newLowLimitBx.Size = new Size(216, 27);
            newLowLimitBx.TabIndex = 8;
            // 
            // newHighLimitBx
            // 
            newHighLimitBx.Location = new Point(211, 152);
            newHighLimitBx.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            newHighLimitBx.Name = "newHighLimitBx";
            newHighLimitBx.Size = new Size(216, 27);
            newHighLimitBx.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(32, 192);
            label2.Name = "label2";
            label2.Size = new Size(157, 32);
            label2.TabIndex = 6;
            label2.Text = "Stock Lower Limit";
            // 
            // stockPageMsg
            // 
            stockPageMsg.AutoSize = true;
            stockPageMsg.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            stockPageMsg.Location = new Point(32, 247);
            stockPageMsg.Name = "stockPageMsg";
            stockPageMsg.Size = new Size(117, 29);
            stockPageMsg.TabIndex = 4;
            stockPageMsg.Text = "*Upto 4 stocks";
            // 
            // newStockCreateBtn
            // 
            newStockCreateBtn.Location = new Point(306, 242);
            newStockCreateBtn.Name = "newStockCreateBtn";
            newStockCreateBtn.Size = new Size(121, 37);
            newStockCreateBtn.TabIndex = 5;
            newStockCreateBtn.Text = "Create";
            newStockCreateBtn.UseVisualStyleBackColor = true;
            newStockCreateBtn.Click += NewStockCreateBtn_Click;
            // 
            // Llimitstocklabel
            // 
            Llimitstocklabel.AutoSize = true;
            Llimitstocklabel.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Llimitstocklabel.Location = new Point(32, 147);
            Llimitstocklabel.Name = "Llimitstocklabel";
            Llimitstocklabel.Size = new Size(157, 32);
            Llimitstocklabel.TabIndex = 3;
            Llimitstocklabel.Text = "Stock Upper Limit";
            // 
            // SymbolDown
            // 
            SymbolDown.DisplayMember = "Select";
            SymbolDown.DropDownStyle = ComboBoxStyle.DropDownList;
            SymbolDown.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            SymbolDown.FormattingEnabled = true;
            SymbolDown.Location = new Point(211, 89);
            SymbolDown.Name = "SymbolDown";
            SymbolDown.Size = new Size(216, 38);
            SymbolDown.TabIndex = 2;
            SymbolDown.ValueMember = "Select";
            // 
            // Symbolselectlabel
            // 
            Symbolselectlabel.AutoSize = true;
            Symbolselectlabel.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Symbolselectlabel.Location = new Point(32, 92);
            Symbolselectlabel.Name = "Symbolselectlabel";
            Symbolselectlabel.Size = new Size(124, 32);
            Symbolselectlabel.TabIndex = 1;
            Symbolselectlabel.Text = "Select Symbol";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(32, 29);
            label1.Name = "label1";
            label1.Size = new Size(196, 42);
            label1.TabIndex = 0;
            label1.Text = "Brand New Stock";
            // 
            // panel1
            // 
            panel1.Controls.Add(Symbol1bx);
            panel1.Controls.Add(LowerLimit1bx);
            panel1.Controls.Add(UpperLimit1bx);
            panel1.Controls.Add(Stock1Msg);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(stock1Label);
            panel1.Location = new Point(19, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(462, 169);
            panel1.TabIndex = 1;
            panel1.Visible = false;
            panel1.Click += panel1_Click;
            // 
            // Symbol1bx
            // 
            Symbol1bx.BorderStyle = BorderStyle.None;
            Symbol1bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Symbol1bx.Location = new Point(149, 43);
            Symbol1bx.Name = "Symbol1bx";
            Symbol1bx.ReadOnly = true;
            Symbol1bx.Size = new Size(241, 29);
            Symbol1bx.TabIndex = 15;
            // 
            // LowerLimit1bx
            // 
            LowerLimit1bx.BorderStyle = BorderStyle.None;
            LowerLimit1bx.Location = new Point(341, 75);
            LowerLimit1bx.Name = "LowerLimit1bx";
            LowerLimit1bx.ReadOnly = true;
            LowerLimit1bx.Size = new Size(108, 20);
            LowerLimit1bx.TabIndex = 14;
            // 
            // UpperLimit1bx
            // 
            UpperLimit1bx.BorderStyle = BorderStyle.None;
            UpperLimit1bx.Location = new Point(134, 75);
            UpperLimit1bx.Name = "UpperLimit1bx";
            UpperLimit1bx.ReadOnly = true;
            UpperLimit1bx.Size = new Size(82, 20);
            UpperLimit1bx.TabIndex = 13;
            // 
            // Stock1Msg
            // 
            Stock1Msg.BorderStyle = BorderStyle.None;
            Stock1Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Stock1Msg.Location = new Point(33, 120);
            Stock1Msg.Name = "Stock1Msg";
            Stock1Msg.ReadOnly = true;
            Stock1Msg.Size = new Size(383, 31);
            Stock1Msg.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(223, 71);
            label10.Name = "label10";
            label10.Size = new Size(112, 32);
            label10.TabIndex = 11;
            label10.Text = "Lower Limit:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(16, 71);
            label9.Name = "label9";
            label9.Size = new Size(112, 32);
            label9.TabIndex = 10;
            label9.Text = "Upper Limit:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(16, 39);
            label8.Name = "label8";
            label8.Size = new Size(127, 32);
            label8.TabIndex = 9;
            label8.Text = "Symbol Name:";
            // 
            // stock1Label
            // 
            stock1Label.AutoSize = true;
            stock1Label.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            stock1Label.Location = new Point(16, -9);
            stock1Label.Name = "stock1Label";
            stock1Label.Size = new Size(76, 34);
            stock1Label.TabIndex = 2;
            stock1Label.Text = "Stock 1";
            // 
            // panel2
            // 
            panel2.Controls.Add(Symbol2bx);
            panel2.Controls.Add(LowerLimit2bx);
            panel2.Controls.Add(UpperLimit2bx);
            panel2.Controls.Add(Stock2Msg);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(Stock2label);
            panel2.Location = new Point(524, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 169);
            panel2.TabIndex = 16;
            panel2.Visible = false;
            // 
            // Symbol2bx
            // 
            Symbol2bx.BorderStyle = BorderStyle.None;
            Symbol2bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            Symbol2bx.Location = new Point(149, 43);
            Symbol2bx.Name = "Symbol2bx";
            Symbol2bx.ReadOnly = true;
            Symbol2bx.Size = new Size(241, 29);
            Symbol2bx.TabIndex = 15;
            // 
            // LowerLimit2bx
            // 
            LowerLimit2bx.BorderStyle = BorderStyle.None;
            LowerLimit2bx.Location = new Point(341, 75);
            LowerLimit2bx.Name = "LowerLimit2bx";
            LowerLimit2bx.ReadOnly = true;
            LowerLimit2bx.Size = new Size(108, 20);
            LowerLimit2bx.TabIndex = 14;
            // 
            // UpperLimit2bx
            // 
            UpperLimit2bx.BorderStyle = BorderStyle.None;
            UpperLimit2bx.Location = new Point(134, 75);
            UpperLimit2bx.Name = "UpperLimit2bx";
            UpperLimit2bx.ReadOnly = true;
            UpperLimit2bx.Size = new Size(82, 20);
            UpperLimit2bx.TabIndex = 13;
            // 
            // Stock2Msg
            // 
            Stock2Msg.BorderStyle = BorderStyle.None;
            Stock2Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            Stock2Msg.Location = new Point(33, 120);
            Stock2Msg.Name = "Stock2Msg";
            Stock2Msg.ReadOnly = true;
            Stock2Msg.Size = new Size(383, 31);
            Stock2Msg.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(223, 71);
            label11.Name = "label11";
            label11.Size = new Size(112, 32);
            label11.TabIndex = 11;
            label11.Text = "Lower Limit:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(16, 71);
            label12.Name = "label12";
            label12.Size = new Size(112, 32);
            label12.TabIndex = 10;
            label12.Text = "Upper Limit:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(16, 39);
            label13.Name = "label13";
            label13.Size = new Size(127, 32);
            label13.TabIndex = 9;
            label13.Text = "Symbol Name:";
            // 
            // Stock2label
            // 
            Stock2label.AutoSize = true;
            Stock2label.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Stock2label.Location = new Point(16, -9);
            Stock2label.Name = "Stock2label";
            Stock2label.Size = new Size(76, 34);
            Stock2label.TabIndex = 2;
            Stock2label.Text = "Stock 2";
            // 
            // WorkerServiceIcon
            // 
            WorkerServiceIcon.Text = "WorkerService";
            WorkerServiceIcon.Visible = true;
            // 
            // StockPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 737);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(inputContainer);
            Name = "StockPage";
            Text = "Form1";
            Load += Form1_Load;
            inputContainer.Panel1.ResumeLayout(false);
            inputContainer.Panel1.PerformLayout();
            inputContainer.Panel2.ResumeLayout(false);
            inputContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)inputContainer).EndInit();
            inputContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)editLowLimitBx).EndInit();
            ((System.ComponentModel.ISupportInitialize)editHighLimitBx).EndInit();
            ((System.ComponentModel.ISupportInitialize)newLowLimitBx).EndInit();
            ((System.ComponentModel.ISupportInitialize)newHighLimitBx).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer inputContainer;
        private Label label1;
        private Label label2;
        private Label stockPageMsg;
        private Button newStockCreateBtn;
        private Label Llimitstocklabel;
        private ComboBox SymbolDown;
        private Label Symbolselectlabel;
        private Button editUpdateBtn;
        private Label label7;
        private Label label3;
        private Label updateMsgBx;
        private Label label5;
        private Button editDeleteBtn;
        private Panel panel1;
        private Label stock1Label;
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
        private NumericUpDown editLowLimitBx;
        private NumericUpDown editHighLimitBx;
        private NumericUpDown newLowLimitBx;
        private NumericUpDown newHighLimitBx;
        private TextBox editSymbolBx;
        private Label label4;
        private NotifyIcon WorkerServiceIcon;
    }
}