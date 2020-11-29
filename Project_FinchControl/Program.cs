using System;
using System.Collections.Generic;
using System.IO;
using FinchAPI;

namespace Project_FinchControl
{

    // **************************************************
    //
    // Title: Finch Control - Menu Starter
    // Description: Finch Robot Control 
    // Application Type: Console
    // Author: Harrall, Drew
    // Dated Created: 11/18/2020
    // Last Modified: 11/19/2020
    //
    // **************************************************

    class Program
    {
        /// <summary>
        /// first method run when the app starts up
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SetTheme();

            DisplayWelcomeScreen();
            DisplayMenuScreen();
            DisplayClosingScreen();
        }

        /// <summary>
        /// setup the console theme
        /// </summary>
        static void SetTheme()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Main Menu                                 *
        /// *****************************************************************
        /// </summary>
        static void DisplayMenuScreen()
        {
            Console.CursorVisible = true;

            bool quitApplication = false;
            string menuChoice;

            Finch finchRobot = new Finch();

            do
            {
                DisplayScreenHeader("Main Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Connect Finch Robot");
                Console.WriteLine("\tb) Talent Show");
                Console.WriteLine("\tc) Data Recorder");
                Console.WriteLine("\td) Light Alarm System");
                Console.WriteLine("\te) User Programming");
                Console.WriteLine("\tf) Disconnect Finch Robot");
                Console.WriteLine("\tq) Quit");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        DisplayConnectFinchRobot(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayMenuScreen(finchRobot);
                        break;

                    case "c":
                        DisplayDataRecorderMenu(finchRobot);
                        break;

                    case "d":
                        LightAlarmDisplayMenuScreen(finchRobot);
                        break;

                    case "e":

                        break;

                    case "f":
                        DisplayDisconnectFinchRobot(finchRobot);
                        break;

                    case "q":
                        DisplayDisconnectFinchRobot(finchRobot);
                        quitApplication = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitApplication);
        }

        #region TALENT SHOW

        /// <summary>
        /// *****************************************************************
        /// *                     Talent Show Menu                          *
        /// *****************************************************************
        /// </summary>
        static void TalentShowDisplayMenuScreen(Finch finchRobot)
        {
            Console.CursorVisible = true;

            bool quitTalentShowMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Talent Show Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Light and Sound");
                Console.WriteLine("\tb) Dance");
                Console.WriteLine("\tc) Mixing it up");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                //
                // process user menu choice
                //
                switch (menuChoice)
                {
                    case "a":
                        TalentShowDisplayLightAndSound(finchRobot);
                        break;

                    case "b":
                        TalentShowDisplayDance(finchRobot);
                        break;

                    case "c":
                        TalentShowMixingItUp(finchRobot);
                        break;

                    case "q":
                        quitTalentShowMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }

            } while (!quitTalentShowMenu);
        }

        /// <summary>
        /// *****************************************************************
        /// *               Talent Show > Light and Sound                   *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayLightAndSound(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Light and Sound");

            Console.WriteLine("\tThe Finch robot will not show off its glowing talent!");
            DisplayContinuePrompt();

