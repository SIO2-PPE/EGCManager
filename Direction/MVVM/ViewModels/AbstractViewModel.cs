using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Direction.ViewModels
{
    public abstract class AbstractViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string caller = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
