namespace PrimeraAPI.BusinessModels.models
{
    public class PaginatedBaseRequest
    {
        private int? page = null;
        public int? Page
        {
            get => page;
            set
            {
                if (value == null)
                {
                    page = 1;
                }
                else
                {
                    page = value;
                }
            }
        }
        private int? itemsPerPage = null;
        public int? ItemsPerPage
        {
            get => itemsPerPage;
            set
            {
                if (value == null)
                {
                    itemsPerPage = 5;
                }
                else
                {
                    itemsPerPage = value;
                }
            }
        }

    }
}
