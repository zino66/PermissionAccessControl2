﻿// Copyright (c) 2018 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;

namespace PermissionParts
{
    public enum Permissions : short
    {
        NotSet = 0, //error condition

        //Here is an example of very detailed control over something
        [Display(GroupName = "Stock", Name = "Read", Description = "Can read stock")]
        StockRead = 10,
        [Display(GroupName = "Stock", Name = "Sell", Description = "Can sell items from stock")]
        StockSell = 11,
        [Display(GroupName = "Stock", Name = "Return", Description = "Can return an item to stock")]
        StockReturn = 12,
        [Display(GroupName = "Stock", Name = "Add new", Description = "Can add a new stock item")]
        StockAddNew = 13,
        [Display(GroupName = "Stock", Name = "Remove", Description = "Can delete a stock item")]
        StockRemove = 14,

        [Display(GroupName = "Employees", Name = "Read", Description = "Can read company employees")]
        EmployeeRead = 20,

        [Display(GroupName = "UserAdmin", Name = "Read users", Description = "Can list User")]
        UserRead = 30,
        //This is an example of grouping multiple actions under one permission
        [Display(GroupName = "UserAdmin", Name = "Alter user", Description = "Can do anything to the User")]
        UserChange = 31,

        [Display(GroupName = "UserAdmin", Name = "Read Roles", Description = "Can list Role")]
        RoleRead = 40,
        [Display(GroupName = "UserAdmin", Name = "Change Role", Description = "Can create, update or delete a Role")]
        RoleChange = 41,

        //This is an example of a permission linked to a optional (paid for?) feature
        //The code that turns roles to permissions can
        //remove this permission if the user isn't allowed to access this feature
        [LinkedToModule(PaidForModules.Feature1)]
        [Display(GroupName = "Features", Name = "Feature1", Description = "Can access feature1")]
        Feature1Access = 50,
        [LinkedToModule(PaidForModules.Feature2)]
        [Display(GroupName = "Features", Name = "Feature2", Description = "Can access feature2")]
        Feature2Access = 51,

        //This is an example of what to do with permission you don't used anymore.
        //You don't want its number to be reused as it could cause problems 
        //Just mark it as obsolete and the PermissionDisplay code won't show it
        [Obsolete]
        [Display(GroupName = "Old", Name = "Not used", Description = "example of old permission")]
        OldPermissionNotUsed = 100,

        [Display(GroupName = "SuperAdmin", Name = "AccessAll", Description = "This allows the user to access every feature")]
        AccessAll = Int16.MaxValue, 
    }
}