using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MvvmTutorial.ViewModels
{
    public class LanguagesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
           
        }
        public LanguagesViewModel()
        {
            _languages = new List<Language> { new Language { Name= "english",ShortName="eng"},
                new Language{Name="russian",ShortName="rus" },new Language{Name= "german",ShortName="ger" } };
        }
        private List<Language> _languages;
        public List<Language> languages
        {
            get { return _languages; }
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged(nameof(languages));
                }
            }
        }

        private List<string> _selectedLanguage = new List<string>();

        public List<string> SelectedLanguage
        {
            get { return _selectedLanguage; }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    OnPropertyChanged(nameof(SelectedLanguage));
                }
            }
        }
    }
}
