using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspMvcFullApp.Models
{
    public class FilterViewModel
    {
        public SelectList Companies { get; }
        public int SelectedCompanyId { get; }
        public string SelectedName { get; }
        public FilterViewModel(List<Company> companies, 
                              int companyId, 
                              string name)
        {
            companies.Insert(0, new() { Id = 0, Title = "All Company" });
            Companies = new(companies, "Id", "Title", companyId);
            SelectedCompanyId = companyId;
            SelectedName = name;
        }
    }
}
