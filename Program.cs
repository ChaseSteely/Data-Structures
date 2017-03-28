using System;

using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PatentData
{
    class Program
    {
        private const int LIST_SIZE = 200;

        static void showPatient(Patient p)
        {
      
            Console.WriteLine("Name: {0}, ID: {1}, Cost: {2}", p.FirstName + " " + p.LastName, p.Id, p.ProcedureCost);
        }

        static void Main(string[] args)
        {
            PatientData data = new PatientData(LIST_SIZE);
            data.LoadPatients("C:/Users/Marshall/Desktop/patientList.csv");
            String action = "";
         
            while (!action.ToLower().StartsWith("q"))
            {
                Console.WriteLine("(F)ind, (S)tatistics, (R)emove (Q)uit");
              
                Console.WriteLine("Choose from the Menu above");
                action = Console.ReadLine();
                switch (action)
                {
                    case "f":
                    case "F":
                        {
                            Console.WriteLine("Enter first and last name:");
                            string name = Console.ReadLine();
                           
                                String[] names = name.Split();
                                if (names.Length != 2)
                                {
                                    Console.WriteLine("Please enter a First and Last Name ONLY.");
                                    continue;
                                }

                                Patient.Comparisons = 0;
                                Patient pat = data.FindPatientByName(names[0], names[1]);
                                if (pat != null)
                                {
                                    showPatient(pat);
                                }
                                else
                                {
                                    Console.WriteLine("Patient not found");
                                }
                                Console.WriteLine("Comparisions: {0}", Patient.Comparisons);
                        }break;
                    case "s":
                    case "S":
                        {
                            Console.WriteLine("Number of Slots in the Array: {0} \n Percentage of Used Slots: {1}\n Max Length of LinkedList: {2}\n Avg Length of LinkedList: {3}\n", data.size, data.usedSlots(),
                                data.FindLongestLength(), data.avgSlots());
                        }
                        break;

                    case "q":
                    case "Q":
                        {

                        }return;
                }
            }//END SWITCH

            Console.ReadLine();
        }
    }
}
