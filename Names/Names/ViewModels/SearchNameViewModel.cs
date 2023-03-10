using Names.Services;
using System.ComponentModel;

namespace Names.ViewModels
{
    public class SearchNameViewModel : ISearchNameViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private IDataService service;
        private string name;
        private IList<Models.Result> results = new List<Models.Result>();
        private bool busy = false;
        private bool resultsFound = false;
        private bool noResultsFound = false;

        public SearchNameViewModel(Services.IDataService service)
        {
            this.service = service;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public IList<Models.Result> Results {
            get
            {
                return results;
            }
            set
            {
                results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Results)));
            }
        }

        public bool Busy
        {
            get
            {
                return busy;
            }
            private set
            {
                busy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Busy)));
            }
        }

        public bool ResultsFound
        {
            get
            {
                return resultsFound;
            }
            private set
            {
                resultsFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultsFound)));
            }
        }

        public bool NoResultsFound
        {
            get
            {
                return noResultsFound;
            }
            private set
            {
                noResultsFound = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NoResultsFound)));
            }
        }

        public async Task SearchName()
        {
            Busy = true;
            Results = await service.GetResultsByName(Name);
            Busy = false;
            NoResultsFound = !(ResultsFound = Results.Count > 0);
        }

        public void ClearResults()
        {
            Results.Clear();
            NoResultsFound = ResultsFound = false;
        }
    }
}
