﻿namespace SharedLiberary.General.DbStructs
{

    public struct RolesList
    {
        public const string Dev = "Developer";
        public const string Admin = "Administrator";
        public const string Super = "SuperVisor";
        public const string GnMng = "GeneralManager";
        public const string PrtMng = "PartManager";
        public const string DptMng = "DeptManager";
        public const string Doc = "Doctor";
        public const string Doc_Ass = "D_Assist";
        public const string User = "User";
        public string Role { get; private set; }
        public RolesList(Roles? roles)
        {
            switch (roles)
            {
                case Roles.Developer:
                    Role = Dev;
                    break;
                case Roles.Administrator:
                    Role = Admin;
                    break;
                case Roles.SuperVisor:
                    Role = Super;
                    break;
                case Roles.GeneralManager:
                    Role = GnMng;
                    break;
                case Roles.PartManager:
                    Role = PrtMng;
                    break;
                case Roles.DeptManager:
                    Role = DptMng;
                    break;
                case Roles.Doctor:
                    Role = Doc;
                    break;
                case Roles.D_Assist:
                    Role = Doc_Ass;
                    break;

                default:
                    Role = User;
                    break;
            }
        }
    }

    public enum Roles
    {
        Developer, Administrator, SuperVisor, GeneralManager, PartManager, DeptManager, Doctor, D_Assist, User
    }

    public struct UserCookie
    {
        public const string CookieName = "UidCook";
    }
}
