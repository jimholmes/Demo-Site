using Telerik.TestingFramework.Controls.KendoUI;
using Telerik.WebAii.Controls.Html;
using Telerik.WebAii.Controls.Xaml;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ArtOfTest.Common.UnitTesting;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Controls.HtmlControls.HtmlAsserts;
using ArtOfTest.WebAii.Design;
using ArtOfTest.WebAii.Design.Execution;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Silverlight;
using ArtOfTest.WebAii.Silverlight.UI;

using SupportApi;
using WebApi.Models;



namespace Code_In_Your_Projects
{

    public class ____Much_Better_Test : BaseWebAiiTest
    {
        #region [ Dynamic Pages Reference ]

        private Pages _pages;

        /// <summary>
        /// Gets the Pages object that has references
        /// to all the elements, frames or regions
        /// in this project.
        /// </summary>
        public Pages Pages
        {
            get
            {
                if (_pages == null)
                {
                    _pages = new Pages(Manager.Current);
                }
                return _pages;
            }
        }

        #endregion
        
        // Add your test methods here...
 
    
        int id = 0;
        
        [CodedStep(@"New Coded Step")]
        public void _2__A_Little_Better_Test_CodedStep()
        {
            id = DataHelpers.create_new_contact();
            Log.WriteLine("ID: " + id);
            SetExtractedValue("new_id",id);
        }
    
        [CodedStep(@"New Coded Step")]
        public void _3__Much_Better_Test_CodedStep()
        {
            Contact updated= DataHelpers.get_contact_by_id(id);
            string region = updated.Region;
            Assert.AreEqual("Pacific Northwest", region);
        }
    }
}
