using Stockwatch.Business;

namespace Stockwatch.WindowsApp
{
    public partial class Form1 : Form
    {
        private IStockSymbolPage _stockSymbolPage;
        public Form1(IStockSymbolPage stockSymbolPage)
        {
            _stockSymbolPage = stockSymbolPage;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SymbolDdown.DataSource = _stockSymbolPage.GetSymbolList();            
        }

        private void SymbolsubmitBtn_Click(object sender, EventArgs e)
        {
            if (SymbolnameTbx.Text == string.Empty)
            {
                SymbolpageMsg.Text = "Please Enter Symbol name!";
            }
            else
            {
                SymbolpageMsg.Text = String.Empty;
                var newsymbolname = SymbolnameTbx.Text;
                _stockSymbolPage.AddSymbol(newsymbolname);
            }
        }


        private void NewStockcreateBtn_Click(object sender, EventArgs e)
        {

            if (SymbolDdown.SelectedIndex == 0)
            {
                StockPageMsg.Text = "Please select valid Symbol!";
            }
        }
    }
}