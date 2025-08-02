//-----------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.CompilerServices;

using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    [DependencyInjectionTransient]
    public class MainWindowViewModel : IMainWindowViewModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private String _formTitle = String.Empty;
        public String FormTitle
        {
            get => _formTitle;
            set => SetField(ref _formTitle, value);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] String? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public IViewModel? ParentViewModel { get; }

        public Dictionary<String, Object> Parameters { get; }
        public void Initialise(IWindow targetWindow, IViewModel? parentViewModel, String formTitle)
        {
            FormTitle = formTitle;
        }
    }

}
