using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
            {
            Console.WriteLine("Enter the item number of an appliance: \n");
            long item_num;
            item_num = long.Parse(Console.ReadLine());
            Appliance? foundAppliance = null;
            foreach (Appliance appliance in Appliances)
                {

                if (appliance.ItemNumber == item_num)
                    {
                    // add appliance to the found list
                    foundAppliance = appliance;
                    break;
                    }

                }
            if (foundAppliance == null)
                {
                Console.WriteLine("No appliances found with that item number.\n");
                }
            else
                {
                // Test found appliance is available
                if (foundAppliance.IsAvailable)
                    {
                    foundAppliance.Checkout();
                    Console.WriteLine($"Appliance \"{item_num}\" has been checked out.\n");
                    }
                else
                    {
                    Console.WriteLine("The appliance is not available to be checked out.\n");
                    }
                }
            }
        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>

        public override void Find()
            {
            Console.WriteLine("Enter brand to search for:");
            string input_brand = Console.ReadLine();
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
                {
                if (appliance.Brand == input_brand)
                    {
                    found.Add(appliance);
                    }
                }
            //Display found appliances
            DisplayAppliancesFromList(found, 0);

            }


        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
            {
            // Write "Possible options:"
            Console.WriteLine("Enter number of doors: 2 (double door), 3 (three doors) or 4 (four doors):");
            // Create variable to hold entered number of doors           

            int number_doors = Convert.ToInt32(Console.ReadLine());

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances 
            foreach (Appliance appliance in Appliances)
                {
                // Test that current appliance is a refrigerator
                // Down cast Appliance to Refrigerator
                // Refrigerator refrigerator = (Refrigerator) appliance;
                if (appliance is Refrigerator)
                    {
                    // Test user entered 0 or refrigerator doors equals what user entered.
                    // Add current appliance in list to found list
                    Refrigerator refrigerator = (Refrigerator)appliance;
                    if (number_doors == 0 || refrigerator.Doors == number_doors)
                        {
                        found.Add(refrigerator);
                        }
                    }
                }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
            {
            // Write "Possible options:"
            // Write "0 - Any"
            // Write "1 - 18 Volt"
            // Write "2 - 24 Volt"          
            // Write "Enter voltage:"
            Console.WriteLine("Enter battery voltage value. 18 V (low) or 24 V (high)");
            // Create variable to hold voltage
            int voltage = Convert.ToInt32(Console.ReadLine());
            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
                {
                // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
                // Add current appliance in list to found list
                if (appliance is Vacuum)
                    {
                    Vacuum vacuum = (Vacuum)appliance;
                    if (voltage.Equals(vacuum.BatteryVoltage))
                        {
                        found.Add(vacuum);
                        }
                    }
                }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
            {

            // Write "Enter room type:"
            Console.WriteLine("Room where the microwave will be installed: K (kitchen) or W (work site):");
            // Get user input as string and assign to variable
            string input_room = Console.ReadLine();

            // Create character variable that holds room type
            char room_type = Char.ToUpper(input_room[0]);
            // Create variable that holds list of 'found' appliances
            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
                {
                if (appliance is Microwave)
                    {
                    Microwave microwave = (Microwave)appliance;
                    if (room_type.Equals(microwave.RoomType))
                        {
                        found.Add(microwave);
                        }
                    }
                }

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(found, 0);
            }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
            {
            Console.WriteLine("Enter the sound rating of the dishwasher: Qt (Quietest), Qr (Quieter), Qu(Quiet) or M (Moderate):");
            string sound_rating = Console.ReadLine().ToUpper();

            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
                {
                if (appliance is Dishwasher)
                    {
                    Dishwasher dishwasher = (Dishwasher)appliance;
                    if (sound_rating.Equals(dishwasher.SoundRating.ToUpper()))
                        {
                        found.Add(dishwasher);
                        }
                    }
                }

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
            DisplayAppliancesFromList(found, 0);
            }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
            {
            // Write "Enter number of appliances: "
            Console.WriteLine("Enter number of appliances:");
            // Get user input as string and assign to variable
            int app_number = int.Parse(Console.ReadLine());
            //a list to save random number
            List<int> random_number = new List<int>();
            //the length of the Appliance list
            int list_length = Appliances.Count();
            // Convert user input from string to int
            for (int i = 0; i <= app_number; i++)
                {
                int random_no = new Random().Next(0, list_length);
                random_number.Add(random_no);
                }
            // Create variable to hold list of found appliances
            List<Appliance> found_appliances = new List<Appliance>();

            // Loop through appliances
            foreach (var number in random_number)
                {
                found_appliances.Add(Appliances[number]);
                }

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());
            found_appliances.Sort(new RandomComparer());
            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
            DisplayAppliancesFromList(found_appliances, app_number);
            
        }
    }
}
