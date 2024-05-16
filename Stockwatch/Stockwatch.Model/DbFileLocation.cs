namespace Stockwatch.Model
{
    public class DbFileLocation
    {
        public static string GetDbFileLocation()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string stockWatchFolder = Path.Combine(appDataPath, "StockWatch");
            
            if (!Directory.Exists(stockWatchFolder))
            {
                throw new Exception($"{stockWatchFolder} folder does not exist.");
            }

            string stockDatabasePath = Path.Combine(stockWatchFolder, "stock_database.db");
            return stockDatabasePath;
        }
    }
}
