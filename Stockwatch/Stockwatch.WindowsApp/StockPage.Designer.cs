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
            currentPriceStock1Bx = new TextBox();
            label6 = new Label();
            symbol1Bx = new TextBox();
            lowerLimit1Bx = new TextBox();
            upperLimit1Bx = new TextBox();
            stock1Msg = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            stock1Label = new Label();
            panel2 = new Panel();
            currentPriceStock2Bx = new TextBox();
            label14 = new Label();
            symbol2Bx = new TextBox();
            lowerLimit2Bx = new TextBox();
            upperLimit2Bx = new TextBox();
            stock2Msg = new TextBox();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            Stock2label = new Label();
            WorkerServiceIcon = new NotifyIcon(components);
            panel3 = new Panel();
            currentPriceStock3Bx = new TextBox();
            label15 = new Label();
            symbol3Bx = new TextBox();
            lowerLimit3Bx = new TextBox();
            upperLimit3Bx = new TextBox();
            stock3Msg = new TextBox();
            label16 = new Label();
            label17 = new Label();
            label18 = new Label();
            label19 = new Label();
            panel4 = new Panel();
            currentPriceStock4Bx = new TextBox();
            label20 = new Label();
            symbol4Bx = new TextBox();
            lowerLimit4Bx = new TextBox();
            upperLimit4Bx = new TextBox();
            stock4Msg = new TextBox();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
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
            panel3.SuspendLayout();
            panel4.SuspendLayout();
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
            panel1.Controls.Add(currentPriceStock1Bx);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(symbol1Bx);
            panel1.Controls.Add(lowerLimit1Bx);
            panel1.Controls.Add(upperLimit1Bx);
            panel1.Controls.Add(stock1Msg);
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
            // currentPriceStock1Bx
            // 
            currentPriceStock1Bx.BorderStyle = BorderStyle.None;
            currentPriceStock1Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentPriceStock1Bx.Location = new Point(170, 64);
            currentPriceStock1Bx.Name = "currentPriceStock1Bx";
            currentPriceStock1Bx.ReadOnly = true;
            currentPriceStock1Bx.Size = new Size(241, 29);
            currentPriceStock1Bx.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(16, 63);
            label6.Name = "label6";
            label6.Size = new Size(123, 32);
            label6.TabIndex = 16;
            label6.Text = "Current Price:";
            // 
            // symbol1Bx
            // 
            symbol1Bx.BorderStyle = BorderStyle.None;
            symbol1Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            symbol1Bx.Location = new Point(170, 26);
            symbol1Bx.Name = "symbol1Bx";
            symbol1Bx.ReadOnly = true;
            symbol1Bx.Size = new Size(241, 29);
            symbol1Bx.TabIndex = 15;
            // 
            // lowerLimit1Bx
            // 
            lowerLimit1Bx.BorderStyle = BorderStyle.None;
            lowerLimit1Bx.Location = new Point(341, 104);
            lowerLimit1Bx.Name = "lowerLimit1Bx";
            lowerLimit1Bx.ReadOnly = true;
            lowerLimit1Bx.Size = new Size(108, 20);
            lowerLimit1Bx.TabIndex = 14;
            // 
            // upperLimit1Bx
            // 
            upperLimit1Bx.BorderStyle = BorderStyle.None;
            upperLimit1Bx.Location = new Point(134, 104);
            upperLimit1Bx.Name = "upperLimit1Bx";
            upperLimit1Bx.ReadOnly = true;
            upperLimit1Bx.Size = new Size(82, 20);
            upperLimit1Bx.TabIndex = 13;
            // 
            // stock1Msg
            // 
            stock1Msg.BorderStyle = BorderStyle.None;
            stock1Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stock1Msg.Location = new Point(28, 138);
            stock1Msg.Name = "stock1Msg";
            stock1Msg.ReadOnly = true;
            stock1Msg.Size = new Size(383, 31);
            stock1Msg.TabIndex = 12;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(223, 100);
            label10.Name = "label10";
            label10.Size = new Size(112, 32);
            label10.TabIndex = 11;
            label10.Text = "Lower Limit:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(16, 100);
            label9.Name = "label9";
            label9.Size = new Size(112, 32);
            label9.TabIndex = 10;
            label9.Text = "Upper Limit:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(16, 25);
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
            panel2.Controls.Add(currentPriceStock2Bx);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(symbol2Bx);
            panel2.Controls.Add(lowerLimit2Bx);
            panel2.Controls.Add(upperLimit2Bx);
            panel2.Controls.Add(stock2Msg);
            panel2.Controls.Add(label11);
            panel2.Controls.Add(label12);
            panel2.Controls.Add(label13);
            panel2.Controls.Add(Stock2label);
            panel2.Location = new Point(524, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(462, 169);
            panel2.TabIndex = 16;
            panel2.Visible = false;
            panel2.Click += panel2_Click;
            // 
            // currentPriceStock2Bx
            // 
            currentPriceStock2Bx.BorderStyle = BorderStyle.None;
            currentPriceStock2Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentPriceStock2Bx.Location = new Point(149, 69);
            currentPriceStock2Bx.Name = "currentPriceStock2Bx";
            currentPriceStock2Bx.ReadOnly = true;
            currentPriceStock2Bx.Size = new Size(257, 29);
            currentPriceStock2Bx.TabIndex = 17;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label14.Location = new Point(16, 68);
            label14.Name = "label14";
            label14.Size = new Size(123, 32);
            label14.TabIndex = 16;
            label14.Text = "Current Price:";
            // 
            // symbol2Bx
            // 
            symbol2Bx.BorderStyle = BorderStyle.None;
            symbol2Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            symbol2Bx.Location = new Point(149, 33);
            symbol2Bx.Name = "symbol2Bx";
            symbol2Bx.ReadOnly = true;
            symbol2Bx.Size = new Size(241, 29);
            symbol2Bx.TabIndex = 15;
            // 
            // lowerLimit2Bx
            // 
            lowerLimit2Bx.BorderStyle = BorderStyle.None;
            lowerLimit2Bx.Location = new Point(341, 104);
            lowerLimit2Bx.Name = "lowerLimit2Bx";
            lowerLimit2Bx.ReadOnly = true;
            lowerLimit2Bx.Size = new Size(108, 20);
            lowerLimit2Bx.TabIndex = 14;
            // 
            // upperLimit2Bx
            // 
            upperLimit2Bx.BorderStyle = BorderStyle.None;
            upperLimit2Bx.Location = new Point(134, 104);
            upperLimit2Bx.Name = "upperLimit2Bx";
            upperLimit2Bx.ReadOnly = true;
            upperLimit2Bx.Size = new Size(82, 20);
            upperLimit2Bx.TabIndex = 13;
            // 
            // stock2Msg
            // 
            stock2Msg.BorderStyle = BorderStyle.None;
            stock2Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stock2Msg.Location = new Point(23, 138);
            stock2Msg.Name = "stock2Msg";
            stock2Msg.ReadOnly = true;
            stock2Msg.Size = new Size(383, 31);
            stock2Msg.TabIndex = 12;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(223, 100);
            label11.Name = "label11";
            label11.Size = new Size(112, 32);
            label11.TabIndex = 11;
            label11.Text = "Lower Limit:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label12.Location = new Point(16, 100);
            label12.Name = "label12";
            label12.Size = new Size(112, 32);
            label12.TabIndex = 10;
            label12.Text = "Upper Limit:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label13.Location = new Point(16, 29);
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
            // panel3
            // 
            panel3.Controls.Add(currentPriceStock3Bx);
            panel3.Controls.Add(label15);
            panel3.Controls.Add(symbol3Bx);
            panel3.Controls.Add(lowerLimit3Bx);
            panel3.Controls.Add(upperLimit3Bx);
            panel3.Controls.Add(stock3Msg);
            panel3.Controls.Add(label16);
            panel3.Controls.Add(label17);
            panel3.Controls.Add(label18);
            panel3.Controls.Add(label19);
            panel3.Location = new Point(19, 241);
            panel3.Name = "panel3";
            panel3.Size = new Size(462, 169);
            panel3.TabIndex = 18;
            panel3.Visible = false;
            panel3.Click += panel3_Click;
            // 
            // currentPriceStock3Bx
            // 
            currentPriceStock3Bx.BorderStyle = BorderStyle.None;
            currentPriceStock3Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentPriceStock3Bx.Location = new Point(149, 69);
            currentPriceStock3Bx.Name = "currentPriceStock3Bx";
            currentPriceStock3Bx.ReadOnly = true;
            currentPriceStock3Bx.Size = new Size(257, 29);
            currentPriceStock3Bx.TabIndex = 17;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label15.Location = new Point(16, 68);
            label15.Name = "label15";
            label15.Size = new Size(123, 32);
            label15.TabIndex = 16;
            label15.Text = "Current Price:";
            // 
            // symbol3Bx
            // 
            symbol3Bx.BorderStyle = BorderStyle.None;
            symbol3Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            symbol3Bx.Location = new Point(149, 33);
            symbol3Bx.Name = "symbol3Bx";
            symbol3Bx.ReadOnly = true;
            symbol3Bx.Size = new Size(241, 29);
            symbol3Bx.TabIndex = 15;
            // 
            // lowerLimit3Bx
            // 
            lowerLimit3Bx.BorderStyle = BorderStyle.None;
            lowerLimit3Bx.Location = new Point(341, 104);
            lowerLimit3Bx.Name = "lowerLimit3Bx";
            lowerLimit3Bx.ReadOnly = true;
            lowerLimit3Bx.Size = new Size(108, 20);
            lowerLimit3Bx.TabIndex = 14;
            // 
            // upperLimit3Bx
            // 
            upperLimit3Bx.BorderStyle = BorderStyle.None;
            upperLimit3Bx.Location = new Point(134, 104);
            upperLimit3Bx.Name = "upperLimit3Bx";
            upperLimit3Bx.ReadOnly = true;
            upperLimit3Bx.Size = new Size(82, 20);
            upperLimit3Bx.TabIndex = 13;
            // 
            // stock3Msg
            // 
            stock3Msg.BorderStyle = BorderStyle.None;
            stock3Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stock3Msg.Location = new Point(23, 138);
            stock3Msg.Name = "stock3Msg";
            stock3Msg.ReadOnly = true;
            stock3Msg.Size = new Size(383, 31);
            stock3Msg.TabIndex = 12;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label16.Location = new Point(223, 100);
            label16.Name = "label16";
            label16.Size = new Size(112, 32);
            label16.TabIndex = 11;
            label16.Text = "Lower Limit:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label17.Location = new Point(16, 100);
            label17.Name = "label17";
            label17.Size = new Size(112, 32);
            label17.TabIndex = 10;
            label17.Text = "Upper Limit:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label18.Location = new Point(16, 29);
            label18.Name = "label18";
            label18.Size = new Size(127, 32);
            label18.TabIndex = 9;
            label18.Text = "Symbol Name:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label19.Location = new Point(16, -9);
            label19.Name = "label19";
            label19.Size = new Size(76, 34);
            label19.TabIndex = 2;
            label19.Text = "Stock 3";
            // 
            // panel4
            // 
            panel4.Controls.Add(currentPriceStock4Bx);
            panel4.Controls.Add(label20);
            panel4.Controls.Add(symbol4Bx);
            panel4.Controls.Add(lowerLimit4Bx);
            panel4.Controls.Add(upperLimit4Bx);
            panel4.Controls.Add(stock4Msg);
            panel4.Controls.Add(label21);
            panel4.Controls.Add(label22);
            panel4.Controls.Add(label23);
            panel4.Controls.Add(label24);
            panel4.Location = new Point(524, 241);
            panel4.Name = "panel4";
            panel4.Size = new Size(462, 169);
            panel4.TabIndex = 19;
            panel4.Visible = false;
            panel4.Click += panel4_Click;
            // 
            // currentPriceStock4Bx
            // 
            currentPriceStock4Bx.BorderStyle = BorderStyle.None;
            currentPriceStock4Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentPriceStock4Bx.Location = new Point(149, 69);
            currentPriceStock4Bx.Name = "currentPriceStock4Bx";
            currentPriceStock4Bx.ReadOnly = true;
            currentPriceStock4Bx.Size = new Size(257, 29);
            currentPriceStock4Bx.TabIndex = 17;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label20.Location = new Point(16, 68);
            label20.Name = "label20";
            label20.Size = new Size(123, 32);
            label20.TabIndex = 16;
            label20.Text = "Current Price:";
            // 
            // symbol4Bx
            // 
            symbol4Bx.BorderStyle = BorderStyle.None;
            symbol4Bx.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            symbol4Bx.Location = new Point(149, 33);
            symbol4Bx.Name = "symbol4Bx";
            symbol4Bx.ReadOnly = true;
            symbol4Bx.Size = new Size(241, 29);
            symbol4Bx.TabIndex = 15;
            // 
            // lowerLimit4Bx
            // 
            lowerLimit4Bx.BorderStyle = BorderStyle.None;
            lowerLimit4Bx.Location = new Point(341, 104);
            lowerLimit4Bx.Name = "lowerLimit4Bx";
            lowerLimit4Bx.ReadOnly = true;
            lowerLimit4Bx.Size = new Size(108, 20);
            lowerLimit4Bx.TabIndex = 14;
            // 
            // upperLimit4Bx
            // 
            upperLimit4Bx.BorderStyle = BorderStyle.None;
            upperLimit4Bx.Location = new Point(134, 104);
            upperLimit4Bx.Name = "upperLimit4Bx";
            upperLimit4Bx.ReadOnly = true;
            upperLimit4Bx.Size = new Size(82, 20);
            upperLimit4Bx.TabIndex = 13;
            // 
            // stock4Msg
            // 
            stock4Msg.BorderStyle = BorderStyle.None;
            stock4Msg.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            stock4Msg.Location = new Point(23, 138);
            stock4Msg.Name = "stock4Msg";
            stock4Msg.ReadOnly = true;
            stock4Msg.Size = new Size(383, 31);
            stock4Msg.TabIndex = 12;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label21.Location = new Point(223, 100);
            label21.Name = "label21";
            label21.Size = new Size(112, 32);
            label21.TabIndex = 11;
            label21.Text = "Lower Limit:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label22.Location = new Point(16, 100);
            label22.Name = "label22";
            label22.Size = new Size(112, 32);
            label22.TabIndex = 10;
            label22.Text = "Upper Limit:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Dubai", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label23.Location = new Point(16, 29);
            label23.Name = "label23";
            label23.Size = new Size(127, 32);
            label23.TabIndex = 9;
            label23.Text = "Symbol Name:";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Dubai", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label24.Location = new Point(16, -9);
            label24.Name = "label24";
            label24.Size = new Size(76, 34);
            label24.TabIndex = 2;
            label24.Text = "Stock 4";
            // 
            // StockPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 737);
            Controls.Add(panel4);
            Controls.Add(panel3);
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
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
        private TextBox symbol1Bx;
        private TextBox lowerLimit1Bx;
        private TextBox upperLimit1Bx;
        private TextBox stock1Msg;
        private Label label10;
        private Label label9;
        private Label label8;
        private Panel panel2;
        private TextBox symbol2Bx;
        private TextBox lowerLimit2Bx;
        private TextBox upperLimit2Bx;
        private TextBox stock2Msg;
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
        private TextBox currentPriceStock1Bx;
        private Label label6;
        private TextBox currentPriceStock2Bx;
        private Label label14;
        private Panel panel3;
        private TextBox currentPriceStock3Bx;
        private Label label15;
        private TextBox symbol3Bx;
        private TextBox lowerLimit3Bx;
        private TextBox upperLimit3Bx;
        private TextBox stock3Msg;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Panel panel4;
        private TextBox currentPriceStock4Bx;
        private Label label20;
        private TextBox symbol4Bx;
        private TextBox lowerLimit4Bx;
        private TextBox upperLimit4Bx;
        private TextBox stock4Msg;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
    }
}