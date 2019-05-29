﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using ThanksCardClient.Services;
using Newtonsoft.Json;

namespace ThanksCardClient.Models
{
    public class Tag : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */


        #region IdProperty
        private long _Id;

        public long Id
        {
            get
            { return _Id; }
            set
            { 
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region NameProperty
        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async Task<List<Tag>> GetTagsAsync()
        {
            IRestService rest = new RestService();
            List<Tag> tags  = await rest.GetTagsAsync();
            return tags;
        }

        public async Task<Tag> PostTagAsync(Tag tag)
        {
            IRestService rest = new RestService();
            Tag createdTag = await rest.PostTagAsync(tag);
            return createdTag;
        }

        public async Task<Tag> PutTagAsync(Tag tag)
        {
            IRestService rest = new RestService();
            Tag updatedTag = await rest.PutTagAsync(tag);
            return updatedTag;
        }

        public async Task<Tag> DeleteTagAsync(long Id)
        {
            IRestService rest = new RestService();
            Tag deletedTag = await rest.DeleteTagAsync(Id);
            return deletedTag;
        }
    }
}
