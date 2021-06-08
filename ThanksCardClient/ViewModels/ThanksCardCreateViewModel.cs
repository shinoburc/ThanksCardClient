using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        #region FromUsersProperty
        private List<User> _FromUsers;
        public List<User> FromUsers
        {
            get { return _FromUsers; }
            set { SetProperty(ref _FromUsers, value); }
        }
        #endregion

        #region ToUsersProperty
        private List<User> _ToUsers;
        public List<User> ToUsers
        {
            get { return _ToUsers; }
            set { SetProperty(ref _ToUsers, value); }
        }
        #endregion

        #region DepartmentChildrensProperty
        private List<DepartmentChildren> _DepartmentChildrens;
        public List<DepartmentChildren> DepartmentChildrens
        {
            get { return _DepartmentChildrens; }
            set { SetProperty(ref _DepartmentChildrens, value); }
        }
        #endregion

        #region TagsProperty
        private List<Tag> _Tags;
        public List<Tag> Tags
        {
            get { return _Tags; }
            set { SetProperty(ref _Tags, value); }
        }
        #endregion

        public ThanksCardCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        // この画面に遷移し終わったときに呼ばれる。
        // それを利用し、画面表示に必要なプロパティを初期化している。
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ThanksCard = new ThanksCard();
            
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.FromUsers = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
                this.ToUsers = this.FromUsers;
            }

            var tag = new Tag();
            this.Tags = await tag.GetTagsAsync();

            var dept = new DepartmentChildren();
            this.DepartmentChildrens = await dept.GetDepartmentChildrensAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region FromDepartmentChildrensChangedCommand
        private DelegateCommand<long?> _FromDepartmentChildrensChangedCommand;
        public DelegateCommand<long?> FromDepartmentChildrensChangedCommand =>
            _FromDepartmentChildrensChangedCommand ?? (_FromDepartmentChildrensChangedCommand = new DelegateCommand<long?>(ExecuteFromDepartmentChildrensChangedCommand));

        async void ExecuteFromDepartmentChildrensChangedCommand(long? FromDepartmentChildrenId)
        {
            this.FromUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(FromDepartmentChildrenId);
        }
        #endregion

        #region ToDepartmentChildrensChangedCommand
        private DelegateCommand<long?> _ToDepartmentChildrensChangedCommand;
        public DelegateCommand<long?> ToDepartmentChildrensChangedCommand =>
            _ToDepartmentChildrensChangedCommand ?? (_ToDepartmentChildrensChangedCommand = new DelegateCommand<long?>(ExecuteToDepartmentChildrensChangedCommand));

        async void ExecuteToDepartmentChildrensChangedCommand(long? ToDepartmentChildrenId)
        {
            this.ToUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(ToDepartmentChildrenId);
        }
        #endregion

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            System.Diagnostics.Debug.WriteLine(this.Tags);

            //選択された Tag を取得し、ThanksCard.ThanksCardTags にセットする。
            List<ThanksCardTag> ThanksCardTags = new List<ThanksCardTag>();
            foreach (var tag in this.Tags.Where(t => t.Selected))
            {
                ThanksCardTag thanksCardTag = new ThanksCardTag();
                thanksCardTag.TagId = tag.Id;
                ThanksCardTags.Add(thanksCardTag);
            }
            this.ThanksCard.ThanksCardTags = ThanksCardTags;

            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);

            //TODO: Error handling
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));

        }
        #endregion

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
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion
    }
}
