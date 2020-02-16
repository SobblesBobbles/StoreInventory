# StoreInventory
 
# Documentation

Written by: Stephen O'Brien 15/02/20  
Framework : Asp.Net Framework 4.6.1  

![Dashboard](https://github.com/SobblesBobbles/StoreInventory/blob/master/Images/StoreInventory_Dashboard3.PNG)
  
## Requirements
-Here, the user is the end customer  
-The web application should allow the user to upload/read price data from a given file
  (ExportFile.csv) and store it to the SQL server database.  
-The web application should allow the user to select a date range and perform the following
operations:  
-Display a given date range (chosen by user) of price values in a suitable chart with,  
  The maximum price  
  The minimum price  
  The average price  
  The most expensive hour (i.e. two consecutive values) for the half hour period  
-Display all the data in a data grid.  
-Date and Price are mandatory fields and should be validated with helpful messages.  
-A file of example data is provided called ‘ExportFile.csv’.  

## How to Use:
###Data Management:
 In the data dashboard, it currently gets the csv at a specific location to read first.   
 If you would like to read a new file, click "Browse" and select the file,   
 you will then be asked if you would like to read the file or upload it to the database.  
 ### Data Visualisation
  At first load, the data is based on what is already currently in the database.  
  Using the data parameters, you can specify the dates you'd like to receive.   
  It displays the information using AMCharts and displays the most important time.   


