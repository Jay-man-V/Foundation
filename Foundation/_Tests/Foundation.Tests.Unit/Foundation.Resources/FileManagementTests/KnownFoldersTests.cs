//-----------------------------------------------------------------------
// <copyright file="KnownFoldersTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
using System.Runtime.InteropServices;

using Foundation.Interfaces;
using Foundation.Resources;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.FileManagementTests
{
    /// <summary>
    /// Unit Tests for Known Folders class
    /// </summary>
    [TestFixture]
    public class KnownFoldersTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="KnownFolders"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            //IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            //Int32 testMethodCount = testMethods.Count();

            //// This test exists to ensure all the Properties are tested/checked in the next test
            //Type theType = typeof(KnownFolders);
            //PropertyInfo[] propertyInfos = theType.GetProperties();

            //Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount - 1));

            //Int32 index = 0;
            //Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(KnownFolders.)));
            //Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(KnownFolders.TextFiles)));
            //Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(KnownFolders.CsvFiles)));
            //Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(KnownFolders.ExcelFiles)));
            //Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(KnownFolders.WordFiles)));

            //Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_KnownFolderFlags()
        {
            // This test exists to ensure all the Application Role are tested/checked in the next test
            FieldInfo[] fieldInfos = GetFieldInfosForType(typeof(KnownFolders.KnownFolderFlags));

            Int32 index = 0;

            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.SimpleIdList, Is.EqualTo(256L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.NotParentRelative, Is.EqualTo(512L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.DefaultPath, Is.EqualTo(1024L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.Init, Is.EqualTo(2048L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.NoAlias, Is.EqualTo(4096L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.DoNotUnExpand, Is.EqualTo(8192L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.DoNotVerify, Is.EqualTo(16384L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.Create, Is.EqualTo(32768L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.NoAppContainerRedirection, Is.EqualTo(65536L));
            index++; Assert.That((UInt32)KnownFolders.KnownFolderFlags.AliasOnly, Is.EqualTo(2147483648L));

            Assert.That(fieldInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetPath()
        {
            String loggedOnUser = Environment.UserName;

            String expectedContacts = $@"C:\Users\{loggedOnUser}\Contacts";
            String expectedDesktop = $@"C:\Users\{loggedOnUser}\OneDrive\Desktop";
            String expectedDocuments = $@"C:\Users\{loggedOnUser}\OneDrive\Documents";
            String expectedDownloads = $@"C:\Users\{loggedOnUser}\Downloads";
            String expectedFavorites = $@"C:\Users\{loggedOnUser}\Favorites";
            String expectedLinks = $@"C:\Users\{loggedOnUser}\Links";
            String expectedMusic = $@"C:\Users\{loggedOnUser}\Music";
            String expectedPictures = $@"C:\Users\{loggedOnUser}\OneDrive\Pictures";
            String expectedSavedGames = $@"C:\Users\{loggedOnUser}\Saved Games";
            String expectedSavedSearches = $@"C:\Users\{loggedOnUser}\Searches";
            String expectedVideos = $@"C:\Users\{loggedOnUser}\Videos";

            String actualContacts = KnownFolders.GetPath(KnownFolder.Contacts);
            String actualDesktop = KnownFolders.GetPath(KnownFolder.Desktop);
            String actualDocuments = KnownFolders.GetPath(KnownFolder.Documents);
            String actualDownloads = KnownFolders.GetPath(KnownFolder.Downloads);
            String actualFavorites = KnownFolders.GetPath(KnownFolder.Favourites);
            String actualLinks = KnownFolders.GetPath(KnownFolder.Links);
            String actualMusic = KnownFolders.GetPath(KnownFolder.Music);
            String actualPictures = KnownFolders.GetPath(KnownFolder.Pictures);
            String actualSavedGames = KnownFolders.GetPath(KnownFolder.SavedGames);
            String actualSavedSearches = KnownFolders.GetPath(KnownFolder.SavedSearches);
            String actualVideos = KnownFolders.GetPath(KnownFolder.Videos);

            Assert.That(actualContacts, Is.EqualTo(expectedContacts));
            Assert.That(actualDesktop, Is.EqualTo(expectedDesktop));
            Assert.That(actualDocuments, Is.EqualTo(expectedDocuments));
            Assert.That(actualDownloads, Is.EqualTo(expectedDownloads));
            Assert.That(actualFavorites, Is.EqualTo(expectedFavorites));
            Assert.That(actualLinks, Is.EqualTo(expectedLinks));
            Assert.That(actualMusic, Is.EqualTo(expectedMusic));
            Assert.That(actualPictures, Is.EqualTo(expectedPictures));
            Assert.That(actualSavedGames, Is.EqualTo(expectedSavedGames));
            Assert.That(actualSavedSearches, Is.EqualTo(expectedSavedSearches));
            Assert.That(actualVideos, Is.EqualTo(expectedVideos));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetPath_DefaultUser_False()
        {
            String loggedOnUser = Environment.UserName;

            String expectedContacts = $@"C:\Users\{loggedOnUser}\Contacts";
            String expectedDesktop = $@"C:\Users\{loggedOnUser}\OneDrive\Desktop";
            String expectedDocuments = $@"C:\Users\{loggedOnUser}\OneDrive\Documents";
            String expectedDownloads = $@"C:\Users\{loggedOnUser}\Downloads";
            String expectedFavorites = $@"C:\Users\{loggedOnUser}\Favorites";
            String expectedLinks = $@"C:\Users\{loggedOnUser}\Links";
            String expectedMusic = $@"C:\Users\{loggedOnUser}\Music";
            String expectedPictures = $@"C:\Users\{loggedOnUser}\OneDrive\Pictures";
            String expectedSavedGames = $@"C:\Users\{loggedOnUser}\Saved Games";
            String expectedSavedSearches = $@"C:\Users\{loggedOnUser}\Searches";
            String expectedVideos = $@"C:\Users\{loggedOnUser}\Videos";

            Boolean defaultUser = false;

            String actualContacts = KnownFolders.GetPath(KnownFolder.Contacts, defaultUser);
            String actualDesktop = KnownFolders.GetPath(KnownFolder.Desktop, defaultUser);
            String actualDocuments = KnownFolders.GetPath(KnownFolder.Documents, defaultUser);
            String actualDownloads = KnownFolders.GetPath(KnownFolder.Downloads, defaultUser);
            String actualFavorites = KnownFolders.GetPath(KnownFolder.Favourites, defaultUser);
            String actualLinks = KnownFolders.GetPath(KnownFolder.Links, defaultUser);
            String actualMusic = KnownFolders.GetPath(KnownFolder.Music, defaultUser);
            String actualPictures = KnownFolders.GetPath(KnownFolder.Pictures, defaultUser);
            String actualSavedGames = KnownFolders.GetPath(KnownFolder.SavedGames, defaultUser);
            String actualSavedSearches = KnownFolders.GetPath(KnownFolder.SavedSearches, defaultUser);
            String actualVideos = KnownFolders.GetPath(KnownFolder.Videos, defaultUser);

            Assert.That(actualContacts, Is.EqualTo(expectedContacts));
            Assert.That(actualDesktop, Is.EqualTo(expectedDesktop));
            Assert.That(actualDocuments, Is.EqualTo(expectedDocuments));
            Assert.That(actualDownloads, Is.EqualTo(expectedDownloads));
            Assert.That(actualFavorites, Is.EqualTo(expectedFavorites));
            Assert.That(actualLinks, Is.EqualTo(expectedLinks));
            Assert.That(actualMusic, Is.EqualTo(expectedMusic));
            Assert.That(actualPictures, Is.EqualTo(expectedPictures));
            Assert.That(actualSavedGames, Is.EqualTo(expectedSavedGames));
            Assert.That(actualSavedSearches, Is.EqualTo(expectedSavedSearches));
            Assert.That(actualVideos, Is.EqualTo(expectedVideos));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetPath_DefaultUser_True()
        {
            String loggedOnUser = "Default";

            String expectedContacts = $@"C:\Users\{loggedOnUser}\Contacts";
            String expectedDesktop = $@"C:\Users\{loggedOnUser}\Desktop";
            String expectedDocuments = $@"C:\Users\{loggedOnUser}\Documents";
            String expectedDownloads = $@"C:\Users\{loggedOnUser}\Downloads";
            String expectedFavorites = $@"C:\Users\{loggedOnUser}\Favorites";
            String expectedLinks = $@"C:\Users\{loggedOnUser}\Links";
            String expectedMusic = $@"C:\Users\{loggedOnUser}\Music";
            String expectedPictures = $@"C:\Users\{loggedOnUser}\Pictures";
            String expectedSavedGames = $@"C:\Users\{loggedOnUser}\Saved Games";
            String expectedSavedSearches = $@"C:\Users\{loggedOnUser}\Searches";
            String expectedVideos = $@"C:\Users\{loggedOnUser}\Videos";

            Boolean defaultUser = true;

            String actualContacts = KnownFolders.GetPath(KnownFolder.Contacts, defaultUser);
            String actualDesktop = KnownFolders.GetPath(KnownFolder.Desktop, defaultUser);
            String actualDocuments = KnownFolders.GetPath(KnownFolder.Documents, defaultUser);
            String actualDownloads = KnownFolders.GetPath(KnownFolder.Downloads, defaultUser);
            String actualFavorites = KnownFolders.GetPath(KnownFolder.Favourites, defaultUser);
            String actualLinks = KnownFolders.GetPath(KnownFolder.Links, defaultUser);
            String actualMusic = KnownFolders.GetPath(KnownFolder.Music, defaultUser);
            String actualPictures = KnownFolders.GetPath(KnownFolder.Pictures, defaultUser);
            String actualSavedGames = KnownFolders.GetPath(KnownFolder.SavedGames, defaultUser);
            String actualSavedSearches = KnownFolders.GetPath(KnownFolder.SavedSearches, defaultUser);
            String actualVideos = KnownFolders.GetPath(KnownFolder.Videos, defaultUser);

            Assert.That(actualContacts, Is.EqualTo(expectedContacts));
            Assert.That(actualDesktop, Is.EqualTo(expectedDesktop));
            Assert.That(actualDocuments, Is.EqualTo(expectedDocuments));
            Assert.That(actualDownloads, Is.EqualTo(expectedDownloads));
            Assert.That(actualFavorites, Is.EqualTo(expectedFavorites));
            Assert.That(actualLinks, Is.EqualTo(expectedLinks));
            Assert.That(actualMusic, Is.EqualTo(expectedMusic));
            Assert.That(actualPictures, Is.EqualTo(expectedPictures));
            Assert.That(actualSavedGames, Is.EqualTo(expectedSavedGames));
            Assert.That(actualSavedSearches, Is.EqualTo(expectedSavedSearches));
            Assert.That(actualVideos, Is.EqualTo(expectedVideos));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_GetPath_Exception()
        {
            KnownFolder knownFolder = KnownFolder.Contacts;

            String expectedMessage = $"Unable to retrieve the known folder path '{knownFolder}'. It may not be available on this system.";
            Int32 expectedErrorCode = -2147024809;
            Exception actualException = null;

            try
            {
                Boolean defaultUser = true;
                KnownFolders.GetPath(knownFolder, KnownFolders.KnownFolderFlags.AliasOnly, defaultUser);
            }
            catch (Exception exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException, Is.InstanceOf<ExternalException>());

            ExternalException eeException = actualException as ExternalException;

            Assert.That(eeException.Message, Is.EqualTo(expectedMessage));
            Assert.That(eeException.ErrorCode, Is.EqualTo(expectedErrorCode));
        }
    }
}
