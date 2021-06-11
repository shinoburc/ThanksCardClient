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
        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
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
            this.UpdateThanksCards();

        }
        private async void UpdateThanksCards()
        {
            var thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
        #region BackCommand
        private DelegateCommand _BackCommand;
        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));
        void ExecuteBackCommand()
        {
            SessionService.Instance.AuthorizedUser = null;
            SessionService.Instance.IsAuthorized = false;
            // HeaderRegion, FooterRegion を破棄して、ContentRegion をログオン画面に遷移させる。
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Home));
            
        }
        #endregion

        #region board_sort2Command
        private DelegateCommand _board_sort2Command;
        public DelegateCommand board_sort2Command =>
            _board_sort2Command ?? (_board_sort2Command = new DelegateCommand(Executeboard_sort2Command));
        void Executeboard_sort2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.board_sort2));
        }
        #endregion

        #region ThanksCardDeleteCommand
        private DelegateCommand<ThanksCard> _ThanksCardDeleteCommand;
        public DelegateCommand<ThanksCard> ThanksCardDeleteCommand =>
            _ThanksCardDeleteCommand ?? (_ThanksCardDeleteCommand = new DelegateCommand<ThanksCard>(ExecuteThanksCardDeleteCommand));

        async void ExecuteThanksCardDeleteCommand(ThanksCard SelectedThanksCard)
        {
            ThanksCard deletedThanksCard = await SelectedThanksCard.DeleteThanksCardAsync(SelectedThanksCard.Id);

            // ユーザ一覧 ThanksCards を更新する。
            this.UpdateThanksCards();
        }
        #endregion
    }
}