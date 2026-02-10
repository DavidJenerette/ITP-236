using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections_Assignment
{
        public class State
        {
            public string Code { get; }
            public string Name { get; }
            public int Population { get; }

            private static readonly State[] stateslist =
            {
            new State("AL","Alabama",4903185),
            new State("AK","Alaska",731545),
            new State("AZ","Arizona",7278717),
            new State("AR","Arkansas",3017804),
            new State("CA","California",39512223),
            new State("CO","Colorado",5758736),
            new State("CT","Connecticut",3565287),
            new State("DE","Delaware",973764),
            new State("FL","Florida",21477737),
            new State("GA","Georgia",10617423),
            new State("HI","Hawaii",1415872),
            new State("ID","Idaho",1787065),
            new State("IL","Illinois",12671821),
            new State("IN","Indiana",6732219),
            new State("IA","Iowa",3155070),
            new State("KS","Kansas",2913314),
            new State("KY","Kentucky",4467673),
            new State("LA","Louisiana",4648794),
            new State("ME","Maine",1344212),
            new State("MD","Maryland",6045680),
            new State("MA","Massachusetts",6892503),
            new State("MI","Michigan",9986857),
            new State("MN","Minnesota",5639632),
            new State("MS","Mississippi",2976149),
            new State("MO","Missouri",6137428),
            new State("MT","Montana",1068778),
            new State("NE","Nebraska",1934408),
            new State("NV","Nevada",3080156),
            new State("NH","New Hampshire",1359711),
            new State("NJ","New Jersey",8882190),
            new State("NM","New Mexico",2096829),
            new State("NY","New York",19453561),
            new State("NC","North Carolina",10488084),
            new State("ND","North Dakota",762062),
            new State("OH","Ohio",11689100),
            new State("OK","Oklahoma",3956971),
            new State("OR","Oregon",4217737),
            new State("PA","Pennsylvania",12801989),
            new State("RI","Rhode Island",1059361),
            new State("SC","South Carolina",5148714),
            new State("SD","South Dakota",884659),
            new State("TN","Tennessee",6829174),
            new State("TX","Texas",28995881),
            new State("UT","Utah",3205958),
            new State("VT","Vermont",623989),
            new State("VA","Virginia",8535519),
            new State("WA","Washington",7614893),
            new State("WV","West Virginia",1792147),
            new State("WI","Wisconsin",5822434),
            new State("WY","Wyoming",578759)
        };

            public State(string code, string name, int population)
            {
                Code = code;
                Name = name;
                Population = population;
            }
            public static List<State> StateList
            {
                get { return new List<State>(stateslist); }
            }
            public static SortedDictionary<string, string> StatesDictionary
            {
                get
                {
                    var dict = new SortedDictionary<string, string>();
                    foreach (var state in stateslist)
                    {
                        dict[state.Code] = state.Name;
                    }
                    return dict;
                }
            }
            public static SortedList<string, State> SortedStates
            {
                get
                {
                    var list = new SortedList<string, State>();
                    foreach (var state in stateslist)
                    {
                        list[state.Code] = state;
                    }
                    return list;
                }
            }
            public static List<int> StatePopulations
        {
                get
                {
                    var populations = new List<int>();
                    foreach (var state in stateslist)
                    {
                        populations.Add(state.Population);
                    }
                    return populations;
                }
            }

            public override string ToString()
            {
                return $"{Code} - {Name} (Population: {Population})";
            }
        }
    }
