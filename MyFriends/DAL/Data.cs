namespace MyFriends.DAL
{
    public class Data
    {
        private readonly string _connectionString = "Data Source=AEK\\SQLEXPRESS;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;initial catalog=myfriends;Application Intent=ReadWrite;Multi Subnet Failover=False";
        static Data? _data;
        private DataLayer _dataLayer;
        private Data()
        {
         _dataLayer = new DataLayer(_connectionString);
        }

        public static DataLayer Get
        {
            get
            {
                if (_data?._dataLayer == null)_data = new Data();
                return _data._dataLayer;
            }
        }
    }
}
