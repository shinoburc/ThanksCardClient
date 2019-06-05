using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using ThanksCardClient.Models;
using ThanksCardClient.Services;
using System.Collections.ObjectModel;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardCreateViewModel : ViewModel
    {

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;

        public ThanksCard ThanksCard
        {
            get
            { return _ThanksCard; }
            set
            { 
                if (_ThanksCard == value)
                    return;
                _ThanksCard = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FromUsersProperty
        private List<User> _FromUsers;

        public List<User> FromUsers
        {
            get
            { return _FromUsers; }
            set
            {
                if (_FromUsers == value)
                    return;
                _FromUsers = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ToUsersProperty
        private List<User> _ToUsers;

        public List<User> ToUsers
        {
            get
            { return _ToUsers; }
            set
            {
                if (_ToUsers == value)
                    return;
                _ToUsers = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TagsProperty
        private ObservableCollection<Tag> _Tags;

        public ObservableCollection<Tag> Tags
        {
            get
            { return _Tags; }
            set
            { 
                if (_Tags == value)
                    return;
                _Tags = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;

        public List<Department> Departments
        {
            get
            { return _Departments; }
            set
            { 
                if (_Departments == value)
                    return;
                _Departments = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            this.ThanksCard = new ThanksCard();
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.FromUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(null);
                this.ToUsers = this.FromUsers;
            }
            var tag = new Tag();
            this.Tags = await tag.GetTagsAsync();
            var dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;

        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
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
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion

        #region FromDepartmentsChangedCommand
        private ListenerCommand<long> _FromDepartmentsChangedCommand;

        public ListenerCommand<long> FromDepartmentsChangedCommand
        {
            get
            {
                if (_FromDepartmentsChangedCommand == null)
                {
                    _FromDepartmentsChangedCommand = new ListenerCommand<long>(FromDepartmentsChanged);
                }
                return _FromDepartmentsChangedCommand;
            }
        }

        public async void FromDepartmentsChanged(long DepartmentId)
        {
            System.Diagnostics.Debug.WriteLine(DepartmentId);
            this.FromUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(DepartmentId);
        }
        #endregion

        #region ToDepartmentsChangedCommand
        private ListenerCommand<long> _ToDepartmentsChangedCommand;

        public ListenerCommand<long> ToDepartmentsChangedCommand
        {
            get
            {
                if (_ToDepartmentsChangedCommand == null)
                {
                    _ToDepartmentsChangedCommand = new ListenerCommand<long>(ToDepartmentsChanged);
                }
                return _ToDepartmentsChangedCommand;
            }
        }

        public async void ToDepartmentsChanged(long DepartmentId)
        {
            System.Diagnostics.Debug.WriteLine(DepartmentId);
            this.ToUsers = await SessionService.Instance.AuthorizedUser.GetDepartmentUsersAsync(DepartmentId);
        }
        #endregion
    }
}
