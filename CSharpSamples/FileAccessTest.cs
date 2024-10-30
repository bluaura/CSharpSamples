using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace CSharpSamples
{
    class FileAccessTest
    {
        static public void CheckFileAccess(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            FileSecurity fileSecurity = fileInfo.GetAccessControl();
            WindowsIdentity identity = WindowsIdentity.GetCurrent();

            bool hasReadPermission = HasAccess(fileSecurity, identity, FileSystemRights.Read);
            bool hasWritePermission = HasAccess(fileSecurity, identity, FileSystemRights.Write);
            bool hasExecutePermission = HasAccess(fileSecurity, identity, FileSystemRights.ExecuteFile);

            Console.WriteLine($"읽기 권한: {hasReadPermission}");
            Console.WriteLine($"쓰기 권한: {hasWritePermission}");
            Console.WriteLine($"실행 권한: {hasExecutePermission}");
        }

        static bool HasAccess(FileSecurity fileSecurity, WindowsIdentity identity, FileSystemRights rights)
        {
            AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(SecurityIdentifier));

            foreach (FileSystemAccessRule rule in rules)
            {
                if (identity.User.Equals(rule.IdentityReference) || identity.Groups.Contains(rule.IdentityReference))
                {
                    if ((rule.FileSystemRights & rights) == rights)
                    {
                        return rule.AccessControlType == AccessControlType.Allow;
                    }
                }
            }
            return false;
        }
    }
}
