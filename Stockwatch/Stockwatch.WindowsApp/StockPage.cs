using Stockwatch.Business;
using Stockwatch.Model;
using System.Windows.Forms;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockAlertRangeservice _dataService;
        private IStockPriceUpdates _stockPriceUpdates;
        public StockPage(IStockPriceUpdates stockPriceUpdates, IStockSymbolPage stockSymbolPage, IStockAlertRangeservice dataservice)
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


        private void DisplayStockDetails()
        {
            var Count = _dataService.GetAll().Count();
            switch (Count)
            {
                case 0:
                    break;
                case 1:
                    panel1.Show();
                    Symbol1bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();
                    var currentPrice = _stockPriceUpdates.GetCurrentPrice(_dataService.GetAll()[0].StockSymbol);
                    Stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataService.GetAll()[0]);


                    return;
                case 2:
                    panel1.Show();
                    Symbol1bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();

                    return;
                case 3:
                    panel1.Show();
                    Symbol1bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();

                    return;
                case 4:
                    panel1.Show();
                    Symbol1bx.Text = _dataService.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataService.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataService.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataService.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataService.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataService.GetAll()[1].LowerLimit.ToString();

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
                var Symbol = _stockSymbolPage.FetchStockAlertRangeByIdSymbolByName(SymbolDown.Text);
                var NewStock = new StockAlertRange() { StockSymbolId = Symbol.Id, StockSymbol = Symbol, UpperLimit = newHighLimitBx.Value, LowerLimit = newLowLimitBx.Value };
                _dataService.AddStockAlertRange(NewStock);
                DisplayStockDetails();
            }

        }

        private void panel1_Click(object sender, EventArgs e)
        {
            var EditStock = _dataService.FetchStockAlertRangeByName(Symbol1bx.Text);
            editSymbolBx.Text = EditStock.StockSymbol.SymbolName;
            editLowLimitBx.Value = EditStock.LowerLimit;
            editHighLimitBx.Value = EditStock.UpperLimit;
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