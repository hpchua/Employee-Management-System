# Employee Management System

Simple website created with **Visual Studio 2019** and **Microsoft SQL Server**

## Table of Contents

* [Installation](#installation)
* [Features](#features)
* [Database](#database)

### Installation
1. After cloning this project, go to **Visual Studio**
2. Select the project solution, clean and build the project
3. Proceed to ```Tools``` > ```NuGet Package Manager``` > ```Package Manager Console```
4. Type ```update-database``` in the console
5. You may start this project right away with the existing data provided below.

    | Employee Username | Password   |
    | ----------------- | ---------- |
    | employee1         | testing123 |
    | employee2         | testing123 |
    | employee3         | testing123 |
    | employee4         | testing123 |
    | employee5         | testing123 |

![installiation for ems](https://user-images.githubusercontent.com/52247950/137860136-ceea91d1-a913-4e0e-810d-4ae493c00e4a.gif)

### Database
#### ERD

![ERD](https://user-images.githubusercontent.com/52247950/113497458-fcface80-9536-11eb-9c20-a1857c401c59.png)

#### Update Database Schema
1. ```enable-migrations```

2. ```add-migration [name]```

3. ```update-database```

### Features
#### Login
* Restrict the user login failure attempts (10 times) and add into Block IP Address 

![login failure attempt](https://user-images.githubusercontent.com/52247950/137866615-3ea4476f-043c-4eb2-a83b-5808ca71782f.gif)

* User is not allowed to login simultaneously, system will detect and redirect the current user to logout

![login multiple](https://user-images.githubusercontent.com/52247950/137864673-bd33b69a-6e1d-431f-8d54-ce13efdac306.gif)

* Display loading screen and display error message if no records found

#### Employee
* **Add / Edit** employee and display error message if found invalid format and duplicate existing information

![add employee](https://user-images.githubusercontent.com/52247950/137903315-52bc3098-5c59-4be7-b0cf-67d0d3f89e54.gif)

![edit employee](https://user-images.githubusercontent.com/52247950/137903724-d01f4030-7127-49fb-87bc-7a3a63a1cd5e.gif)

 
* **Delete** Employee Display successful message using ```Notify.js```

![delete employee](https://user-images.githubusercontent.com/52247950/137903870-a4aa1e70-55f8-45c6-a963-0889b22f3173.gif)


#### Features Prerequisites
##### NuGet Packages
> jQuery.UI.Combined

##### References
1. Font Awesome Icons
> ```<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">```

2. Modal Window
> ```<link href="~/Content/themes/base/jquery-ui.min.css" rel="stylesheet" />```

> ```<script src="~/Scripts/jquery-ui-1.12.1.min.js"></script>```

3. Validator JS For ModelState Error
> ```<script src="~/Scripts/jquery.validate.min.js"></script>```

> ```<script src="~/Scripts/jquery.validate.unobtrusive.js"></script>```