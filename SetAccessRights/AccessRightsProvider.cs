using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace SetAccessRights
{
    public class AccessRightsProvider
    {
        public void SetRightsToAll()
        {
            string folder = GetExecutionFolder();
            GrantAccess(folder);
            //string folder = GetExecutionFolder();
            //List<string> files = GetAllFiles(folder);

            //foreach (string file in files)
            //{
            //    try
            //    {
            //        SetAccessRights(file);
            //    }
            //    catch
            //    {
            //        // Discard
            //    }
            //}
        }

        private string GetExecutionFolder()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        public void GrantAccess(string fullPath)
        {
            DirectoryInfo dInfo = new DirectoryInfo(fullPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule(new SecurityIdentifier(WellKnownSidType.WorldSid, null), FileSystemRights.FullControl, InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit, PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
        }

        /// <summary>
        /// Returns all files in folder recursively
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //private List<string> GetAllFiles(string path)
        //{
        //    List<string> files = new List<string>();
        //    Stack<string> directoryStack = new Stack<string>();

        //    directoryStack.Push(path);
        //    while (directoryStack.Count > 0)
        //    {
        //        string dir = directoryStack.Pop();

        //        try
        //        {
        //            files.AddRange(Directory.GetFiles(dir, "*.*"));

        //            foreach (string directory in Directory.GetDirectories(dir))
        //            {
        //                directoryStack.Push(directory);
        //            }
        //        }
        //        catch
        //        {
        //            // Discard
        //        }
        //    }

        //    return files;
        //}

        /// <summary>
        /// Set full access rights for specified file
        /// </summary>
        /// <param name="file"></param>
        //private void SetAccessRights(string file)
        //{
        //    FileSecurity fileSecurity = File.GetAccessControl(file);
        //    AuthorizationRuleCollection rules = fileSecurity.GetAccessRules(true, true, typeof(NTAccount));

        //    foreach (FileSystemAccessRule rule in rules)
        //    {
        //        string name = rule.IdentityReference.Value;

        //        if (rule.FileSystemRights != FileSystemRights.FullControl)
        //        {
        //            FileSecurity newFileSecurity = File.GetAccessControl(file);
        //            FileSystemAccessRule newRule = new FileSystemAccessRule(name, FileSystemRights.FullControl, AccessControlType.Allow);
        //            newFileSecurity.AddAccessRule(newRule);
        //            File.SetAccessControl(file, newFileSecurity);
        //        }
        //    }
        //}
    }
}
