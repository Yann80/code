Introduction

The API uses a model, productdetails.cs and aspnet.core to implement some basics api calls in productdetailscontroller.cs.
 A Razor page, index.cshml is used to display the results of these api calls.
 A client side library has been developed in jquery (script.js) to implement the web api.
The data is stored in memory via a data context implemented from entityframeworkcore.

Web API
The API is accessible via /api/productdetails and comprises of the following methods:-
api/ProductDetails (GET)
This call returns all the product that have been added to the data context.
api/ProductDetails (DELETE)
This method clears out all the items from the data context.
api/ProductDetails (POST)
This method takes as input the productid which is internally used to fetch the details of that product and save it to the data context.
api/ProductDetails/id (DELETE)
This method takes as input a productid which is removed from the data context.

Client Library

List of Functions: -

buttonClick(productid)
It determines what web api that need to be called depending on the label of the form button. This approach can be refined by using a hidden field which can serve as a flag to determine the state of a product, whether it need to be removed or added to the shopping cart instead of relying on text

addItem(productid)
Add the current product passed as parameter to the shopping cart. Product quantity was not implemented due to time constraint. A property can be used in the product model which stores the quantity. Instead of a guid an object build in json can be passed to the web method which will have all the information required

var product = {  productId : "<Guid>", quantity : <qty> };
 
One point that need to be thought around is how to read the correct textbox field with quantity when adding the product to the shopping cart

deleteItem(id)
Clears the product that is passed as parameter from the data context

clearCart()
Clears items from the data context

getCartContent()
Retrieve all the ojects from the data context in json format which in turn can be processed client side for representation

Testing
The web api can be tested locally by running the solution (press F5) in visual studio. The page is simple and intuitive.

 





