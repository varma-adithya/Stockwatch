using Stockwatch.Business;

namespace Stockwatch.WindowsApp
{
    public partial class Form1 : Form
    {
        private IStockSymbolPage _symbolpage;
        public Form1(IStockSymbolPage symbolpage)
        {
            _symbolpage = symbolpage;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SymbolDdown.Items.Add("Select");

            foreach (string item in _symbolpage.GetSymbolList())
            {
                SymbolDdown.Items.Add(item);
            }
            SymbolDdown.SelectedIndex = 0;

        }

        private void SymbolsubmitBtn_Click(object sender, EventArgs e)
        {
            if (SymbolnameTbx.Text == String.Empty)
            {
                SymbolpageMsg.Text = "Please Enter Symbol name!";
            }
            else
            {
                SymbolpageMsg.Text = String.Empty;
                var newsymbolname = SymbolnameTbx.Text;
                _symbolpage.AddSymbol(newsymbolname);
            }
        }

        private void SymbolDdown_SelectedIndexChanged(object sender, EventArgs e)
        {
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