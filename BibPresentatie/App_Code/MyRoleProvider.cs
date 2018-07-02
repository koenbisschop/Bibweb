using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BibDomain.Business;
using System.Text.RegularExpressions;

namespace Bibweb
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                return System.AppDomain.CurrentDomain.FriendlyName;
            }
            set
            {

            }
        }
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            Controller _controller = (Controller) System.Web.HttpContext.Current.Application["Controller"];
            //Controller _controller = new Controller();
            Regex regex = new Regex(usernameToMatch);
            List<Gebruiker> gebruikers = _controller.GetGebruikers();
            List<string> result = new List<string>();
            foreach (Gebruiker gebruiker in gebruikers)
            {
                if (gebruiker.Rol.ToString().Equals(roleName) && regex.IsMatch(gebruiker.Gebruikersnaam))
                    result.Add(gebruiker.Gebruikersnaam);
            }
            return result.ToArray();
        }

        public override string[] GetRolesForUser(string username)
        {
            Controller _controller = (Controller)System.Web.HttpContext.Current.Application["Controller"];
            //Controller _controller = new Controller();
            Gebruiker gebruiker = _controller.GetGebruikers().Find(g => g.Gebruikersnaam.Equals(username));
            if (gebruiker == null)
                return new string[] { BibDomain.Business.Rol.Anoniem.ToString() };
            else
                return new string[] { gebruiker.Rol.ToString() };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            Controller _controller = (Controller)System.Web.HttpContext.Current.Application["Controller"];
            //Controller _controller = new Controller();
            List<Gebruiker> gebruikers = _controller.GetGebruikers().FindAll(g => g.Rol.ToString().Equals(roleName));
            List<string> namen = gebruikers.ConvertAll(g => g.Gebruikersnaam);
            return namen.ToArray();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            Controller _controller = (Controller)System.Web.HttpContext.Current.Application["Controller"];
            //Controller _controller = new Controller();
            Gebruiker gebruiker = _controller.GetGebruikers().Find(g => g.Gebruikersnaam.Equals(username));
            return gebruiker.Rol.ToString().Equals(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException("Delete Role not implemented");
        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException("Remove users from roles not implemented");
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException("Not implemented GetAllRoles");
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException("RoleExists not implemented");
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException("Create Role not implemented");
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException("Add users to roles not implemented");
        }
    }
}