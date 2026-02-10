using System;
using System.Collections.Generic;
using System.Linq;

namespace Week_4_CW
{
    internal class Lists
    {
        // Make Run public so Program.Main can call it (prevents it from appearing as unused/gray)
        public static void Run()
        {
            var capitalOne = new VirginiaPublicCorporation("COF", "Capital One Financial Corporation", "McLean, VA", 50_000_000_000m);
            var carMax = new VirginiaPublicCorporation("KMX", "CarMax, Inc.", "Richmond, VA", 30_000_000_000m);
            var norfolkSouthern = new VirginiaPublicCorporation("NSC", "Norfolk Southern Corporation", "Norfolk, VA", 60_000_000_000m);

            var corporationsList = new List<VirginiaPublicCorporation>();
            corporationsList.Add(capitalOne);
            corporationsList.Add(carMax);
            corporationsList.Add(norfolkSouthern);

            // Remove CarMax if present
            var corp = corporationsList.FirstOrDefault(c => c.StockSymbol == "KMX");
            if (corp != null)
                corporationsList.Remove(corp);

            // Remove Capital One if present
            corp = corporationsList.FirstOrDefault(c => c.StockSymbol == "COF");
            if (corp != null)
                corporationsList.Remove(corp);

            // Remove Norfolk Southern if present
            corp = corporationsList.FirstOrDefault(c => c.StockSymbol == "NSC");
            if (corp != null)
                corporationsList.Remove(corp);

            // Show remaining items (expected: none)
            Console.WriteLine("Remaining corporations:");
            foreach (var c in corporationsList)
            {
                Console.WriteLine(c);
            }
            var CorporationsDict = VirginiaPublicCorporation.CorporationsDictionary;
            var keys = CorporationsDict.Keys.ToList();
            CorporationsDict.Add("KMX", carMax);
            corp = CorporationsDict["KMX"];
            if (corp != null)
            {
                CorporationsDict.Remove("KMX");
            }
            var corporationsHashSet = VirginiaPublicCorporation.CorporationsHashSet;
            corp = corporationsHashSet.FirstOrDefault(c => c.StockSymbol == "COF");
            corporationsHashSet.Add("COF");
            corporationsHashSet.Add("KMX");
            corporationsHashSet.Add("NSC");
        }
    }
}
