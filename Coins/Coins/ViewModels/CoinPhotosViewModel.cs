using System.Windows.Input;

namespace Coins.ViewModels
{
    public class CoinPhotosViewModel : BaseViewModel
    {
        private string id;
        public ICommand GoToCoin { get; private set; }

        public string Id
        {
            set
            {
                id = value;
                OnPropertyChanged(nameof(Sides));
            }
        }
        public CoinPhotosViewModel(Data.Database database) : base(database)
        {
            GoToCoin = new Command(
                async () => await Shell.Current.GoToAsync($"//coin?id={id}"));
        }

        public IList<dynamic> Sides
        {
            get
            {
                return new List<dynamic>
                {
                    new
                    {
                        Title = "Front",
                        Photo = Path.Combine(FileSystem.CacheDirectory, $"{id}_front.jpg"),
                        TakePhotoCommand = new Command<string>(async (side) => await TakePhoto(side))
                    },
                    new
                    {
                        Title = "Back",
                        Photo = Path.Combine(FileSystem.CacheDirectory, $"{id}_back.jpg"),
                        TakePhotoCommand = new Command<string>(async (side) => await TakePhoto(side))
                    }
                };
            }
        }

        async public Task TakePhoto(string side)
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                if (photo != null)
                {
                    string path = Path.Combine(FileSystem.CacheDirectory, $"{id}_{side.ToLower()}.jpg");
                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream targetStream = File.OpenWrite(path);
                    await sourceStream.CopyToAsync(targetStream);
                    OnPropertyChanged(nameof(Sides));
                }
            }
        }
    }
}
