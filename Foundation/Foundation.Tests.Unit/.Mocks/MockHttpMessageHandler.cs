//-----------------------------------------------------------------------
// <copyright file="MockHttpMessageHandler.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Tests.Unit.Mocks
{
    public class MockHttpMessageHandler : HttpMessageHandler
    {
        private const String ErrorMessage = "Method must be mocked, use: Substitute.ForPartsOf<MockHttpMessageHandler>()";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Send(request, cancellationToken);
        }

        public new virtual Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException(ErrorMessage);
        }
    }
}
