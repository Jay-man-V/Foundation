//-----------------------------------------------------------------------
// <copyright file="ImageConversionTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;

using NUnit.Framework;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.NetFramework
{
    /// <summary>
    /// The ImageConversionTests class
    /// </summary>
    [TestFixture]
    public class ImageConversionTests
    {
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\JDV Software Logo.png", @".Support\SampleDocuments\")]
        public void Test_Base64ForEmbedding()
        {
            String expectedBase64String = "iVBORw0KGgoAAAANSUhEUgAAAMgAAAAsCAIAAACv72BdAAAABGdBTUEAALGPC/xhBQAAAAlwSFlzAAAOwgAADsIBFShKgAAAEIlJREFUeF7tXE9IW9kX7sKFGxfZuMmi4KoLV110Y3cBwZCAQnAQSkGkUCGrLAIBBWG6UVBQsAhxNYIojFIhlCIiHbRgZyyFigwS2i4SGYyiAYVgIr4fH9/hvJv7XmLaaf0xbeCjxPfuu+/ec797/t3zeuf62mmiiW+OO95LN6JyBfhe915s4ufEFxDLlze+F5v4IvyQMvwCYhHZvLO06STnnP4xJ5RwuuJAT9J59MwZmXfWtp3DY/uRJn5CNEqsixL41DfqBGNOWxgIRJ32XheBqFzvGADJXr21e/iRcFLE/imcfQNlUzhzxhedSAqbM5JyZlbsBv9RNESspU3nwVMhUzAG6iiTWrsB5VkwBvBWT9J5/d7uqj4+fIQWjKRcUNxdcYyBbQ6P5bqJSAqkj0876YyTK1T1+etvolP7Rp2jU/uNRK4gr+uKOxu79l1FNg9VHUo4nYMQQucg2g9NOKtb2Hje9jfi8BiCbe0Wid15iHGqF/vvWft/xA3EyhVg8trCIA351NqNf7vizvAUtlo6A0wuY1FDCdzSxoEokJh1iud2t7Xw+r3TEhLNZ+rFlhDepUMirU1o47YwmJ2cc1+6to3H2Uk6Y7+RmFzG3UAUwz4p2neJ3/8Qba2v4+9AFM8m5+z2RC2K8EpiFvLsGEDPfaPO/SeyfxKz+H3/icxaH/f283WoNSqrgfe6t02tZvWI9WbPufcY4uPMW7sx1ZkVZ/8z7pYrWOMPH4FsXrbs0anz/AVoR/51DOBHVxwNvP178effUAMPnopY7z9BDx0DGIPaiFxBxkPdaUK1Zms3WE79VLkSxnM/eAVRusQbqWiVvhb2PkkPfG8kBXMfSWG0gShe9xWmv3KF93KTcHalS+D6Gp3TFMSn7af+K6hJrFdvRZRcsGBMtjt98/FFXFGDyL0eSkBA5QoarG1D6CRlIIrfpOONuCgBxXOI+OgUD1JPTC5LAyVWIIohXZRw5fAY3F3bhinhYFq7oQP4SDrjjsTLgN//ED3XMeCzAUjE5Jy0uffY2dl37xbPYQfj00IIE4fHGM/MCrC6ZRvo4jkEwtkFomhZPBe/7aQIYlG2w1O4ns1Dqgc56LOlzaoBEK/e4vratj2MDx/lkYOcXMkVZFSTyxDLzr6sl+KihNESpUu8fW0bysK09RclOAzPX6CTpU0fodUk1ps9l1Wt3diahTO8IzGLi7kCfrSEXM2hrlUgCumkM5jS9TX8D6p6cssS7o0onkNp1SJWW9h1vEwMTwmN2sIQCvWoLuGjZ3b7SEpGPjxl31I8eiZtlKx1DFPpEo4dZ60WMxir8goePasSHTVu5yAkxt96vXMQMk9nnHcHkDnthsmG/c/yopaQvW0iKXnk3QG41TdaNSoOLJSQxSKyeVxs7cbb0xnxrYMx1z1d3cIA2IbutTU1wodYuQL2pbKK2nhtW5aK70jOoWuLWNzQxXO4ZS0hMJq+s2qLnqS9P+qjQWJpn1zpk6JLo6EJuTUyL4MPxmDXtDG3ELXvmz17AIr4tMwiGMN2t4IAc1LlikxfdxpBA92TFB+uJwlX3dyTdPJIBbW59FnvPIQYr69hyrnhGWHwvZPLroS5WJzaQQ4X23slIFjalFdwMNSIFGPHgLvnVbxmiBaMiaWaWREnh6tP0tPzjqSq5OBDLHrrpBE38fii211rN94Rn8Zsdf7mzjspYjkZMPLxX38TvdXajQX2vrEWGiSWCcqUPKBTxdnufZIRtoVlDLwen8ak2nshF+8AFBu7Li8p00gK89rYdW0EXz2+KLqctN7YRURCTU8JJGbRbHULLTmR9l4IKp3BVlzbxg91CnuS+HN8UUg/vijMYCdEKCFDau/FSmvwQcKpA1e5Etfw5Q4U2LsDjF9HReJaLiztTGJWXM8PH4WLgSg0SzYPJrzckW3c2l3lodrEWtp06U+mk1XBGLTi8JRY/YV1DLF/zKXU3V9klOWKEKtjACKmztAr7b2YknflfPHVxBpfFB50DlZZH8qlc1BUTjZfrysL6Yy0NPN2gShGOLksNC2eu8rS8rtVZap6UM3aFoafZ9rWoYkqAul1bo/2XryU8zI1Lrta3ZLG6m6qD+QNzxOzaGPuKxUvt6UGQLoJvVPb2Zf2D566SquKWIyPVA/R0aOyaQtLdydFcZapbJVYfOrNHkavnXA3TC5jW9fxcmqhQWJ5fR2uIhdA/dmNXRF0W1gCEZppSqSRRFQ2L8lMTaZw4i0h0c1//u0uM3VMuSKyVllpAGGGJmrT2dgilumSq0dI9zExi8c7BsQ5awuLeHf2hf39Y+6z5QpePbmMiY/MYy59o2jW3gu1xzaf/3HFu7AuT/GW6tH+MTw7Mu/i3mNZbo0Sqoil6opsKJ6LjqGiS8yCT3y+LYzB5QrCd7Z5/R4iUM1sOhAHOeyklpAotgaV1lcTqycpYrUMnGli2DmdGO28DkwHgiYgMSsjoUD2PmE5ybZgzBUxcXQq0tdhmxrLmohFLBPpjNziPqcfff+J5Fop+YuS7JlA1NXE2Tw0EH38Ow8Fap264tJMiRWIVjmdqnTu/oKntAeCXnxrN7YW21cRq29U5EJTzUxV4QxCOTzGn9m8K0d6KofHcpcJAmawuGWVcG1h2TeMotvCNdOJCq6iKXpvHsvrvBNLmyJfbg9zwZh34BSGJoQBput6I8qVKh6/2UMPlPXSpuw0rgpPHVQJffgorwtExfVunFjmBDn9QBTLvLAu8mQz2jVmYXqSuK5Gn4vLpQkl8CDTE8NTaE+rx2ZKrPZeO6+h23Vowln/Cz0o1rblh3p4LrFMh2NkHqxPzoH4RHIOezSbx+ACUZA0OYcJj8yLXqXapELuHMTu7BwUwRG09CPz2DHqU1tY2qzao6/fYybksboOXmLpepQuxROiXO49tsM3rqVaK9PE1wczLJYSMg2cjpBa0LJBTIKQc/ceY6/6+lgKJZZGtSYePcMjHQOiAtXsUlx8hRl7cf8rXdRGqzNqEsv0sSxiaTKvK26fT2Tztt1wicU8IXcDE2tUldRydx5ilOUKek/MYjE2doVnCroOpUu8g+P+/I87eW5T9WHN3AnxZk/EEUmBHzMrskjq8HlnHklhJAwpHj0Tu6Bx8sudqv45c01/KP9Ue9cBz3w6BkCXyWXIanULIzS9SY4wnXGjQsZ0C+tiChjNaOhUh1imp5/OYC3IWkp1dUvuUv+pe1S5knyE5czxXWrgxhdFj27suqvTiMaivaIh6hyEHKioGJlZ7oRLLJ1M5yDeyhjKPC0ZmsD4uNsuSvi9sQsroA2YPIxP49m+UUygeC4pMQ5F3S/fKIyBOofO9B0F1BKSYJjMsOJh78Fiazfe5c2wE6pjzDHfiFBC0ksaDPKHXqHCJngCqLfME89Hz9yd7TWFCgb2pAhTPGZSVPWuedhlaiBuLSsiiU+74n3wtOrYzWRnHWIxncl5cY00S8ffpkZ3iWUll01toSvBVx4ei1bUBeb8+SBn2xLCnxclmaQmP/rHZEyaODGxsC5aR9ExUJUdIbF035jDownoSULQtQ6SCe4wrihjqxuRK2DAeqSoYDy1/pfdfmHdPQdkMx6zmvbipCi7zkssPRMz5cBlI4EYDHJRzBOV/c8iCk0Z6hsvSuCWMpUpzXRGBqkaS9VSIOpDLJK+f0yWlWMLxiB2qyrEJRZdM/ocxXPp3eQNzWJLCFJOzokn6CWWhlr8s3AmoLvDLeXNhSiK5/AVFtYx55c7ktcwUa4g/vJi/7PtUdVC4QzS4VO+rl4tlCt4kDnMdAYmiUl8X5QrCH7XtoE///ZPZxzk0MOHj/47gaJY3cKaeZ1FHv/7un11+szmIdXVLTklvChJP8pOFe+Hj/5jJnIFjGp1C735ngK7xKJ5pi45OrVZlZjFJF+/F2Jq+sRLLC1XUp8sPo32QxMYPeOy+gdz/xLe7MM3wXfq9keFD7FG5sXcEIzbF9bl3JtbkGk6X43FI3EmeU+KuKWB5Ov30Pnfm1i+KF3ijf1jGCTDon9DlDp1SE0QLrGUKxqskjF3fwEzqPQ0TtSks/o6dAP7RqGxWMHCWlBqNXqIBzkch5FY1mEFUbmCYutJ4tlaRXlfByZ76fxZIVgT3wMusdSlDcZgDYenhDHUWEubMIIMpMk8E3d/EW7xlP7dARxV7yn1SVGSeBqdeol1/4ksP5OovoqBFQRdcTSm9+3rKlGv8JYm8fUwpInvChCLi2e51WZM2xKSPEokhTY7+2LvtCJPSUmt8O4A+kaLbrmcjDs0e+u7uszEsL2ZYrBQrkjw2BKSON+3mQmTWJprbeL7wdVYr95C6ExyMOggJ/TINpsHhyIpWLTf/0B6Ij4NVK5cXz4QlZIsZsWoybQw4+jU1V6+ZYea4tMjIy9jCmcYgEb+TC5wbGazvU8YNuskD3LYA5oTJ7G8PTfxDeESq3AmeVieN1+U8Lu9V/LXrChi8QIPKOhvBaK4MjwF5dEWRg+Hx3DSvcmIbB7ahUlFFuR40QixhiZEj2pswZyK5lEKZ9JGE6f8vELzIE1i3QKqDqFZ1MvVKpxhr/MkVT/UCcZk/VhJx5bFc6iNUALNsnmoJZ4zkltmLYeSxtfBapBYkRQ4bVK2tRtXuAGK5xiJ1kObOWJVwE1TeAuoIpZZsUTfWWstNM0fjGHxknOiNjoHJYfJZBozv3x2ZkXo2N6LfsxvFmpVEzRCrLVtuIM8DGnvhXJijSVtq1arsvBrYxdadmReWMUyhCaxbgFVxDIrZ9p7wRKNBE27xkyrOu889+4YEL+Hp3VUUatb+M1vafRcrE7NTCPEspqZznvp0nWkrHJCstwqlGji+8EmFktdzeIvxncmsVg6bYKnWppc0CKFkyJYqEfavOU9pVE0SCwtOlNi0XP3Vmlq+ZTWjTSJdTuwicUyBy1HZlHR8xe4oi6zVVOg7peCze48lPNjRojs0KwC8MIklu8pNVGu2MRisurdgYzEezJ/UXJPhZvEugX4EKtckfpDk1sbu/hT/XEzL8p/TUqRajyx1zqIRr7r9WoszXyaH3R7iUWNxZN5M1mlBZxmeWCTWLcAH2LRcGjRXFsYi50rYIXoBfNIx9JSVAZUbMNTCCovSlVfkvWN+ufHTXiJ5QuTWPx6US2mfnnXk6w6nFd+N4l1O/AnFnc/v4Klv9XeK5WH/Parf0zy8hrSdw6COumMFHgsrMuD+rW799sjL5RYrGlkqaqJxKxUGurJ5oOnUsfCo+WZFYk26CM+f4GRsNa+GRXeJmoSix+WaAU++dExANdH/1OQo1Pwj7krtTgsKVZ/n+nWG3UVYRbXmhlOs0aUaYWFdbcekmc7DAMrV/hhVaKaDmKTWLeDesTiOk0uy3rowvAD2f4x2JfxRTQYmcdy8vMjPclmIt5bG1kH/A9YzE/KLGtr5sAml0UzET1J8bTKFYzq3mP31r3HUGn8gLNJrNvBDcQisnm4TeqVq57w1purnugYANsaLOk0sf8ZwR3LGn1hKr+jU0QVa9uwg1a540kRxwZr22jAWsqDnHxa7lta2cS3RUPEIvgdcCgB9pjfFBD8k/+pwfMX9ZJVTfwM+AJiKVjHN7ksZcfxafyYWcFpXa2zmiZ+NnwZsXzz4F402KyJHxhfRiwTZt13swa8CQtfT6wmmqiD/wHgGpeYg+zukgAAAABJRU5ErkJggg==";

            String imagePath = @".Support\SampleDocuments\JDV Software Logo.png";

            using (Image image = Image.FromFile(imagePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    Byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    String base64String = Convert.ToBase64String(imageBytes);

                    Assert.That(base64String, Is.EqualTo(expectedBase64String));
                }
            }
        }
    }
}
