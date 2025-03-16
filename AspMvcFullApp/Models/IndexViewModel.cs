namespace AspMvcFullApp.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Employee> Employees { get; }
        public FilterViewModel filterViewModel { get; }
        public SortViewModel sortViewModel { get; }
        public PageViewModel pageViewModel { get; }

        public IndexViewModel(IEnumerable<Employee> employees, 
                              FilterViewModel filterViewModel, 
                              SortViewModel sortViewModel, 
                              PageViewModel pageViewModel)
        {
            Employees = employees;
            this.filterViewModel = filterViewModel;
            this.sortViewModel = sortViewModel;
            this.pageViewModel = pageViewModel;
        }
    }
}
