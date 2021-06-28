# Employee Management System

## Features
### Login
* Restrict the user login failure attempts (10 times)
* user is not allowed to login simultaneously, system will detect and redirect the current user to logout
* loading screen
* display error message

### Employee
(jQuery DataTable and Popup Modal Window)  
* Perform **Add, List, Edit and Delete** employee operation
* Display error message if found any employee duplicate existing information
* Display successful message using **Notify.js**

## ERD

![ERD](https://user-images.githubusercontent.com/52247950/113497458-fcface80-9536-11eb-9c20-a1857c401c59.png)

## Make any changes to database
1. ```enable-migrations```

2. ```add-migration [name]```

3. ```update-database```

## NuGet Packages Needed
> jQuery.UI.Combined

## References Needed
1. Font Awesome Icons
> ```<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">```

2. Modal Window
> ```<link href="~/Content/themes/base/jquery-ui.min.css" rel="stylesheet" />```

> ```<script src="~/Scripts/jquery-ui-1.12.1.min.js"></script>```

3. Validator JS For ModelState Error
> ```<script src="~/Scripts/jquery.validate.min.js"></script>```

> ```<script src="~/Scripts/jquery.validate.unobtrusive.js"></script>```

