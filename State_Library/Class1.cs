using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateLibrary
{
    public class StateInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Population { get; set; }
        public string FlagDescription { get; set; }
        public string Flower { get; set; }
        public string Bird { get; set; }
        public string Colors { get; set; }
        public string Capital { get; set; }
        public decimal MedianIncome { get; set; }
        public double ComputerJobPercentage { get; set; }
        public List<string> LargestCities { get; set; } = new List<string>();
    }
}
