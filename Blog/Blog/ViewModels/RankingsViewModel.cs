using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSite.ViewModels
{
    public class RankingsViewModel
    {
        public int CategoryId { get; set; }
        public ICollection<int> UserRankings { get; set; }
        public static ICollection<int> OverallRankings { get; set; }
    }
}