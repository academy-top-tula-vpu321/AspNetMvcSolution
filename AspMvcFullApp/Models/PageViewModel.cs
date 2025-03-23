namespace AspMvcFullApp.Models
{
    public class PageViewModel
    {
        public int Page { get; }
        public int TotalPages { get; }

        public bool HasPrevPage => Page > 1;
        public bool HasNextPage => Page < TotalPages;

        public PageViewModel(int count, int page, int size)
        {
            Page = page;
            TotalPages = (int)Math.Ceiling((count / (double)size));
        }
    }
}
