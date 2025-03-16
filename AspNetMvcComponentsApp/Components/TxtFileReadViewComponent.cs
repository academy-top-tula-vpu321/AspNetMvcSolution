using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.ComponentModel;

namespace AspNetMvcComponentsApp.Components
{
    public class TxtFileReadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
                return new ContentViewComponentResult(reader.ReadToEnd());
        }
    }
}
