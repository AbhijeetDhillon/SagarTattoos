using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagarTattoos.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Portfolio
    {

        
        public string ImageName { get; set; }
       
        public string ImagePath
        {
            get { return ImageName.Replace(" ", string.Empty) + ".jpg"; }
        }
       
    }
}