using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Services.Contracts;

namespace WebShop.Services.Models.PolymorphicCollections
{
    public class PolyListCollection
    {
        public PolyListCollection()
        {
            this.Collection = new List<IBasePolyCollection>();
            this.Type = typeof(object);
        }

        public Type Type { get; set; }

        public List<IBasePolyCollection> Collection { get; set; }
    }
}
