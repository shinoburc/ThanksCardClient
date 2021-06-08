using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class DepartmentChildren : BindableBase
    {
        #region IdProperty
        private long _Id;
        public long Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }
        #endregion

        #region NameProperty
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }
        #endregion

        #region DepartmentIdProperty
        private long? _DepartmentId;
        public long? DepartmentId
        {
            get { return _DepartmentId; }
            set { SetProperty(ref _DepartmentId, value); }
        }
        #endregion

        #region DepartmentProperty
        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
        }
        #endregion

        #region CodeProperty
        private int _Code;
        public int Code
        {
            get { return _Code; }
            set { SetProperty(ref _Code, value); }
        }
        #endregion

        public async Task<DepartmentChildren> LogonAsync()
        {
            IRestService rest = new RestService();
            DepartmentChildren authorizedDepartmentChildren = await rest.LogonAsync(this);
            return authorizedDepartmentChildren;
        }

        public async Task<List<DepartmentChildren>> GetDepartmentDepartmentChildrensAsync(long? DepartmentId)
        {
            IRestService rest = new RestService();
            List<DepartmentChildren> departmentChildrens = await rest.GetDepartmentDepartmentChildrensAsync(DepartmentId);
            return departmentChildrens;
        }

        public async Task<List<DepartmentChildren>> GetDepartmentChildrensAsync()
        {
            IRestService rest = new RestService();
            List<DepartmentChildren> departmentChildrens = await rest.GetDepartmentChildrensAsync();
            return departmentChildrens;
        }

        public async Task<DepartmentChildren> PostDepartmentChildrenAsync(DepartmentChildren departmentChildren)
        {
            IRestService rest = new RestService();
            DepartmentChildren createdDepartmentChildren = await rest.PostDepartmentChildrenAsync(departmentChildren);
            return createdDepartmentChildren;
        }

        public async Task<DepartmentChildren> PutDepartmentChildrenAsync(DepartmentChildren departmentChildren)
        {
            IRestService rest = new RestService();
            DepartmentChildren updatedDepartmentChildren = await rest.PutDepartmentChildrenAsync(departmentChildren);
            return updatedDepartmentChildren;
        }

        public async Task<DepartmentChildren> DeleteDepartmentChildrenAsync(long Id)
        {
            IRestService rest = new RestService();
            DepartmentChildren deletedDepartmentChildren = await rest.DeleteDepartmentChildrenAsync(Id);
            return deletedDepartmentChildren;
        }
    }
}
