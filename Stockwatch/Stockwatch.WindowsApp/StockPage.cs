using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockAlertRangeService _dataService;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        private readonly ILogger _logger;
        DataGridViewRow? selectedRow = null;
        public StockPage(IStockAlertRangeDisplayService stockAlertRangeDisplayService, IStockSymbolPage stockSymbolPage, IStockAlertRangeService dataservice, ILogger<StockPage> logger)
        {
            InitializeComponent();
            _dataService = dataservice;
            _stockSymbolPage = stockSymbolPage;
            _stockAlertRangeDisplayService = stockAlertRangeDisplayService;
            _logger = logger;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _stockSymbolPage.AddSymbol();
            symbolDropDown.DataSource = _stockSymbolPage.GetSymbolList();
            this.dataGridViewAlertRange.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            DataGrid_Load();
        }

        private async Task DataGrid_Load()
        {
            selectedRow = null;
            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = await _dataService.GetAllAsync();
            if(stockData != null)
            {
                foreach (var item in stockData)
                {
                    //Null ref exception
                    var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRange(item);
                    stockDisplays.Add(stockDisplay);
                }
                dataGridViewAlertRange.DataSource = stockDisplays;
            }
            else
            {
                _logger.LogInformation("No stock alert ranges saved in database.");
                MessageBox.Show("No stock alert ranges saved. Please add new Stock ranges", "Stock Alert Range", MessageBoxButtons.OK);
                dataGridViewAlertRange.DataSource = null;
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (upperLimitNbx.Value < lowerLimitNbx.Value)
            {
                MessageBox.Show("Lower limit value greater than upper limit value", "New Stock", MessageBoxButtons.OK);
            }
            else if (_dataService.FetchStockAlertRangeByNameAsync(symbolDropDown.Text) != null)
            {
                MessageBox.Show("Stock alert already exists for this stock symbol", "New Stock", MessageBoxButtons.OK);
            }
            else
            {
                var newStock = new StockAlertRange
                {
                    StockSymbolId = _stockSymbolPage.FetchStockSymbolByNameAsync(symbolDropDown.Text).Id,
                    LowerLimit = lowerLimitNbx.Value,
                    UpperLimit = upperLimitNbx.Value,
                };
                _dataService.AddStockAlertRangeAsync(newStock);
                DataGrid_Load();
                MessageBox.Show("New stock range created!", "New Stock", MessageBoxButtons.OK);

            }
        }

        private async void editBtn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int newUpperLimit = Convert.ToInt32(selectedRow.Cells[0].Value);
                int newLowerLimit = Convert.ToInt32(selectedRow.Cells[1].Value);
                StockAlertRange? editStockAlert = _dataService.FetchStockAlertRangeByNameAsync(selectedRow.Cells[2].Value.ToString()).Result;
                if (editStockAlert != null && (editStockAlert.UpperLimit != newUpperLimit || editStockAlert.LowerLimit != newLowerLimit))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update stock alert?", "Stock Alert Update", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        editStockAlert.LowerLimit = newLowerLimit;
                        editStockAlert.UpperLimit = newUpperLimit;
                        await _dataService.UpdateStockAlertRangeAsync(editStockAlert);                        
                        await DataGrid_Load();
                        MessageBox.Show("Stock range updated!", "Stock Alert Update", MessageBoxButtons.OK);
                    }
                    else
                    {
                        _logger.LogInformation("Update dialog box confirmation rejected. Hence Update failed.");
                    }
                }
                else if(editStockAlert != null)
                {
                    selectedRow = null;
                    _logger.LogInformation("No change made on selected stock range for update.");
                    MessageBox.Show("No change made on selected stock range", "Stock Alert Update", MessageBoxButtons.OK);

                }
                else
                {
                    _logger.LogInformation($"{selectedRow.Cells[2].Value.ToString()} not found in database.");
                    MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
                }
            }
            else
            {
                _logger.LogInformation("No stock range selected for update.");
                MessageBox.Show("No stock range selected", "Stock Alert Update", MessageBoxButtons.OK);
            }
        }

        private void dataGridViewAlertRange_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            selectedRow = dataGridViewAlertRange.Rows[index];
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete stock alert?", "Stock Alert Delete", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    StockAlertRange? delStockAlert = _dataService.FetchStockAlertRangeByNameAsync(selectedRow.Cells[2].Value.ToString()).Result;
                    if (delStockAlert != null) 
                    {
                        _dataService.DeleteStockAlertRangeAsync(delStockAlert);
                        DataGrid_Load();
                        _logger.LogInformation($"{delStockAlert.StockSymbol.SymbolName} stock range deleted");
                        MessageBox.Show($"{delStockAlert.StockSymbol.SymbolName} stock range deleted", "Stock Alert Delete", MessageBoxButtons.OK);
                    }
                    else
                    {
                        _logger.LogInformation($"{selectedRow.Cells[2].Value.ToString()} not found in database.");
                        MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    _logger.LogInformation("Delete dialog box confirmation rejected. Hence Delete failed.");
                }
            }
            else
            {
                _logger.LogInformation("No stock range selected for delete.");
                MessageBox.Show("No stock range selected", "Stock Alert Delete", MessageBoxButtons.OK);
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            DataGrid_Load();
        }
    }
}