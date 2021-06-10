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

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }


        #region Home2Command
        private DelegateCommand _Home2Command;
        public DelegateCommand Home2Command =>
            _Home2Command ?? (_Home2Command = new DelegateCommand(ExecuteHome2Command));

        void ExecuteHome2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Home2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();

        }
        #endregion
        /*#region CardDeleteCommand
        private DelegateCommand<User> _CardDeleteCommand;
        public DelegateCommand<User> CardDeleteCommand =>
            _CardDeleteCommand ?? (_CardDeleteCommand = new DelegateCommand<User>(ExecuteCardDeleteCommand));

        async void ExecuteCardDeleteCommand(User SelectedUser)
        {
            User deletedUser = await SelectedUser.DeleteUserAsync(SelectedUser.Id);

            // ユーザ一覧 Users を更新する。
            this.UpdateCard();
        }
        #endregion*/
    }
}