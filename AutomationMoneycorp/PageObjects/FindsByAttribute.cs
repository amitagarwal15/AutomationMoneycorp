using System;
using SeleniumExtras.PageObjects;

namespace AutomationMoneycorp.PageObjects
{
    internal class FindsByAttribute : Attribute
    {
        public How How;

        public string Using { get; set; }
    }
}