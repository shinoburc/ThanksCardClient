using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardListViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        IRestService service = new RestService();

        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        #region ThanksCardsLoginUserProperty
        private List<ThanksCard> _UThanksCards;
        public List<ThanksCard> UThanksCards
        {
            get { return _UThanksCards; }
            set { SetProperty(ref _UThanksCards, value); }
        }
        #endregion

        public ThanksCardListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
            this.UThanksCards = await service.GetThanksCardsAsync();
            User AuthorizedUser = SessionService.Instance.AuthorizedUser;
            UThanksCards = UThanksCards.Where(x => x.ToId == AuthorizedUser.Id).ToList();

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        
        #region ShowDetailCommand
        private DelegateCommand<ThanksCard> _ShowDetailCommand;
        public DelegateCommand<ThanksCard> ShowDetailCommand =>
            _ShowDetailCommand ?? (_ShowDetailCommand = new DelegateCommand<ThanksCard>(ExecuteShowDetailCommand));

        void ExecuteShowDetailCommand(ThanksCard SelectedDetail)
        {

            // 対象のThanksCardをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedDetail", SelectedDetail);
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Detail), parameters);
        }
        #endregion*
    }
}