using SimpleLinkedList;
using System;
using System.IO;

namespace PatentData
{
    class PatientData
    {
        private SimpleLinkedList<Patient>[] list;
        public int size { get; set; }
        /// <summary>
        /// Constructor.  Instantiates the array based on the size passed to the constructor.
        /// </summary>
        /// <param name="size">The size of the array.</param>
        public PatientData(int size)
        {
            this.size = size;
            list = new SimpleLinkedList<Patient>[size];
        }

        /// <summary>
        /// Loads patients into the data structure from the filename passed as a parameter.
        /// </summary>
        /// <param name="filename">Path to the file where the patient data is kept.  The format is: <para>first,last,procedureCost</para></param>
        public void LoadPatients(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            StreamReader input = new StreamReader(fs);

            while (!input.EndOfStream)
            {
                string line = input.ReadLine();
                string[] fields = line.Split(",".ToCharArray());
                // TODO create the new patient
                string last = fields[0];
                string first = fields[1];
                double cost = Double.Parse(fields[2]);
                Patient p = new Patient(first, last, cost);
                // TODO add the patient to the list
                AddPatient(p);
          
            }
        }

        /// <summary>
        /// Adds a patient to the data structure.
        /// </summary>
        /// <param name="patient">The patient to be added.</param>
        public void AddPatient(Patient patient)
        {

            int index = Patient.genPatientId(patient.FirstName, patient.LastName) % this.size;
            SimpleLinkedList<Patient> pList = list[index];
            if (pList == null)
            {
                pList = new SimpleLinkedList<Patient>();
                pList.AddAtHead(patient);
                list[index] = pList;
            }
            else
             {
                pList.AddAtHead(patient);
             }

        }

        public Patient FindPatientByName(string first, string last)
        {
            Patient pat = null;
            
            int index = Patient.genPatientId(first, last) % this.size;
            SimpleLinkedList<Patient> pList = list[index];
            if (pList != null)
            {
                pat = pList.Find(new Patient(first, last, 0));
            }
      
            return pat;
        }
        
        public int FindLongestLength()
        {
            int max = 0;
           for(int i = 0; i < this.size; i++)
            {
                if (list[i] != null)
                {
                    int lSize = list[i].Count;
                    if (lSize > max)
                    {
                        max = lSize;
                    }
                }
            }
            return max;
        }

        public double usedSlots()
        {
            double numSlots = 0.0;
            for (int i = 0; i < this.size; i++)
            {
                if(list[i] != null)
                {
                    numSlots++;
                }
            }
            double perc = (numSlots / this.size) * 100;
            return perc;
        }

        public double avgSlots()
        {
            int numSlots = 0;
            int sum = 0;
            for (int i = 0; i < this.size; i++)
            {
                if (list[i] != null)
                {
                    numSlots++;
                    sum += list[i].Count;
                   
                }
            }
            double aList = (sum / numSlots);
            return aList;
        }

        public Patient RemovePatientById(string first, string last)
        {
            Patient pat = FindPatientByName(first, last);
            int index = Patient.genPatientId(first, last) % this.size;
            if (list[index]!= null)
            {
                list[index].Remove(pat);
            }
            return pat;
        }
    }
}
