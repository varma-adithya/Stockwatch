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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dataGridViewAlertRange = new DataGridView();
            label11 = new Label();
            resetBtn = new Button();
            StockSymbolName = new DataGridViewComboBoxColumn();
            UpperLimit = new DataGridViewTextBoxColumn();
            LowerLimit = new DataGridViewTextBoxColumn();
            CurrentPrice = new DataGridViewTextBoxColumn();
            Comments = new DataGridViewTextBoxColumn();
            Delete = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlertRange).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewAlertRange
            // 
            dataGridViewAlertRange.AllowUserToResizeColumns = false;
            dataGridViewAlertRange.AllowUserToResizeRows = false;
            dataGridViewAlertRange.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewAlertRange.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewAlertRange.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dataGridViewAlertRange.BackgroundColor = SystemColors.ActiveCaption;
            dataGridViewAlertRange.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewAlertRange.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridViewAlertRange.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAlertRange.Columns.AddRange(new DataGridViewColumn[] { StockSymbolName, UpperLimit, LowerLimit, CurrentPrice, Comments, Delete });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewAlertRange.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewAlertRange.GridColor = Color.SteelBlue;
            dataGridViewAlertRange.Location = new Point(35, 27);
            dataGridViewAlertRange.MultiSelect = false;
            dataGridViewAlertRange.Name = "dataGridViewAlertRange";
            dataGridViewAlertRange.RowHeadersWidth = 20;
            dataGridViewAlertRange.RowTemplate.Height = 29;
            dataGridViewAlertRange.Size = new Size(955, 639);
            dataGridViewAlertRange.TabIndex = 2;
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label11.Location = new Point(373, 685);
            label11.Name = "label11";
            label11.Size = new Size(299, 20);
            label11.TabIndex = 9;
            label11.Text = "Type / Choose a value and press Enter";
            label11.TextAlign = ContentAlignment.BottomCenter;
            // 
            // resetBtn
            // 
            resetBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            resetBtn.Location = new Point(878, 680);
            resetBtn.Name = "resetBtn";
            resetBtn.Size = new Size(112, 39);
            resetBtn.TabIndex = 15;
            resetBtn.Text = "Refresh";
            resetBtn.UseVisualStyleBackColor = true;
            resetBtn.Click += resetBtn_Click;
            // 
            // StockSymbolName
            // 
            StockSymbolName.HeaderText = "StockSymbolName";
            StockSymbolName.MinimumWidth = 6;
            StockSymbolName.Name = "StockSymbolName";
            // 
            // UpperLimit
            // 
            UpperLimit.DataPropertyName = "UpperLimit";
            UpperLimit.HeaderText = "UpperLimit";
            UpperLimit.MinimumWidth = 6;
            UpperLimit.Name = "UpperLimit";
            // 
            // LowerLimit
            // 
            LowerLimit.DataPropertyName = "LowerLimit";
            LowerLimit.HeaderText = "LowerLimit";
            LowerLimit.MinimumWidth = 6;
            LowerLimit.Name = "LowerLimit";
            // 
            // CurrentPrice
            // 
            CurrentPrice.DataPropertyName = "CurrentPrice";
            CurrentPrice.HeaderText = "CurrentPrice";
            CurrentPrice.MinimumWidth = 6;
            CurrentPrice.Name = "CurrentPrice";
            CurrentPrice.ReadOnly = true;
            // 
            // Comments
            // 
            Comments.DataPropertyName = "Comments";
            Comments.HeaderText = "Comments";
            Comments.MinimumWidth = 6;
            Comments.Name = "Comments";
            Comments.ReadOnly = true;
            // 
            // Delete
            // 
            Delete.HeaderText = "Delete";
            Delete.MinimumWidth = 6;
            Delete.Name = "Delete";
            Delete.Text = "Del this Row";
            // 
            // StockPage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.InactiveCaption;
            ClientSize = new Size(1029, 737);
            Controls.Add(resetBtn);
            Controls.Add(label11);
            Controls.Add(dataGridViewAlertRange);
            Name = "StockPage";
            Text = "Stock Watch";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewAlertRange).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dataGridViewAlertRange;
        private Label label11;
        private Button resetBtn;
        private DataGridViewComboBoxColumn StockSymbolName;
        private DataGridViewTextBoxColumn UpperLimit;
        private DataGridViewTextBoxColumn LowerLimit;
        private DataGridViewTextBoxColumn CurrentPrice;
        private DataGridViewTextBoxColumn Comments;
        private DataGridViewButtonColumn Delete;
    }
}