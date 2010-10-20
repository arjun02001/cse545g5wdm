using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Enumeration
/// </summary>
public class Enumeration
{
	public Enumeration()
	{
	}

    public enum Department : int
    {
        HumanResources = 1,
        LogisticsAndSupply = 2,
        ITSupport = 3,
        Sales = 4,
        ResearchAndDevelopment = 5
    }

    public enum Role : int
    {
        Temp = 1,
        Guest = 2,
        SystemAdministrator = 3,
        Employee = 4,
        CorporateExecutive = 5,
        CEO = 6
    }

    public enum Right : int
    {
        None = 1,
        Upload = 2,
        Read = 3,
        Update = 4,
        Delete = 5,
        Checkin = 6,
        Checkout = 7,
        Sysadmin = 8
    }
}
