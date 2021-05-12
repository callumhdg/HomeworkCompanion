# Homework Companion
A C# app for teachers to allocate classes of students homework.



# ERD







# Project Goals

## Epics
1. As a Teacher I need to be able to Add Students to a Class.
2. As a Teacher I need to be able to Add Questions to Homework.
3. As a Teacher I need to be able to assign a Class Homework.
4. As a Student I need to be able to Complete and Submit Homework.
5. As a Teacher I need to be able to Grade Homework.
## Stretch Goals
6. As a Student I want to be able to View my Homework with marks.
7. As a Teacher I want to be able to Create Students.

   

   

# Sprints:

## Sprint 1 -

### Start:

![Initial_Backlog](Images/Backlog_0.png)

This was the initial project backlog, the *Done* column and the *Notes* column have been swapped for this screenshot only.



Sprint Goals:

- [x] Project Initialisation 0.1
- [x] Project Initialisation 0.2
- [x] Project Initialisation 0.3
- [ ] User Story 2.1



### End:

![Sprint1_End_Backlog](Images/Backlog_1.png)





### Retrospective:

The first sprint is usually the most challenging so I tried to aim for an achievable amount to complete; the sprint goals were to initialise the project and the database. Initialising the project went without a hitch but when writing the create statements for the database it became apparent that another link table was needed. 

One thing that I would do differently next time would be to not create the ERD until the backlog is well populated, this resulted in me planning ideas that were too specific instead of planning more general ideas of what needs to be done.

Another improvement would be to add a bit more than I think can be done this sprint because I aimed too small I had to add another user story into the sprint goals.





## Sprint 2 -

### Start:

![Sprint2_Start_Backlog](Images/Backlog_2.png)



Sprint Goals:- [ ] Utilities login
- [x] User Story 1.1
- [x] User Story 1.2
- [x] User Story 2.1
- [x] User Story 2.2
- [x] User Story 2.3
- [ ] User Story 3.1





### End:

![Sprint2_End_Backlog](Images/Backlog_3.png)





### Retrospective:

This sprint went well overall, I set a lot of work to be completed including some stretch goals. The login isn't really a login yet because it isn't as valuable to the project as having something that works. Students can be added to a class and removed from it but there is an issue with the refresh that I mistook for a bug, the listboxes are updated quicker than the database can be referenced and adding a one second pause did not resolve the issue.

User story 3.1 was ambitious for this sprint and subsequently was not achieved but a good amount of functionality was added.

The `SelectAllStudentsInAClass()` and `SelectAllStudentsNotInAClass()` were only manually tested for now but I plan to write unit tests for these methods later.



























