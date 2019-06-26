using role_searcher.Databases;
using role_searcher.Domains;
using System.Collections.Generic;
using System.Linq;

namespace role_searcher.Searchers
{
    public class UserCondoPermissionsSearcher
    {
        private readonly IDatabase _database;

        public UserCondoPermissionsSearcher(IDatabase database)
        {
            _database = database;
        }

        public List<CondoPermission> Search(string email)
        {
            var user = FindUser(email);
            var condoPermissons = FindCondoPermissons(user);

            return condoPermissons;
        }

        private User FindUser(string email) =>
            _database.Users.FirstOrDefault(u => u.Email == email);

        private Group FindGroup(GroupType groupType, int condo) =>
            _database.Groups.FirstOrDefault(g => g.GroupType == groupType && g.Condo == condo);

        private List<CondoPermission> FindCondoPermissons(User user)
        {
            var condoPermissons = new List<CondoPermission>();

            foreach (var userGroup in user.Groups)
            {
                var group = FindGroup(userGroup.GroupType, userGroup.Condo);

                var condoPermisson = condoPermissons.FirstOrDefault(c => c.Condo == group.Condo);
                if (condoPermisson == null)
                {
                    condoPermisson = new CondoPermission
                    {
                        Condo = group.Condo
                    };

                    condoPermissons.Add(condoPermisson);
                }

                foreach (var permission in group.Permissions)
                    condoPermisson.AddPermisson(permission);
            }

            return condoPermissons;
        }
    }
}
