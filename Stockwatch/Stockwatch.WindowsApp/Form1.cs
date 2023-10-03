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
            symbolDdown.DataSource = _stockSymbolPage.GetSymbolList();            
        }
        private void SymbolsubmitBtn_Click(object sender, EventArgs e)
        {
            if (symbolnameTbx.Text == string.Empty)
            {
                SymbolpageMsg.Text = "Please Enter Symbol name!";
            }
            else
            {
                SymbolpageMsg.Text = String.Empty;
                var newsymbolname = symbolnameTbx.Text;
                _stockSymbolPage.AddSymbol(newsymbolname);
            }
        }
        private void NewStockcreateBtn_Click(object sender, EventArgs e)
        {

            if (symbolDdown.SelectedIndex == 0)
            {
                StockPageMsg.Text = "Please select valid Symbol!";
            }
        }
    }
}