using System;
using System.Collections.Generic;
using System.Text;

namespace IBusinessServices
{
  public interface   IUserServices
    {
        int Authenticate(string userName, string password);
    }
}
