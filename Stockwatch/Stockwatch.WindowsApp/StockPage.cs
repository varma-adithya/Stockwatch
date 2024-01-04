using Microsoft.Extensions.Logging;
using Stockwatch.Business;
using Stockwatch.Model;
using System.Data;
using System.Windows.Forms;

namespace Stockwatch.WindowsApp
{
    public partial class StockPage : Form
    {
        private IStockSymbolService _stockSymbolService;
        private IStockAlertRangeService _stockAlertRangeService;
        private IStockAlertRangeDisplayService _stockAlertRangeDisplayService;
        private readonly ILogger _logger;
        private DataGridViewRow? selectedRow = null;
        private BindingSource? bindingSource = new BindingSource();
        private string originalStockSymbolName;

        public StockPage(IStockAlertRangeDisplayService stockAlertRangeDisplayService, IStockSymbolService stockSymbolService, IStockAlertRangeService stockAlertRangeService, ILogger<StockPage> logger)
        {
            InitializeComponent();
            _stockAlertRangeService = stockAlertRangeService;
            _stockSymbolService = stockSymbolService;
            _stockAlertRangeDisplayService = stockAlertRangeDisplayService;
            _logger = logger;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await _stockSymbolService.AddSymbol();
            await DataGrid_Load();
        }

        private async Task DataGrid_Load()
        {

            selectedRow = null;
            var comboBox = (DataGridViewComboBoxColumn)dataGridViewAlertRange.Columns["StockSymbolName"];
            comboBox.DataSource = await _stockSymbolService.GetSymbolListAsync();

            dataGridViewAlertRange.DataSource = bindingSource;

            var stockDisplays = new List<StockAlertRangeDisplay>();
            var stockData = await _stockAlertRangeService.GetAllStockAlertRangesAsync();
            foreach (var item in stockData)
            {
                var stockDisplay = await _stockAlertRangeDisplayService.GetStockAlertRangeAsync(item);
                stockDisplays.Add(stockDisplay);
            }

            bindingSource.DataSource = stockDisplays;

            dataGridViewAlertRange.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridViewAlertRange.CellBeginEdit += DataGridView1_CellBeginEdit;
            dataGridViewAlertRange.CellEndEdit += DataGridView_Edit;
        }
        private void DataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewAlertRange.NewRowIndex)
            {
                originalStockSymbolName = dataGridViewAlertRange["StockSymbolName", e.RowIndex].Value?.ToString();
            }
        }
        private async void DataGridView_Edit(object? sender, DataGridViewCellEventArgs e)
        {
            dataGridViewAlertRange.EndEdit();
            if (e.RowIndex != dataGridViewAlertRange.NewRowIndex && e.RowIndex != dataGridViewAlertRange.NewRowIndex-1)
            {
                var  rowView = dataGridViewAlertRange.Rows[e.RowIndex].DataBoundItem as StockAlertRangeDisplay;

                if (rowView?.StockSymbolName == originalStockSymbolName)
                {
                    var newUpperLimit = rowView.UpperLimit;
                    var newLowerLimit = rowView.LowerLimit;
                    StockAlertRange? editStockAlert = await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(originalStockSymbolName);
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
                    else if (editStockAlert != null)
                    {
                        _logger.LogInformation("No change made on selected stock range for update.");
                        MessageBox.Show("No change made on selected stock range", "Stock Alert Update", MessageBoxButtons.OK);

                    }
                    else
                    {
                        _logger.LogInformation($"{originalStockSymbolName} not found in database.");
                        MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    MessageBox.Show("Stock symbol name cannot be edited!", "Stock Alert edit", MessageBoxButtons.OK);
                    await DataGrid_Load();
                }
            }
        }

        private async void AddBtn_Click(object sender, EventArgs e)
        {

            var newSymbolName = Convert.ToString(dataGridViewAlertRange.Rows[dataGridViewAlertRange.NewRowIndex-1].Cells["StockSymbolName"].Value);
            var newUpperLimit = Convert.ToInt32(dataGridViewAlertRange.Rows[dataGridViewAlertRange.NewRowIndex-1].Cells["UpperLimit"].Value);
            var newLowerLimit = Convert.ToInt32(dataGridViewAlertRange.Rows[dataGridViewAlertRange.NewRowIndex - 1].Cells["LowerLimit"].Value);

            if (newUpperLimit < newLowerLimit)
            {
                MessageBox.Show("Lower limit value greater than upper limit value", "New Stock", MessageBoxButtons.OK);
            }
            else if(newSymbolName == null)
            {
                MessageBox.Show("Please select StockSymbol", "New Stock", MessageBoxButtons.OK);
            }
            else if (await _stockAlertRangeService.FetchStockAlertRangeByNameAsync(newSymbolName) != null)
            {
                MessageBox.Show("Stock alert already exists for this stock symbol", "New Stock", MessageBoxButtons.OK);
            }
            else
            {
                var newStock = new StockAlertRange
                {
                    StockSymbolId = (await _stockSymbolService.FetchStockSymbolByNameAsync(newSymbolName)).Id,
                    LowerLimit = newLowerLimit,
                    UpperLimit = newUpperLimit,
                };
                await _stockAlertRangeService.AddStockAlertRangeAsync(newStock);
                await DataGrid_Load();
            }

        }
        
        //private async void editBtn_Click(object sender, EventArgs e)
        //{

        //    if (selectedRow != null)
        //    {
        //        int newUpperLimit = Convert.ToInt32(selectedRow.Cells[0].Value);
        //        int newLowerLimit = Convert.ToInt32(selectedRow.Cells[1].Value);
        //        StockAlertRange? editStockAlert = _stockAlertRangeService.FetchStockAlertRangeByNameAsync(selectedRow.Cells[2].Value.ToString()).Result;
                
        //        if (editStockAlert != null && (editStockAlert.UpperLimit != newUpperLimit || editStockAlert.LowerLimit != newLowerLimit))
        //        {
        //            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update stock alert?", "Stock Alert Update", MessageBoxButtons.YesNo);
                    
        //            if (dialogResult == DialogResult.Yes)
        //            {
        //                editStockAlert.LowerLimit = newLowerLimit;
        //                editStockAlert.UpperLimit = newUpperLimit;
        //                await _stockAlertRangeService.UpdateStockAlertRangeAsync(editStockAlert);                        
        //                await DataGrid_Load();
        //                MessageBox.Show("Stock range updated!", "Stock Alert Update", MessageBoxButtons.OK);
        //            }
        //            else
        //            {
        //                await DataGrid_Load();
        //                _logger.LogInformation("Update dialog box confirmation rejected. Hence Update failed.");
        //            }

        //        }
        //        else if(editStockAlert != null)
        //        {
        //            selectedRow = null;
        //            _logger.LogInformation("No change made on selected stock range for update.");
        //            MessageBox.Show("No change made on selected stock range", "Stock Alert Update", MessageBoxButtons.OK);

        //        }
        //        else
        //        {
        //            _logger.LogInformation($"{selectedRow.Cells[2].Value.ToString()} not found in database.");
        //            MessageBox.Show("Please refresh and try again.", "Stock Alert Delete", MessageBoxButtons.OK);
        //        }

        //    }
        //    else
        //    {
        //        _logger.LogInformation("No stock range selected for update.");
        //        MessageBox.Show("No stock range selected", "Stock Alert Update", MessageBoxButtons.OK);
        //    }

        //}
        
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