# ST10084349-PROG6212-POE-TASK-2
This is the Programming 2B POE Task 2 for ST10084349 Darius Lynton Paul
## Table of Contents
1. [General Info](#general-info)
2. [Software](#software)
3. [Installation Instructions](#installation-instructions)
4. [Database Instructions](#database-instructions)
5. [Additional Artefacts](#additional-artefacts)
6. [Developer Info](#developer-info)
7. [FAQs](#faqs)
8. [Code Attributions](#code-attributions) 
***
### General Info
I am tasked to create a program that will help organize a user's time management in their classes. The program will take values such as the name of the modules, hours spent studying the modules, etc and use those values to do specific calculations to help the user manange their time for studying. This program will make use of a database which will store a user's information and display it back to them in a tabular format. This program is created by Darius Lynton Paul.
#### Screenshot of the Program
![Screenshot (136)](https://user-images.githubusercontent.com/106805800/199504204-d0d689dc-78fd-47fb-9032-eda99d1861d8.png)
***
### Software
* [Microsoft Visual Studio 2022] (Version no: 17.2)
* [Git] (Version no: 2.36.1)
* [Net Frameworks] (Net Framework 4.7.2)
* [Microsoft SQL Server Mangement Studio] (Version no: 18.11.1)

**Plugins used**
* EntityFramework
* Visual Studio IntelliCode
* Visual Studio Rich Navigation
***
### Installation Instructions
A. **Download Links**
* Net Framework 4.7.2 - https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net472-web-installer
* Microsoft Visual Studio 2022 - https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false
* Microsoft SQL Server Mangement Studio - https://aka.ms/ssmsfullsetup

B. **To run the program WITHOUT Microsoft Visual Studio installed, follow these steps:**
* _Download Net Framework 4.7.2 using the above link._
* _Download the file named "TaskTwoFinal" onto your desktop._
* _Double click on the folder titled "TaskTwoFinal"._
* _Double click on the folder titled "bin"._
* _Double click on the folder titled "Debug"._
* _Double click on the application titled "TaskTwoFinal.exe"._

C. **To run the program WITH Microsoft Visual Studio installed, follow these steps:**
* _Download Microsoft Visual Studio Using the above link._
* _Download the file named "TaskTwoFinal" onto your desktop._
* _Double click on the folder titled "TaskTwoFinal"._
* _Double click on the Visual Studio Solution file named "TaskTwoFinal.sln"._
* _After the program has finished loading, press on the green play symbol with the words "Start" written next to it, or press the "F5" key on your keyboard._
_Please note: Download all the files from the TaskOne folder to make sure the program executes with no errors_
***
### Database Instuctions
* _When running the program there won't be any databases displayed until you have pressed the appropriate button which will then display the database._
* _These databases can only be added to, no other processes can be done._
***
### Additional Artefacts
_To execute the following statements, paste it in Microsoft SQL Server Mangement Studio_
***
A. **Create database**
* _Open Microsoft SQL Server Mangement Studio._
* _Right click on the word "Databases" and select "New Database..."._
* _Name the database "TimeManager" and press the OK button._

B. **Create Table SQL statements**
create table users(
UserID int IDENTITY(1,1) PRIMARY KEY,
Username varchar(25) NOT NULL,
Email varchar(50) NOT NULL,
HashedPassword varchar(255) NOT NULL
);

create table semester(
SemesterID int IDENTITY(1,1) PRIMARY KEY,
SemesterName varchar(25) NOT NULL,
SemesterWeeks int NOT NULL,
SemesterStartDate datetime NOT NULL,
UserID int,
FOREIGN KEY (UserID) REFERENCES users(UserID)
)

create table modules(
ModuleID int IDENTITY(1,1) PRIMARY KEY,
ModuleCode varchar(10) NOT NULL,
ModuleName varchar(50) NOT NULL,
Credits int NOT NULL,
ClassHours int NOT NULL,
StudyDate datetime NOT NULL,
SelfStudyHours int NOT NULL,
UserID int,
SemesterID int,
FOREIGN KEY (UserID) REFERENCES users(UserID),
FOREIGN KEY (SemesterID) REFERENCES semester(SemesterID)
)
***
### Developer Info
* Name: Darius Lynton Paul
* Student No: ST10084349
* Email: ST10084349@vcconnect.edu.za
* Link to GIT Repository: 
* Link to Kanban board: 
***

### FAQs
1. **How do I see my modules?**
_After successfully logging in and adding atleast one module, go back to the home page and click on the "View your info" button. This will display all of your modules that you have correctly entered._
2. **How do I create an account?**
_After the loading/Splash screen, the login page will show up. Click on the text that says "Click here to create an account". This will take you to the Registration page where you can enter a username, password and e-mail address. After clicking the "Create Account" button you will be redirected to the Login page where you can now login with the account you have just created._
3. **How do I see my remaining self study hours?**
_After inputting the required information and pressing the 'Add Module' button on The Module page, your self study hours will be displayed on the bottom of the screen._
***
### Code Attributions
1. https://wpf-tutorial.com/misc-controls/the-progressbar-control/- used to create a working progress bar
2. https://stackoverflow.com/questions/15358865/how-can-i-check-if-the-name-exist-in-table - used to understand how to get a specific user's info from the database
3. https://stackoverflow.com/questions/43542570/how-to-use-click-event-for-label-or-textblock-in-wpf-c-sharp-visual-studio/43543628#43543628 - used to create a textblock click event
4. https://www.aspsnippets.com/Articles/Merge-and-display-multiple-Tables-in-single-GridView-in-ASPNet-using-C-and-VBNet.aspx - to display columns from different tables in one datagrid
