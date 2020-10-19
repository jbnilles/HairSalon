# _Hair Salon_

#### _This application will allow user to track Clients, Stylists  and their Appointments, 10/9/2020_

#### By _**Joseph Nilles**_

## Description

_This project allows the user to create stylists and clients and make appointments for them. After creating at least one Stylist you can then create a Client.To schedule an appointment you must find the client that you want to schedule an appointment for and then click on the add an appointment button. This will bring up a form where you are able to schedule and appointment for the client you chose with their selected Stylist. Appointments cannot be scheduled within one hour of another for either the stylist or the client. At any time you are able to edit the stylists, clients or appointments. You can delete clients at any time as well as appointments however you cannot delete a stylist if they have at least one client. You are able to edit the clients and change their stylists and then delete the stylist. When you select a stylist it will show you a list of their clients and appointments. If you select a client it will show their details as well as their appointments. _




## Setup/Installation Requirements

* _clone this repository_
* _create the database from the joseph_nilles.sql file that is in the root dir of the porject_
* _navigate to the root dir of this project_
* _Navigate to the HairSalon dir_
* Create a file called `appsettings.json`
* In the `appsettings.json` file add the following
```json
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=joseph_nilles;uid=root;pwd=YOUR_PASSWORD;"
  }
}
```
* Replace `YOUR_PASSWORD` with your own MySQL password
* _In the terminal enter the command 'dotnet restore'_
* _In the terminal enter the command 'dotnet run'_





## Known Bugs

_ No known bugs_

## Support and contact details

_Contact author at jbnilles24@gmail.com_

## Technologies Used

_C#, HTML, CSS, JS, jQuery, and MySQL was used in creating this application._

### License

*This software is available with an MIT license*

Copyright (c) 2020 **_Joseph Nilles_**