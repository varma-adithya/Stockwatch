using Stockwatch.Business;
using Stockwatch.Model;
using System.Windows.Forms;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockSymbolService _symbolservice;
        private IStockAlertRangeservice _dataservice;
        private IStockPriceUpdates _stockPriceUpdates;
        public StockPage(IStockPriceUpdates stockPriceUpdates, IStockSymbolPage stockSymbolPage,IStockSymbolService symbolservice, IStockAlertRangeservice dataservice)
        {
            _stockPriceUpdates = stockPriceUpdates;
            _dataservice = dataservice;
            _stockSymbolPage = stockSymbolPage;
            _symbolservice = symbolservice;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            _stockSymbolPage.AddSymbol();
            SymbolDdown.DataSource = _stockSymbolPage.GetSymbolList();
            DisplayStockDetails();
        }


        private void DisplayStockDetails()
        {
            var Count = _dataservice.GetAll().Count();
            switch (Count)
            {
                case 0:
                    break;
                case 1:
                    panel1.Show();
                    Symbol1bx.Text = _dataservice.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text= _dataservice.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataservice.GetAll()[0].LowerLimit.ToString();
                    var currentPrice = _stockPriceUpdates.GetCurrentPrice(_dataservice.GetAll()[0].StockSymbol);
                    Stock1Msg.Text = _stockPriceUpdates.GetComments(currentPrice, _dataservice.GetAll()[0]);


                    return;
                case 2:
                    panel1.Show();
                    Symbol1bx.Text = _dataservice.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataservice.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataservice.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataservice.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataservice.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataservice.GetAll()[1].LowerLimit.ToString();

                    return;
                case 3:
                    panel1.Show();
                    Symbol1bx.Text = _dataservice.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataservice.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataservice.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataservice.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataservice.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataservice.GetAll()[1].LowerLimit.ToString();
                    
                    return;
                case 4:
                    panel1.Show();
                    Symbol1bx.Text = _dataservice.GetAll()[0].StockSymbol.SymbolName;
                    UpperLimit1bx.Text = _dataservice.GetAll()[0].UpperLimit.ToString();
                    LowerLimit1bx.Text = _dataservice.GetAll()[0].LowerLimit.ToString();

                    panel2.Show();
                    Symbol2bx.Text = _dataservice.GetAll()[1].StockSymbol.SymbolName;
                    UpperLimit2bx.Text = _dataservice.GetAll()[1].UpperLimit.ToString();
                    LowerLimit2bx.Text = _dataservice.GetAll()[1].LowerLimit.ToString();

                    return;

            }
        }


        private void SymbolDdown_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void NewStockcreateBtn_Click(object sender, EventArgs e)
        {
            if(NewHLimitbx.Value <= NewLLimitbx.Value)
            {
                StockPageMsg.Text = "Upper limit should be higher Lower limit"; 
            }
            else {
                var Symbol = _symbolservice.FetchStockAlertRangeByIdSymbolByName(SymbolDdown.Text);
                var NewStock = new StockAlertRange() { SymbolId = Symbol.Id,StockSymbol = Symbol, UpperLimit = NewHLimitbx.Value, LowerLimit = NewLLimitbx.Value };
                _dataservice.AddStockAlertRange(NewStock);
                DisplayStockDetails();
            }

        }


        private void panel1_Click(object sender, EventArgs e)
        {
            var EditStock = _dataservice.FetchStockAlertRangeByName(Symbol1bx.Text);
            EditSymbolbx.Text = EditStock.StockSymbol.SymbolName;
            EditLLimitbx.Value = EditStock.LowerLimit;
            EditHLimitbx.Value = EditStock.UpperLimit;
        }

        private void EditUpdatebtn_Click(object sender, EventArgs e)
        {
            if (EditHLimitbx.Value <= EditLLimitbx.Value)
            {
                UpdataMsgbx.Text = "Upper limit should be higher Lower limit";
            }
            else
            {
                var Stock = _dataservice.FetchStockAlertRangeByName(EditSymbolbx.Text);
                Stock.UpperLimit = EditHLimitbx.Value;
                Stock.LowerLimit = EditLLimitbx.Value;
                _dataservice.UpdateStockAlertRange(Stock);
                DisplayStockDetails();
            }
        }

        private void EditDeletebtn_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to Remove Stock?", "Confirmation", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                var Symbol = _dataservice.FetchStockAlertRangeByName(EditSymbolbx.Text);
                if(Symbol != null)
                    _dataservice.RemoveStockAlertRange(Symbol);
                DisplayStockDetails();
            }
        }
    }
}