# SocialNetwork
Application Description:
Blog application serves as an internship project where students get the opportunity to 
demonstrate their development skills. 

Blog application encompasses three skill sets:
  A. Setting up the database schema and organization of the data
  B. Implementation of Web API endpoints
  C. Implementation of Single Page Application
Technologies:
  MSSQL
  Angular
  .NET 6.0

Mandatory features:
  1. Login, Registration & Log out
     The user must be able to register a profile on our application.
     Register form must ask for a username, email, and password
     The username must be unique
     Email must have a valid domain
     Password must have between 5 and 10 characters
     The user must be able to log in with email and password
     In case the user entered the wrong credentials, do not authenticate and 
    authorize the user
     In case the user entered the correct credentials, issue a user session (e.g. JWT) 
    and redirect the user to the news feed page
     The user must be able to log out from the application which closes the session

  2. News feed with pagination
     Logged in user must be able to see blog posts from all other users
     Each blog post must contain a post picture, description, number of likes & 
    comments, comment section, and post creation date.
     Users must be able to leave a like or a comment on a blog post
     User must never see all posts, but rather front-end or back-end pagination must 
    be implemented
    3. Notifications
     The user must be able to see the notification dropdown button
     Once the button is clicked the latest three notifications (if any ) must appear
     There are two types of notifications: another user likes a post, another user 
    comments on a post
     Notifications are not in real-time
     When a user logs in and if there are any notifications, the notification button 
    must have a number of notifications (max 3) and must last for 30 seconds after 
    which it expires
    
  4. Search bar
     Seach bar must be at the top of the news feed page
     The search bar must be used to find other users by username only
     If the desired user is found, found user record is clickable
     The user profile page must show the latest three posts, username, and profile 
    picture
     The user profile must not be edited since this is not the profile that belongs to 
    the current session user
    5. Add a new blog post
     News feed must have an ‘Add new post’ button
     Upon clicking the button, the user must be redirected to a separate page
     The page must contain a form that asks for a blog picture, blog description
     The form must have ‘Cancel’ and ‘Save’ buttons
     The cancel button cancels the current request and redirects the user back to the 
    news feed page
     The save button saves the current request and redirects the user to the news 
    feed page
  6. Profile customization
     The user must be able to visit their profile by clicking the profile icon
     The user must be able to change the profile picture
     The user must be able to toggle between dark and light UI theme
     The user must be able to turn on or off notifications
     The user must be able to see the latest three posts

Optional features:
  1. Forgot & reset password
     The user should be able to reset the password
     Forgot & reset password button will be visible on the register form
     A randomly generated password will be sent to the user’s email that is valid 
    only for 5 minutes
     The user should be able to change the old password from within the profile 
    page
  
  2. Notification email sending
     The user should be able to receive an email notification in case another user 
    liked a post or left a comment
     The welcome email should be sent to a user’s email when it is registered for 
    the first time
    3. Making a post private
     The user should be able to set a blog post as private so that it is hidden from 
    other users
  
  4. Disable comments & likes on a post
     The user should be able to disable the comments section or likes on its post

  5. Post and comments edit and removal
     The user should be able to remove their post, edit the description or photo
     The user should be able to delete other people's comments on its post only
     The user should be able to edit its comment on the posts only the user left the 
    comments
    
    
    
    
    
    
