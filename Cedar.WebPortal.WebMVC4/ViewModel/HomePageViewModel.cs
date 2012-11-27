namespace Cedar.WebPortal.WebMVC4.ViewModel
{
    using System.Collections.Generic;

    using Cedar.WebPortal.Domain;

    public class HomePageViewModel
    {
        public HomePageViewModel(IEnumerable<News> news)
        {
            this.News = news;
        }
        public IEnumerable<News> News { get; private set; }
    }
}