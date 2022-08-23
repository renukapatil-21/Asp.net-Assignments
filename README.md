# Asp.net-Assignments
Mindbody-Asp.net-assignments Aug22

# ASP.NET Core 6

1. Eco-System For Building Modern Web Apps
    - Object Models
        - Dependency Injection Container (DI) is In-Built
            - THis registers all dependencies as 'services' in the Application
                - Database Connections
                - Session
                - Identity
                - Caching
                - Cross-Origin-Resource-Sharing (CORS)
                - Object Model for
                    - Razor Views
                    - MVC Controllers, Views, and API Controllers
                    - API Controllers
                - Custom Services
                - ... and many more
        - Middlewares
            - Objects used for Managing HTTP Request Processing
                - Exception Management
                - Session Management
                - CORS Management
                - Identityt Management
                - Routing
                - Accessong Local Files on Server
                - Executing the COntrollers or Pages
# ASP.NET Core MVC Project Structure (.NET 6) (.NET Core 1.x to .NET 5, we had Startup.cs and Program.cs. The Startup.cs file is deprecated)
    - Program.cs
        - Entry-Point for the Application
            - Loading the Application Configuration
            - Registering Services as Dependency in DI Container
            - Registring Middlewares and Managing HTTP Request Pipeline
    - appsettings.json
        - Defines Application Level Configirations
            - e.g.
                - Hosting
                - Db Connection Strings
                - Custom Configuration Settings e.g. Tokens
    - Models
        - Contains The Logical Object Model of Applications
            - Entity Classes
            - ViewModel Classes
            - Data Access Layer
            - Business Logic Layer
            - Other Utilities
                - Custom Extensions
                - Data Re-Orgnization classes  
    - Controllers
        - These classes are used to accept HTTP Requests with data
        - Update Models
        - Decides which View is Responded
    - Views
        - Contains Razor Views (.cshtml), these are MVC Views used for User Interaction
    - wwwroot
        - Contains Files those are delivered to Browser e.g. JavaScript, CSS, HTML, Images, etc.
# Programming with ASP.NET Core MVC
- Understand and Create Models
    - Data Access Layer
        - ADO.NET
        - EntityFrameworkCore
            - Object Relational Mapping (ORM)
    - Business Layer
    - Utilities        
- Understand and Create Controllers
    - Action Mathods
    - Exception Management
    - Filters
    - Security
    - The 'IActionResult' inetrface
    - Understanding Request Processing
    - Middlewares
- Understand and Create Views
    - User Interface
        - Scaffolding
            - Model Bindings
        - HTML Tag Helpers

# ADO.NET

- High-Speed Data Access Technology for Microsoft .NET Apps
- The 'System.Data', the Assembly (a Package) for Data Access Object Model
    - The 'System.Data.SqlClient', a Package for SQL Server
