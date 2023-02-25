using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_2
{
    internal class Program
    {
        //List for details to be inserted into
        static List<string> studentFirstName= new List<string>();
        static List<string> studentSurname = new List<string>();
        static List<string> studentEmail = new List<string>();
        static List<string> studentMobile = new List<string>();
        static List<string> studentResidence = new List<string>();


        //variables to get access at various stages
        static string firstName;
        static string surname;
        static string details;
        static int firstIndex;
        static int lastIndex;



        //end of switch cases, traverse to main window
        static void pressKey()
        {            
            Console.WriteLine("\n\t Press any key to return to main window...");
            Console.ReadKey();
        }


        //FUNCTION = getting input for first/given named
        static void getFirstName()
        {
            Console.WriteLine("\n\t Please enter your first name: ");
            firstName = Console.ReadLine();
        }


        //FUNCTION = getting input for last name
        static void getSurname()
        {
            Console.WriteLine("\n\t Please enter your last name: ");
            surname = Console.ReadLine();
        }


        //FUNCTION = to get index placement of first name and last name
        static void getIndex()
        {
            firstIndex = studentFirstName.IndexOf(firstName);
            lastIndex = studentSurname.IndexOf(surname);
        }


        //option to add email mobile address
        static void getDetails()
        {            
            Console.WriteLine("\n\t Would you like to add any other information?\n Y | N");
            details = Console.ReadLine();
        }


        //FUNCTION = Info insert for email ID, mobile number and address (SR25)
        static void getInfo(string message, List<string> list)
        {            
            list.RemoveAt(firstIndex);
            Console.WriteLine(message);
            var userInput = Console.ReadLine();
            list.Insert(firstIndex, userInput);
        }


        static void Main(string[] args)
        {
            //Attempting to run a loop so one can input and modify data as needed

            while (true)
            {         
                // Landing Page for Techtorium Student
                Console.WriteLine("\n\t     TECHTORIUM STUDENT RECORDS   ");
                Console.WriteLine("\t  ________________________________\n\n");

                Console.WriteLine("\t ==========Student Information==========\n\n");



                //Options to insert data into
                Console.WriteLine("\t 1. Add Student Information");
                Console.WriteLine("\t ------------------------\n");

                Console.WriteLine("\t 2. Insert Student Information");
                Console.WriteLine("\t ---------------------------\n");

                Console.WriteLine("\t 3. Update Student Information");
                Console.WriteLine("\t ---------------------------\n");

                Console.WriteLine("\t 4. Delete Student Information");
                Console.WriteLine("\t ---------------------------\n");

                Console.WriteLine("\t 5. Search Student Information");
                Console.WriteLine("\t ---------------------------\n");

                Console.WriteLine("\t 6. Display Student Information");
                Console.WriteLine("\t ----------------------------\n");

                Console.WriteLine("\t Please choose number 1 --> 6 to add appropriate data within given menu options");
                

                //Prompt user to imput numbers from 1 --> 6 which correspondes with the Main Menu
                var input = Console.ReadLine();

                switch (input)
                {
                    
                    case "1": 

                        //first running naming fuctions
                        getFirstName();
                        getSurname();
                        

                        //prompting user to input names
                        studentFirstName.Add(firstName);
                        studentSurname.Add(surname);


                        //Check if user wants to add additional info - email mobile and address
                        getDetails();

                        if (details == "Y")
                        {
                            Console.WriteLine("\n\t Enter students email address?");
                            studentEmail.Add(Console.ReadLine());

                            Console.WriteLine("\n\t Enter students mobile number?");
                            studentMobile.Add(Console.ReadLine());

                            Console.WriteLine("\n\t Enter students address?");
                            studentResidence.Add(Console.ReadLine());
                        }
                        else
                        {
                            //adds consistency on email mobile address 
                            studentEmail.Add("");
                            studentMobile.Add("");
                            studentResidence.Add("");
                        }

                        
                        Console.WriteLine("\n\t Details you have entered has been added successfully!");

                        pressKey();
                        break;


                    case "2":

                        //first running naming fuctions
                        getFirstName();
                        getSurname();


                        //prompting user to input names
                        studentFirstName.Add(firstName);
                        studentSurname.Add(surname);


                        //Check what position in list one would like information held
                        Console.WriteLine("\t Selection position for name  to be stored");


                        //locate position user wants to insert details entered
                        int position = Convert.ToInt32(Console.ReadLine());

                        studentFirstName.Insert(position, firstName);
                        studentSurname.Insert(position, surname);

                        getDetails();

                        //Checking input of details
                        if (details == "Y")
                        {
                            Console.WriteLine("\n\t Enter students email address?");
                            studentEmail.Add(Console.ReadLine());

                            Console.WriteLine("\n\t Enter students mobile number?");
                            studentMobile.Add(Console.ReadLine());
;
                            Console.WriteLine("\n\t Enter students address?");
                            studentResidence.Add(Console.ReadLine());
                        }
                        else
                        {
                            //adds consistency on email mobile address 
                            studentEmail.Insert(position, "");
                            studentMobile.Insert(position, "");
                            studentResidence.Insert(position, "");
                        }

                        Console.WriteLine("\n\t Details you have entered has been added in appropriate location!");

                        pressKey();
                        break;

                    case "3":

                        getFirstName();
                        getSurname();
                        getIndex();//looking for index number of the details entered


                        //checks for index number ensuring its the same
                        if (firstIndex == lastIndex)
                        {
                            //re-locating name at said index position
                            studentFirstName.Remove(firstName);
                            studentSurname.Remove(surname);


                            Console.WriteLine("\t\n What would you like to change the first name to? ");
                            var firstNameUpdate = Console.ReadLine();

                            Console.WriteLine("\t\n What would you like to change the surname to? ");
                            var surnameUpdate = Console.ReadLine();

                            //inserting new name at specific index position
                            
                            studentFirstName.Insert(firstIndex, firstNameUpdate);
                            studentSurname.Insert(lastIndex, surnameUpdate);
                            Console.WriteLine("\t Details of student \"" + firstNameUpdate + " " + surnameUpdate + "\" has been updated.\n\n");
                            Console.WriteLine("\t Would you like to add other details? Y | N ");
                            string answer = Console.ReadLine();

                            //nested statement to determine if one wants to continue modification or not
                            if (answer == "Y")
                            {
                                getInfo("\t\n Please enter students email addres", studentEmail);
                                getInfo("\t Please enter students mobile number", studentMobile);
                                getInfo("\t Please enter students address", studentResidence);

                                
                                Console.WriteLine("\t\n Your information has been updated");
                            }
                            else
                            {
                            }
                        }                        
                        else//original else statement
                        {
                            Console.WriteLine("\t\n Name that you have entered was not found. Please try again! ");
                        }

                        pressKey();
                        break;


                    case "4":

                        getFirstName();
                        getSurname();
                        getIndex();


                        //deleting info from given list
                        if (firstIndex == lastIndex)
                        {
                            studentFirstName.RemoveAt(firstIndex);
                            studentSurname.RemoveAt(firstIndex);
                            studentMobile.RemoveAt(firstIndex);
                            studentResidence.RemoveAt(firstIndex);
                            studentEmail.RemoveAt(firstIndex);

                            Console.WriteLine("\n\t You have successfully deleted this entry");
                        }
                        else
                        {
                            Console.WriteLine("\n\t Name that you have entered was not found. Please try again! ");
                        }

                        pressKey();
                        break;


                    case "5":

                        //Allowing details to be found within given list/DB
                        Console.WriteLine("\n\t Search For: ");

                        //Search will look through list and match with details given
                        var searchStudentName = Console.ReadLine();
                        bool correct = studentFirstName.Contains(searchStudentName);
                        var searchIndex = studentFirstName.IndexOf(searchStudentName);

                        if(correct)
                        {
                            //show all appropriate info it entered details are correct
                            Console.WriteLine( "\n");
                            Console.WriteLine(studentFirstName[searchIndex] + " ");
                            Console.WriteLine(studentSurname[searchIndex] + " ");
                            Console.WriteLine(studentMobile[searchIndex] + " ");
                            Console.WriteLine(studentResidence[searchIndex] + " ");
                            Console.WriteLine(studentEmail[searchIndex] + " ");
                        }
                        else 
                        {
                            //checks entered details through the list and informs of details not being found
                            Console.WriteLine("\n\t Details you have entered cannot be found. Please try again!");
                        }

                        pressKey();
                        break;
                        

                    case "6":

                        //Attempt to try loop to display details of students and the order of index students are located
                        string display = "";
                        for (int i = 0; i < studentFirstName.Count; i++)
                        {
                            Console.Write(studentFirstName[i] + " \n");
                            Console.Write(studentSurname[i] + " \n");
                            Console.Write(studentResidence[i] + " \n");
                            Console.Write(studentMobile[i] + " \n");
                            Console.Write(studentEmail[i] + " \n");


                            //using same loops to combine all details and display to user
                            display += (
                                studentFirstName[i] + "\t \n" +
                                studentSurname[i] + "\t  \n" +
                                studentEmail[i] + "\t \n" +
                                studentMobile[i] + "\t \n" +
                                studentResidence[i] + "\t \n");
                        }

                        //writes the given display into a .txt
                        FileStream newfile = new FileStream("studentinfo.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter sw = new StreamWriter(newfile);
                        //Console.WriteLine("\n\t Hello WOrld" );
                        //string userInput = Console.ReadLine();
                        sw.WriteLine(display);

                        sw.Flush();

                        sw.Close();
                        
                        
                        //reading appropriate file
                        Console.WriteLine("This is a read file");
                        FileStream fileRead = new FileStream("studentinfo.txt", FileMode.Open, FileAccess.Read);
                        StreamReader stRead = new StreamReader(fileRead);
                        Console.WriteLine(stRead.ReadLine());
                        stRead.Close();
                        Console.ReadKey();

                        pressKey();
                        break;

                        
                    default:
                        //prompts user to enter number 1--> 6 that matches the numerals as per menu
                        Console.WriteLine("\n\t Please enter a valid number that correspondence with the menu.");
                        Console.ReadLine();
                        
                        pressKey();
                        break;

                }


            }


        }

    }
}

