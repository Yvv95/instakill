using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using instakill.WinForms;
using instakill.Model;

namespace instakill.WinForms
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly HttpClientWrapper _httpClient = new HttpClientWrapper("http://instagram20161204020526.azurewebsites.net/");
        private string _userName;
        private string _userId;

        public string UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public ICommand GetUserById
        {
            get
            {
                return new CommandWrapper((o) =>
                {
                    Username = _httpClient.GetUserById(Guid.Parse(UserId)).Nickname;
                }, o => true);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}