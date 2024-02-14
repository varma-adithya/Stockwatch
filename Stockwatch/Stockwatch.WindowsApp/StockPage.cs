using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolService _stockSymbolPage;
        private IStockAlertRangeService _stockAlertRangeService;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        private readonly ILogger _logger;
        DataGridViewRow? selectedRow = null;

        public StockPage(IStockAlertRangeDisplayService stockAlertRangeDisplayService, IStockSymbolService stockSymbolPage, IStockAlertRangeService stockAlertRangeService, ILogger<StockPage> logger)
        {
            InitializeComponent();
            _stockAlertRangeService = stockAlertRangeService;
            _stockSymbolPage = stockSymbolPage;
            _stockAlertRangeDisplayService = stockAlertRangeDisplayService;
            _logger = logger;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await _stockSymbolPage.AddSymbol();
            symbolDropDown.DataSource = await _stockSymbolPage.GetSymbolListAsync();
            this.dataGridViewAlertRange.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            await DataGrid_Load();
        }

        private async Task DataGrid_Load()
        {
            selectedRow = null;
            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = await _stockAlertRangeService.GetAllStockAlertRangesAsync();
            
            if (stockData.Count != 0)
            {
                foreach (var item in stockData)
                {
                    //Null ref exception
                    var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRangeAsync(item);
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
        
        private async void AddBtn_Click(object sender, EventArgs e)
        {
            if (upperLimitNbx.Value < lowerLimitNbx.Value)
            {
                MessageBox.Show("Lower limit value greater than upper limit value", "New Stock", MessageBoxButtons.OK);
            }
            else if (await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(symbolDropDown.Text) != null)
            {
                MessageBox.Show("Stock alert already exists for this stock symbol", "New Stock", MessageBoxButtons.OK);
            }
            else
            {
                var newStock = new StockAlertRange
                {
                    StockSymbolId = (await _stockSymbolPage.FetchStockSymbolByNameAsync(symbolDropDown.Text)).Id,
                    LowerLimit = lowerLimitNbx.Value,
                    UpperLimit = upperLimitNbx.Value,
                };
                await _stockAlertRangeService.AddStockAlertRangeAsync(newStock);
                await DataGrid_Load();
            }

        }
        
        private async void editBtn_Click(object sender, EventArgs e)
        {

            if (selectedRow != null)
            {
                int newUpperLimit = Convert.ToInt32(selectedRow.Cells[0].Value);
                int newLowerLimit = Convert.ToInt32(selectedRow.Cells[1].Value);
                StockAlertRange? editStockAlert = _stockAlertRangeService.FetchStockAlertRangeByNameAsync(selectedRow.Cells[2].Value.ToString()).Result;
                
                if (editStockAlert != null && (editStockAlert.UpperLimit != newUpperLimit || editStockAlert.LowerLimit != newLowerLimit))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update stock alert?", "Stock Alert Update", MessageBoxButtons.YesNo);
                    
                    if (dialogResult == DialogResult.Yes)
                    {
                        editStockAlert.LowerLimit = newLowerLimit;
                        editStockAlert.UpperLimit = newUpperLimit;
                        await _stockAlertRangeService.UpdateStockAlertRangeAsync(editStockAlert);                        
                        await DataGrid_Load();
                        MessageBox.Show("Stock range updated!", "Stock Alert Update", MessageBoxButtons.OK);
                    }
                    else
                    {
                        await DataGrid_Load();
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
        
        private async void deleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete stock alert?", "Stock Alert Delete", MessageBoxButtons.YesNo);
                
                if (dialogResult == DialogResult.Yes)
                {
                    StockAlertRange? delStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(selectedRow.Cells[2].Value.ToString());
                    
                    if (delStockAlert != null) 
                    {
                        await _stockAlertRangeService.DeleteStockAlertRangeAsync(delStockAlert);
                        await DataGrid_Load();
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
        
        private async void resetBtn_Click(object sender, EventArgs e)
        {
            await DataGrid_Load();
        }

    }
}