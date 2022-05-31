# AutomationProject
Automated tests for a webshop website https://juice-shop.herokuapp.com/.

In the first test a user is created,products are added to the checkout and the test verifies:
  1. After purchasing two products the text "Thank you for your purchase!" appears.
  2. The total price of the purchase is equal to 3.87

In the second test, the user login to the web page with a previously created user, and is verified the status of the purchase. 
The test verifies: 
  1.Status of the purchase is "In transit".
  2.The list of purchased products has two items
  3.The price of each product is extracted, they are added, and is validated if the result is equal to 2.88