- Various Classes
    - SqlConnection
        - Used to Manage teh Database Connection
        - Open(), OpenAsync(), methdos to Open Connection With Database
        - Close(), CloseAsync(), methods to Close Database Connection
        - ConnectionString property, that accepts Connection String as input
            - Examples of Connection String
            - Case 1: Using Windows Admin user to connect to Database
                - Data Source=[SERVER-NAME];Initial Catalog=[DATABASE-NAME];Integrated Security=SSPI
                    - SERVER-NAME: The Name of the MAchine where the SQL Server Instance is Running
                        - localhost (if using local machine) OR IP ADDRESS OR . (if using the Local Machine)
                - e.g.
                    - Data Source=.;Initial Catalog=Companyl;Integrated Security=SSPI;
            - Case 2: Using SQL Server Authentication
                - Data Source=[SERVER-NAME];Initial Catalog=[DATABASE-NAME];User Id=[SQL-SERVER-USER-ID];Password=[Password];
                - e.g.
                    - Data Source=.;Initial Catalog=Company;User Id=sa;Password=Pass@word;
            - Follow the SWebSite
                - https://www.connectionstrings.com/microsoft-data-sqlclient/
                
    - SqlCommand 
        - Used to Perform DB Transactions (Read/Write) Operations with Database over the Connection
        - The 'Connection' property, this accepts the Connection object to Database over which the Read/Write Operations are performed
        - CommandType
            - Property that represents the Type of Statement to be executed on the Database Server
            - CommandType.Text, accepts a string which contains Query e.g. Select, Insert, Update, and Delete
            - CommandType.StoredProcedute, accept the Stored Procedure name
                - CommandText="Stored-Procedure-Name"
        - Execute Methods
            - ExecuteReader(), ExecuteReaderAsync()
                - Returns an Instance of 'SqlDataReader' class when the CommandText is 'Select' Statement
                - SqlDataReader: The Read-Only-Forward-Only Cursor, that reads data from First Record and Move to next till last record
                    - The 'Read()' method to start reading
                    - The 'Close()' method to CLose the Reader
            - ExecuteNonQuery(), ExecuteNotQueryAsync()
                - USed when the ComamndText is DML Statement (Insert, Update and Delete)
                - This method will return a 'Non-Zero' number that represents no. of records affected
            - ExecuteScalar(), ExecuteScalarAsync()
                - Used when the Select Query returns a Single Value e.g. Min, Max, Average, etc.
                - We can use while working with Stored Procs
    - SqlParameter
        - The class that represent the Parameter passed to
            - Parameterized Query
            - Stored Proc
        - Properties
            - ParameterName
                - Actual NAme of the Paremeter passed to a Query or SP
            - Direction
                - Input or Output Parameter
            - DbType
                - SQL Data Type
            - Size
                - MUST be set for String Parameter
            - Value
                 - Value to be passed to the Parameter   
    - Pseduo Code
        - Create an Instance of SqlConnection by using the Connection String
        - Open the Connection
        - Defien an instance of SqlCommand
        - Pass connection object to the Connection Property of Command class
        - Set the CommandType for The Command Instance as Text or Stored Procedure
        - Set the CommandText property of the Command Instance as either Query or Stored Procedure name dependning on the CommandType
        - Invoke an Execute Method based on CommandText
        - If the SqlDataReader as return from Command's execute method then use 'Read()' method to read data and then 'Close()' reader
        - If the DML Operations then cehck for Non-Zero value from the Execute method of Command object
        - Close() the connection
- Practices for Building Data Access Layer with ADO.NET
    - Create a Generic Interface that will be containing declarations for methods commonly used for CRUD Operations
    - Define Separate Layers (.dll) files for Entity Classes, DAL, and Interface Contract

# ASP.NET Core 6 As a Technology
1. Depedency Injection
    - Managed using 'IServiceCollection' interface
        - This will be used to Register External Dependencies in DI Container of WebApplicationBuilder 
    - The 'ServiceDescrioptor' class is used to provode the Dependency Container with Following Methods
            - AddScoped()
                - The Object will be live for the Current Requested Session (Log-In), and this obejct will be destroyed, when the session is over or closed (Log-Out)
                - The Object will be available across all HTTP Requests under that current Session
                - Recommended in case of Razor Views Apps (Web App) and MVC Apps
                - Statefull
                    - Maintain the state of the object across all requests for an active session
                - Generally Following Objects are Scopped
                    - Database Access Objects
                    - Objects for Session Based Logging
                    - Identity Objects (aka Security)
            - AddSingleton()
                - The Object will be live throughout the life of the Application
                - It will be created once and will be destroyed only when the Application is Unloded from the web server or Crashed
                - One object will be shared across all Sessions
                - Application Level Logging Objects MUST be Sigleton
                - Global State or Shared object across all sessions
            - AddTransient()
                - The Object will be live only for the request
                - This will be killed once the request is over
                - Use this carefully for all suces object those are lightweight or does not have any heavyload dependencies
                - Stateless
                    - Really Loightweight
                - E.g.
                    - A In-Memeory Collection that is sued only for a specific request

