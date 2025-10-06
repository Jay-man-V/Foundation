//-----------------------------------------------------------------------
// <copyright file="MockClipBoardWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Mocks.Wrappers
{
    public class MockClipBoardWrapper : IClipBoardWrapper
    {
        private String Text { get; set; } = String.Empty;

        public void SetText(String text)
        {
            Text = text;
        }

        public String GetText()
        {
            return Text;
        }
    }
}
