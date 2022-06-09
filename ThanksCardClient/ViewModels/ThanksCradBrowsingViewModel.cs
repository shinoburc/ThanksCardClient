#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCradBrowsingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        public ThanksCradBrowsingViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            this._SearchWord = this.AuthorizedUser.Name;
        }
        #region roginuser
        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }
        #endregion
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

        #region UsersProperty
        private List<User> _Users;
        public List<User> Users
        {
            get { return _Users; }
            set { SetProperty(ref _Users, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion


        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;
        public List<ThanksCard> ThanksCards
        {
            get { return _ThanksCards; }
            set { SetProperty(ref _ThanksCards, value); }
        }
        #endregion

        public ThanksCradBrowsingViewModel(RegionManager regionManager)
        {
            this.regionManager = regionManager;
        }


        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            this.ThanksCard = navigationContext.Parameters.GetValue<ThanksCard>("SelectedThanksCard");

            User user = new User();
            this.Users = await user.GetUsersAsync();

            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region  MenuUserCommand
        private DelegateCommand _MenuUserCommand;
        public DelegateCommand MenuUserCommand =>
            _MenuUserCommand ?? (_MenuUserCommand = new DelegateCommand(ExecuteMenuUserCommand));

        void ExecuteMenuUserCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
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


        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion
        #region DownloadfileCommand
        private DelegateCommand<ThanksCard> _DownloadfileCommand;
        public DelegateCommand<ThanksCard> DownloadfileCommand =>
            _DownloadfileCommand ?? (_DownloadfileCommand = new DelegateCommand<ThanksCard>(ExecuteDownloadfileCommand));

        async void ExecuteDownloadfileCommand(ThanksCard SelectedThanksCard)
        {
            ThanksCard thanksCard = await SelectedThanksCard.DownloadfileAsync(SelectedThanksCard.Id);
            string str = "タイトル：" + thanksCard.Title + "\n本文:" + thanksCard.Body;
            Encoding encoding = Encoding.UTF8;
            byte[] Bytes = encoding.GetBytes(str);

            ThanksCardDownload thanksCardDownload = new ThanksCardDownload();
            thanksCardDownload.cardDownload(Bytes);

            //    ThanksCard thanksCard = new ThanksCard();
            //    this.ThanksCards = await thanksCard.GetThanksCardsAsync();

            //    ThanksCards = this.ThanksCards.Where(x => x.Id == Id).ToList();

            //    thanksCard = await ThanksCard.DownloadfileAsync(ThanksCard.Id);

        }
        #endregion
    }
}
