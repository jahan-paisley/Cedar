using System.Collections.Generic;
using Cedar.WebPortal.Domain.Entities;

namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    public class HomePageViewModel
    {
        public HomePageViewModel(IEnumerable<News> news)
        {
            News = news;
        }

        public IEnumerable<News> News { get; private set; }
    }
}