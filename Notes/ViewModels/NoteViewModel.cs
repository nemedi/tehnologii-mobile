using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Notes.ViewModels;

internal partial class NoteViewModel : ObservableObject, IQueryAttributable
{
    private Models.Note note;

    public string Text
    {
        get => note.Text;
        set
        {
            if (note.Text != value)
            {
                note.Text = value;
                OnPropertyChanged();
            }
        }
    }

    public DateTime Date => note.Date;

    public string Identifier => note.Filename;

    public NoteViewModel()
    {
        note = new Models.Note();
    }
    
    public NoteViewModel(Models.Note note)
    {
        this.note = note;
    }

    [RelayCommand]
    private async Task Save()
    {
        note.Date = DateTime.Now;
        note.Save();
        await Shell.Current.GoToAsync($"..?saved={note.Filename}");
    }

    [RelayCommand]
    private async Task Delete()
    {
        note.Delete();
        await Shell.Current.GoToAsync($"..?deleted={note.Filename}");
    }

    void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("load"))
        {
            note = Models.Note.Load(query["load"].ToString());
            RefreshProperties();
        }
    }

    public void Reload()
    {
        note = Models.Note.Load(note.Filename);
        RefreshProperties();
    }

    private void RefreshProperties()
    {
        OnPropertyChanged(nameof(Text));
        OnPropertyChanged(nameof(Date));
    }
}