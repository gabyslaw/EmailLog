using log4net.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EmailLog.Helpers
{
    public class SpecialFolderPatternConverter : PatternConverter
    {
        protected override void Convert(TextWriter writer, object state)
        {
            //Environment.SpecialFolder specialFolder = (Environment.SpecialFolder)Enum.Parse(typeof(Environment.SpecialFolder), base.Option, true);
            string homePath = HttpRuntime.AppDomainAppPath;
            //writer.Write(Environment.GetFolderPath(specialFolder));
            writer.Write(homePath);

        }
    }
}