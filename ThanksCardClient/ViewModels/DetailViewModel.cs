using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class DetailViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region ThanksCardsProperty
        private ThanksCard _UThanksCards;
        public ThanksCard UThanksCards
        {
            get { return _UThanksCards; }
            set { SetProperty(ref _UThanksCards, value); }
        }
        #endregion

        public DetailViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 画面遷移元から送られる SelectedDeteil パラメーターを取得。
            this.UThanksCards = navigationContext.Parameters.GetValue<ThanksCard>("SelectedDetail");

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

