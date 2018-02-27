# University Registrar
#### C Sharp and ASP.Net web app, 2-27-18  

#### _By Stephanie Faber and Nico Daunt_  

## Description
_This is a project designed to take user input and store information regarding students and courses._  

## Specifications

1. User inputs a student's information, such as their name, course number, and enrollment date. This is stored to the database.
* Example input: User enters student data
* Example output: Data is stored in the students table

2. On Index, the user can choose between seeing all students and all courses.
* Example input: Click on All Students
* Example output: Goes to page where all student info is shown

3. When looking at all students, the user can click on one to see all their classes.
* Example input: User clicks on "John Smith"
* Example output: A list of John Smith's classes appears

4. When looking at all courses, the user can click on one to see all students taking that course.
* Example input: User click on "History 101"
* Example output: A list of students taking that course appears


## Setup/Installation Requirements

* _Clone Repository_

* _Download and install .NET Core 1.1 SDK_

* _Download and install .NET runtime_

* _Download and install Mono for your platform_

* _Download and install MAMP for your platform_

* _Open MAMP and use the default ports_

* _In Mono command prompt, type >mysql -uroot -proot_

* _In mysql shell type >CREATE DATABASE registrar_

* _In mysql shell type >USE registrar_

* _In mysql shell type >CREATE TABLE students (id serial PRIMARY KEY, name VARCHAR(255), enroll_date VARCHAR(255));_

* _In mysql shell type >CREATE TABLE clients (id serial PRIMARY KEY, name VARCHAR(255), stylistId INT(11));_

* _In mysql shell type >QUIT_

* _In Mono command prompt, navigate to this project's folder_

* _In Mono command prompt, enter >dotnet restore_

* _In Mono command prompt, enter >dotnet build_

* _If there are no errors: In Mono command prompt, enter >dotnet run_

* _If there is an error, please contact me via email and describe your issue_

* _When the command prompt runs the build, enter localhost:5000 to your web browser. This should take you to the index page._

Github Repository Link (https://github.com/eyesicedover/HairSalon)

## Support and contact details

_Please email me directly at eyesicedover@gmail.com_

## Technologies Used

* HTML
* ASP.NET
* Razor
* .NET Core
* .NET SDK
* MAMP
* mysql

### License

*MIT License*

Copyright (c) 2018 **_Stephanie Faber_**

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
