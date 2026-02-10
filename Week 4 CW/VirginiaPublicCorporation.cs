using System;
using System.Collections.Generic;

namespace Week_4_CW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Virginia Public Corporations (top 10 sample):");
            Console.WriteLine("---------------------------------------------");

            foreach (var corp in VirginiaPublicCorporation.SampleData)
            {
                Console.WriteLine(corp.ToString());
            }
        }
    }
    /// <summary>
    /// Minimal model for a Virginia public corporation containing only:
    /// Stock symbol, Name, Location, and Market capitalization (USD).
    /// </summary>
    public class VirginiaPublicCorporation
    {
        public string StockSymbol { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        /// <summary>
        /// Market capitalization in USD. Null when unknown or not applicable.
        /// Approximate values in the sample data for illustration only.
        /// </summary>
        public decimal? MarketCapitalizationUsd { get; set; }

        public VirginiaPublicCorporation(string stockSymbol, string name, string location, decimal? marketCapitalizationUsd = null)
        {
            StockSymbol = stockSymbol ?? throw new ArgumentNullException(nameof(stockSymbol));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Location = location ?? throw new ArgumentNullException(nameof(location));
            MarketCapitalizationUsd = marketCapitalizationUsd;
        }

        public VirginiaPublicCorporation() : this(string.Empty, string.Empty, string.Empty, null) { }

        public override string ToString()
        {
            var marketCap = MarketCapitalizationUsd.HasValue ? MarketCapitalizationUsd.Value.ToString("C0") : "Unknown";
            return $"{Name} ({StockSymbol}) — {Location}, MarketCap: {marketCap}";
        }

        /// <summary>
        /// Array of top 10 Virginia public corporations (sample).
        /// Headquarters and market caps are approximate and provided for illustration.
        /// </summary>
        private static VirginiaPublicCorporation[] Top10 { get; } = new[]
        {
            new VirginiaPublicCorporation("COF",  "Capital One Financial Corporation",           "McLean, VA",        50_000_000_000m),
            new VirginiaPublicCorporation("NOC",  "Northrop Grumman Corporation",               "Falls Church, VA",  60_000_000_000m),
            new VirginiaPublicCorporation("D",    "Dominion Energy, Inc.",                      "Richmond, VA",      45_000_000_000m),
            new VirginiaPublicCorporation("AEE",  "AES Corporation",                             "Arlington, VA",      9_000_000_000m),
            new VirginiaPublicCorporation("LDOS", "Leidos Holdings, Inc.",                      "Reston, VA",        15_000_000_000m),
            new VirginiaPublicCorporation("DLTR", "Dollar Tree, Inc.",                           "Chesapeake, VA",    30_000_000_000m),
            new VirginiaPublicCorporation("KMX",  "CarMax, Inc.",                                "Richmond, VA",      10_000_000_000m),
            new VirginiaPublicCorporation("HII",  "Huntington Ingalls Industries, Inc.",         "Newport News, VA",   6_000_000_000m),
            new VirginiaPublicCorporation("GNW",  "Genworth Financial, Inc.",                    "Richmond, VA",       1_000_000_000m),
            new VirginiaPublicCorporation("NSC",  "Norfolk Southern Corporation",                "Norfolk, VA",       40_000_000_000m)
        };

        /// <summary>
        /// Public mutable List of the sample Virginia public corporations.
        /// Initialized from the Top10 array so callers can add/remove if needed.
        /// </summary>
        public static List<VirginiaPublicCorporation> Corporations { get; } = new List<VirginiaPublicCorporation>();

        /// <summary>
        /// Public Queue of the sample Virginia public corporations.
        /// Initialized from Top10 so callers can Enqueue/Dequeue as needed.
        /// </summary>
        public static Queue<VirginiaPublicCorporation> CorporationsQueue { get; } = new Queue<VirginiaPublicCorporation>();

        /// <summary>
        /// Public Stack of the sample Virginia public corporations.
        /// Initialized from Top10 so callers can Push/Pop/Peek as needed.
        /// </summary>
        public static Stack<VirginiaPublicCorporation> CorporationsStack { get; } = new Stack<VirginiaPublicCorporation>();

        // Static constructor populates the List, Queue and Stack from the Top10 array.
        static VirginiaPublicCorporation()
        {
            Corporations.AddRange(Top10);
            foreach (var corp in Top10)
            {
                CorporationsQueue.Enqueue(corp);
                CorporationsStack.Push(corp);
            }
        }

        /// <summary>
        /// Backwards-compatible sample data used by the Program. References Top10 so Main prints the top 10.
        /// </summary>
        public static IReadOnlyList<VirginiaPublicCorporation> SampleData { get; } = Top10;
    }
}