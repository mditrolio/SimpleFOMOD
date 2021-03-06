﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleFOMOD.Class_Files
{
    class MainWindowChecker
    {
        public static bool ModNameCheck (string modName)
        {
            if(modName.Length > 0 && modName.Length < 30)
            {
                return true;
            }
            return false;
        }

        public static bool AuthorNameCheck (string authName)
        {
            if (authName.Length > 0 && authName.Length < 30)
            {
                Regex regex = new Regex("^[a-z0-9._-]+$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(authName))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool VerNumberCheck(string verNumber)
        {
            if (verNumber.Length > 0 && verNumber.Length < 10)
            {
                Regex regex = new Regex("^[abv0-9.]+$", RegexOptions.IgnoreCase);
                if (regex.IsMatch(verNumber))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool URLCheck(string url)
        {
            if (url != "")
            {
                if (url.Contains("nexusmods.com") && url.Contains("/mods/"))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }

    public class ModuleConfigWindowChecker
    {
        public static bool GroupCheck(string groupInput)
        {
            foreach(var group in ModuleConfigWindow.mod.Groups)
            {
                if(group.GroupName == groupInput)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ModuleCheck(string moduleInput)
        {
            foreach (var group in ModuleConfigWindow.mod.Groups)
            {
                foreach (var module in group.Modules)
                {
                    if (module.ModuleName == moduleInput)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public static bool FileCheck(string fileInput, List<String> existingFiles)
        {
            if (fileInput.Contains(@"\"))
            {
                fileInput = fileInput.Remove(0, fileInput.IndexOf(@"\") + 1);
            }

            foreach (var file in existingFiles)
            {
                if(fileInput == file)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