- MVC Controllers
    - They are Objects those are responsible to Accept HTTP Requests and Process them
    - HTTP GET, POST, PUT, and DELETE
    - Based on requests the 'Action Method (?)' will be executed and the Model will be updated and the View will be returned
        - Action Method: A Method from a controller class that is Mapped with HTTP Request
            - This action method performs following
                  - Accept the Data Posted by the client in Request using Http Post and Put request
                  - Validates the Data (Provided the Validation Rukes are applied)
                  - Call the Business Logic from Models
                  - Handle the Exception if the Logical Error Occured and then Response the Error Page
                  - If The Method is Successfull then Returns a View or Redirect to other Action Method from Same Controller or redirect to action method of Different Controller
            - Action Method returna a Common COntract named 'IActionResult'
                - The IActionResult can be
                    - ViewResult: Returns a View
                    - RedirectToActionREsult: Return to Action method of same controller ot Different Controller
                    - JsonResult: Returns JSON
                    - OKResult: Returns OK() as a Stastus (API Reponses)
                    - OkObjectResult: Return HTTP Status Code with Data as JSON (API Reponses)
                    - NotFound, NoContent, etc. (API Reponses)
            - All Action Methods are HttpGet by default, to use them for Http Post / Http Put / Http Delete, we need to apply the [HttpPost] attribute, [HttpPut], [HttpDelete]

    - The 'Controller' is a Base class for MVC Controller and this class has following
        - Having its base class as 'ControllerBase'
            - Common Base for MVC COntroller and ApiController
            - Properties for
                - HTTP Request and Response
                - Valdating Models Received using HTTP POST and POST Requests
                - 
        - Contains method for
            - Returning View as a reponse
                - Page View
                - Partial View
            - Returning JSON as a Response
            - Action Execution
        - Properties
            - ViewData
                - Pass data from Controller to View Other Than Model
                - Of the Type ViewDataDictionary 
            - TempData
                - Pass Data Across Controllers
            - ViewBag
                - A Dynamic Object that will be Casted to 'ViewDataDictionary'
- Process for Adding View
     - If using Visual Studio 2022 on WIndows, the Right-Click on Action Method and select Add view
            - In VS 2022 on Window, the Add View Scaffolder WIndow will be shown which will take the View Name as the name of the Action Method in whichw we have Right-CLicked to add View. For thios window Select View Template(?) and The select the Model class
            - View Template, ready to scaffold templates to show UI
                - List
                    - For Index() action method
                    - LIst ot IEnumerable of Model class to show data in List (or HTML Table)
                - Create
                    - Accepts an EMoty Model class to create a View with TextBoxes to add da a values to create new record
                - Edit
                    - Accepts a Model class that is to be Updated
                - Delete
                    - Acccpets a Mdoel class which is to be deleted 
                - Details
                    - Accepts a Model class which is ReadOnly
                - Empty
                    - Provides facility to developers to create views as per their needs
                - Empty Without Model
                    - EMpty for HTML and JavaScript 
     - If using Vidsual Studio 2022 for Mac OR Visual Studio Code, then Create a Folder in the Views folder with Same name as Name of the Controller for which the Views are added and then add views in this folder
- @model IEnumerable<Department>
     - This indicates the type if data that is passed to View

- RazorPage<TModel>, the base class for Razor View in ASP.NET Core MVC
     - Properties
          - Model
                - The model Data passed to View using @model directive
                - The model Data passed to View while scaffolding (VS 2022 on WIndows)
                - Using this Model propwrty, properties of model classed passed to the View can be access on the View for 'Model Binding'
                - The 'Html' is a property of View Base class tthat is used to access HTML Helper Methods on View to Generate HTML Output
    - Tag Helpers
          - Lightweight attribute classes those are applied on HTML elements to define its behavior
          - They are classes those are used to help HTML standard elements to Show Data, Accept data, and generate HTML Dynamically
          - e.g.
               - asp-for: Applied on HTML input:text elememt so that it can accept data from end-user
               - asp-controller: applied on Anchro tag 'a' to navigate to the controller
               - asp-action: To navigate to action method of the controller, applied on Anchor tag
               - asp-items: Accept the IEnumerable<T> as input parameter to generate HTML Dynamically
               - ...and many more
```` html
    <input type="text" asp-for="Model.DeptNo"/>
````
    - Show and accept DeptNo

# MVC Programming Object Model

1. Handling Model Validations in POST Request
    - System.ComponentModel.DataAnnotation.dll
        - Assembly that contains 'ValidationAttribute' abstract class
            - This class has a 'IsValid()' method which is overriden for writing Validation Logic for Model Properties
        - THis is ised to define Model Class Propeties Validation Classes
            - RequiredAttribute
            - ComparerAttribute
            - StringLengthAttribute,
            - ... various other attribute classes
    - If the Entities are in seperate dll file, then add System.ComponentModel.DataAnnotation package in it to use validation classes
    - Use the 'ModelState' property of ControllerBase class to validated the Posted model as folows
```` csharp
    if(ModelState.IsValid){.....}
