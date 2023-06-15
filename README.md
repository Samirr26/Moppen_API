# Samir's Jokes API
An API to retrieve Jokes

## Use cases

### Receive random joke
<pre>
GET: jokes/random
</pre>
### Receive list of jokes based on subject
<pre>
GET: jokes/subject/{subject} <br />
e.g. : /subject/sports
</pre>

### Receive list of jokes based on author
<pre>
GET: jokes/subject/{author} <br />
e.g. : /subject/samir
</pre>
### Add a new joke to the JokesDB
<pre>
POST: /jokes/create-new-joke
</pre>
#### body example: <br /> 
<pre>
{
  "author": "Samir",
  "subject": "Animals", 
  "fullJoke": "What do you call a dog who can manipulate you well? A golden deceiver" 
}
</pre>

### Receive list of all authors
<pre>
GET: authors/all 
</pre>

### Add a new author to the JokesDB
<pre>
POST: /authors/create-new-author
</pre>
#### body example: <br /> 
<pre>
{
  "authorName": "Samir"
}
</pre>
 **_NOTE:_**  Author name has to be unique, you cannot add an author which already exists in JokesDB.


## ERD JokesDB
![image](https://github.com/Samirr26/Moppen_API/assets/55532641/741314df-45b3-4100-b10c-27830ea6e26b)

## Acceptance tests
From the use cases the following acceptance tests have been set up:

|                                            	| Accepted? 	|
|--------------------------------------------	|-----------	|
| User can receive a random joke             	|       Yes 	|
| User can receive a joke based on an author 	|       Yes 	|
| User can receive a joke based on a subject 	|       Yes 	|
| User can add a new joke to the database    	|       Yes 	|
| User can add a new author to the database   |       Yes 	|
| User can receive a list of all authors    	|       Yes 	|
<br/>
The acceptance tests were tested with postman:

![image](https://github.com/Samirr26/Moppen_API/assets/55532641/4f4d9270-ee20-4bec-9c7e-862f1c6e463b)

## ORM software used:
https://github.com/Drizin/DapperQueryBuilder

## Class diagram
![JokesAPIDiagram](https://github.com/Samirr26/Moppen_API/assets/55532641/41392c48-9ce5-40d1-a299-8c82a4e1b070)


