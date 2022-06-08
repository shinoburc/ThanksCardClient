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
    public class RankViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region RanksProperty
        private List<Rank> _Ranks;
        public List<Rank> Ranks
        {
            get { return _Ranks; }
            set { SetProperty(ref _Ranks, value); }
        }
        #endregion

        public RankViewModel(IRegionManager regionManager)
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
        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

        #region  ThanksCradCreateCommand
        private DelegateCommand _ThanksCradCreateCommand;


        public DelegateCommand ThanksCradCreateCommand =>
            _ThanksCradCreateCommand ?? (_ThanksCradCreateCommand = new DelegateCommand(ExecuteThanksCradCreateCommand));

        void ExecuteThanksCradCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  ThanksCradListCommand
        private DelegateCommand _ThanksCradListCommand;


        public DelegateCommand ThanksCradListCommand =>
            _ThanksCradListCommand ?? (_ThanksCradListCommand = new DelegateCommand(ExecuteThanksCradListCommand));

        void ExecuteThanksCradListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region  MenuAdminCommand
        private DelegateCommand _MenuAdminCommand;


        public DelegateCommand MenuAdminCommand =>
            _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteMenuAdminCommand));

        void ExecuteMenuAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion

        #region  HitAdminCommand
        private DelegateCommand _HitAdminCommand;


        public DelegateCommand HitAdminCommand =>
            _HitAdminCommand ?? (_HitAdminCommand = new DelegateCommand(ExecuteHitAdminCommand));

        void ExecuteHitAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HitAdmin));
        }
        #endregion

        private async void UpdateRank()
        {
            Rank rank = new Rank();
            this.Ranks = await rank.GetRanksAsync();
        }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateRank();
            //throw new NotImplementedException();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            //throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }
    }
}
