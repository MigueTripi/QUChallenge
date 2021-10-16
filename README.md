# QUChallenge

Platform:
.NET Core 3.1

General considerations:
I'm providing two possible solutions, original one implemented in main branch and an improved solution in Approach2 branch.

Technical decisions
I respect the contracts provided in the challenge.
Because I am receiving a matrix in the contructor I discharged the option of implement inversion of control.

I separate the solution into three projects: API, business and unit testing
- API -> it is not really needed for the final solution but I have added it to provide a fast way to test it.
  - I'm validating the request using a validator. This could affect the performance because I validate the matrix lenght between others.
  - Additionally I would like to clarify that I didn't create a DTO project because it is a small topic
  - I'm returning bad request code when request is not provided properly. 
- Business -> There has the main algorithm.
- UTesting -> I have tested the input data, finding words in an unidimentional matrix and a completed one.
 
- Main algorithm (Branch approach2):
  1 - I convert the IEnumerable to an array in order to could access it freely when iterating.
  2 - I fire the search when current character in the matrix is match with at least one word. 
  3 - I solve searches in a recursive way moving horizontal and vertical at same time.
  4 - Each time I find a complete match I store the result in a dictionary<string>. I decided to use dictionary because is faster than collections to set values.
  5 - I cut recursive execution when there is not remaining words to find.

- Main algorithm (Branch main):
  - The same but in step 3 instead of moving in both directions at same time I have solved the horizontal side first and after that, I calculate the column I sent the characters to the recursive search.
  
See documentation folder for simple request example
