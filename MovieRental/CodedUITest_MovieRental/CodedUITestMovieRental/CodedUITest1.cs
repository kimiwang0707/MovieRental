using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITestMovieRental
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public CodedUITest1()
        {
        }

        [TestMethod]
        public void CodedUITestCustomers()
        {
            // Create a new customer
            this.UIMap.RecordedMethod_CreateCustomer();
            this.UIMap.AssertMethod_CreateCustomer();

            // Search a customer in list
            this.UIMap.RecordedMethod_SearchCustomer();
            this.UIMap.AssertMethod_SearchCustomer();

            // Edit a customer
            this.UIMap.RecordedMethod_EditCustomer();
            this.UIMap.AssertMethod_EditCustomer();

            // Check details of customer
            this.UIMap.RecordedMethod_DetailsCustomer();
            this.UIMap.AssertMethod_DeatilsCustomer();

        }


        [TestMethod]
        public void CodedUITestDirectors()
        {
            // Create a new director

            this.UIMap.RecordedMethod_CreateDirector();
            this.UIMap.AssertMethod_CreateDirector();

            // Search a director in list
            this.UIMap.RecordedMethod_SearchDirector();
            this.UIMap.AssertMethod_SearchDirector();

            // Edit a director
            this.UIMap.RecordedMethod_EditDirector();
            this.UIMap.AssertMethod_EditDirector();

            // Check details of director
            this.UIMap.RecordedMethod_DetailsDirector();
            this.UIMap.AssertMethod_DetailsDirector();

        }

        [TestMethod]
        public void CodedUITestMovies()
        {
            // Create a new movie
            this.UIMap.RecordedMethod_CreateMovie();
            this.UIMap.AssertMethod_CreateMovie();

            // Search a movie in list
            this.UIMap.RecordedMethod_SearchMovie();
            this.UIMap.AssertMethod_SearchMovie();

            // Edit a movie
            this.UIMap.RecordedMethod_EditMovie();
            this.UIMap.AssertMethod_EditMovie();

            // Check details of movie
            this.UIMap.RecordedMethod_DetailsMovie();
            this.UIMap.AssertMethod_DetailsMovie();


        }


        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if (this.map == null)
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
