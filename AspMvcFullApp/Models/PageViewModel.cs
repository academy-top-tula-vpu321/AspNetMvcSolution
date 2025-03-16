namespace AspMvcFullApp.Models
{
    public class PageViewModel
    {
        public int Page { get; }
        public int Total { get; }

        public bool HasPrevPage => Page > 1;
        public bool HasNextPage => Page < Total;

        public PageViewModel(int page, int total)
        {
            Page = page;
            Total = total;
        }
    }
}
