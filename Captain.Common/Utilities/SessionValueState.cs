/**********************************************************************************************************
 * Class Name   : SessionValueState<T>
 * Author       : chitti
 * Created Date : 
 * Version      : 
 * Description  : Used to get a session value from the asp.net http session.
 **********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Captain.Common.Utilities
{
    public class SessionValueState<T>
    {
        public SessionValueState()
        {
        }

        public T this[string name]
        {
            get
            {
                T returnValue = default(T);

                try
                {
                    if (HttpContext.Current.Session != null && HttpContext.Current.Session[name] != null)
                    {
                        returnValue = (T)HttpContext.Current.Session[name];
                    }
                }
                catch { }

                if (returnValue == null) { returnValue = default(T); }

                return returnValue;
            }
            set
            {
                HttpContext.Current.Session[name] = value;
            }
        }

        public T this[string name, T defaultValue]
        {
            get
            {
                T returnValue = default(T);

                try
                {
                    if (HttpContext.Current.Session != null && HttpContext.Current.Session[name] != null)
                    {
                        returnValue = (T)HttpContext.Current.Session[name];
                    }
                }
                catch { }

                if (returnValue == null) { returnValue = defaultValue; }

                return returnValue;
            }
            set
            {
                HttpContext.Current.Session[name] = value;
            }
        }
    }
}
