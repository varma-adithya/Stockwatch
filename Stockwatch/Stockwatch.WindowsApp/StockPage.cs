using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;
using System.Windows.Forms;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolService _stockSymbolService;
        private IStockAlertRangeService _stockAlertRangeService;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        private readonly ILogger _logger;
        private BindingSource? bindingSource = new BindingSource();
        private string originalStockSymbolName;

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
            await DataGrid_Load();
        }

        private async Task DataGrid_Load()
        {
            dataGridViewAlertRange.AutoGenerateColumns = false;

            await _stockSymbolService.AddSymbol();
            var comboBox = (DataGridViewComboBoxColumn)dataGridViewAlertRange.Columns["StockSymbolName"];
            comboBox.DataSource = await _stockSymbolService.GetSymbolListAsync();

            dataGridViewAlertRange.DataSource = bindingSource;

            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = await _stockAlertRangeService.GetAllStockAlertRangesAsync();
            foreach (var item in stockData)
            {
                var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRangeAsync(item);
                stockDisplays.Add(stockDisplay);
            }

            bindingSource.DataSource = stockDisplays;
        }

        private void dataGridViewAlertRange_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 )
            {
                originalStockSymbolName = dataGridViewAlertRange["StockSymbolName", e.RowIndex].Value?.ToString();
            }
        }

        private async void resetBtn_Click(object sender, EventArgs e)
        {
            await DataGrid_Load();
        }

        private async void dataGridViewAlertRange_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAlertRange.Columns[e.ColumnIndex].Name == "Delete")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete stock alert?", "Stock Alert Delete", MessageBoxButtons.YesNo);

                if (dialogResult == DialogResult.Yes)
                {
                    var delStockAlertDisplay = dataGridViewAlertRange.Rows[e.RowIndex].DataBoundItem as StockAlertRangeDisplay;
                    StockAlertRange? delStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(delStockAlertDisplay.StockSymbolName);

                    if (delStockAlert != null)
                    {
                        await _stockAlertRangeService.DeleteStockAlertRangeAsync(delStockAlert);
                        await DataGrid_Load();
                        _logger.LogInformation($"{delStockAlert.StockSymbol.SymbolName} stock range deleted");
                        MessageBox.Show($"{delStockAlert.StockSymbol.SymbolName} stock range deleted", "Stock Alert Delete", MessageBoxButtons.OK);
                    }
                    else
                    {
                        _logger.LogInformation($"{delStockAlertDisplay.StockSymbolName} not found in database.");
                        MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    _logger.LogInformation("Delete dialog box confirmation rejected. Hence Delete failed.");
                }

            }

            await DataGrid_Load();
        }

        private async void dataGridViewAlertRange_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAlertRange.CurrentRow != null)
            {
                DataGridViewRow row = dataGridViewAlertRange.CurrentRow;
                if (row.Cells["StockSymbolName"]?.Value == null)
                {
                    MessageBox.Show("Please select StockSymbol", "New Stock", MessageBoxButtons.OK);
                }
                else
                {
                    var newUpperLimit = Convert.ToInt32(row.Cells["UpperLimit"]?.Value);
                    var newLowerLimit = Convert.ToInt32(row.Cells["LowerLimit"]?.Value);
                    var editStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(originalStockSymbolName);
                    if (editStockAlert == null)
                    {//Create
                        if (newUpperLimit > newLowerLimit)
                        {
                            var newStockAlertRange = new StockAlertRange
                            {
                                StockSymbolId = (await _stockSymbolService.FetchStockSymbolByNameAsync(row.Cells["StockSymbolName"].Value.ToString())).Id,
                                UpperLimit = newUpperLimit,
                                LowerLimit = newLowerLimit
                            };
                            await _stockAlertRangeService.AddStockAlertRangeAsync(newStockAlertRange);
                            await DataGrid_Load();
                        }
                    }
                    else
                    {//Update
                        if(newUpperLimit > newLowerLimit)
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
            }
        }

        private void dataGridViewAlertRange_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if(dataGridViewAlertRange.Columns[dataGridViewAlertRange.CurrentCell.ColumnIndex].Name == "UpperLimit")
            {
                e.Control.KeyPress -= AllowNumbersOnly;
                e.Control.KeyPress += AllowNumbersOnly;
            }
            if (dataGridViewAlertRange.Columns[dataGridViewAlertRange.CurrentCell.ColumnIndex].Name == "LowerLimit")
            {
                e.Control.KeyPress -= AllowNumbersOnly;
                e.Control.KeyPress += AllowNumbersOnly;
            }
        }

        private void AllowNumbersOnly(Object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}