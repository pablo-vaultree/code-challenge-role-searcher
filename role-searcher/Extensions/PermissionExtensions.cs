using role_searcher.Domains;
using System.Collections.Generic;

namespace role_searcher.Extensions
{
    public static class PermissionExtensions
    {
        public static string ConvertToParsedString(this List<Permission> permissions)
        {
            var stringfiedPermissons = new List<string>(permissions.Count);

            foreach (var permission in permissions)
                stringfiedPermissons.Add($"({permission.Functionality},{permission.Role.ToString()})");

            var joinedstringfiedPermissons = string.Join(",", stringfiedPermissons);
            var returnBody = $"[{joinedstringfiedPermissons}]";

            return returnBody;
        }
    }
}
