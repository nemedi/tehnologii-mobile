using System.Windows.Input;

namespace Coins.ViewModels
{
    public class CoinPhotosViewModel : BaseViewModel
    {
        string id;
        public ICommand TakePhotoCommand { get; private set; }
        public ICommand GoToCoin { get; private set; }

        public string Id
        {
            set
            {
                id = value;
                OnPropertyChanged(nameof(FrontPhoto));
                OnPropertyChanged(nameof(BackPhoto));
            }
        }

        public bool New { get; set; } = false;
        
        public CoinPhotosViewModel(Data.Database database) : base(database)
        {
            TakePhotoCommand = new Command<string>(
                async (side) =>
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
                            OnPropertyChanged(side + "Photo");
                        }
                    }
                });
            GoToCoin = new Command(
                async () => await Shell.Current.GoToAsync($"//coin?id={id}&new={New}"));
        }

        public string FrontPhoto => Path.Combine(FileSystem.CacheDirectory, $"{id}_front.jpg");

        public string BackPhoto => Path.Combine(FileSystem.CacheDirectory, $"{id}_back.jpg");

    }
}
