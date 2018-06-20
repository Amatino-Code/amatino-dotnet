# Amatino .NET

Amatino is a double entry accounting system. It provides double entry accounting as a service. Amatino is served via an HTTP API. Amatino .NET is a library for interacting with the Amatino API from within a .NET application. By using Amatino .NET, a .NET developer can utilise Amatino services without needing to deal with raw HTTP requests.

## Under Construction

Amatino .NET is in an alpha state. It is not yet ready for widespread use and should not be used by anyone for anything important.

Right now, Amatino .NET’s capabilities are limited. There is one class available: `AmatinoAlpha`. `AmatinoAlpha` is a thin wrapper arround HTTP requests to the Amatino API. It facilitates testing an experimentation with the Amatino API without having to resort to raw HTTP request manipulation and HMAC generation.

To be notified when Amatino .NET enters a beta state, with all capabilities available, sign up to the Amatino Development Newsletter at [https://amatino.io/newsletter/](https://amatino.io/newsletter/).

In the mean time, you may wish to review Amatino’s HTTP documentation at [https://amatino.io/documentation/http](https://amatino.io/documentation), to see what capabilities you can expect from Amatino .NET in future.

## Installation

You can install Amatino .NET using the .NET CLI:

````
$ dotnet add package Amatino
````

For more information about installing Nuget packages, check out Microsoft's [package installation documentation](https://docs.microsoft.com/en-us/nuget/consume-packages/ways-to-install-a-package).

## Example usage

During the Alpha development stage, Amatino API resources may be accessed using the `AmatinoAlpha` object. The `AmatinoAlpha` object is a thin wrapper around syncronous HTTP requests. It is an interim measure designed to make interacting with the Amatino API easier while the more expressive, full-featured, and type-safe Amatino .NET library is built.

You can initialise the `AmatinoAlpha` object like so:

````
using  Amatino;
//...
AmatinoAlpha amatinoAlpha = new AmatinoAlpha(  
	email: "clever@cookie.com",  
	secret: "high entropy passphrase"  
);
````

Make requests to the Amatino API using the `Request()` method:

````
object responseData = amatinoAlpha.Request(
	path: "/entities",  
	queryString: null,  
	method: "POST",  
	body: new List<Dictionary<string, object>>() {
		new  Dictionary<string, object> {
			{"name", "My First Entity"},
			{"description", null},
			{"region_id", null}  
		}
	}
);
````

The parameters of `Request()` match up to the paths, methods, and other attributes of Amatino resources defined in the [Amatino API HTTP documentation]("https://amatino.io/documentation").

For a more in depth introduction to using the `AmatinoAlpha` object, check out the [Getting Started guide]("https://amatino.io/articles/getting-started").

## Source Code

Amatino .NET's source code is [available on GitHub](https://github.com/amatino-code/amatino-dotnet). Pull requests, issue reports, and general commentary are most welcome!

## Feedback & development discussion

We would love to hear from you. What you like, what you don't, what you want to see from a double-entry accounting API, how you think Amatino .NET should evolve: Please join us to discuss these topics and more on the [Amatino discussion forums](https://amatino.io/discussion).

## Other links

 - [Subscribe to Amatino](https://amatino.io/subscribe)
 - [Development blog](https://amatino.io/blog)
 - [Development newsletter](https://amatino.io/newsletter)
 - [Amatino API features](https://amatino.io/features)
