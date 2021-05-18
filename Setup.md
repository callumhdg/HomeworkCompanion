# Setup

## Required Software

1. Visual Studio



### Visual Studio Packages

1. MaterialDesignThemes - by James Wilock (v4.0.0)
2. Microsoft.EntityFrameworkCore - by Microsoft (v5.0.5)
3. Microsoft.EntityFrameworkCore.SqlServer - by Microsoft (v5.0.5)
4. Microsoft.EntityFrameworkCore.Tools - by Microsoft (v5.0.5)
5. Misrosoft.NET.Test.Sdk - by Microsoft (v16.5.0)
6. NUnit - by Charlie Poole, Rob Prouse (v3.12.0)
7. NUnit3TestAdapter - by Charlie Poole, Terje Sandstorm (v3.16.1)





## Database Setup

1. Install [Packages](#Visual Studio Packages). 
2. Open Package Manager Console.
3. Input 'Add-Migration InitialCreate' into the PMC and press `Enter`.
4. Input 'Update-Database' into the PMC and press `Enter`.
5. Execute the following SQL queries in the database, the values should be changed but the system can't be used without users.

```sql
INSERT INTO Teachers
(first_name, last_name, title)
VALUES (
'Forname'
,'Surname'
,'Mx'
);
```

```sql
INSERT INTO Students
(first_name, last_name, title)
VALUES (
'Forname'
,'Surname'
,'Mx'
);
```

```sql
INSERT INTO Classes
(class_name, class_subject, class_teacher_fk)
VALUES (
'Name'
,'Subject'
,1 /*This should be the ID of the Teacher created above*/
);
```