````
    - We can also add a custom Vadlition attribute by deriving the class from 'ValidationAttribute' class and overriding an 'IsValid()' method
        - NOTE: For Custom Validators the Page will be posted back to the server
    - The Entity class for Validations can be changed using ValidationAttribute if the sourece code access is available, other it is better to write a custom Validator
2. Customization of View by passing data to it other than Model Properties data
    - Use ViewData or ViewBag to pass such additional data
    - Please Note ****
        - If a View is accepting a ViewBag or ViewData, then all Action Methods returning to that view MUST pass the VeiwBag or ViewData otherwise the View will crash
    - Since a View can accept only one Model object, to pass the data in the form ParentChild models, use one of the following
        - Use ViewBag and pass data to View
            - If passing the List of Parent Model preeprties to the Child view and wants to show it in the DropDoenList or HTML select element, then use the 'Selectist<T>' object  provided by MVC
                    - Microsoft.AspNetCore.Mvc.Rendering  
        - Create a ViewModel class

3. Sharing Data Across Controllers by Maintaining Data Out-of-The-Controller Object
    - Hosting Env. i.e. The  dotnet.exe will be responsible for storing thios data on sever
    - Two Ways
        - TempData
            - TempDataProvider object
            - Maintain the state untill the Target Controller is not reading data from TempData
            - Once the Target COntroller Reads the data from TempData, it will be cleaned from the TempData
            - This is recommended for Sharing data across 2 COntrollers
            - *** Once aan Action Method from Target Controller reads the data, its will be cleaned from TempData so other action methods of target controller will not be able to read data
                - TO make sure that the Data from TempData to be availble across all action method of Target Controller use 'TempData.Keep()' method explicitly  
        - Session State
            - Storage of the Data on the Server for the current session
            - This data will be Available for all consecutive requests in that session
            - This data will be managed by the server in its own memory
            - This data will be killed / removed when the session is closed
            - Using Session
                -HttpContext: The Current Chennel where Session is Active. THis is alos known as the Current HTTP Request Pipeline.
                - Session: The Session State for the Current HTTP REquest Pipeline
            - If the CLR Object is to be stored in the Session State, then use the Custom Session State Provider and decide the format of Storing data in session
                -  It MUST be an Extesnion Class for Managing Session Read and Write
4. Planning for Error Handling for Controller
    - Make sure that each action method has Exception Handling and Instead of Showing error data on the actual view returned by Action Method return the Error Page with Exception Details
    - To read the Controller Name and Action Name whihc is currently under request, use the 'RouteData' property of the 'ControllerBase' class
    - Consider creating 'Action Filters' for performing Custom Logic execution for all action methods of the controller
            - Either Apply Filter at Action Method Level
                    - WIll be executed only for that action method
            - Or Apply Filter at Controller Level
                    - Will be executed for all action methods of the Controller
            - Or Apply Filter at Application Level (Recommended)
                    - Will be executed for all controllers and their Action methods in Application
    - Filters are applied on COntroller class as well as on action methods Attributes
        - e.g.

```` csharp
    [MyFilter]
    public class MyController : Controller
    {
        [MyNewFilter]
        public IActionResult DoSomething(){....}    
    }
````

    - MyFilter and MyNewFilter are Action Filter classes as
        - MyFilterAttribute and MyNewFilterAttribute
    - Filter classes are deried from 'ActionFilterAttribute' abstract base class and implements IActionFilter interface
        - ActionExecuting Stage
            - The action is targetted and Model (Data) is available to the Action
            - ActionExcutingContext
                - Class that is derived from FilterContext
                - Has an access to RouteData
        - ActionExecuted
            - The Action Has completed its execution
                - Success of Exception
            - ActionExcutedContext
                - Class that is derived from FilterContext
                - Has an access to RouteData
                - Indicates that action is done with execution
        - ResultExecuting
            - Start the Process of Generating Result based on Action Execution
            - ResultExcutingContext
                ¸
                - Represents that the Result generation is in progress
                    - The IActionResult Type is loaded
                        - VeiwResult, JsonEesult, FileResult, etc.
                        - The Result Object is created
        - ResultExecuted
            - The Resule Resource Object is ready
                - Veiw, JSON, File, ect.
            - ResultExecutedContext
                - Class that is derived from FilterContext
                - Has an access to RouteData
                - MAke the Result Object Ready for Response    
                
