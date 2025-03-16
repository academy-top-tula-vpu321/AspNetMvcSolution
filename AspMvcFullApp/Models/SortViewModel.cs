namespace AspMvcFullApp.Models
{
    public class SortViewModel
    {
        public SortState NameSort { get; }
        public SortState AgeSort { get; }
        public SortState CompanySort { get; }
        public SortState CurrentSort { get; }

        public SortViewModel(SortState sortState)
        {
            CurrentSort = sortState;

            NameSort = (sortState == SortState.NameAsc) ? SortState.NameDesc : SortState.NameAsc;
            AgeSort = (sortState == SortState.AgeAsc) ? SortState.AgeDesc : SortState.AgeAsc;
            CompanySort = (sortState == SortState.CompanyAsc) ? SortState.CompanyDesc : SortState.CompanyAsc;
        }

    }
}
