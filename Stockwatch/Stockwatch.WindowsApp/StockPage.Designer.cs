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
            dataGridViewAlertRange = new DataGridView();
            label11 = new Label();
            panel1 = new Panel();
            lowerLimitNbx = new NumericUpDown();
            upperLimitNbx = new NumericUpDown();
            addBtn = new Button();
            symbolDropDown = new ComboBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            createStockAlert = new Label();
            editBtn = new Button();
            deleteBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlertRange).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lowerLimitNbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)upperLimitNbx).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAlertRange
            // 
            dataGridViewAlertRange.AllowUserToAddRows = false;
            dataGridViewAlertRange.AllowUserToDeleteRows = false;
            dataGridViewAlertRange.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAlertRange.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewAlertRange.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewAlertRange.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewAlertRange.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlertRange.GridColor = SystemColors.ControlLight;
            dataGridViewAlertRange.Location = new Point(35, 27);
            dataGridViewAlertRange.Name = "dataGridViewAlertRange";
            dataGridViewAlertRange.ReadOnly = true;
            dataGridViewAlertRange.RowHeadersWidth = 20;
            dataGridViewAlertRange.RowTemplate.Height = 29;
            dataGridViewAlertRange.Size = new Size(953, 403);
            dataGridViewAlertRange.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(595, 433);
            label11.Name = "label11";
            label11.Size = new Size(298, 29);
            label11.TabIndex = 9;
            label11.Text = "Select the row to Edit/Delete Stock Alert";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(lowerLimitNbx);
            panel1.Controls.Add(upperLimitNbx);
            panel1.Controls.Add(addBtn);
            panel1.Controls.Add(symbolDropDown);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(44, 459);
            panel1.Name = "panel1";
            panel1.Size = new Size(468, 227);
            panel1.TabIndex = 10;
            // 
            // lowerLimitNbx
            // 
            lowerLimitNbx.Location = new Point(147, 118);
            lowerLimitNbx.Name = "lowerLimitNbx";
            lowerLimitNbx.Size = new Size(241, 27);
            lowerLimitNbx.TabIndex = 14;
            // 
            // upperLimitNbx
            // 
            upperLimitNbx.Location = new Point(147, 71);
            upperLimitNbx.Name = "upperLimitNbx";
            upperLimitNbx.Size = new Size(241, 27);
            upperLimitNbx.TabIndex = 13;
            // 
            // addBtn
            // 
            addBtn.Font = new Font("Dubai", 9F, FontStyle.Regular, GraphicsUnit.Point);
            addBtn.Location = new Point(197, 168);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(94, 29);
            addBtn.TabIndex = 6;
            addBtn.Text = "Add";
            addBtn.UseVisualStyleBackColor = true;
            addBtn.Click += AddBtn_Click;
            // 
            // symbolDropDown
            // 
            symbolDropDown.FormattingEnabled = true;
            symbolDropDown.Location = new Point(147, 27);
            symbolDropDown.Name = "symbolDropDown";
            symbolDropDown.Size = new Size(241, 28);
            symbolDropDown.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(29, 119);
            label4.Name = "label4";
            label4.Size = new Size(85, 25);
            label4.TabIndex = 2;
            label4.Text = "Lower Limit";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(29, 72);
            label3.Name = "label3";
            label3.Size = new Size(85, 25);
            label3.TabIndex = 1;
            label3.Text = "Upper Limit";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(29, 29);
            label2.Name = "label2";
            label2.Size = new Size(86, 25);
            label2.TabIndex = 0;
            label2.Text = "Select Stock";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(48, 445);
            label1.Name = "label1";
            label1.Size = new Size(88, 30);
            label1.TabIndex = 11;
            label1.Text = "Add Stock";
            // 
            // createStockAlert
            // 
            createStockAlert.AutoSize = true;
            createStockAlert.Font = new Font("Dubai", 10F, FontStyle.Regular, GraphicsUnit.Point);
            createStockAlert.Location = new Point(75, 700);
            createStockAlert.Name = "createStockAlert";
            createStockAlert.Size = new Size(0, 29);
            createStockAlert.TabIndex = 12;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(595, 482);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(112, 39);
            editBtn.TabIndex = 13;
            editBtn.Text = "Edit";
            editBtn.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            deleteBtn.Location = new Point(781, 482);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(112, 39);
            deleteBtn.TabIndex = 14;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = true;
            // 
            // StockPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1022, 737);
            Controls.Add(deleteBtn);
            Controls.Add(editBtn);
            Controls.Add(createStockAlert);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(label11);
            Controls.Add(dataGridViewAlertRange);
            Name = "StockPage";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlertRange).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lowerLimitNbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)upperLimitNbx).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewAlertRange;
        private Label label11;
        private Panel panel1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private ComboBox symbolDropDown;
        private Button addBtn;
        private Label createStockAlert;
        private NumericUpDown lowerLimitNbx;
        private NumericUpDown upperLimitNbx;
        private Button editBtn;
        private Button deleteBtn;
    }
}