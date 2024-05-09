#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;

namespace SampleBrowser.Maui.ListView.SfListView
{
    public class ListViewOrientationViewModel
    {
        #region Fields

        private ObservableCollection<PizzaInfo>? pizzaInfo;
        private ObservableCollection<PizzaInfo>? pizzaInfo1;


        #endregion

        #region Constructor

        public ListViewOrientationViewModel()
        {
            GenerateSource();
        }

        #endregion

        #region Properties

        public ObservableCollection<PizzaInfo>? PizzaInfo
        {
            get { return pizzaInfo; }
            set { this.pizzaInfo = value; }
        }

        public ObservableCollection<PizzaInfo>? PizzaInfo1
        {
            get { return pizzaInfo1; }
            set { this.pizzaInfo1 = value; }
        }

        #endregion

        #region Generate Source

        private void GenerateSource()
        {
            PizzaInfoRepository pizzainfo = new();
            pizzaInfo = pizzainfo.GetPizzaInfo();
            pizzaInfo1 = pizzainfo.GetPizzaInfo1();

        }

        #endregion
    }
}
