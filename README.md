
**OOP** is object-oriented programming with objects as the minimum unit. The extensibility of programs depends on the replacement of object based on abstraction mainly. That is to say, there is no way to go deep into the class to expand the function. As business requirements change, developers need to create more classes to meet different requirements which make it more and more difficult to maintain the system. Also there are some non-business functional requirements in the system which cause a large amount of duplicate code, such as logging, exception handling, performance statistics and security control etc. Is there a good way to expand the functionalities without breaking the encapsulation of the class or creating new classes? Yes, we could achieve them through AOP.

**AOP** is a technology to achieve unified maintenance of program functions through precompiling and runtime dynamic agents. It is a supplement to OOP.

There are some key concepts in AOP Model.

![AOP concepts](/Images/aop_concepts.png)

**1. Aspect**
A module which has a set of APIs providing cross-cutting requirements. For example, a logging module would be called AOP aspect for logging. An application can have any number of aspects depending on the requirement.

**2. Advice**
This is the actual action to be taken either before or after the method execution. This is the actual piece of code that is invoked during program execution.

**3. JoinPoint**
This represents a point in your application where you can plug-in AOP aspect.

**4. Target**
The object being advised by one or more aspects.

**5. PointCut**
This is a set of one or more joinpoints where an advice should be executed.


.Net uses the following 3 types of solutions to complete the AOP extension of the whole system from top to bottom.

**1. Middleware**

Request level, which is used to handle all the requests, such as request interception, authentication, session management, log recording of all requests etc.

**2. Filter**

Function level, which is used to extend the functions of one or some or a series of requests. For example, for some sensitive APIs, it needs to record the detail user access information.

**3. AutofacAOP**

Business level, which is used handle the specific business, such as CRUD of a business data. It can extend function within one method.

![AOP in .Net](/Images/aop_in_net.png)

**Middleware** is software that's assembled into an pipeline to handle requests and responses. Each middleware can choose whether to pass the request to the next middleware in the pipeline and perform additional work before and after the next middle in the pipeline.

![Middle workflow](/Images/middleware_workflow.png)

![built-in middleware](/Images/bultin_middleware.png)

**Filter** in .Net allows code to run before or after specific stages in the request processing pipeline.

![Filters](/Images/filter.png)

**1. Authorization filter**

It's used to determine whether the user is authorized for the request.

**2. Resource filter**

It’s suitable for cache.

**3. Action filter**

It’s suitable for log.

**4. Result filter**

It's used to format result.

**5. Exception filter**

It's used to apply global policies to unhandled exceptions. The exceptions in the following cases can be catched by it,

(1) Action has unhandled exception

(2) Service has unhandled exception

(3) The constructor in controller has unhandled exception

The exceptions in the following cases can't be catched by exception filter. But we can use the Middleware to catch them.

(4) View binding has unhandled exception

(5) The non-existed URL

**Autofac** is an excellent IOC container with good performance under .Net. It supports AOP too. **AutofacAOP** is implemented through the core part of Castle (also a container) project. Its implementation mode is dynamic proxy.

To summarize, AOP can easily extend functions, such as logging, exception handling, performance statistics and security control etc. The extended functions can be managed centralized and be maintained conveniently. The extended functions and business are independent and uncoupled. Multiple businesses can reuse the same extended function. In this way, some developers can focus on core business logic while other developers can focus on the extended functions that is very beneficial for the division of labor and collaboration and team management in software development. So for that reason, OOP extensibility design should be abstract-oriented class replacement extension and AOP aspect-oriented extension.

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