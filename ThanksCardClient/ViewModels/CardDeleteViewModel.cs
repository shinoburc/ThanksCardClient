using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class CardDeleteViewModel : BindableBase, INavigationAware
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

        public CardDeleteViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
        }

        private async void UpdateCards()
        {
            var card = new ThanksCard();
            this.ThanksCards = await card.GetThanksCardsAsync();
        }

        private void UpdateCard()
        {
            throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region CardDeleteCommand
        private DelegateCommand<ThanksCard> _CardDeleteCommand;
        public DelegateCommand<ThanksCard> CardDeleteCommand =>
            _CardDeleteCommand ?? (_CardDeleteCommand = new DelegateCommand<ThanksCard>(ExecuteCardDeleteCommand));

        async void ExecuteCardDeleteCommand(ThanksCard SelectedUser)
        {
            ThanksCard deletedUser = await SelectedUser.DeleteThanksCardAsync(SelectedUser.Id);

            // ユーザ一覧 Users を更新する。
            this.UpdateCards();
        }
        #endregion

    }
}