            for (int lightSoundLevel = 0; lightSoundLevel < 255; lightSoundLevel++)
            {
                finchRobot.setLED(lightSoundLevel, lightSoundLevel, lightSoundLevel);
                finchRobot.noteOn(lightSoundLevel * 100);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// ************************************************************
        /// *                   Talent Show > Dance                    *
        /// ************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowDisplayDance(Finch finchRobot)
        {

            Console.CursorVisible = false;

            DisplayScreenHeader("Dance");

            Console.WriteLine("\tThe Finch robot will now show off its dance moves.");
            DisplayContinuePrompt();


            for (int danceLoop = 0; danceLoop < 3; danceLoop++)
            {
                finchRobot.setMotors(255, 255);
                finchRobot.wait(500);
                finchRobot.setMotors(-255, -255);
                finchRobot.wait(500);
                finchRobot.setMotors(-100, 100);
                finchRobot.wait(500);
                finchRobot.setMotors(100, -100);
                finchRobot.wait(1000);
                finchRobot.setMotors(-100, 100);
                finchRobot.wait(500);
                finchRobot.setMotors(0, 0);
            }

            DisplayMenuPrompt("Talent Show Menu");
        }
        /// <summary>
        /// ****************************************************
        /// *            Talent Show > Mixing it Up            *
        /// ****************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void TalentShowMixingItUp(Finch finchRobot)
        {

            Console.CursorVisible = false;

            DisplayScreenHeader("Mixing it Up");

            Console.WriteLine("The finch robot will put on a show!");

            #region SONG AND DANCE

            finchRobot.setLED(255, 255, 0);
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(880);///a
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(880);///a
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(880);///a
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(880);///a
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(784);///g
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(698);///f
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(659);///e
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(587);///d
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.noteOn(1047);///c
            finchRobot.setMotors(-50, 50);
            finchRobot.wait(200);
            finchRobot.setMotors(50, -50);
            finchRobot.wait(200);
            finchRobot.noteOff();
            finchRobot.setMotors(0, 0);

            #endregion

            DisplayMenuPrompt("Talent Show Menu");
        }

        #endregion

        #region DATA RECORDER

        /// <summary>
        /// *****************************************
        /// *          Data Recorder Menu           *
        /// *****************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        
        static void DisplayDataRecorderMenu(Finch finchRobot)
        {
            int numberOfDataPoints = 0;
            double dataPointFrequency = 0;
            double[] temperatures = null;
            
            
            Console.CursorVisible = true;

            bool quitDataRecorder = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Data Recorder Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Number of Data Points");
                Console.WriteLine("\tb) Frequency of Data Points");
                Console.WriteLine("\tc) Get Data");
                Console.WriteLine("\td) Show Data");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {

                    case "a":
                        numberOfDataPoints = GetDataRecorderDisplayGetNumberOfDataPoints();
                        break;

                    case "b":
                        dataPointFrequency = GetDataRecorderDisplayGetDataPointFrequency();
                        break;

                    case "c":
                        temperatures = DataRecprderDisplayGetData(numberOfDataPoints, dataPointFrequency, finchRobot);
                        break;

                    case "d":
                        DataRecorderDisplayData(temperatures);
                        break;

                    case "q":
                        quitDataRecorder = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice");
                        DisplayContinuePrompt();
                        break;
                }

            }

            while (!quitDataRecorder);
             
        }
        /// <summary>
        /// *****************************************
        /// *          Displays Temperatures        *
        /// *****************************************
        /// </summary>
        /// <param name="temperatures"></param>
        static void DataRecorderDisplayData(double[] temperatures)
        {
            DisplayScreenHeader("Show Data");

            Console.WriteLine(
                "Recordings #".PadLeft(15) +
                "Temp Ferenheit".PadLeft(15)
                );
            Console.WriteLine(
                "____________".PadLeft(15) +
                "____________".PadLeft(15) 
                );

            for (int index = 0; index < temperatures.Length; index++)
            {
                double tempFerenheit = (temperatures[index] * 1.8 + 32);
                Console.WriteLine(
                Convert.ToString(index + 1).PadLeft(4) +
                tempFerenheit.ToString("n2").PadLeft(19)
                );
            }

            DisplayContinuePrompt();
        }
        /// <summary>
        /// ********************************
        /// *       Gets Temperatures      *
        /// ********************************
        /// </summary>
        /// <param name="numberOfDataPoints"></param>
        /// <param name="dataPointFrequency"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static double[] DataRecprderDisplayGetData(int numberOfDataPoints, double dataPointFrequency, Finch finchRobot)
        {
            double[] temperatures = new double[numberOfDataPoints];
            
            DisplayScreenHeader("Get Data");

            Console.WriteLine($"Number of data points: [{numberOfDataPoints}], with [{dataPointFrequency}] second intervals");
            Console.WriteLine();
            Console.WriteLine("Your Finch Robot is now ready to begin reading temperatures");

            DisplayContinuePrompt();

            for (int index = 0; index < numberOfDataPoints; index++)
            {

                temperatures[index] = finchRobot.getTemperature();
                Console.WriteLine($"Reading {index + 1}: {temperatures[index]:n2}");
                int waitInSeconds = Convert.ToInt32(dataPointFrequency * 1000);
                finchRobot.wait(waitInSeconds);

            }

            DisplayContinuePrompt();

            return temperatures;

        }
        /// <summary>
        /// ***********************************************
        /// *          Frequency of Data Points           *
        /// ***********************************************
        /// </summary>
        /// <returns></returns>
        static double GetDataRecorderDisplayGetDataPointFrequency()
        {
            double dataPointFrequency;
            bool validResponse;
            string userResposne;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                validResponse = true;

                Console.WriteLine("How many seconds would you like between every interaval?");
                userResposne = Console.ReadLine();

                if (!double.TryParse(userResposne, out dataPointFrequency))
                {
                    
                    validResponse = false;

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Invalid Number");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();

                }

            } while (!validResponse);


