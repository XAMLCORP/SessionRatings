using Microsoft.AspNetCore.Mvc;
using System;

namespace Gaming.Foundation.MVC
{
    public class GamingControllerBase : ControllerBase
    {
        protected Guid UserId
        {
            get { return Guid.Parse(Request.Headers["Ubi-UserId"]); }
        }
    }
}
