namespace Collections_Assignment
{
    class Program
    {
        static void Main()
        {
            State newState = new State("DR", "Disctrict of Reynolds", 42540);

            Console.WriteLine("--- State List ---");
            List<State> states = State.StateList;
            states.Add(newState);

            foreach (var state in states)
            {
                Console.WriteLine(state);
            }

            states.Remove(newState);
            
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.WriteLine("\n---- State Dictionary ----");
            SortedDictionary<string, string> dict = State.StatesDictionary;
            dict.Add(newState.Code, newState.Name);

            foreach (var kvp in dict)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }

            dict.Remove(newState.Code);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.WriteLine("\n--- Sorted State List ---");
            SortedList<string, State> sortedStates = State.SortedStates;
            sortedStates.Add(newState.Code, newState);

            foreach (var kvp in sortedStates)
            {
                Console.WriteLine(kvp.Value);
            }

            sortedStates.Remove(newState.Code);

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            Console.WriteLine("\n--- State Populations ---");
            List<int> populations = State.StatePopulations;
            populations.Add(newState.Population);

            int totalPopulation = populations.Sum();
            Console.WriteLine($"Total Population: {totalPopulation}");

            Console.ReadKey();
        }
    }
}
