using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolService _stockSymbolService;
        private IStockAlertRangeService _stockAlertRangeService;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        private readonly ILogger _logger;
        private BindingSource? bindingSource = new BindingSource();
        private BindingSource? comboBindingSource = new BindingSource();
        private string originalStockSymbolName;
        private bool unsavedChanges = false;

        public StockPage(IStockAlertRangeDisplayService stockAlertRangeDisplayService, IStockSymbolService stockSymbolService, IStockAlertRangeService stockAlertRangeService, ILogger<StockPage> logger)
        {
            InitializeComponent();
            _stockAlertRangeService = stockAlertRangeService;
            _stockSymbolService = stockSymbolService;
            _stockAlertRangeDisplayService = stockAlertRangeDisplayService;
            _logger = logger;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            dataGridViewAlertRange.CellContentClick += dataGridViewAlertRange_CellContentClick;
            dataGridViewAlertRange.CellBeginEdit += dataGridViewAlertRange_CellBeginEdit;
            dataGridViewAlertRange.CellValidating += dataGridViewAlertRange_CellValidating;
            dataGridViewAlertRange.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridViewAlertRange.RowValidating += dataGridView1_RowValidating;
            //dataGridViewAlertRange.DataError += dataGridViewAlertRange_DataError;

            await _stockSymbolService.AddSymbol();
            await DataGrid_Load();
        }

        //private void dataGridViewAlertRange_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private async void dataGridViewAlertRange_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAlertRange.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete stock alert?", "Stock Alert Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var delStockAlertDisplay = dataGridViewAlertRange.Rows[e.RowIndex].DataBoundItem as StockAlertRangeDisplay;
                    StockAlertRange? delStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(delStockAlertDisplay.SymbolName);

                    if (delStockAlert != null)
                    {
                        await _stockAlertRangeService.DeleteStockAlertRangeAsync(delStockAlert);
                        await DataGrid_Load();
                        MessageBox.Show($"{delStockAlert.StockSymbol.SymbolName} stock range deleted", "Stock Alert Delete", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
                    }

                }
            }
        }

        private void dataGridViewAlertRange_CellBeginEdit(object? sender, DataGridViewCellCancelEventArgs e)
        {
            if (dataGridViewAlertRange.Columns[e.ColumnIndex].Name == "StockSymbolName" && e.RowIndex != dataGridViewAlertRange.NewRowIndex)
            {
                e.Cancel = true;
            }
        }

        private void dataGridViewAlertRange_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                if (!decimal.TryParse(e.FormattedValue.ToString(), out var newInteger))
                {
                    dataGridViewAlertRange.Rows[e.RowIndex].ErrorText = "Please enter a positive integer value";
                    e.Cancel = true;
                }

                var upperLimit = e.ColumnIndex == 1 ? Convert.ToDecimal(e.FormattedValue) : Convert.ToDecimal(dataGridViewAlertRange.Rows[e.RowIndex].Cells[1].Value);
                var lowerLimit = e.ColumnIndex == 2 ? Convert.ToDecimal(e.FormattedValue) : Convert.ToDecimal(dataGridViewAlertRange.Rows[e.RowIndex].Cells[2].Value);

                if (upperLimit < lowerLimit)
                {
                    MessageBox.Show($"UpperLimit should be greater than LowerLimit, Either fix the {dataGridViewAlertRange.Columns[e.ColumnIndex].Name} value or press Esc to undo.", "Stock Alert Range Values", MessageBoxButtons.OK);
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Set the flag indicating that there are unsaved changes
            unsavedChanges = true;
        }

        private async void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Check for unsaved changes before moving to the next row
            if (unsavedChanges)
            {
                // Prompt the user to save changes
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save them?", "Unsaved Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                DataGridViewRow row = dataGridViewAlertRange.CurrentRow;
                var newUpperLimit = Convert.ToInt32(row.Cells["UpperLimit"]?.Value);
                var newLowerLimit = Convert.ToInt32(row.Cells["LowerLimit"]?.Value);

                if (result == DialogResult.Yes)
                {
                    if (row.Index == dataGridViewAlertRange.NewRowIndex)
                    {
                        if (row.Cells["StockSymbolName"]?.Value == null)
                        {
                            MessageBox.Show("Please select StockSymbol", "New Stock", MessageBoxButtons.OK);
                        }
                        else
                        {
                            //Create
                            if (newUpperLimit > newLowerLimit)
                            {
                                var newStockAlertRange = new StockAlertRange
                                {
                                    StockSymbolId = (int)row.Cells["StockSymbolName"].Value,
                                    UpperLimit = newUpperLimit,
                                    LowerLimit = newLowerLimit
                                };
                                await _stockAlertRangeService.AddStockAlertRangeAsync(newStockAlertRange);

                            }
                        }
                    }
                    else
                    {
                        var editStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(originalStockSymbolName);
                        if (editStockAlert == null)
                        {
                            // Show alert
                        }
                        else
                        {
                            //Update
                            if (newUpperLimit > newLowerLimit)
                            {
                                if (originalStockSymbolName == row.Cells["StockSymbolName"].Value.ToString())
                                {
                                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update stock alert?", "Stock Alert Update", MessageBoxButtons.YesNo);
                                    if (dialogResult == DialogResult.Yes)
                                    {
                                        editStockAlert.LowerLimit = newLowerLimit;
                                        editStockAlert.UpperLimit = newUpperLimit;
                                        await _stockAlertRangeService.UpdateStockAlertRangeAsync(editStockAlert);
                                        await DataGrid_Load();

                                    }
                                    else
                                    {
                                        await DataGrid_Load();
                                        _logger.LogInformation("Update cancelled. Hence Update failed.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Cannot Edit Stock Alert Range Symbol", "Stock Alert Range Values", MessageBoxButtons.OK);
                                    await DataGrid_Load();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please enter proper UpperLimit value and LowerLimit values (UpperLimit>LowerLimit)", "Stock Alert Range Values", MessageBoxButtons.OK);
                                await DataGrid_Load();
                            }
                        }
                    }

                    // Reset the flag
                    unsavedChanges = false;
                }
                else if (result == DialogResult.No)
                {
                    // If the user selects 'No', continue without saving
                    dataGridViewAlertRange.CancelEdit();

                    // Reset the flag
                    unsavedChanges = false;
                }
                else
                {
                    // Cancel the row validation to prevent moving to the next row
                    e.Cancel = true;
                }

            }
        }

        private async Task DataGrid_Load()
        {
            await BindSymbolCombo();
            await BindDataGridView();
        }

        private async Task BindDataGridView()
        {
            dataGridViewAlertRange.AutoGenerateColumns = false;
            dataGridViewAlertRange.DataSource = bindingSource;
            bindingSource.DataSource = await GetStockDisplays();
        }

        private async Task BindSymbolCombo()
        {
            var comboBox = (DataGridViewComboBoxColumn)dataGridViewAlertRange.Columns["StockSymbolName"];
            comboBox.DataSource = await FilterStockSymbol();
            comboBox.ValueMember = "Id";
            comboBox.DisplayMember = "SymbolName";
            //comboBindingSource.DataSource = await _stockSymbolService.GetSymbolListAsync();
        }
        private async Task<List<StockSymbol>> FilterStockSymbol()
        {
            var symbolList = await _stockSymbolService.GetSymbolListAsync();
            var stockData = await _stockAlertRangeService.GetAllStockAlertRangesAsync();
            var stockSymbolsInAlertRanges = stockData.Select(s => s.StockSymbol).ToList();
            return symbolList.Where(i => !stockSymbolsInAlertRanges.Contains(i)).ToList();
        }

        private async Task<List<StockAlertRangeDisplay>> GetStockDisplays()
        {
            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = await _stockAlertRangeService.GetAllStockAlertRangesAsync();
            foreach (var item in stockData)
            {
                var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRangeAsync(item);
                stockDisplays.Add(stockDisplay);
            }

            return stockDisplays;
        }

        private async void resetBtn_Click(object sender, EventArgs e)
        {
            await DataGrid_Load();
        }

       

        

    }
}