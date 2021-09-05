using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;

namespace WebForum.Models {
    public class SlugifyParameterTransformer : IOutboundParameterTransformer {
        public string TransformOutbound(object value) {
            if(value == null) { return null; }

            string valuestr = Regex.Replace(value.ToString(),
              "([a-z])([A-Z])",
              "$1-$2",
              RegexOptions.CultureInvariant,
              TimeSpan.FromMilliseconds(100)).ToLowerInvariant();

            valuestr = Regex.Replace(valuestr, @"\s", "-");

            return valuestr;
        }
    }
}
