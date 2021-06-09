using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class OverallCardListDetailViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        #region ThanksCardsProperty
        private ThanksCard _ThanksCards;
        public ThanksCard ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public OverallCardListDetailViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCards = navigationContext.Parameters.GetValue<ThanksCard>("SelectedOverallCardListDetail");

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}