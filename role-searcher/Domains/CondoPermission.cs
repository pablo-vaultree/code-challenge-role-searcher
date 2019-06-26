using System;
using System.Collections.Generic;
using System.Linq;

namespace role_searcher.Domains
{
    public class CondoPermission
    {
        public CondoPermission()
        {
            Permissions = new List<Permission>();
        }

        public int Condo { get; set; }

        public List<Permission> Permissions { get; internal set; }

        public void AddPermisson(Permission newPermission)
        {
            var existingPermission = Permissions
                .FirstOrDefault(p => p.Functionality == newPermission.Functionality);

            if (existingPermission == null)
            {
                Permissions.Add(newPermission);
                return;
            }

            if (NewPermissonHasGreaterPriority(existingPermission, newPermission))
            {
                Permissions.Remove(existingPermission);
                Permissions.Add(newPermission);
            }
        }

        public bool NewPermissonHasGreaterPriority(Permission existingPermission, Permission newPermission) => 
            newPermission.Role > existingPermission.Role;
    }
}
