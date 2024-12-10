using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using WPF_FirstAPP.Interfaces;
using WPF_FirstAPP.Models;
using WPF_FirstAPP.Utils;

namespace WPF_FirstAPP.ViewModel
{
    public partial class ContactManagerViewModel : ViewModelBase
    {
        private readonly IFileService<ContactModel> _fileService;
        private readonly Random _random = new();

        public ContactManagerViewModel(IFileService<ContactModel> fileService)
        {
            _fileService = fileService;
            Contacts = new ObservableCollection<ContactModel>();
        }

        [ObservableProperty]
        private ObservableCollection<ContactModel> contacts;

        [RelayCommand]
        public void LoadFromFile()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var loadedContacts = _fileService.Load(openFileDialog.FileName);
                Contacts = new ObservableCollection<ContactModel>(loadedContacts);
            }
        }

        [RelayCommand]
        public void SaveToFile()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.JSON_FILTER
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                _fileService.Save(saveFileDialog.FileName, Contacts);
            }
        }
        public override Task LoadAsync()
        {
            Contacts ??= new ObservableCollection<ContactModel>();


            if (Contacts.Count > 0)
                return Task.CompletedTask;


            int numberOfContacts = _random.Next(5, 20);

            for (int i = 0; i < numberOfContacts; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Name = $"Contact {i + 1}",
                    Email = $"contact{i + 1}@example.com",
                    Phone = $"{_random.Next(600, 700)}-{_random.Next(1000000, 9999999)}"
                });
            }
            return Task.CompletedTask;
        }
    }
}
