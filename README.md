# DWP
I choose to code the task in C#.

I set up the API so that it can be called using 3 different url requests

1. api/values  - this is the default url that will return a list of users (in Json format) who are listed in London or whose coordinates are within 50 miles
2. api/values/{city} i.e. api/values/london - this will return a list of users (in Json format) who are listed in the given city
3. api/ values/{city}/{distance} i.e. api/values/london/50 - this will return a list of users (in Json format) who are listed in the given city or whose coordinates are within the given distance (in miles) of the city

I thought it made sense to do this so that the functionality was more general than just hard coding the task question (London ,50 miles) and took full advantage of the functionality of the api being used.  Therefore making the code more robust and adaptable to any potential future implementation expansions required.

I have separated the code into separate classes where it seemed sensible so that similar functionality are grouped, making the code more readable and more adapable/robust to future changes and expansion of the code. 
For example instead of putting the code for an http request in the same class as the methods which call the api being used, I put it in a seperate class so that if other api's were later added they could all share this http connection, keeping the code readable.
