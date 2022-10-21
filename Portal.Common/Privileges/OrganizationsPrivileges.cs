using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Common.Privileges
{
    public static class OrganizationsPrivileges
    {
        public static readonly Privilege ReadActive = new Privilege(typeof(OrganizationsPrivileges), 1);
        public static readonly Privilege ReadInactive = new Privilege(typeof(OrganizationsPrivileges), 2);
        public static readonly Privilege Create = new Privilege(typeof(OrganizationsPrivileges), 3);
        public static readonly Privilege Deactivate = new Privilege(typeof(OrganizationsPrivileges), 4);
        public static readonly Privilege Reactivate = new Privilege(typeof(OrganizationsPrivileges), 5);
    }
}
