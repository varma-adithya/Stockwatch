using Stockwatch.Business;
using Stockwatch.Model;
using System.Windows.Forms;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockAlertRangeService _dataService;
        private IStockPriceUpdates _stockPriceUpdates;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
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
                createStockAlert.Text = "Lower Limit value greater than Upper Limit value";
            }
            else if (_dataService.FetchStockAlertRangeByName(symbolDropDown.Text) != null)
            {
                createStockAlert.Text = "Stock Alert already exists for this Stock Symbol";
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
            }
        }
    }
}