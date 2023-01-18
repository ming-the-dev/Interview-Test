using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTest.Controllers
{
    public class Hero : IHero
    {
        public string name { get; set; }
        public string power { get; set; }
        public List<KeyValuePair<string, int>> stats { get; set; }
        public void evolve(double statIncrease = 1.5)
        {
            foreach (KeyValuePair<string, int> stat in stats.ToList()) 
            {
                var newStat = new KeyValuePair<string, int>(stat.Key, Convert.ToInt32(stat.Value*statIncrease));
                stats.Remove(new KeyValuePair<string, int>(stat.Key, stat.Value));
                stats.Add(newStat);
            }
        }
    }
}
