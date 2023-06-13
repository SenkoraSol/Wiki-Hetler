using System;
using System.Collections.Generic;
using System.Text;

namespace Wiki_Hitler
{
    
        public class ItemHitlerJson
        {
            public string name { get; set; }
            public int layer { get; set; }
            public List<string> links { get; set; }
        }

        public class Root
        {
            public List<ItemHitlerJson> item { get; set; }
        }

    
}
