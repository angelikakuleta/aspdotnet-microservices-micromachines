# aspdotnet-microservices-micromachines

## Story

You are asked to create an internal web shop like portal, which provides micromachinery from a catalog of products. The company already has multiple services which run across it's enterprise operation. Many services are shared by various application.

## Functional requirements

The High Level Design requires you to complete the following user stories on top of some technical steps that we describe below    
- As a `User` I want to be able to browse products
- As a `User` I want to browse the history and status of my orders
- As a `User` I want to browse the history of my purchases
- As a `User` I want to filter products by category
- As a `User` I want to have multiple Balance Account
- As a `User` I can purchase a product from the Stock
- As a `User` I can purchase a product from the Stock only if I have enough balance in my account and there is enough stock supplied
- As a `User` I can purchase a product by creating an order. Orders consist of an itenarary. An order can be accepted only if all products are available. Otherwise an order is denied.
- As a `User` I want to be able to place an order only if my credit balance is sufficient
- If the balance is insufficient, place the order in a wishlist (channel) which will maybe fulfilled once the balance is restored
- As a `User` I can make a transfer to any account apart from the "outgoing" Account
- An Accounts' balance cannot get below 0        
- A Products' stock cannot get below 0 and the price must be above 0.
