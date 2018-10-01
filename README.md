# Xamarin.Forms

This project implements an Android application using Xamarin.Forms.

REQUIREMENTS

This application will show a list of posts and it's possible to view the user profile of the author of the post, and the comments added to it. 
JSON Placeholder service is used to get the required information.

To customize the REST API - https://jsonplaceholder.typicode.com/


1. The application consists of three main screens.
   a. Posts list 
   b. Comments for a post 
   c. User profile 
  
2. Projects are separately created for data retrieval and the entities (data model).

3. Classes are created for each entity.

4. When the application starts, it shows the posts list page. Data fetching happens automatically in the background and a loading indicator  is shown while it’s loading. “ActivityIndicator” class in Xamarin.Forms is used for that.

5. Load posts list from the JSON URL of the API.

6. Since the post contains large amount of text, the text is clipped.

7. Selecting an item will navigate to the comments page and loading happens.

9. Selecting a row opens up the email client of the device with the commenter’s email address in the “to” field (“mailto” protocol is used).

10. There is a toolbar item with a generic “user icon”.

11. Clicking this will navigate to the user profile page.

12. User data is loaded here.
