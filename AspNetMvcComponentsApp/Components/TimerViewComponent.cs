using Microsoft.AspNetCore.Mvc;

namespace AspNetMvcComponentsApp.Components
{
    public class FileTxtViewComponent : ViewComponent
    {
        public async Task<string> InvokeAsync(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
                return await reader.ReadToEndAsync();
        }
    }
}
