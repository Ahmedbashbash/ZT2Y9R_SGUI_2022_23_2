using Microsoft.Toolkit.Mvvm.ComponentModel;
using ZT2Y9R_HFT_2021221.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using Microsoft.Toolkit.Mvvm.Input;

namespace ZT2Y9R_HFT_2021221.WpfClient
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        public RestCollection<Players> Players { get; set; }

        private Players selectedPlayer;

        public Players SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = new Players()
                    {
                        Name = value.Name,
                        PlayerId = value.PlayerId
                    };
                    OnPropertyChanged();
                    (DeletePlayerCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreatePlayerCommand { get; set; }

        public ICommand DeletePlayerCommand { get; set; }

        public ICommand UpdatePlayerCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }


        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Players = new RestCollection<Players>("http://localhost:53910/", "actor", "hub");
                CreatePlayerCommand = new RelayCommand(() =>
                {
                    Players.Add(new Players()
                    {
                        Name = SelectedPlayer.Name
                    });
                });

                UpdatePlayerCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Players.Update(SelectedPlayer);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeletePlayerCommand = new RelayCommand(() =>
                {
                    Players.Delete(SelectedPlayer.PlayerId);
                },
                () =>
                {
                    return SelectedPlayer != null;
                });
                SelectedPlayer = new Players();
            }

        }
    }
}
