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
        public StockPage(IStockPriceUpdates stockPriceUpdates, IStockSymbolPage stockSymbolPage, IStockAlertRangeService dataservice)
        {
            InitializeComponent();
            _stockPriceUpdates = stockPriceUpdates;
            _dataService = dataservice;
            _stockSymbolPage = stockSymbolPage;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _stockSymbolPage.AddSymbol();
            SymbolDown.DataSource = _stockSymbolPage.GetSymbolList();
            DisplayStockDetails();
        }


        private async void DisplayStockDetails()
        {
            var Count = _dataService.GetAll().Count();
            switch (Count)
            {
                case 0:
                    break;
                case 1:
                    panel1.Show();
                    symbol1Bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    upperLimit1Bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    lowerLimit1Bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();
                    var currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[0].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();


                    return;
                case 2:
                    panel1.Show();
                    symbol1Bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    upperLimit1Bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    lowerLimit1Bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[0].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    panel2.Show();
                    symbol2Bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    upperLimit2Bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    lowerLimit2Bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[1].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    return;
                case 3:
                    panel1.Show();
                    symbol1Bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    upperLimit1Bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    lowerLimit1Bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[0].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    panel2.Show();
                    symbol2Bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    upperLimit2Bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    lowerLimit2Bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[1].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    return;
                case 4:
                    panel1.Show();
                    symbol1Bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    upperLimit1Bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    lowerLimit1Bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[0].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    panel2.Show();
                    symbol2Bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    upperLimit2Bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    lowerLimit2Bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();
                    currentPrice = await _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[1].StockSymbol);
                    stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);
                    currentPriceStock1Bx.Text = currentPrice.GlobalQuote.Price.ToString();

                    return;

            }
        }

        private void NewStockCreateBtn_Click(object sender, EventArgs e)
        {
            if (newHighLimitBx.Value <= newLowLimitBx.Value)
            {
                stockPageMsg.Text = "Upper limit should be higher Lower limit";
            }
            else
            {
                var Symbol = _stockSymbolPage.FetchStockSymbolByName(SymbolDown.Text);
                if (_dataService.FetchStockAlertRangeByName(Symbol.SymbolName) == null)
                {
                    var NewStock = new StockAlertRange() { StockSymbolId = Symbol.Id, StockSymbol = Symbol, UpperLimit = newHighLimitBx.Value, LowerLimit = newLowLimitBx.Value };
                    _dataService.AddStockAlertRange(NewStock);
                    DisplayStockDetails();
                }
                else
                {
                    stockPageMsg.Text = "Alert Range with this Symbol exists!";
                }
            }

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var editStock = _dataService.FetchStockAlertRangeByName(symbol1Bx.Text);
            editSymbolBx.Text = editStock.StockSymbol.SymbolName;
            editLowLimitBx.Value = editStock.LowerLimit;
            editHighLimitBx.Value = editStock.UpperLimit;
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            var editStock = _dataService.FetchStockAlertRangeByName(symbol2Bx.Text);
            editSymbolBx.Text = editStock.StockSymbol.SymbolName;
            editLowLimitBx.Value = editStock.LowerLimit;
            editHighLimitBx.Value = editStock.UpperLimit;
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            var editStock = _dataService.FetchStockAlertRangeByName(symbol3Bx.Text);
            editSymbolBx.Text = editStock.StockSymbol.SymbolName;
            editLowLimitBx.Value = editStock.LowerLimit;
            editHighLimitBx.Value = editStock.UpperLimit;
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            var editStock = _dataService.FetchStockAlertRangeByName(symbol4Bx.Text);
            editSymbolBx.Text = editStock.StockSymbol.SymbolName;
            editLowLimitBx.Value = editStock.LowerLimit;
            editHighLimitBx.Value = editStock.UpperLimit;
        }

        private void EditUpdateBtn_Click(object sender, EventArgs e)
        {
            if (editHighLimitBx.Value <= editLowLimitBx.Value)
            {
                updateMsgBx.Text = "Upper limit should be higher Lower limit";
            }
            else
            {
                var Stock = _dataService.FetchStockAlertRangeByName(editSymbolBx.Text);
                Stock.UpperLimit = editHighLimitBx.Value;
                Stock.LowerLimit = editLowLimitBx.Value;
                _dataService.UpdateStockAlertRange(Stock);
                DisplayStockDetails();
            }
        }

        private void EditDeleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Remove Stock?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var Symbol = _dataService.FetchStockAlertRangeByName(editSymbolBx.Text);
                if (Symbol != null)
                    _dataService.RemoveStockAlertRange(Symbol);
                DisplayStockDetails();
            }
        }
    }
}