            Console.WriteLine("You entered {0} second interavals.", userResposne);

            DisplayContinuePrompt();

            return dataPointFrequency;

        }
        /// <summary>
        /// **************************************
        /// *       Number of Data Points        *
        /// **************************************
        /// </summary>
        /// <returns></returns>
        static int GetDataRecorderDisplayGetNumberOfDataPoints()
        {
            int numberOfDataPoints;
            bool validResponse;
            string userResposne;

            DisplayScreenHeader("Number of Data Points");

            do
            {
                
                validResponse = true;

                Console.WriteLine("How many data points would you like?");
                userResposne = Console.ReadLine();

                if (!int.TryParse(userResposne, out numberOfDataPoints))
                {
                    
                    validResponse = false;

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Invalid Number");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();

                }

            } while (!validResponse);


            Console.WriteLine("You entered {0} points.", numberOfDataPoints);

            DisplayContinuePrompt();
            
            return numberOfDataPoints;

        }

        #endregion

        #region Alarm System
        /// <summary>
        /// *********************************
        /// *       Light Alarm Menu        *
        /// *********************************
        /// </summary>
        /// <param name="finchRobot"></param>
        static void LightAlarmDisplayMenuScreen(Finch finchRobot)
        {

            string sensorsToMonitor = "";
            string rangeType = "";
            int minMaxThresholdValue = 0;
            int timeToMonitor = 0;
            
            
            bool alarmSystemMenu = false;
            string menuChoice;

            do
            {
                DisplayScreenHeader("Light Alarm System Menu");

                //
                // get user menu choice
                //
                Console.WriteLine("\ta) Set Range Type");
                Console.WriteLine("\tb) Set Sensors To Monitor");
                Console.WriteLine("\tc) Set Minimum and Maximum Threshold Value");
                Console.WriteLine("\td) Set Time to Monitor");
                Console.WriteLine("\te) Set the Alarm");
                Console.WriteLine("\tq) Main Menu");
                Console.Write("\t\tEnter Choice:");
                menuChoice = Console.ReadLine().ToLower();

                switch (menuChoice)
                {

                    case "a":
                        rangeType = LightAlarmDisplaySetRangeType();
                        break;

                    case "b":
                        sensorsToMonitor = LightAlarmDisplaySetSensorsToMonitor(); 
                        break;

                    case "c":
                        minMaxThresholdValue = LightAlarmDisplaySetMinMaxThresholdValue(rangeType, finchRobot);
                        break;

                    case "d":
                        timeToMonitor = LightAlarmDisplaySetMaximumTimeToMonitor();
                        break;

                    case "e":
                        LightAlarmDisplaySetAlarm(finchRobot , sensorsToMonitor, rangeType, minMaxThresholdValue, timeToMonitor);
                        break;

                    case "q":
                        alarmSystemMenu = true;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine("\tPlease enter a letter for the menu choice");
                        DisplayContinuePrompt();
                        break;
                }

            }

            while (!alarmSystemMenu);

        }
        /// <summary>
        /// ****************************************
        /// *       Runs user input data           *
        /// ****************************************
        /// </summary>
        /// <param name="finchRobot"></param>
        /// <param name="sensorsToMonitor"></param>
        /// <param name="rangeType"></param>
        /// <param name="minMaxThresholdValue"></param>
        /// <param name="timeToMonitor"></param>
        static void LightAlarmDisplaySetAlarm(Finch finchRobot, string sensorsToMonitor, string rangeType, int minMaxThresholdValue, int timeToMonitor)
        {

            int secondsElapse = 0;
            bool thresholdExceeded = false;
            int currentLightSensorValue = 0;


            DisplayScreenHeader("Set Alarm");

            Console.WriteLine($"Sensors to monitor {sensorsToMonitor}");
            Console.WriteLine($"Range Type: {rangeType}");
            Console.WriteLine($"Min/Max threshold value: {minMaxThresholdValue}");
            Console.WriteLine($"Time to Monitor {timeToMonitor}");
            Console.WriteLine();

            Console.WriteLine("Press any key to begin");
            Console.ReadKey();
            Console.WriteLine();

            while (secondsElapse < timeToMonitor && !thresholdExceeded)
            {
                
                switch (sensorsToMonitor)
                {
                    case "left":
                        currentLightSensorValue = finchRobot.getLeftLightSensor();
                        break;

                    case "right":
                        currentLightSensorValue = finchRobot.getRightLightSensor();
                        break;

                    case "both":
                        currentLightSensorValue = (finchRobot.getLeftLightSensor() + finchRobot.getRightLightSensor()) / 2;
                        break;
                }

                switch (rangeType)
                {
                    case "minimum":
                        if (currentLightSensorValue < minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                    case "maximum":
                        if (currentLightSensorValue > minMaxThresholdValue)
                        {
                            thresholdExceeded = true;
                        }
                        break;

                }

                finchRobot.wait(1000);
                secondsElapse++;
            }

            if (thresholdExceeded)
            {
                Console.WriteLine($"The {rangeType} threshold value of {minMaxThresholdValue} was exceeded by the current light sensor value of {currentLightSensorValue}");
                finchRobot.noteOn(5000);
                finchRobot.wait(500);
                finchRobot.noteOff();
            }

            else
            {
                Console.WriteLine($"The {rangeType} theshold value of {minMaxThresholdValue} was not exceeded");
                finchRobot.noteOn(500);
                finchRobot.wait(500);
                finchRobot.noteOff();
            }
            
            DisplayMenuPrompt("Light Alarm");
        }
        /// <summary>
        /// ************************************
        /// *       Gets seconds to wait       *
        /// ************************************
        /// </summary>
        /// <returns></returns>        
        static int LightAlarmDisplaySetMaximumTimeToMonitor()
        {
            int timeToMonitor;
            bool validResponse;
            string userResponse;

            DisplayScreenHeader("Time to Monitor");

            do
            {
                validResponse = true;

                Console.WriteLine("Please enter seconds to monitor:");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out timeToMonitor))
                {

                    validResponse = false;

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Invalid Number");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();

                }

            } while (!validResponse);

            Console.WriteLine($"You entered {timeToMonitor}.");
            
            DisplayMenuPrompt("Light Alarm");
            
            return timeToMonitor;
        }
        /// <summary>
        /// *****************************************
        /// *        Gets min/max threshold         *
        /// *****************************************
        /// </summary>
        /// <param name="rangeType"></param>
        /// <param name="finchRobot"></param>
        /// <returns></returns>
        static int LightAlarmDisplaySetMinMaxThresholdValue(string rangeType, Finch finchRobot)
        {
            int minMaxThresholdValue;
            bool validResponse;
            string userResponse;

            DisplayScreenHeader("Threshold Value");

            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getLeftLightSensor()}");
            Console.WriteLine($"\tLeft light sensor ambient value: {finchRobot.getRightLightSensor()}");

            do
            {
                validResponse = true;

                Console.WriteLine($"Enter the {rangeType} light sensor value:");
                userResponse = Console.ReadLine();

                if (!int.TryParse(userResponse, out minMaxThresholdValue))
                {

                    validResponse = false;

                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Invalid Number");
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again");
                    Console.ReadKey();

                }

            } while (!validResponse);

            Console.WriteLine("You entered {0}.", minMaxThresholdValue);
                
            DisplayMenuPrompt("Light Alarm");
            
            return minMaxThresholdValue;
        }
        /// <summary>
        /// *********************************
        /// *       Gets which sensor       *
        /// *********************************
        /// </summary>
        /// <returns></returns>
        static string LightAlarmDisplaySetSensorsToMonitor()
        {
            string sensorsToMonitor;
            bool validResponse;

            DisplayScreenHeader("Sensors to Monitor");

            do
            {

                Console.WriteLine("\tEnter Range Type [minimum, maximum]");
                sensorsToMonitor = Console.ReadLine();

                if (sensorsToMonitor == "left")
                {

                    validResponse = true;

                    Console.WriteLine($"You have entered {sensorsToMonitor}");


                }

                else if (sensorsToMonitor == "right")
                {

                    validResponse = true;

                    Console.WriteLine($"You have entered {sensorsToMonitor}");

                }

                else if (sensorsToMonitor == "both")
                {

                    validResponse = true;

                    Console.WriteLine($"You have entered {sensorsToMonitor}");

                }

                else
                {

                    validResponse = false;

                    Console.WriteLine("Invalid Anwser please type again");


                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return sensorsToMonitor;
        }
        /// <summary>
        /// *************************************
        /// *           Gets Range Type         *
        /// ************************************* 
        /// </summary>
        /// <returns></returns>
        static string LightAlarmDisplaySetRangeType()
        {
            string rangeType;
            bool validResponse;

            DisplayScreenHeader("Set Range Type");

            do
            {

                Console.WriteLine("\tEnter Range Type [minimum, maximum]");
                rangeType = Console.ReadLine();

                if (rangeType == "minimum")
                {

                    validResponse = true;
                    
                    Console.WriteLine($"You have entered {rangeType}");


                }

                else if (rangeType == "maximum")
                {

                    validResponse = true;
                    
                    Console.WriteLine($"You have entered {rangeType}");

                }

                else
                {

                    validResponse = false;
                    
                    Console.WriteLine("Invalid Anwser please type again");


                }

            } while (!validResponse);

            DisplayMenuPrompt("Light Alarm");

            return rangeType;
        }

        #endregion

        #region FINCH ROBOT MANAGEMENT

        /// <summary>
        /// *****************************************************************
        /// *               Disconnect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        static void DisplayDisconnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            DisplayScreenHeader("Disconnect Finch Robot");

            Console.WriteLine("\tAbout to disconnect from the Finch robot.");
            DisplayContinuePrompt();

            finchRobot.disConnect();

            Console.WriteLine("\tThe Finch robot is now disconnect.");

            DisplayMenuPrompt("Main Menu");
        }

        /// <summary>
        /// *****************************************************************
        /// *                  Connect the Finch Robot                      *
        /// *****************************************************************
        /// </summary>
        /// <param name="finchRobot">finch robot object</param>
        /// <returns>notify if the robot is connected</returns>
        static bool DisplayConnectFinchRobot(Finch finchRobot)
        {
            Console.CursorVisible = false;

            bool robotConnected;

            DisplayScreenHeader("Connect Finch Robot");

            Console.WriteLine("\tAbout to connect to Finch robot. Please be sure the USB cable is connected to the robot and computer now.");
            DisplayContinuePrompt();

            robotConnected = finchRobot.connect();

            // TODO test connection and provide user feedback - text, lights, sounds

            DisplayMenuPrompt("Main Menu");

            //
            // reset finch robot
            //
            finchRobot.setLED(0, 0, 0);
            finchRobot.noteOff();

            return robotConnected;
        }

        #endregion

        #region USER INTERFACE

        /// <summary>
        /// *****************************************************************
        /// *                     Welcome Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tFinch Control");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// *****************************************************************
        /// *                     Closing Screen                            *
        /// *****************************************************************
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.CursorVisible = false;

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tThank you for using Finch Control!");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("\tPress any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display menu prompt
        /// </summary>
        static void DisplayMenuPrompt(string menuName)
        {
            Console.WriteLine();
            Console.WriteLine($"\tPress any key to return to the {menuName} Menu.");
            Console.ReadKey();
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\t" + headerText);
            Console.WriteLine();
        }

        #endregion
    }
}
