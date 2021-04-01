# <p align="center" > 💸 Budget Tracker Prototype! 💰 </p>

<!-- Home Page -->
## <p align="center" > Home Page </p>

This is the home page of my Budget Tracking application. All users will have to go through the home page to access the application. This is just a basic design to catch the users attention. There will be an obvious sign in button in the top right corner which will deliver the user to the Log In page detailed below.

![](/Prototype/images/home.jpg)

<!-- Login Page -->
## <p align="center" > Login Page </p>

This log in page will run on the Microsoft Identity's Individual Account log in functionality. It will be a standard log in page where there are options to input a username and password and then sign in. Clicking the sign in button will deliver the user to the Purchase Input page. That is the next page because the goal is to enable users to easily input their purchases. There will be options on the Log in page for users who forgot their username and passwords. These will deliver them to authenticate themselves and then recieve emailed username or temp passwords. The Register link on this page will take the user to a new page that asks them for basic information and a username and password. I plan on enabling the third party authentication that is a feature of Microsoft Identity.

![](/Prototype/images/login.jpg)

<!--Purchase Input Page -->
## <p align="center" > Purchase Input Page </p>

This purchase input page will allow users to input their purchases to be stored in the database and then retrieved from the spending list page. You can access the spending list page either by filling out the form and clicking submit or by going to the spending list page tab at the front. The form asks the user for the name of the purchase, date, category, method, and description.

![](/Prototype/images/purchase-input.jpg)

<!-- Spending List Page -->
## <p align="center" > Spending List Page </p>

The spending list page allows you to view all of the purchases you have made. They will be ordered by most recent initially and will offer other filtering methods such as by price, date, method, etc. To go to another page from here you will have to go to the tabs at the top of the page. 

![](/Prototype/images/spending-list.jpg)

<!-- Spending Summary Page -->
## <p align="center" > Spending Summary Page </p>

The spending summary page is the last priority of being finished in the project. It will offer additional functionality and viewing then the spending list page. There will be a bar chart, pie graph and spending over time graph. This will allow the user to view useful snapshots of their financials. The graphs should have functionality in that they will be linked to filtered views of the spending list. 

![](/Prototype/images/spending-summary.jpg)

<!-- Budget Page -->
## <p align="center" > Budget Page </p>

The budget page will allow users to input their projected and actual spending each month. It will calculate the differences in between the two. There will be several categories and subcategories that let the user put in specific costs that most people have. Each category will populate totals then those totals will be used to populate the totals across all categories. There will be a button at the bottom of this form that populates the totals and saves the data to the database so the user can retrieve it later.

![](/Prototype/images/budget.jpg)


When the user is finished with the application they can click the log off button which will send the user back to the home screen. 
