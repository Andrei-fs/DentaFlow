namespace DentaFlow.ResourceParameters
{
    public class EntityResourceParameters
    {
        const int maxPageSize = 20;
        public string Location { get; set; }
        
        public string SearchQuery { get; set; }

        public int PageNumber { get; set; } = 1;

       

        private int _pageSize=10;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > maxPageSize) ? maxPageSize : value;
        }


    }
    
}