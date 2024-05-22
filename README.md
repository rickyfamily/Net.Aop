
The article focuses on the extensions of Aspect-Oriented Programming (AOP) in .Net, a necessary complement to Object-Oriented Programming (OOP). In OOP, objects serve as the smallest units, and program extensibility primarily relies on object replacement based on abstraction. As business needs evolve, developers must create an increasing number of classes to meet diverse requirements, making system maintenance increasingly challenging. Additionally, the system may have non-business functional requirements that lead to considerable code duplication, such as logging, exception handling, performance statistics, and security control. AOP provides a solution for expanding functionalities without breaking class encapsulation or creating new classes.

**AOP** is a technology that enables unified program function maintenance through precompiling and runtime dynamic agents. It introduces key concepts like Aspect, Advice, JoinPoint, Target, and PointCut. Aspect is a module with a set of APIs providing cross-cutting requirements, like a logging module. Advice refers to the actual action taken before or after method execution. JoinPoint represents a point in an application where an AOP aspect can be plugged in, while Target refers to the object advised by one or more aspects. PointCut is a set of one or more Joinpoints where advice should be executed.

![AOP concepts](/Images/aop_concepts.png)

.Net employs three types of solutions to implement AOP extensions throughout the system: Middleware, Filter, and AutofacAOP. Middleware handles all requests at the request level, like request interception, authentication, session management, and log recording etc. Filter extends the functions of one or more requests at the function level, like recording user access information for sensitive APIs. AutofacAOP handles specific business operations at the business level, like CRUD of business data, and can extend function within a method.

![AOP in .Net](/Images/aop_in_net.png)

**Middleware** is software assembled into a pipeline to manage requests and responses, deciding whether to pass the request to the next middleware and perform additional work before and after the next middleware.

![Middle workflow](/Images/middleware_workflow.png)

.Net provides some built-in middleware like ExceptionHandler, HSTS, HttpsRedirection, Static Files, Routing, CORS, Authentication, Authorization, and Endpoint etc. Also, you can create custom middleware to handle requests and responses.

![built-in middleware](/Images/builtin_middleware.png)

**Filter** in .Net allows code execution before or after specific stages in the request processing pipeline, including Authorization filters, Resource filters, Action filters, Result filters, and Exception filters etc.

![Filters](/Images/filter.png)

**Authorization Filters** - This is the first step in the filter pipeline. It is used to determine whether the user is authorized for the request. It also decides whether the action method gets executed, based on authentication and authorization rules defined in the application.

**Resource Filters** - This is the second step in the filter pipeline. The resource filter can handle tasks both before and after the rest of the pipeline is executed. These filters get executed after authorization filters. They are useful in caching responses or in short-circuiting the pipeline before the action method is called when some specific conditions are met.

**Action Filters** - These filters are executed before and after the controller action method is invoked. Which means they run after the model binding has been done, so they can access the action method’s input parameters. They are suitable for logging or handling custom logic or to modify the arguments or the IActionResult returned by an action.

**Result Filters** - These filters are executed before and after the execution of the action result. They can be used to modify the view data, or to change the arguments of the action result, or to modify the IActionResult prior to its execution. They are very useful to format the outgoing result before it’s sent to the client.

**Exception Filters** - These filters are the error handlers and are used to handle unhandled errors that are thrown during the execution of the Controller Action or the Controller Constructor or within the filter pipeline. But exception filters can’t handle the non-existed URL and the unhandled exception in View binding. We can use middleware to catch and handle them globally across the application.

**Autofac** is a high-performance IOC container under .Net that can be easily integrated with a library such as Castle DynamicProxy to enable AOP through method interception.

In conclusion, AOP can effortlessly extend functions like logging, exception handling, performance statistics, and security control. The extended functions are managed centrally and maintained conveniently, independent and uncoupled from the business. Multiple businesses can reuse the same extended function, allowing some developers to concentrate on core business logic while others focus on extended functions. This division of labor facilitates collaboration and team management in software development. Hence, OOP extensibility design should be abstract-oriented class replacement extension and AOP aspect-oriented extension.

**Development environment setup manual:** 

1. Microsoft Visual Studio Professional 2022 Version 17.8.3

**Tech stack selections with justifications:** 

1. NETCore

	As basic framework to build the application.

2. AspNetCore

	As basic framework to build Web Api site, http://localhost:5000.

3. Autofac

	As IOC container to implement AOP in business level.

4. Newtonsoft.Json

	As class library to serialize object to json and deserialize json to object.