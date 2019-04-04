using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvMazeScrapper.Api.Views.Shows
{
    public class ShowView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<PersonView> Cast { get; set; }
    }
}
