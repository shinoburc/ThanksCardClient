#nullable disable
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

        #region roginuser
        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }
        #endregion

        public ThanksCardListViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            //this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            //this._SearchWord = this.AuthorizedUser.Name;
            //追加したらログインしたユーザーが自動生成される
        }

        #region SearchWordProperty
        private string _SearchWord;
        public string SearchWord
        {
            get { return _SearchWord; }
            set
            {
                SetProperty(ref _SearchWord, value);
                System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion

        //
        #region LoginUserProperty
        private string _LoginUser;
        public string LoginUser
        {
            get { return _LoginUser; }
            set
            {
                SetProperty(ref _LoginUser, value);
            //    System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion

        #region SearchThanksCardProperty
        private SearchThanksCard _SearchThanksCard;
        public SearchThanksCard SearchThanksCard
        {
            get { return _SearchThanksCard; }
            set { SetProperty(ref _SearchThanksCard, value); }
        }
        #endregion

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
            this.SearchThanksCard = new SearchThanksCard();
            //this.SearchThanksCard.SearchWord = this.AuthorizedUser.Name;
            //ThanksCards = await thanksCard.PostSearchThanksCardsAsync(SearchThanksCard);
            //追加したらログインしたユーザーが自動生成される
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitSearchCommand
        private DelegateCommand<string> _SubmitSearchCommand;
        public DelegateCommand<string> SubmitSearchCommand =>
            _SubmitSearchCommand ?? (_SubmitSearchCommand = new DelegateCommand<string>(ExecuteSubmitSearchCommand));

        async void ExecuteSubmitSearchCommand(string parameter)   
        {
            ThanksCard thanksCard = new ThanksCard();
            this.SearchThanksCard = new SearchThanksCard();
            this.SearchThanksCard.SearchWord = parameter;
            ThanksCards = await thanksCard.PostSearchThanksCardsAsync(SearchThanksCard);
        }
        #endregion

        #region  ThanksCardCommand
        private DelegateCommand _ThanksCardCommand;


        public DelegateCommand ThanksCardCommand =>
            _ThanksCardCommand ?? (_ThanksCardCommand = new DelegateCommand(ExecuteThanksCardCommand));

        void ExecuteThanksCardCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  HitCommand
        private DelegateCommand _HitCommand;


        public DelegateCommand HitCommand =>
            _HitCommand ?? (_HitCommand = new DelegateCommand(ExecuteHitCommand));

        void ExecuteHitCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Hit));
        }
        #endregion

        #region  ThankCardListCommand
        private DelegateCommand _ThankCardListCommand;


        public DelegateCommand ThankCardListCommand =>
            _ThankCardListCommand ?? (_ThankCardListCommand = new DelegateCommand(ExecuteThankCardListCommand));

        void ExecuteThankCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region  MenuUserCommand
        private DelegateCommand _MenuUserCommand;


        public DelegateCommand MenuUserCommand =>
            _MenuUserCommand ?? (_MenuUserCommand = new DelegateCommand(ExecuteMenuUserCommand));

        void ExecuteMenuUserCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

        #region  ThanksCradBrowsingCommand
        private DelegateCommand<ThanksCard > _ThanksCradBrowsingCommand;
        public DelegateCommand<ThanksCard> ThanksCradBrowsingCommand =>
            _ThanksCradBrowsingCommand ?? (_ThanksCradBrowsingCommand = new DelegateCommand<ThanksCard>(ExecuteThanksCradBrowsingCommand));

        void ExecuteThanksCradBrowsingCommand(ThanksCard SelectedThanksCard)
        {
            // 対象のSelectedThanksCardをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedThanksCard", SelectedThanksCard);
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCradBrowsing), parameters);
        }
        #endregion

        #region DeleteThankCardCommand
        private DelegateCommand<ThanksCard> _DeleteThankCardCommand;
        public DelegateCommand<ThanksCard> DeleteThankCardCommand =>
            _DeleteThankCardCommand ?? (_DeleteThankCardCommand = new DelegateCommand<ThanksCard>(ExcuteDeleteThankCardCommand));

        async void ExcuteDeleteThankCardCommand(ThanksCard SelectedThanksCard)
        {
            ThanksCard thanksCard = await SelectedThanksCard.DeleteThanksCardAsync(SelectedThanksCard.Id);
            //this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
            
        }
        #endregion

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion
    }
}