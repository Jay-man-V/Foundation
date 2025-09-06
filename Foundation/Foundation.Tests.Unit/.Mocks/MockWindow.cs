//-----------------------------------------------------------------------
// <copyright file="MockViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks
{
    public interface IMockWindow : IWindow
    {
        
    }

    public class MockWindow : IMockWindow
    {
        public Object? DataContext { get; set; }
        public void Close()
        {
        }

        public void Show()
        {
        }
    }
}
