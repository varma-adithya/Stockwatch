using Stockwatch.Business;
using Stockwatch.Model;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        private IStockSymbolService _symbolservice;
        private IStockAlertRangeservice _dataservice;
        public StockPage(IStockSymbolPage stockSymbolPage,IStockSymbolService symbolservice, IStockAlertRangeservice dataservice)
        {
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}