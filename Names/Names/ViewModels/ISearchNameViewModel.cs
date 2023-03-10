using System.ComponentModel;

namespace Names.ViewModels
{
    public interface ISearchNameViewModel : INotifyPropertyChanged
    {
        string Name { get; set; }

        IList<Models.Result> Results { get; }

        bool Busy { get; }

        bool ResultsFound { get; }

        bool NoResultsFound { get; }

        Task SearchName();

        void ClearResults();
    }
}
