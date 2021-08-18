# Healthy Diet
-----------------------------------------------------------------------------------
## Web Application made by Nikola Stanojkovski
-----------------------------------------------------------------------------------
Link: &nbsp;
https://healthydiet.azurewebsites.net/
-----------------------------------------------------------------------------------

In a pandemic, as people's immunity declines and the organization of life becomes more difficult for every person, it's a good idea for people to have support for a better diet and thus a better and healthier lifestyle. <b>"Healthy Diet"</b> is a web application that provides that support. <br/> <br/>
The framework used to implement the system is <b>.NET Core</b> as a back-end tool, and <b>Server-Side Razor</b> as the front-end tool. <b>HTML, CSS</b> and <b>Bootstrap</b> are used for the layout and the design of the pages, while <b>JavaScript</b> and <b>JQuery</b> are used for handling user's activities, creating the appropriate animations and sending requests to the server that enable interactive design.
The application uses <b>SQL Server</b> as a database server, <b>Onion</b> architecture (<b>Domain, Repository, Service, Web</b> layers) as a main architectural pattern, and, <b>C#</b> as a main programming language. <br/> 
<br/>
The folder <b>Documentation</b> has all of the needed documentation and specification of the system, the folder <b>Interactive Prototype</b> includes the interactive prototype of the application, and the final implementation of the system is given in the folder <b>Implementation</b>.
<br/> <br/>
The application has the following functionalities:
<br/>
- <b>Sharing recipes</b>, reviewing them in a list and an opportunity to review them in more detail, which provides information about the ingredients, the method and time of preparation, type of meal, total number of calories, as well as the average rating given by other users. It is also possible to filter them by: type of meal, number of calories, preparation time, and popularity, but also search by any text that is part of the name, description, preparation or ingredients. Recipes can also be sorted according to two criteria: rating and popularity. Each recipe has the opportunity to be rated by each user.
- <b>Finding diet plans</b>, which can be seen in a list with a brief description, or, seen in more detail, where users get the information about how many days the diet lasts, how much is the expected weight loss, what is the popularity and average rating, how much is the intensity, as well as information about which day of the diet is filled with what foods. There is also the ability to filter by: intensity, expected weight loss, length, and, average number of calories, as well as search by any text that is part of the name, description, or ingredients of the diet. Diet plans can also be sorted according to two criteria: rating and popularity. Each of the diet plans can be chosen by each user with the help of which he will receive information on a daily basis about his progress. Also, every diet plan can be rated by every user.
- <b>Calorie calculator</b>, which provides information on the calorie intake of a given user. You can manually enter the consumed foods and beverages, or, you can automatically take the victuals from the information accompanying the appropriate user account (through which you can choose whether to take the victuals that are consumed only today, or, all consumed foods). If there is a need, the user has the option to delete the chosen foods / drinks from the table. In addition to calorie information, if the user is authenticated and has their own account filled with valid data, the application gives a suggestion on how much is his recommended daily calorie intake, and advice on how proper his diet is, depending on the calculation.
- <b>Login / Registration of users</b>. Each user has insight into many statistics that help him maintain continuity in his daily diet if the user is interactive enough and enters his activities on a daily basis:
  - Insight into the daily progress of <b>consumed water</b> after a previous advice on how much is the recommended dose, statistics available on a monthly and weekly basis with the appropriate progress bars
  - Insight into the list of <b>consumed foods</b> along with their quantity, number of calories and last time consumed
  - Insight into the <b>currently selected diet plan</b> with information about its progress on a daily basis, and an option to rate it
  - Information about the <b>previous diet plans</b>, when they were started and when they were completed, along with the rating given to them
  - Option to <b>view and change your personal data</b>, and, data that is important to the "Healthy Diet" community in which each user becomes a member after registration, including the entry of an account picture that can be modified
  - Ability to <b>add / delete friends</b> which the application automatically finds to make suggestions to the appropraite user based on similarities and affinities
