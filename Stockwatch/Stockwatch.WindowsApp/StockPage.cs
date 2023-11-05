using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockAlertRangeService _dataService;
        private IStockPriceUpdates _stockPriceUpdates;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        DataGridViewRow selectedRow = null;
        public StockPage(IStockAlertRangeDisplayService stockAlertRangeDisplayService, IStockPriceUpdates stockPriceUpdates, IStockSymbolPage stockSymbolPage, IStockAlertRangeService dataservice)
        {
            InitializeComponent();
            _stockPriceUpdates = stockPriceUpdates;
            _dataService = dataservice;
            _stockSymbolPage = stockSymbolPage;
            _stockAlertRangeDisplayService = stockAlertRangeDisplayService;
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
            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = _dataService.GetAll();
            foreach (var item in stockData)
            {
                var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRange(item);
                stockDisplays.Add(stockDisplay);
            }
            dataGridViewAlertRange.DataSource = stockDisplays;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (upperLimitNbx.Value < lowerLimitNbx.Value)
            {
                MessageBox.Show("Lower limit value greater than upper limit value", "Add Stock Validations", MessageBoxButtons.OK);
            }
            else if (_dataService.FetchStockAlertRangeByName(symbolDropDown.Text) != null)
            {
                MessageBox.Show("Stock alert already exists for this stock symbol", "Add Stock Validations", MessageBoxButtons.OK);
            }
            else
            {
                var newStock = new StockAlertRange
                {
                    StockSymbolId = _stockSymbolPage.FetchStockSymbolByName(symbolDropDown.Text).Id,
                    LowerLimit = lowerLimitNbx.Value,
                    UpperLimit = upperLimitNbx.Value,
                };
                _dataService.AddStockAlertRange(newStock);
                DataGrid_Load();
                MessageBox.Show("New stock range created!", "Add Stock Validations", MessageBoxButtons.OK);

            }
        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            if (selectedRow != null)
            {
                int newUpperLimit = Convert.ToInt32(selectedRow.Cells[0].Value);
                int newLowerLimit = Convert.ToInt32(selectedRow.Cells[1].Value);
                StockAlertRange editStockAlert = _dataService.FetchStockAlertRangeByName(selectedRow.Cells[2].Value.ToString());
                if (editStockAlert != null && (editStockAlert.UpperLimit != newUpperLimit || editStockAlert.LowerLimit != newLowerLimit))
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to update stock alert?", "Stock Alert Update", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        editStockAlert.LowerLimit = newLowerLimit;
                        editStockAlert.UpperLimit = newUpperLimit;
                        _dataService.UpdateStockAlertRange(editStockAlert);
                        DataGrid_Load();
                        selectedRow = null;
                        MessageBox.Show("Stock range updated!", "Update Stock", MessageBoxButtons.OK);
                    }
                    else
                    {
                    }
                }
                else
                {
                    selectedRow = null;
                    MessageBox.Show("No change made on selected stock range", "Stock Alert Update", MessageBoxButtons.OK);
                }
            }
            else
            {
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
                    StockAlertRange editStockAlert = _dataService.FetchStockAlertRangeByName(selectedRow.Cells[2].Value.ToString());
                    _dataService.RemoveStockAlertRange(editStockAlert);
                    DataGrid_Load();
                    selectedRow = null;
                    MessageBox.Show("Stock range deleted!", "Update Stock", MessageBoxButtons.OK);
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show("No stock range selected", "Stock Alert Update", MessageBoxButtons.OK);
            }
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            DataGrid_Load();
        }
    }
}